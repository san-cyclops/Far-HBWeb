﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Serialization;
using HB.ApiModel.auto.messages;
using HB.Service;
using HB.WebApiModel;
using HB.ApiModel.Content;
using HB.ApiModel.auto.model;
using HotelApiModel.auto.model;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Repositories;
using Repositories.Model;
using Repositories.Service;
using HB.ApiSDK.helpers;
using WebGrease.Css.Extensions;
using WebApiModel;
using Newtonsoft.Json.Linq;

namespace HB.WebApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class HotelBookingController : ApiController
    {

        string filePath = @"C:\Test\Error.txt";


        [HttpGet]
        public AvailabilityRS GetHotelDetailsRS(int HotelCode, string Des, string DepartureDate, string ReturnDate, string Rooms, string Adults1, string Children1, string C1Age1, string C1Age2, string C1Age3, string C1Age4, string Adults2, string Children2, string C2Age1, string C2Age2, string C2Age3, string C2Age4, string Adults3, string Children3, string C3Age1, string C3Age2, string C3Age3, string C3Age4)
        {
            AvailabilityRS availabilityRs = new AvailabilityRS();


            try
            {
                var hotelBookingService = new HotelBookingService();



                HotelBooking hotelBooking = new HotelBooking();
                decimal rates = 0;
                //DateTime varDepartureDate = Convert.ToDateTime(DepartureDate);
                //DateTime VarReturnDate = Convert.ToDateTime(ReturnDate);



                //string strDepartureDate = varDepartureDate.ToString("dd/MM/yyyy");
                //string strReturnDate = VarReturnDate.ToString("dd/MM/yyyy");


                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Date* GetHotelDetailsRS *" + DepartureDate + "--" + ReturnDate);
                }


                hotelBooking.DepartureDate = DepartureDate;
                hotelBooking.ReturnDate = ReturnDate;
                hotelBooking.Rooms = Convert.ToInt32(Rooms);
                hotelBooking.Des = Des;



                hotelBooking.Adults1 = Convert.ToInt32(Adults1);
                hotelBooking.Children1 = Convert.ToInt32(Children1);
                hotelBooking.C1Age1 = Convert.ToInt32(C1Age1);
                hotelBooking.C1Age2 = Convert.ToInt32(C1Age2);
                hotelBooking.C1Age3 = Convert.ToInt32(C1Age3);
                hotelBooking.C1Age4 = Convert.ToInt32(C1Age4);
                hotelBooking.Adults2 = Convert.ToInt32(Adults2);
                hotelBooking.Children2 = Convert.ToInt32(Children2);
                hotelBooking.C2Age1 = Convert.ToInt32(C2Age1);
                hotelBooking.C2Age2 = Convert.ToInt32(C2Age2);
                hotelBooking.C2Age3 = Convert.ToInt32(C2Age3);
                hotelBooking.C2Age4 = Convert.ToInt32(C2Age4);
                hotelBooking.Adults3 = Convert.ToInt32(Adults3);
                hotelBooking.Children3 = Convert.ToInt32(Children3);
                hotelBooking.C3Age1 = Convert.ToInt32(C3Age1);
                hotelBooking.C3Age2 = Convert.ToInt32(C3Age2);
                hotelBooking.C3Age3 = Convert.ToInt32(C3Age3);
                hotelBooking.C3Age4 = Convert.ToInt32(C3Age4);

                List<HotelRep> hotelRepList = new List<HotelRep>();
                List<ImageRep> imageRepsList = new List<ImageRep>();
                HotelContentService hotelContentService = new HotelContentService();
                HotelsRS hotelsRS = new HotelsRS();
                //using (var db = new HBNEWEntities())
                //{
                //    hotelRepList = db.HotelReps.Where(p => p.code == HotelCode).ToList();
                //}


                //if (hotelRepList.Count == 0)
                //{
                hotelsRS = hotelContentService.getHotelsfromCode(HotelCode, HotelCode);

                hotelRepList.Add(new HotelRep { code = hotelsRS.hotels[0].code, description = hotelsRS.hotels[0].description == null ? "" : hotelsRS.hotels[0].description.content, address = hotelsRS.hotels[0].address.content, phoneNumber = hotelsRS.hotels[0].phones[0].phoneNumber, postalCode = hotelsRS.hotels[0].postalCode, email = hotelsRS.hotels[0].email, accommodationTypeCode = hotelsRS.hotels[0].accommodationTypeCode });
                //}


                RateCommentsRS rateCommentsRS = new RateCommentsRS();


                availabilityRs = hotelBookingService.AvailabilityRequestHotelDetails(hotelBooking, hotelRepList);

                CategoriesRS categoriesRs = new CategoriesRS();

                categoriesRs = hotelContentService.Getcategories(1, 1000);

                FacilitiesRS facilitiesRs = new FacilitiesRS();

                facilitiesRs = hotelContentService.Getfacilities(1, 500);

                FacilityGroupsRS facilityGroupsRs = new FacilityGroupsRS();
                facilityGroupsRs = hotelContentService.Getfacilitygroups(1, 100);



                var x = (from h in hotelsRS.hotels[0].facilities
                         join f in facilitiesRs.facilities on h.facilityCode equals f.code
                         join fg in facilityGroupsRs.facilityGroups on h.facilityGroupCode equals fg.code
                         where f.facilityGroupCode == h.facilityGroupCode
                         select new { HotelCode = 0, facilityCode = 0, description = (h.indFee == false ? f.description.content : f.description.content + " *"), fgdescription = fg.description.content });



                var xt = x.Select(item => new FacilitySumRep
                {
                    HotelCode = item.HotelCode,
                    facilityCode = item.facilityCode,
                    DESCRIPTION = item.description,
                    fgdescription = item.fgdescription
                }).ToList();

                //HotelFacilityRep

                List<HotelPointOfInterest> interestPoints = new List<HotelPointOfInterest>();



                List<FacilitySumRep> facilitySumReps = new List<FacilitySumRep>();



                using (var db = new HBNEWEntities())
                {

                    //imageRepsList = db.ImageReps.ToList();
                    // imageRepsList.ToList()
                    //.ForEach(c => c.path = "http://photos.hotelbeds.com/giata/ + c.path.ToString());

                    if (availabilityRs.hotels != null)
                    {

                        foreach (var avarImg in availabilityRs.hotels.hotels)
                        {

                            rates = ConvertRate(avarImg.currency, "LKR");

                            avarImg.imagepath = hotelRepList.Where(a => a.code == avarImg.code).Select(a => "http://photos.hotelbeds.com/giata/" + a.imagepath).FirstOrDefault();


                            avarImg.hotelstar = categoriesRs.categories.Where(a => a.code == avarImg.categoryCode)
                              .Select(a => a.simpleCode)
                              .FirstOrDefault();


                            avarImg.description = hotelRepList.Where(a => a.code == avarImg.code).Select(a => a.description).FirstOrDefault();

                            avarImg.minRate =
                                (int)Math.Round(Convert.ToDecimal(avarImg.minRate) * rates);

                            avarImg.images = new List<ImageRep>();
                            avarImg.images = db.ImageReps.Where(a => a.HotelCode == avarImg.code).ToList();
                            avarImg.hotelrep = new List<HotelRep>();
                            avarImg.hotelrep = hotelRepList;
                            List<ApiModel.auto.model.Room> roomList = new List<ApiModel.auto.model.Room>();

                            roomList = avarImg.rooms.ToList();

                            foreach (var varRoom in roomList)
                            {
                                varRoom.rates
                                    .ForEach(c => c.net = (int)Math.Round((c.net * rates), 0));
                            }
                            avarImg.rooms = roomList;
                            avarImg.facilityrep = new List<FacilitySumRep>();
                            avarImg.facilityrep = xt;

                            if (hotelsRS.hotels[0].interestPoints != null)
                            {
                                interestPoints = (from h in hotelsRS.hotels[0].interestPoints select h).ToList();


                                avarImg.interestPoints = interestPoints;

                            }
                        }
                    }
                }
                return availabilityRs;
            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }
                return availabilityRs;
            }
        }

        [HttpGet]
        public ApiModel.auto.messages.CheckRateRS GetCheckRateRs(string rateKey)
        {
            ApiModel.auto.messages.CheckRateRS checkRateRs = new ApiModel.auto.messages.CheckRateRS();
            string filePath = @"C:\Test\Error.txt";
            try
            {
                var hotelBookingService = new HotelBookingService();
                decimal rates = 0;
                //using (StreamWriter writer = new StreamWriter(filePath, true))
                //{
                //    writer.WriteLine("RateKey - " + rateKey );
                //}
                if (rateKey != "null")
                {
                    checkRateRs = hotelBookingService.CheckRates(rateKey);
                    if (checkRateRs.hotel.rooms != null)
                    {
                        foreach (var var1 in checkRateRs.hotel.rooms)
                        {
                            rates = ConvertRate(checkRateRs.hotel.currency, "LKR");
                            var1.rates
                                .ForEach(c => c.net = (int)Math.Round((c.net * rates), 0));
                        }
                    }
                }
                return checkRateRs;
            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }
                return checkRateRs;
            }
        }


        [Route("api/HotelBooking/Availability")]
        [HttpPost]
        public AvailabilityRS Post([FromBody] HotelBooking hotelBooking)
        {
            try
            {
                HotelContentService hotelContentService = new HotelContentService();
                var hotelBookingService = new HotelBookingService();



                List<HotelRep> hotelRepList = new List<HotelRep>();
                //List<ImageRep> imageRepsList = new List<ImageRep>();
                using (var db = new HBNEWEntities())
                {
                    hotelRepList = db.HotelReps.Where(p => p.destinationCode.Equals(hotelBooking.Des)).Take(100).ToList();
                }

                //HotelsRS hotelsRS = new HotelsRS();

                //hotelsRS = hotelContentService.getHotels(hotelBooking.Des);

                CategoriesRS categoriesRs = new CategoriesRS();

                categoriesRs = hotelContentService.Getcategories(1, 1000);

                AvailabilityRS availabilityRs = new AvailabilityRS();

                //RateCommentsRS rateCommentsRS = new RateCommentsRS();
                //rateCommentsRS = hotelContentService.getRateComments();


                availabilityRs = hotelBookingService.AvailabilityRequest(hotelBooking, hotelRepList);



                availabilityRs.hotels.StrcheckIn = hotelBooking.DepartureDate.ToString();

                availabilityRs.hotels.StrcheckOut = hotelBooking.ReturnDate.ToString();


                //var sseee = availabilityRs.hotels.hotels.Where(a => a.code == 94075).FirstOrDefault();

                //var aaaa = hotelsRS.hotels.Where(a => a.code == 94075).FirstOrDefault();

                List<Hotel> delhotelist = new List<Hotel>();

                using (var db = new HBNEWEntities())
                {

                    // imageRepsList = db.ImageReps.ToList();
                    // imageRepsList.ToList()
                    //.ForEach(c => c.path = "http://photos.hotelbeds.com/giata/" + c.path.ToString());

                    if (availabilityRs.hotels.hotels != null)
                    {
                        Decimal rates = 0;

                        foreach (var avarImg in availabilityRs.hotels.hotels)
                        {
                            if (rates == 0)
                            {
                                rates = ConvertRate(avarImg.currency, "LKR");
                            }

                            var imgset = hotelRepList.Where(a => a.code == avarImg.code).Select(a => a.imagepath).FirstOrDefault();

                            if (imgset != null)
                            {
                                avarImg.imagepath = "http://photos.hotelbeds.com/giata/" + imgset;


                                HttpWebResponse response = null;
                                var request = (HttpWebRequest)WebRequest.Create(avarImg.imagepath);
                                request.Method = "HEAD";


                                try
                                {
                                    response = (HttpWebResponse)request.GetResponse();
                                }
                                catch (WebException ex)
                                {
                                    delhotelist.Add(avarImg);
                                }
                                finally
                                {
                                    // Don't forget to close your response.
                                    if (response != null)
                                    {
                                        response.Close();
                                    }

                                    //else {
                                    //    delhotelist.Add(avarImg);

                                    //}
                                }

                            }
                            else
                            {
                                //avarImg.imagepath = "http://tag2travel.com/images/HotelbedsImages/hotelDefaultImage.png";
                                delhotelist.Add(avarImg);
                            }

                            //avarImg.hotelstar = db.CategoryReps.Where(a => a.code == avarImg.categoryCode)
                            //    .Select(a => a.simpleCode)
                            //    .FirstOrDefault();
                            avarImg.hotelstar = categoriesRs.categories.Where(a => a.code == avarImg.categoryCode)
                              .Select(a => a.simpleCode)
                              .FirstOrDefault();



                            avarImg.description = hotelRepList.Where(a => a.code == avarImg.code).Select(a => a.description).FirstOrDefault();

                            avarImg.minRate =
                                (int)Math.Round(Convert.ToDecimal(avarImg.minRate) * rates);


                        }
                    }

                }

                foreach (Hotel item in delhotelist) availabilityRs.hotels.hotels.Remove(item);


                return availabilityRs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        [HttpGet]
        public AvailabilityRS GethotelView(string DestinationCode)
        {
            try
            {
                HotelContentService hotelContentService = new HotelContentService();
                var hotelBookingService = new HotelBookingService();
                decimal rates = 0;
                HotelsRS hotelsRS = new HotelsRS();

                //hotelsRS = hotelContentService.getHotels(DestinationCode);

                List<HotelRep> hotelRepList = new List<HotelRep>();


                using (var db = new HBNEWEntities())
                {
                    hotelRepList = db.HotelReps.Where(p => p.destinationCode == DestinationCode).Take(50).ToList();
                }

                AvailabilityRS availabilityRs = new AvailabilityRS();

                List<ImageRep> imageRepsList = new List<ImageRep>();


                CategoriesRS categoriesRs = new CategoriesRS();

                categoriesRs = hotelContentService.Getcategories(1, 1000);




                {

                    availabilityRs = hotelBookingService.AvailabilityOfDestination(hotelRepList);



                    availabilityRs.hotels.StrcheckIn = Convert.ToDateTime(availabilityRs.hotels.checkIn.ToString()).ToString("dd/MM/yyyy");
                    availabilityRs.hotels.StrcheckOut = Convert.ToDateTime(availabilityRs.hotels.checkOut.ToString()).ToString("dd/MM/yyyy");



                    if (availabilityRs.hotels != null)
                    {
                        int imgx = 0;
                        foreach (var avarImg in availabilityRs.hotels.hotels)
                        {

                            rates = ConvertRate(avarImg.currency, "LKR");
                            //avarImg.imagepath =
                            //    imageRepsList.Where(a => a.HotelCode == avarImg.code)
                            //        .Select(a => a.path)
                            //        .FirstOrDefault();


                            string x =
                                hotelRepList.Where(a => a.code == avarImg.code)
                                    .Select(a => a.imagepath)
                                    .FirstOrDefault()
                                    .ToString();
                            if (x == "")
                            {
                                avarImg.giata = "http://farholidays.com/wp-content/uploads/2017/10/PARIS-MILAN-ROME-1.jpg";
                            }

                            else
                            {
                                avarImg.giata = "http://photos.hotelbeds.com/giata/" + x;
                            }

                            using (StreamWriter writer = new StreamWriter(filePath, true))
                            {
                                writer.WriteLine(" categories hotelstar- " + categoriesRs.categories.Where(a => a.code == avarImg.categoryCode)
                                .Select(a => a.simpleCode)
                                .FirstOrDefault().ToString());
                            }

                            avarImg.hotelstar = categoriesRs.categories.Where(a => a.code == avarImg.categoryCode)
                                .Select(a => a.simpleCode)
                                .FirstOrDefault();





                            avarImg.minRate = (int)Math.Round(avarImg.minRate * rates, 0);



                            //avarImg.hotelrep = new List<HotelRep>();



                            List<ApiModel.auto.model.Room> roomList = new List<ApiModel.auto.model.Room>();

                            roomList = avarImg.rooms.ToList();
                            foreach (var varRoom in roomList)
                            {
                                varRoom.rates
                                    .ForEach(c => c.net = (int)Math.Round((c.net * rates), 0));

                            }
                            imgx++;
                            avarImg.rooms = roomList;


                        }
                    }

                }


                return availabilityRs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private decimal Convertx(string minRate, string fromCur, string toCur)
        {
            decimal amount = Convert.ToDecimal(minRate);
            WebClient web = new WebClient();
            string url = string.Format("http://finance.yahoo.com/d/quotes.csv?e=.csv&f=sl1d1t1&s={0}{1}=X", fromCur.ToUpper(), toCur.ToUpper());
            string response = web.DownloadString(url);
            string[] values = Regex.Split(response, ",");
            decimal rate = System.Convert.ToDecimal(values[1]);
            return amount * rate;

        }
        private decimal ConvertRate(string fromCur, string toCur)
        {
            try
            {
                if (fromCur != "USD")
                {
                    WebClient web = new WebClient();
                    string url = string.Format("http://finance.yahoo.com/d/quotes.csv?e=.csv&f=sl1d1t1&s={0}{1}=X", fromCur.ToUpper(), toCur.ToUpper());
                    string response = web.DownloadString(url);
                    string[] values = Regex.Split(response, ",");
                    decimal rate = System.Convert.ToDecimal(values[1]);
                    return rate;
                }
                else
                {
                    HotelRepositoryService currency = new HotelRepositoryService();
                    return currency.GetCurrencyRate();
                }
            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Currency Error--"+ex.Message);
                }
                HotelRepositoryService currency = new HotelRepositoryService();
                return currency.GetCurrencyRate();
            }
        } 

        [HttpGet]
        public DocumentRep GetDocumentNo(string DocType)
        {
            using (var db = new HBNEWEntities())
            {
                HotelRepositoryService hotelRepositoryService = new HotelRepositoryService();
                return hotelRepositoryService.GetDocumentNoByForm("BookingConferm");

            }
        }

        [Route("api/HotelBooking/ConfirmBooking")]
        [HttpPost]
        public BookingRS PostConfirmBooking(HotelPayment objData)
        {


            var hotelBookingService = new HotelBookingService();
            var bookingRs = new BookingRS();
            var hotelBookingConfirmation = new HotelBookingConfirmation();



            string childNames = objData.child1name + " " + objData.Child1surname + " - " + objData.child2name + " " + objData.Child2surname + " - " + objData.child3name + " " + objData.Child3surname + " - " + objData.child4name + " " + objData.Child4surname;


            hotelBookingConfirmation.Adults1name = objData.Adults1;
            hotelBookingConfirmation.Adults1surname = objData.Adults1surname;

            hotelBookingConfirmation.Adults2name = objData.Adults2;
            hotelBookingConfirmation.Adults2surname = objData.Adults2surname;

            hotelBookingConfirmation.Adults3name = objData.Adults3;
            hotelBookingConfirmation.Adults3surname = objData.Adults3surname;

            hotelBookingConfirmation.Children1 = objData.child1name + " " + objData.Child1surname;

            hotelBookingConfirmation.Children2 = objData.child2name + " " + objData.Child2surname;
            hotelBookingConfirmation.Children3 = objData.child3name + " " + objData.Child3surname;





            hotelBookingConfirmation.rateKey1 = objData.ratekey1;
            hotelBookingConfirmation.HotelEmail = objData.hotelemail;
            hotelBookingConfirmation.DepartureDate = objData.checkin;
            hotelBookingConfirmation.ReturnDate = objData.checkout;
            hotelBookingConfirmation.HotelAddress = objData.hoteladdress + "-" + objData.board;
            hotelBookingConfirmation.Destination = objData.destination;
            hotelBookingConfirmation.Pax = objData.pax;
            hotelBookingConfirmation.Rooms = objData.noofrooms;
            hotelBookingConfirmation.Email = objData.Adults1email;
            hotelBookingConfirmation.Mobile = objData.Adults1phone;
            hotelBookingConfirmation.Board = objData.board;
            hotelBookingConfirmation.RoomType = objData.roomtype;
            hotelBookingConfirmation.Price = objData.rate;
            hotelBookingConfirmation.HotelName = objData.hotelname;
            hotelBookingConfirmation.HotelPhone = objData.hotelphone;
            bookingRs = hotelBookingService.BookingCconfirmation(hotelBookingConfirmation);



            hotelBookingConfirmation.Description = bookingRs.booking.hotel.rooms[0].rates[0].rateComments;

            string childAge = "";
            string childAge1 = "";
            string childAge2 = "";
            string childAges = "";
            string otherGuestNames = "";

            otherGuestNames = objData.Adults1 + " " + objData.Adults1surname + " - " + objData.Adults2 + " " + objData.Adults2surname + " - " + objData.Adults3 + " " + objData.Adults3surname + " - ";
            bookingRs.GuestNames = otherGuestNames;



            childNames = "Child Details- " + childNames;
            bookingRs.ChildNames = childNames;
            bookingRs.HotelPaymentDetails = new HotelPayment();
            bookingRs.HotelPaymentDetails = objData;



            if (hotelBookingConfirmation.Rooms == "1")
            {
                if (!(objData.C1Age1 == "0"))
                {
                    childAges = "Room 1 Child Ages - " + objData.C1Age1;
                }
                if (!(objData.C1Age2 == "0"))
                {
                    childAges = childAges + " - " + objData.C1Age2;
                }
                if (!(objData.C1Age3 == "0"))
                {
                    childAges = childAges + "-" + objData.C1Age3;
                }
                if (!(objData.C1Age4 == "0"))
                {
                    childAges = childAges + "-" + objData.C1Age4;
                }


            }
            if (hotelBookingConfirmation.Rooms == "2")
            {
                childAge = "Room 1 Child Ages - " + hotelBookingConfirmation.C1Age1 + "-" + hotelBookingConfirmation.C1Age2 + "-" + hotelBookingConfirmation.C1Age3 + "-" + hotelBookingConfirmation.C1Age4;
                childAge1 = "Room 2 Child Ages - " + hotelBookingConfirmation.C2Age1 + "-" + hotelBookingConfirmation.C2Age2 + "-" + hotelBookingConfirmation.C2Age3 + "-" + hotelBookingConfirmation.C2Age4;
                childAges = childAge + " / " + childAge1;

            }
            if (hotelBookingConfirmation.Rooms == "3")
            {
                childAge = "Room 1 Child Ages - " + hotelBookingConfirmation.C1Age1 + "-" + hotelBookingConfirmation.C1Age2 + "-" + hotelBookingConfirmation.C1Age3 + "-" + hotelBookingConfirmation.C1Age4;
                childAge1 = "Room 2 Child Ages - " + hotelBookingConfirmation.C2Age1 + "-" + hotelBookingConfirmation.C2Age2 + "-" + hotelBookingConfirmation.C2Age3 + "-" + hotelBookingConfirmation.C2Age4;
                childAge2 = "Room 3 Child Ages - " + hotelBookingConfirmation.C3Age1 + "-" + hotelBookingConfirmation.C3Age2 + "-" + hotelBookingConfirmation.C3Age3 + "-" + hotelBookingConfirmation.C3Age4;
                childAges = childAge + childAge1 + childAge2;

            }
            string body = this.PopulateBody(hotelBookingConfirmation, bookingRs.booking.clientReference, bookingRs.booking.reference, childAges, bookingRs.booking.hotel.supplier.name, bookingRs.booking.hotel.supplier.vatNumber, hotelBookingConfirmation.HotelAddress, hotelBookingConfirmation.Email, hotelBookingConfirmation.Mobile, otherGuestNames, childNames);
            SendHtmlFormattedEmail(hotelBookingConfirmation.Email, "BOOKING CONFIRMATION", body);
            SendHtmlFormattedEmail("sales@tag2travel.com", "BOOKING CONFIRMATION", body);
            HotelPaymentDetail paymentDetail = new HotelPaymentDetail();


            paymentDetail.clientID = objData.clientID;
            paymentDetail.currency = objData.currency;
            paymentDetail.holderName = objData.holderName;
            paymentDetail.number = objData.number;
            paymentDetail.paymentAmount = Convert.ToDecimal(objData.paymentAmount);
            paymentDetail.responseCode = objData.responseCode;
            paymentDetail.responseText = objData.responseText;
            paymentDetail.txnReference = objData.txnReference;
            paymentDetail.type = objData.type;


            HotelRepositoryService hotelRepositoryService = new HotelRepositoryService();
            hotelRepositoryService.UpdateHotelPaymentDetail(paymentDetail);


            return bookingRs;
        }

        private void SendHtmlFormattedEmail(string recepientEmail, string subject, string body)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress("bookings@tag2travel.com");
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress(recepientEmail));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "mail.tag2travel.com";
                smtp.EnableSsl = true;
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = "bookings@tag2travel.com";
                NetworkCred.Password = "bookings@123";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mailMessage);
            }
        }
        private string PopulateBody(HotelBookingConfirmation hotelEmail, string DocNo, string bookingref, string childAges, string supplierName, string supplierVatNumber, string hotelEmailAddres, string Email, string Mobile, string otherGuestNames, string childNames)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("\\Views\\EmailTemplate\\BookingConfermation.html")))
            {
                body = reader.ReadToEnd();
            }

            int Adults = Convert.ToInt32(string.IsNullOrEmpty(hotelEmail.Adults1name) ? "0" : "1") + Convert.ToInt32(string.IsNullOrEmpty(hotelEmail.Adults2name) ? "0" : "1") +
                         Convert.ToInt32(string.IsNullOrEmpty(hotelEmail.Adults3name) ? "0" : "1");

            int childrens = Convert.ToInt32(Convert.ToInt32((hotelEmail.Children1 == " ") ? "0" : "1")) + Convert.ToInt32((hotelEmail.Children2 == " ") ? "0" : "1") +
                       Convert.ToInt32((hotelEmail.Children3 == " ") ? "0" : "1");

            int TotalPax = Adults + childrens;


            body = body.Replace("{UserName}", hotelEmail.Adults1name + " " + hotelEmail.Adults1surname);
            body = body.Replace("{Email}", hotelEmail.Email);
            body = body.Replace("{Mobile}", Mobile);
            body = body.Replace("{DocNo}", DocNo);
            body = body.Replace("{Reference}", bookingref);
            //body = body.Replace("{Url}", url);
            body = body.Replace("{HotelName}", hotelEmail.HotelName);
            body = body.Replace("{HotelAddress}", hotelEmail.HotelAddress);
            body = body.Replace("{HotelPhone}", hotelEmail.HotelPhone);
            body = body.Replace("{HotelEmail}", hotelEmail.HotelEmail);
            body = body.Replace("{DateFrom}", hotelEmail.DepartureDate);
            body = body.Replace("{DateTo}", hotelEmail.ReturnDate);
            body = body.Replace("{Pax}", hotelEmail.Pax);
            body = body.Replace("{Destination}", hotelEmail.Destination);
            body = body.Replace("{RoomType}", hotelEmail.RoomType);
            body = body.Replace("{Board}", hotelEmail.Board);
            body = body.Replace("{Price}", hotelEmail.Price);
            body = body.Replace("{Description}", hotelEmail.Description);
            body = body.Replace("{Adults}", Adults.ToString());
            body = body.Replace("{Childrens}", childrens.ToString());
            body = body.Replace("{ChildrensAge}", childAges);
            body = body.Replace("{Supplier}", supplierName);
            body = body.Replace("{Vatnumber}", supplierVatNumber);
            body = body.Replace("{OtherGuestNames}", otherGuestNames);
            body = body.Replace("{ChildNames}", childNames);

            return body;
        }



        [Route("api/HotelBooking/BookingCancellation")]
        [HttpGet]
        public string GetBookingCancellation(string recid)
        {
            HotelBookingService hotelBookingService = new HotelBookingService();

            string val = hotelBookingService.BookingCancellation(recid);

            return "";
        }

        [Route("api/HotelBooking/getBookingList")]
        [HttpPost]
        public BookingListRS BookingList(HotelBookingList hotelBookingList)
        {

            var bookingRs = new BookingListRS();
            HotelBookingService hotelBookingService = new HotelBookingService();
            bookingRs = hotelBookingService.getBookingList(hotelBookingList);
            return bookingRs;
        }

        [Route("api/HotelBooking/getBookingDetailList")]
        [HttpPost]
        public BookingDetailRS getBookingDetailList(string reference)
        {

            var detailRs = new BookingDetailRS();
            HotelBookingService hotelBookingService = new HotelBookingService();
            detailRs = hotelBookingService.getBookingDetailList(reference);
            return detailRs;
        }

    }


    public class Ratex
    {
        public string to { get; set; }
        public string from { get; set; }
        public double rate { get; set; }
    }
}