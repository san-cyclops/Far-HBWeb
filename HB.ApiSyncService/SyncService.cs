using HB.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using HB.ApiModel.Content;
using Repositories;
using HB.ApiModel.auto.model;
using System.Net;
using System.Text.RegularExpressions;
using Repositories.Service;

namespace HB.ApiSyncService
{
    public class SyncService
    {
        string filePath = @"C:\Test\log.txt";
        public bool SyncDestinations()
        {
            try
            {
                //destinations 
                DestinationsRS destinationsRs = new DestinationsRS();
                HotelContentService hotelContentService = new HotelContentService();

                int hotelfrom = 1;
                int hotelto = 1000;



                for (int i = 1; i <= 7; i++)
                {

                    destinationsRs = hotelContentService.getDestinations(hotelfrom, hotelto);
                    DestinationsRep destinationsRep = new DestinationsRep();
                    using (var db = new HBNEWEntities())
                    {
                        foreach (var desList in destinationsRs.destinations)
                        {
                            destinationsRep.code = desList.code ?? "";
                            destinationsRep.countryCode = desList.countryCode ?? "";
                            destinationsRep.isoCode = desList.isoCode ?? "";
                            destinationsRep.name = (desList.name == null) ? "" : desList.name.content;
                            db.DestinationsReps.Add(destinationsRep);
                            db.SaveChanges();
                        }
                    }
                    hotelfrom = hotelfrom + 1000;
                    hotelto = hotelto + 1000;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool SyncTerminals()
        {
            try
            {

                TerminalsRS terminalsRs = new TerminalsRS();
                HotelContentService hotelContentService = new HotelContentService();
                //Enum count = {}

                int hotelfrom = 1001;
                int hotelto = 2000;


                for (int i = 1; i <= 10; i++)
                {
                    terminalsRs = hotelContentService.Getterminals(hotelfrom, hotelto);
                    TerminalRep terminalRep = new TerminalRep();
                    using (var db = new HBNEWEntities())
                    {
                        foreach (var varlist in terminalsRs.terminals)
                        {
                            terminalRep = new TerminalRep();
                            terminalRep.code = varlist.code;
                            terminalRep.country = varlist.country;
                            terminalRep.description = (varlist.description == null) ? "" : varlist.description.content;
                            terminalRep.name = (varlist.name == null) ? "" : varlist.name.content;
                            terminalRep.type = varlist.type;
                            db.TerminalReps.Add(terminalRep);
                            db.SaveChanges();
                        }
                    }
                    hotelfrom = hotelfrom + 1000;
                    hotelto = hotelto + 1000;
                }


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string SyncHotel(int from)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    ////destinations 
                    HotelsRS hotelsRs = new HotelsRS();
                    HotelContentService hotelContentService = new HotelContentService();
                    //Enum count = {}

                    int hotelfrom = from;
                    int hotelto = from + 999;



                    for (int i = 1; i <= 200; i++)
                    {
                        writer.WriteLine(hotelfrom.ToString() + " - " + hotelto.ToString());
                        hotelsRs = hotelContentService.getHotels(1, hotelto);
                        HotelRep hotel = new HotelRep();
                        List<HotelRep> hotelReplist = new List<HotelRep>();
                        using (var db = new HBNEWEntities())
                        {
                            int hotelCount = 0;



                            foreach (var hotelList in hotelsRs.hotels)
                            {

                                // ***********************Images
                                if (hotelsRs.hotels[hotelCount].terminals != null)
                                {
                                    List<HotelTerminalRep> hotelTerminalReplst = new List<HotelTerminalRep>();


                                    foreach (var varlist in hotelsRs.hotels[hotelCount].terminals)
                                    {
                                        HotelTerminalRep hotelTerminalRep = new HotelTerminalRep();

                                        hotelTerminalRep.code = varlist.terminalCode;
                                        hotelTerminalRep.country =
                                            db.TerminalReps.Where(a => a.code == varlist.terminalCode)
                                                .Select(a => a.country).FirstOrDefault();
                                        hotelTerminalRep.description = (varlist.description == null)
                                            ? ""
                                            : varlist.description.content;
                                        hotelTerminalRep.name = (varlist.name == null) ? "" : varlist.name.content;
                                        hotelTerminalRep.type =
                                            db.TerminalReps.Where(a => a.code == varlist.terminalCode)
                                                .Select(a => a.type).FirstOrDefault();
                                        hotelTerminalRep.hotelcode = hotelList.code;
                                        hotelTerminalRep.distance = varlist.distance;

                                        hotelTerminalReplst.Add(hotelTerminalRep);

                                    }
                                    db.HotelTerminalReps.AddRange(hotelTerminalReplst);
                                    db.SaveChanges();
                                }





                                //****************boardCodes
                                List<HotelBoardCodesRep> boardCodeslst = new List<HotelBoardCodesRep>();
                                if (hotelsRs.hotels[hotelCount].boardCodes != null)
                                {
                                    for (int xx = 1; xx <= hotelsRs.hotels[hotelCount].boardCodes.Count; xx++)
                                    {
                                        HotelBoardCodesRep boardCodes = new HotelBoardCodesRep();

                                        boardCodes.code = hotelList.code;
                                        boardCodes.HotelCode = hotelList.code;
                                        boardCodes.BoardCode = hotelsRs.hotels[hotelCount].boardCodes[xx - 1];
                                        boardCodeslst.Add(boardCodes);
                                    }

                                    db.HotelBoardCodesReps.AddRange(boardCodeslst);
                                    db.SaveChanges();
                                }

                                //****************Coordinates
                                if (hotelsRs.hotels[hotelCount].coordinates != null)
                                {

                                    GeoLocationRep geoLocationRep = new GeoLocationRep();
                                    GeoLocation geoLocation = new GeoLocation();
                                    geoLocationRep.HotelCode = hotelList.code;
                                    geoLocationRep.longitude = hotelsRs.hotels[0].coordinates.longitude;
                                    geoLocationRep.latitude = hotelsRs.hotels[0].coordinates.latitude;
                                    geoLocationRep.radius = hotelsRs.hotels[0].coordinates.radius;
                                    geoLocationRep.secondaryLatitude = hotelsRs.hotels[0].coordinates.secondaryLatitude;
                                    geoLocationRep.secondaryLongitude =
                                        hotelsRs.hotels[0].coordinates.secondaryLongitude;
                                    db.GeoLocationReps.Add(geoLocationRep);
                                    db.SaveChanges();

                                }

                                // ***********************HotelFacilityRep
                                if (hotelsRs.hotels[hotelCount].facilities != null)
                                {
                                    List<HotelFacilityRep> hotelFacilityReplst = new List<HotelFacilityRep>();
                                    foreach (var hotelfac in hotelsRs.hotels[hotelCount].facilities)
                                    {
                                        HotelFacilityRep hotelFacilityRep = new HotelFacilityRep();

                                        hotelFacilityRep.HotelCode = hotelList.code;
                                        hotelFacilityRep.facilityCode = hotelfac.facilityCode;
                                        hotelFacilityRep.facilityGroupCode = hotelfac.facilityGroupCode;
                                        hotelFacilityRep.description = hotelfac.description != null
                                            ? hotelfac.description
                                            : "";
                                        hotelFacilityRep.order = hotelfac.order;

                                        hotelFacilityRep.indLogic = hotelfac.indLogic;
                                        hotelFacilityRep.indFee = hotelfac.indFee;
                                        hotelFacilityRep.indYesOrNo = hotelfac.indYesOrNo;
                                        hotelFacilityRep.facilityName = hotelfac.facilityName != null
                                            ? hotelfac.facilityName
                                            : "";

                                        hotelFacilityRep.number = hotelfac.number;
                                        hotelFacilityRep.distance = hotelfac.distance;

                                        hotelFacilityRep.ageFrom = hotelfac.ageFrom;
                                        hotelFacilityRep.ageTo = hotelfac.ageTo;
                                        hotelFacilityRep.currency = hotelfac.currency != null ? hotelfac.currency : "";
                                        hotelFacilityRep.applicationType = hotelfac.applicationType;

                                        hotelFacilityReplst.Add(hotelFacilityRep);
                                        db.SaveChanges();
                                    }
                                    db.HotelFacilityReps.AddRange(hotelFacilityReplst);
                                    db.SaveChanges();
                                }


                                // ***********************Images
                                if (hotelsRs.hotels[hotelCount].images != null)
                                {
                                    List<ImageRep> imageReplst = new List<ImageRep>();
                                    foreach (var hotelfac in hotelsRs.hotels[hotelCount].images)
                                    {
                                        ImageRep imageRep = new ImageRep();

                                        imageRep.HotelCode = hotelList.code;
                                        imageRep.hotel = hotelfac.hotel;
                                        imageRep.characteristicCode = hotelfac.characteristicCode;
                                        imageRep.imageTypeCode = hotelfac.imageTypeCode;
                                        imageRep.order = hotelfac.order;

                                        imageRep.path = hotelfac.path;
                                        imageRep.roomCode = hotelfac.roomCode;
                                        imageRep.roomType = hotelfac.roomType;


                                        imageReplst.Add(imageRep);
                                    }
                                    db.ImageReps.AddRange(imageReplst);
                                    db.SaveChanges();


                                }


                                // ***********************hotelPhone
                                if (hotelsRs.hotels[hotelCount].phones != null)
                                {
                                    List<HotelPhoneRep> hotelPhoneReplst = new List<HotelPhoneRep>();
                                    foreach (var hotelPhone in hotelsRs.hotels[hotelCount].phones)
                                    {
                                        HotelPhoneRep hotelPhoneRep = new HotelPhoneRep();

                                        hotelPhoneRep.HotelCode = hotelList.code;
                                        hotelPhoneRep.phoneNumber = hotelPhone.phoneNumber;
                                        hotelPhoneRep.phoneType = hotelPhone.phoneType;
                                        hotelPhoneReplst.Add(hotelPhoneRep);
                                    }
                                    db.HotelPhoneReps.AddRange(hotelPhoneReplst);
                                    db.SaveChanges();
                                }

                                int roomCount = 0;
                                if (hotelsRs.hotels[hotelCount].rooms != null)
                                {
                                    List<HotelRoomRep> hotelRoomReplst = new List<HotelRoomRep>();

                                    foreach (var hotelRoom in hotelsRs.hotels[hotelCount].rooms)
                                    {
                                        HotelRoomRep hotelRoomRep = new HotelRoomRep();

                                        hotelRoomRep.HotelCode = hotelList.code;
                                        hotelRoomRep.characteristicCode = hotelRoom.characteristicCode;
                                        hotelRoomRep.description = hotelRoom.description;
                                        hotelRoomRep.roomCode = hotelRoom.roomCode;
                                        hotelRoomRep.roomType = hotelRoom.roomType;
                                        hotelRoomReplst.Add(hotelRoomRep);


                                        if (hotelsRs.hotels[hotelCount].rooms[roomCount].roomFacilities != null)
                                        {
                                            List<HotelRoomFacilityRep> hotelRoomFacilityReplst =
                                                new List<HotelRoomFacilityRep>();

                                            foreach (
                                                var varlist in
                                                    hotelsRs.hotels[hotelCount].rooms[roomCount].roomFacilities)
                                            {
                                                HotelRoomFacilityRep hotelRoomFacilityRep = new HotelRoomFacilityRep();

                                                hotelRoomFacilityRep.HotelCode = hotelList.code;
                                                hotelRoomFacilityRep.description = varlist.description;
                                                hotelRoomFacilityRep.facilityCode = varlist.facilityCode;
                                                hotelRoomFacilityRep.facilityGroupCode = varlist.facilityGroupCode;
                                                hotelRoomFacilityRep.indFee = varlist.indFee;
                                                hotelRoomFacilityRep.indLogic = varlist.indLogic;
                                                hotelRoomFacilityRep.indYesOrNo = varlist.indYesOrNo;
                                                hotelRoomFacilityRep.number = varlist.number;
                                                hotelRoomFacilityRep.order = varlist.order;
                                                hotelRoomFacilityRep.roomCode = hotelRoom.roomCode;
                                                hotelRoomFacilityReplst.Add(hotelRoomFacilityRep);
                                            }
                                            db.HotelRoomFacilityReps.AddRange(hotelRoomFacilityReplst);
                                            db.SaveChanges();

                                        }
                                        if (hotelsRs.hotels[hotelCount].rooms[roomCount].roomStays != null)
                                        {
                                            List<HotelRoomStayRep> hotelRoomStayRepslst = new List<HotelRoomStayRep>();
                                            foreach (
                                                var varlist in hotelsRs.hotels[hotelCount].rooms[roomCount].roomStays)
                                            {
                                                HotelRoomStayRep hotelRoomStayRep = new HotelRoomStayRep();

                                                hotelRoomStayRep.HotelCode = hotelList.code;
                                                hotelRoomStayRep.order = varlist.order;
                                                hotelRoomStayRep.description = varlist.description;
                                                hotelRoomStayRep.roomCode = hotelRoom.roomCode;
                                                hotelRoomStayRep.stayType = varlist.stayType;
                                                hotelRoomStayRepslst.Add(hotelRoomStayRep);
                                            }
                                            db.HotelRoomStayReps.AddRange(hotelRoomStayRepslst);
                                            db.SaveChanges();
                                        }
                                        db.HotelRoomReps.AddRange(hotelRoomReplst);
                                        roomCount++;
                                    }

                                    db.SaveChanges();
                                }


                                // ***********************Images
                                if (hotelsRs.hotels[hotelCount].segments != null)
                                {
                                    foreach (var hotelsegmentCodes in hotelsRs.hotels[hotelCount].segments)
                                    {
                                        HotelSegmentRep segmentRep = new HotelSegmentRep();

                                        segmentRep.HotelCode = hotelList.code;
                                        segmentRep.code = hotelsegmentCodes.code;
                                        segmentRep.description = (hotelsegmentCodes.description == null)
                                            ? ""
                                            : hotelsegmentCodes.description.content;
                                        db.HotelSegmentReps.Add(segmentRep);
                                        db.SaveChanges();
                                    }
                                }


                                hotelCount++;



                            }


                        }
                       
                        hotelfrom = hotelfrom + 1000;
                        hotelto = hotelto + 1000;
                    }
                    return "Done";
                }
            }
            catch (Exception ex)
            {
                SendHtmlFormattedEmail("sancyclops@gmail.com", "Error", ex.Message);
              //  SendHtmlFormattedEmail("shaban@farholidays.com", "Error", ex.Message);


                return ex.Message;
            }
        }

        private void SendHtmlFormattedEmail(string recepientEmail, string subject, string body)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress("sanjeewakumara226@gmail.com");
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress(recepientEmail));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = "sanjeewakumara226@gmail.com";
                NetworkCred.Password = "Dn5vlPP6";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mailMessage);
            }
        }

        public bool SyncCountry()
        {
            try
            {
                ////destinations 
                CountriesRS countriesRs = new CountriesRS();
                HotelContentService hotelContentService = new HotelContentService();
                //Enum count = {}


                countriesRs = hotelContentService.getCountries(0, 300);
                CountryRep country = new CountryRep();
                using (var db = new HBNEWEntities())
                {
                    foreach (var countryList in countriesRs.countries)
                    {
                        country = new CountryRep();
                        country.code = countryList.code;
                        country.description = (countryList.description == null) ? "" : countryList.description.content;
                        country.isoCode = countryList.isoCode;


                        //destinationsRep.countryCode = desList.countryCode ?? "";

                        db.CountryReps.Add(country);
                        db.SaveChanges();
                    }
                }


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool SyncAccommodations()
        {
            try
            {

                AccommodationsRS accommodationRepRs = new AccommodationsRS();
                HotelContentService hotelContentService = new HotelContentService();
                //Enum count = {}

                int hotelfrom = 1;
                int hotelto = 1000;


                for (int i = 1; i <= 100; i++)
                {
                    accommodationRepRs = hotelContentService.getAccommodations(hotelfrom, hotelto);
                    AccommodationRep accommodationRep = new AccommodationRep();
                    using (var db = new HBNEWEntities())
                    {
                        foreach (var varlist in accommodationRepRs.accommodations)
                        {
                            accommodationRep = new AccommodationRep();
                            accommodationRep.code = varlist.code;
                            accommodationRep.typeDescription = varlist.typeDescription;
                            accommodationRep.typeMultiDescription = (varlist.typeMultiDescription == null) ? "" : varlist.typeMultiDescription.content;

                            db.AccommodationReps.Add(accommodationRep);
                            db.SaveChanges();
                        }
                    }
                    hotelfrom = hotelfrom + 1000;
                    hotelto = hotelto + 1000;
                }


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Syncboards()
        {
            try
            {

                BoardsRS boardsRs = new BoardsRS();
                HotelContentService hotelContentService = new HotelContentService();
                //Enum count = {}

                int hotelfrom = 1;
                int hotelto = 1000;


                for (int i = 1; i <= 100; i++)
                {
                    boardsRs = hotelContentService.GetBoards(hotelfrom, hotelto);
                    BoardRep board = new BoardRep();
                    using (var db = new HBNEWEntities())
                    {
                        foreach (var varlist in boardsRs.boards)
                        {
                            board = new BoardRep();
                            board.code = varlist.code;
                            board.multiLingualCode = varlist.multiLingualCode;
                            board.description = (varlist.description == null) ? "" : varlist.description.content;

                            db.BoardReps.Add(board);
                            db.SaveChanges();
                        }
                    }
                    hotelfrom = hotelfrom + 1000;
                    hotelto = hotelto + 1000;
                }


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool SyncCategories()
        {
            try
            {

                CategoriesRS categoriesRs = new CategoriesRS();
                HotelContentService hotelContentService = new HotelContentService();
                //Enum count = {}

                int hotelfrom = 1;
                int hotelto = 1000;


                for (int i = 1; i <= 1; i++)
                {
                    categoriesRs = hotelContentService.Getcategories(hotelfrom, hotelto);
                    CategoryRep categoryRep = new CategoryRep();
                    using (var db = new HBNEWEntities())
                    {
                        foreach (var varlist in categoriesRs.categories)
                        {
                            categoryRep = new CategoryRep();
                            categoryRep.code = varlist.code;
                            categoryRep.accommodationType = varlist.accommodationType;
                            categoryRep.description = (varlist.description == null) ? "" : varlist.description.content;
                            categoryRep.group = varlist.@group;
                            categoryRep.simpleCode = varlist.simpleCode;

                            db.CategoryReps.Add(categoryRep);
                            db.SaveChanges();
                        }
                    }
                    hotelfrom = hotelfrom + 1000;
                    hotelto = hotelto + 1000;
                }


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool SyncChains()
        {
            try
            {

                ChainsRS chainsRs = new ChainsRS();
                HotelContentService hotelContentService = new HotelContentService();
                //Enum count = {}

                int hotelfrom = 1;
                int hotelto = 1000;


                for (int i = 1; i <= 100; i++)
                {
                    chainsRs = hotelContentService.Getchains(hotelfrom, hotelto);
                    ChainRep chainRep = new ChainRep();
                    using (var db = new HBNEWEntities())
                    {
                        foreach (var varlist in chainsRs.chains)
                        {
                            chainRep = new ChainRep();
                            chainRep.code = varlist.code;

                            chainRep.description = (varlist.description == null) ? "" : varlist.description.content;


                            db.ChainReps.Add(chainRep);
                            db.SaveChanges();
                        }
                    }
                    hotelfrom = hotelfrom + 1000;
                    hotelto = hotelto + 1000;
                }


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool SyncRatecomments()
        {
            try
            {

                RateCommentsRS commentsRs = new RateCommentsRS();
                HotelContentService hotelContentService = new HotelContentService();
                //Enum count = {}

                int hotelfrom = 1;
                int hotelto = 1000;


                for (int i = 1; i <= 100; i++)
                {
                    commentsRs = hotelContentService.getRateComments(hotelfrom, hotelto);
                    RateCommentRep rateCommentRep = new RateCommentRep();
                    using (var db = new HBNEWEntities())
                    {
                        foreach (var varlist in commentsRs.RateComments)
                        {
                            rateCommentRep = new RateCommentRep();
                            //rateCommentRep.dateEnd = Convert.ToDateTime(varlist.commentsByRates);
                            //rateCommentRep.dateStart = Convert.ToDateTime(varlist.dateStart);
                            //rateCommentRep.description = varlist.description;

                            db.RateCommentReps.Add(rateCommentRep);
                            db.SaveChanges();
                        }
                    }
                    hotelfrom = hotelfrom + 100;
                    hotelto = hotelto + 100;
                }


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool SyncCurrencies()
        {
            try
            {

                CurrenciesRS currenciesRs = new CurrenciesRS();
                HotelContentService hotelContentService = new HotelContentService();


                int hotelfrom = 1;
                int hotelto = 1000;

                int xddd = 0;
                for (int i = 1; i <= 1; i++)
                {
                    currenciesRs = hotelContentService.Getcurrencies(hotelfrom, hotelto);
                    CurrencyRep currencyRep = new CurrencyRep();
                    using (var db = new HBNEWEntities())
                    {
                        foreach (var varlist in currenciesRs.currencies)
                        {
                            currencyRep = new CurrencyRep();
                            currencyRep.code = varlist.code;
                            currencyRep.currencyType = varlist.currencyType;
                            currencyRep.description = (varlist.description == null) ? "" : varlist.description.content;
                            xddd = xddd + 1;
                            if (xddd == 210)
                            {

                            }
                            db.CurrencyReps.Add(currencyRep);
                            db.SaveChanges();
                        }
                    }
                    hotelfrom = hotelfrom + 1000;
                    hotelto = hotelto + 1000;

                }


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool SyncFacilities()
        {
            try
            {

                FacilitiesRS facilitiesRs = new FacilitiesRS();
                HotelContentService hotelContentService = new HotelContentService();


                int hotelfrom = 1;
                int hotelto = 1000;


                for (int i = 1; i <= 1; i++)
                {
                    facilitiesRs = hotelContentService.Getfacilities(hotelfrom, hotelto);
                    FacilityRep facilityRep = new FacilityRep();
                    using (var db = new HBNEWEntities())
                    {
                        foreach (var varlist in facilitiesRs.facilities)
                        {
                            facilityRep = new FacilityRep();
                            facilityRep.description = (varlist.description == null) ? "" : varlist.description.content;
                            facilityRep.code = varlist.code;
                            facilityRep.facilityGroupCode = varlist.facilityGroupCode;
                            facilityRep.facilityTypologyCode = varlist.facilityTypologyCode;
                            db.FacilityReps.Add(facilityRep);
                            db.SaveChanges();
                        }
                    }
                    hotelfrom = hotelfrom + 1000;
                    hotelto = hotelto + 1000;
                }


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool SyncFacilitygroups()
        {
            try
            {

                FacilityGroupsRS facilityGroupsRs = new FacilityGroupsRS();
                HotelContentService hotelContentService = new HotelContentService();


                int hotelfrom = 1;
                int hotelto = 1000;


                for (int i = 1; i <= 1; i++)
                {
                    facilityGroupsRs = hotelContentService.Getfacilitygroups(hotelfrom, hotelto);
                    FacilityGroupRep facilityGroup = new FacilityGroupRep();
                    using (var db = new HBNEWEntities())
                    {
                        foreach (var varlist in facilityGroupsRs.facilityGroups)
                        {
                            facilityGroup = new FacilityGroupRep();
                            facilityGroup.code = varlist.code;
                            facilityGroup.description = (varlist.description == null) ? "" : varlist.description.content.ToString();

                            db.FacilityGroupReps.Add(facilityGroup);
                            db.SaveChanges();
                        }
                    }
                    hotelfrom = hotelfrom + 1000;
                    hotelto = hotelto + 1000;
                }


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Syncacilitytypologies()
        {
            try
            {

                FacilityTypologiesRS facilityTypologiesRs = new FacilityTypologiesRS();
                HotelContentService hotelContentService = new HotelContentService();


                int hotelfrom = 1;
                int hotelto = 1000;


                for (int i = 1; i <= 1; i++)
                {
                    facilityTypologiesRs = hotelContentService.Getfacilitytypologies(hotelfrom, hotelto);
                    FacilityTypeRep facilityType = new FacilityTypeRep();
                    using (var db = new HBNEWEntities())
                    {
                        foreach (var varlist in facilityTypologiesRs.facilityTypologies)
                        {
                            facilityType = new FacilityTypeRep();
                            facilityType.code = varlist.code;
                            facilityType.conceptFlag = varlist.conceptFlag;
                            facilityType.numberFlag = varlist.numberFlag;
                            facilityType.logicFlag = varlist.logicFlag;
                            facilityType.feeFlag = varlist.feeFlag;
                            facilityType.distanceFlag = varlist.distanceFlag;
                            facilityType.ageFromFlag = varlist.ageFromFlag;
                            facilityType.ageToFlag = varlist.ageToFlag;
                            facilityType.dateFromFlag = varlist.dateFromFlag;
                            facilityType.dateToFlag = varlist.dateToFlag;
                            facilityType.timeFromFlag = varlist.timeFromFlag;
                            facilityType.timeToFlag = varlist.timeToFlag;
                            facilityType.indYesOrNoFlag = varlist.indYesOrNoFlag;
                            facilityType.amountFlag = varlist.amountFlag;
                            facilityType.currencyFlag = varlist.currencyFlag;
                            facilityType.appTypeFlag = varlist.appTypeFlag;



                            db.FacilityTypeReps.Add(facilityType);
                            db.SaveChanges();
                        }
                    }
                    hotelfrom = hotelfrom + 1000;
                    hotelto = hotelto + 1000;
                }


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool SyncIssuess()
        {
            try
            {

                IssuesRS issuesRs = new IssuesRS();
                HotelContentService hotelContentService = new HotelContentService();

                int hotelfrom = 1;
                int hotelto = 1000;


                for (int i = 1; i <= 1; i++)
                {
                    issuesRs = hotelContentService.Getissues(hotelfrom, hotelto);
                    IssueRep issueRep = new IssueRep();
                    using (var db = new HBNEWEntities())
                    {
                        foreach (var varlist in issuesRs.issues)
                        {
                            issueRep = new IssueRep();
                            issueRep.code = varlist.code;
                            issueRep.alternative = varlist.alternative;
                            issueRep.description = (varlist.description == null) ? "" : varlist.description.content;
                            issueRep.name = (varlist.name == null) ? "" : varlist.name.content;
                            issueRep.type = varlist.type;
                            db.IssueReps.Add(issueRep);
                            db.SaveChanges();
                        }
                    }
                    hotelfrom = hotelfrom + 1000;
                    hotelto = hotelto + 1000;
                }


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool SyncLanguages()
        {
            try
            {

                LanguagesRS languagesRs = new LanguagesRS();
                HotelContentService hotelContentService = new HotelContentService();

                int hotelfrom = 1;
                int hotelto = 1000;


                for (int i = 1; i <= 100; i++)
                {
                    languagesRs = hotelContentService.Getlanguage(hotelfrom, hotelto);
                    LanguageRep languageRep = new LanguageRep();
                    using (var db = new HBNEWEntities())
                    {
                        foreach (var varlist in languagesRs.languages)
                        {
                            languageRep = new LanguageRep();
                            languageRep.code = varlist.code;
                            languageRep.description = (varlist.description == null) ? "" : varlist.description.content;
                            languageRep.name = varlist.name;
                            db.LanguageReps.Add(languageRep);
                            db.SaveChanges();
                        }
                    }
                    hotelfrom = hotelfrom + 1000;
                    hotelto = hotelto + 1000;
                }


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool SyncPromotions()
        {
            try
            {

                PromotionsRS promotionsRs = new PromotionsRS();
                HotelContentService hotelContentService = new HotelContentService();

                int hotelfrom = 1;
                int hotelto = 1000;


                for (int i = 1; i <= 1; i++)
                {
                    promotionsRs = hotelContentService.Getpromotions(hotelfrom, hotelto);
                    PromotionRep promotionRep = new PromotionRep();
                    using (var db = new HBNEWEntities())
                    {
                        foreach (var varlist in promotionsRs.promotions)
                        {
                            promotionRep = new PromotionRep();
                            promotionRep.code = varlist.code;
                            promotionRep.description = (varlist.description == null) ? "" : varlist.description.content;
                            promotionRep.name = (varlist.name == null) ? "" : varlist.name.content;
                            db.PromotionReps.Add(promotionRep);
                            db.SaveChanges();
                        }
                    }
                    hotelfrom = hotelfrom + 1000;
                    hotelto = hotelto + 1000;
                }


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool SyncRooms()
        {
            try
            {

                RoomsRS roomsRs = new RoomsRS();
                HotelContentService hotelContentService = new HotelContentService();

                int hotelfrom = 1;
                int hotelto = 1000;


                for (int i = 1; i <= 3; i++)
                {
                    roomsRs = hotelContentService.Getrooms(hotelfrom, hotelto);
                    RoomRep roomRep = new RoomRep();
                    using (var db = new HBNEWEntities())
                    {
                        foreach (var varlist in roomsRs.rooms)
                        {
                            roomRep = new RoomRep();
                            roomRep.code = varlist.code;
                            roomRep.description = varlist.description;
                            roomRep.characteristic = varlist.characteristic;
                            roomRep.characteristicDescription = (varlist.characteristicDescription == null) ? "" : varlist.characteristicDescription.content;
                            roomRep.maxAdults = varlist.maxAdults;
                            roomRep.maxChildren = varlist.maxChildren;
                            roomRep.maxPax = varlist.maxPax;
                            roomRep.minAdults = varlist.minAdults;
                            roomRep.minPax = varlist.minPax;
                            roomRep.type = varlist.type;
                            roomRep.typeDescription = (varlist.typeDescription == null) ? "" : varlist.typeDescription.content;
                            db.RoomReps.Add(roomRep);
                            db.SaveChanges();
                        }
                    }
                    hotelfrom = hotelfrom + 1000;
                    hotelto = hotelto + 1000;
                }


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool SyncSegment()
        {
            try
            {

                SegmentsRS segmentsRs = new SegmentsRS();
                HotelContentService hotelContentService = new HotelContentService();
                //Enum count = {}

                int hotelfrom = 1;
                int hotelto = 1000;


                for (int i = 1; i <= 1; i++)
                {
                    segmentsRs = hotelContentService.getSegments(0, 300);
                    SegmentRep segmentRep = new SegmentRep();
                    using (var db = new HBNEWEntities())
                    {
                        foreach (var varlist in segmentsRs.segments)
                        {
                            segmentRep = new SegmentRep();
                            segmentRep.code = varlist.code;
                            segmentRep.description = (varlist.description == null) ? "" : varlist.description.content;
                            db.SegmentReps.Add(segmentRep);
                            db.SaveChanges();
                        }
                    }
                    hotelfrom = hotelfrom + 1000;
                    hotelto = hotelto + 1000;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public bool SyncImagetypes()
        {
            try
            {

                ImageTypesRS imageTypesRs = new ImageTypesRS();
                HotelContentService hotelContentService = new HotelContentService();
                //Enum count = {}

                int hotelfrom = 1;
                int hotelto = 1000;


                for (int i = 1; i <= 1; i++)
                {
                    imageTypesRs = hotelContentService.Getimagetypes(0, 300);
                    ImageTypeRep imageTypeRep = new ImageTypeRep();
                    using (var db = new HBNEWEntities())
                    {
                        foreach (var varlist in imageTypesRs.imageTypes)
                        {
                            imageTypeRep = new ImageTypeRep();
                            imageTypeRep.code = varlist.code;
                            imageTypeRep.description = (varlist.description == null) ? "" : varlist.description.content;
                            db.ImageTypeReps.Add(imageTypeRep);
                            db.SaveChanges();
                        }
                    }
                    hotelfrom = hotelfrom + 1000;
                    hotelto = hotelto + 1000;
                }


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool SyncGroupcategories()
        {
            try
            {

                GroupCategoriesRS groupCategoriesRs = new GroupCategoriesRS();
                HotelContentService hotelContentService = new HotelContentService();
                //Enum count = {}

                int hotelfrom = 1;
                int hotelto = 1000;


                for (int i = 1; i <= 100000; i++)
                {
                    groupCategoriesRs = hotelContentService.Getgroupcategories(0, 300);
                    GroupCategoryRep groupCategoryRep = new GroupCategoryRep();
                    using (var db = new HBNEWEntities())
                    {
                        foreach (var varlist in groupCategoriesRs.groupCategories)
                        {
                            groupCategoryRep = new GroupCategoryRep();
                            groupCategoryRep.code = varlist.code;
                            groupCategoryRep.description = (varlist.description == null) ? "" : varlist.description.content;
                            groupCategoryRep.name = (varlist.name == null) ? "" : varlist.name.content;
                            groupCategoryRep.order = varlist.order;
                            db.GroupCategoryReps.Add(groupCategoryRep);
                            db.SaveChanges();
                        }
                    }
                    hotelfrom = hotelfrom + 1000;
                    hotelto = hotelto + 1000;
                }


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public string TakeExchangRate()
        {
            CurrencyRate currencyRate = new CurrencyRate();
            CurrencyRep currencyRep = new CurrencyRep();

            using (var db = new HBNEWEntities())
            {
                var currencyData = db.CurrencyReps.Select(x => x);
                foreach (var varlist in currencyData)
                {
                    currencyRep.code = varlist.code;

                    string fromCur = currencyRep.code;
                    string toCur = "LKR";
                    WebClient web = new WebClient();
                    string url = string.Format("http://finance.yahoo.com/d/quotes.csv?e=.csv&f=sl1d1t1&s={0}{1}=X", fromCur.ToUpper(), toCur.ToUpper());
                    string response = web.DownloadString(url);
                    string[] values = Regex.Split(response, ",");
                    decimal rate = System.Convert.ToDecimal(values[1]);


                }
            }




            return currencyRep.ToString();

        }

        public bool SyncCurrencyConverter()
        {

            CurrencyRep currencyRep = new CurrencyRep();
            try
            {
                using (var db = new HBNEWEntities())
                {
                    var currencyData = db.CurrencyReps.Select(x => x);
                    foreach (var varlist in currencyData)
                    {
                        decimal cnvval = ConvertRate(varlist.code, "LKR");
                        HotelRepositoryService hotelrepositerysevice = new HotelRepositoryService();
                        var a = varlist.CurrencyRepID;
                        hotelrepositerysevice.ExecuteSqlstatement("UPDATE dbo.CurrencyReps SET Value=" + cnvval + "WHERE CurrencyRepID =" + a);

                    }

                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }




        }
        public decimal ConvertRate(string fromCur, string toCur)
        {
            decimal amount = 1;
            try
            {
                WebClient web = new WebClient();
                string url = string.Format("https://finance.google.com/bctzjpnsun/converter?a={2}&from={0}&to={1}", fromCur.ToUpper(),
                    toCur.ToUpper(), amount);


                string response = web.DownloadString(url);

                var split = response.Split((new string[] { "<span class=bld>" }), StringSplitOptions.None);
                var value = split[1].Split(' ')[0];
                decimal rate = decimal.Parse(value);
                return rate;


            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
