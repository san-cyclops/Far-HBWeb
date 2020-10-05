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
using Repositories;
using Repositories.Model;
using Repositories.Service;
using HB.ApiSDK.helpers;
using WebGrease.Css.Extensions;
using WebApiModel;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Web.Http.Cors;

namespace HB.WebUI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class HotelBookingController : ApiController
    {
        string filePath = @"C:\Test\Error.txt";

        [HttpGet]
        public string GetHotelDetailsRS(int HotelCode, string Des, string DepartureDate, string ReturnDate, string Rooms, string Adults1, string Children1, string C1Age1, string C1Age2, string C1Age3, string C1Age4, string Adults2, string Children2, string C2Age1, string C2Age2, string C2Age3, string C2Age4, string Adults3, string Children3, string C3Age1, string C3Age2, string C3Age3, string C3Age4,string visitorsCurrency, int Markup)
        {
            AvailabilityRS availabilityRs = new AvailabilityRS();
            string result = "";
            decimal markup = 0;
            decimal agentMarkup = Markup;
            try
            {
                var hotelBookingService = new HotelBookingService();
                HotelBooking hotelBooking = new HotelBooking();
                decimal rates = 0;
                decimal visitorsRate1 = 0;
                string strRateCurrency = "";
                string strVisitorsCurrency = "";
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
                hotelBooking.visitorsCurrency = visitorsCurrency;
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
                         where f.facilityGroupCode == h.facilityGroupCode && h.indYesOrNo==true 
                         select new {
                             HotelCode = 0,
                             facilityCode = 0,
                             description = (h.indFee == false ? (h.number>0 ? f.description.content + " "+ h.number : f.description.content): (h.number > 0 ? f.description.content + " " + h.number : f.description.content) + "*"),
                             fgdescription = fg.description.content
                         });

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
                //  using (var db = new HBNEWEntities())
                //  {
                var db = new HBNEWEntities();
                if (availabilityRs.hotels != null)
                {
                    //********************************************************coded by isuru************************************************

                    var avb_Hotels = (from avb in availabilityRs.hotels.hotels select avb).ToList();
                    string currency = (from avb in availabilityRs.hotels.hotels select avb.currency).FirstOrDefault().ToString();
                    var cat_Rs = (from cat in categoriesRs.categories select cat).AsEnumerable();

           

                    if (hotelBooking.visitorsCurrency == "LKR")
                    {
                        visitorsRate1 = ConvertRate(currency, "USD");
                        strVisitorsCurrency = "USD";
                    }
                    else
                    {
                        visitorsRate1 = ConvertRate(currency, hotelBooking.visitorsCurrency);
                        strVisitorsCurrency = hotelBooking.visitorsCurrency;
                    }

                    if (hotelBooking.visitorsCurrency == "LKR")
                    {
                        rates = ConvertRate(currency, "LKR");
                        strRateCurrency = "LKR";
                    }
                    else
                    {
                        rates = ConvertRate(currency, "USD");
                        strRateCurrency = "USD";
                    }

                    //add markup value by Anu on 2018-03-30
                    markup = setAgentMarkup("00001");
                    markup = markup + agentMarkup;
                    markup = markup / 100;

                    //-----end--------


                    int hcode = 0;
                    hcode = (from av in availabilityRs.hotels.hotels select av.code).FirstOrDefault();
                    var img = (from a in db.ImageReps
                               where a.HotelCode == hcode
                               select new
                               {
                                   a.path,
                                   img = ("http://photos.hotelbeds.com/giata/" + a.path)
                               }
                                 ).ToList();
                    avb_Hotels.ToList().ForEach(c => c.rooms.ToList().ForEach(h => h.rates.ForEach(f => f.visitorsRate = (decimal)Math.Round((f.net * visitorsRate1) + ((f.net * visitorsRate1) * markup), 2))));
                    avb_Hotels.ToList().ForEach(c => c.rooms.ToList().ForEach(h => h.rates.ForEach(f => f.net = (decimal)Math.Round((f.net * rates) + ((f.net * rates) * markup), 2))));
               

                    // var interestPoints = (from h in hotelsRS.hotels[0].interestPoints select h).ToList();
                    var hotelrs = (from hotRs in hotelsRS.hotels select hotRs).ToList();

                    //*****this is also correct********availabilityRs.hotels.hotels.ToList().ForEach((c => c.rooms.ToList().ForEach(h => h.rates.ForEach(f => f.net = (int)Math.Round((f.net * rates), 0)))));

             



                    var textvar = (from avbH in avb_Hotels
                                   join catRs in cat_Rs on avbH.categoryCode equals catRs.code
                                   join rep in hotelRepList on avbH.code equals rep.code

                                   select new
                                   {
                                       //  destinationCode = avbH.destinationCode,
                                       //destinationName = avbH.destinationName,
                                       // latitude = avbH.latitude,
                                       //  longitude = avbH.longitude,
                                       description = rep.description,//working                                                         
                                       hotelstar = catRs.simpleCode,//working
                                       checkIn = DepartureDate,
                                       checkOut = ReturnDate,
                                       name = avbH.name,
                                       address = rep.address,
                                       phoneNumber = rep.phoneNumber,
                                       destinationName = avbH.destinationName,
                                       categoryName = avbH.categoryName,
                                       latitude = avbH.latitude,
                                       longitude = avbH.longitude,
                                       accommodationTypeCode = rep.accommodationTypeCode,
                                       minRate = (decimal)Math.Round((Convert.ToDecimal(avbH.minRate) * rates) + ((Convert.ToDecimal(avbH.minRate) * rates) * markup), 2),
                                       // minRate = (decimal)Math.Round((Convert.ToDecimal(avbH.minRate) * rates),2),//working
                                       // visitorsRate = (decimal)Math.Round((Convert.ToDecimal(avbH.minRate) * visitorsRate1),1),
                                       visitorsRate = (decimal)Math.Round((Convert.ToDecimal(avbH.minRate) * visitorsRate1) + ((Convert.ToDecimal(avbH.minRate) * visitorsRate1) * markup), 2),
                                       rateCurrency = strRateCurrency,
                                       visitingCurrency = strVisitorsCurrency,
                                       images = (from ImgRep in img
                                                 select ImgRep).ToList(),
                                       rooms = avbH.rooms,
                                       facilityrep = (from fac in xt
                                                      select fac
                                                        ),
                                       interestPoints = (from intr in hotelrs
                                                         select intr.interestPoints
                                                          ),

                                       ratecomment = avbH.ratecomment,
                                       imagepath = (from a in img
                                                    select a.ToString()
                                                        )
                                   }).ToList();
                    result = JsonConvert.SerializeObject(textvar, Newtonsoft.Json.Formatting.None);

                }

                return result;

            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }
                //return Json(textvar);
                //return Request.CreateResponse(HttpStatusCode.OK,"" , "application/json");
                return result;
                //return availabilityRs;
            }
        }

        [HttpGet]
        public ApiModel.auto.messages.CheckRateRS GetCheckRateRs(string rateKey, string Rooms, string Adults1, string Children1, string C1Age1, string C1Age2, string C1Age3, string C1Age4, string Adults2, string Children2, string C2Age1, string C2Age2, string C2Age3, string C2Age4, string Adults3, string Children3, string C3Age1, string C3Age2, string C3Age3, string C3Age4, string visitorsCurrency, int Markup)
        {
            ApiModel.auto.messages.CheckRateRS checkRateRs = new ApiModel.auto.messages.CheckRateRS();
            string filePath = @"C:\Test\Error.txt";
            try
            {
                var hotelBookingService = new HotelBookingService();
                decimal rates = 0;
                decimal visitorsRates1 = 0;
                string strRateCurrency = "";
                string strVisitorsCurrency = "";

                decimal markup = 0;
                decimal agentMarkup = Markup;

                if (rateKey != "null")
                {
                    checkRateRs = hotelBookingService.CheckRates(rateKey,Rooms,Adults1,Children1,C1Age1,C1Age2,C1Age3,C1Age4,Adults2,Children2,C2Age1,C2Age2,C2Age3,C2Age4,Adults3,Children3,C3Age1,C3Age2,C3Age3,C3Age4);
                    if (checkRateRs.hotel.rooms != null)
                    {
                        foreach (var var1 in checkRateRs.hotel.rooms)
                        {
                            if (visitorsCurrency == "LKR")
                            {
                                visitorsRates1 = ConvertRate(checkRateRs.hotel.currency, "USD");
                                strVisitorsCurrency = "USD";
                            }
                            else
                            {
                                visitorsRates1 = ConvertRate(checkRateRs.hotel.currency, visitorsCurrency);
                                strVisitorsCurrency = visitorsCurrency;
                            }

                            if (visitorsCurrency == "LKR")
                            {
                                rates = ConvertRate(checkRateRs.hotel.currency, "LKR");
                                strRateCurrency = "LKR";
                            }
                            else
                            {
                                rates = ConvertRate(checkRateRs.hotel.currency, "USD");
                                strRateCurrency = "USD";
                            }

                            //add markup value by Anu on 2018-03-30
                            markup = setAgentMarkup("00001");
                            markup = markup + agentMarkup;
                            markup = markup / 100;

                            //-----end--------



                            var1.rates 
                               .ForEach(c => c.visitorsRate = (decimal)Math.Round((c.net * visitorsRates1) + ((c.net * visitorsRates1) * markup), 2));

                            var1.rates
                                .ForEach(c => c.net = (decimal)Math.Round((c.net * rates) + ((c.net * rates) * markup), 2));
                            var1.strVisitorsCurrency = strVisitorsCurrency;
                            var1.strRateCurrency = strRateCurrency;                            
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
        public string Post([FromBody] HotelBooking hotelBooking)
        {
            string result = "";
            decimal agentMarkup = hotelBooking.Markup;
            try
            {
                decimal rates = 0;
                decimal visitorsRate1 = 0;
                decimal markup = 0;
                string strRateCurrency = "";
                string strVisitorsCurrency = "";
                HotelContentService hotelContentService = new HotelContentService();
                var hotelBookingService = new HotelBookingService();
                List<HotelRep> hotelRepList = new List<HotelRep>();
               // List<ImageRep> imageRepsList = new List<ImageRep>();
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

                        //*****************************coded by isuru*************************************************************************

                        var avb_Hotels = (from avb in availabilityRs.hotels.hotels select avb).ToList();
                        string currency = (from avb in availabilityRs.hotels.hotels select avb.currency).FirstOrDefault().ToString();
                        // string VisitorsCurrency = (from hbkn in hotelBookingC select hbkn.visitorsCurrency);
                        if (hotelBooking.visitorsCurrency == "LKR")
                        {
                            visitorsRate1 = ConvertRate(currency, "USD");
                            strVisitorsCurrency = "USD";
                        }
                        else
                        {
                            visitorsRate1 = ConvertRate(currency, hotelBooking.visitorsCurrency);
                            strVisitorsCurrency = hotelBooking.visitorsCurrency;
                        }

                        if (hotelBooking.visitorsCurrency == "LKR")
                        {
                            rates = ConvertRate(currency, "LKR");
                            strRateCurrency = "LKR";
                        }
                        else
                        {
                            rates = ConvertRate(currency, "USD");
                            strRateCurrency = "USD";
                        }


                        //add markup value by Anu on 2018-03-30
                        markup = setAgentMarkup("00001");
                        markup = markup + agentMarkup;
                        markup = markup / 100;
                     
                        //-----end--------


                        var cat_Rs = (from cat in categoriesRs.categories select cat).AsEnumerable();

                        // avb_Hotels.ToList().ForEach(c => c.rooms.ToList().ForEach(h => h.rates.ForEach(f => f.net = (int)Math.Round((f.net * rates), 0))));

                        var textvar = (from avbH in avb_Hotels
                                       join catRs in cat_Rs on avbH.categoryCode equals catRs.code
                                       join rep in hotelRepList on avbH.code equals rep.code
                                       select new
                                       {
                                          
                                           code = avbH.code,
                                           destinationCode = avbH.destinationCode,
                                           description = rep.description,//working                                                         
                                           hotelstar = catRs.simpleCode,//working
                                           checkIn = hotelBooking.DepartureDate,
                                           checkOut = hotelBooking.ReturnDate,
                                           name = avbH.name,
                                           address = rep.address,
                                           phoneNumber = rep.phoneNumber,
                                           destinationName = avbH.destinationName,
                                           categoryName = avbH.categoryName,
                                           latitude = avbH.latitude,
                                           longitude = avbH.longitude,
                                           accommodationTypeCode = rep.accommodationTypeCode,
                                          // minRate = (decimal)Math.Round((avbH.minRate) * rates,2),//working
                                           minRate = (decimal)Math.Round((avbH.minRate * rates) + ((avbH.minRate * rates) * markup), 2),
                                           imagepath = "http://photos.hotelbeds.com/giata/" + rep.imagepath,
                                           rooms = avbH.rooms,
                                           ratecomment = avbH.ratecomment,
                                           // visitorsRate = (decimal)Math.Round((avbH.minRate) * visitorsRate, 2),
                                           visitorsRate = (decimal)Math.Round((avbH.minRate * visitorsRate1) + ((avbH.minRate * visitorsRate1) * markup), 2),
                                           rateCurrency = strRateCurrency,
                                           visitingCurrency = strVisitorsCurrency
                                       });

                        var textvar2 = textvar.FirstOrDefault();

                        result = JsonConvert.SerializeObject(textvar, Newtonsoft.Json.Formatting.None);






                    }
                }
                // foreach (Hotel item in delhotelist) availabilityRs.hotels.hotels.Remove(item);

                //return availabilityRs;
                return result;
            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.InnerException +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }
                return result;
            }
        }

        [HttpGet]
        public AvailabilityRS GethotelView(string DestinationCode)
        {
            try
            {
                decimal markup = 0;
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

                //add markup value by Anu on 2018-03-30
                markup = setAgentMarkup("00001");             
                markup = markup / 100;

                //-----end--------

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
                                avarImg.giata = "http://farholidays.com/wp-content/uploads/2018/01/default-hotel-image.jpg";
                            }
                            else
                            {
                                avarImg.giata = "http://photos.hotelbeds.com/giata/" + x;
                            }


                            //By Anu
                            //To check if a URL exists/is valid

                            bool s = RemoteFileExists(avarImg.giata);
                            if(s==false)
                            {
                                avarImg.giata = "http://farholidays.com/wp-content/uploads/2018/01/default-hotel-image.jpg";

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

                            avarImg.minRate = (decimal)Math.Round((avarImg.minRate * rates) + ((avarImg.minRate * rates) * markup), 2);
                            //avarImg.hotelrep = new List<HotelRep>();
                            List<ApiModel.auto.model.Room> roomList = new List<ApiModel.auto.model.Room>();
                            roomList = avarImg.rooms.ToList();
                            foreach (var varRoom in roomList)
                            {
                                varRoom.rates
                                    .ForEach(c => c.net = (decimal)Math.Round((c.net * rates) + ((c.net * rates) * markup), 2));
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

        private bool RemoteFileExists(string url)
        {
            try
            {
                //Creating the HttpWebRequest
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                //Setting the Request method HEAD, you can also use GET too.
                request.Method = "HEAD";
                //Getting the Web Response.
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //Returns TRUE if the Status code == 200
                response.Close();
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch
            {
                //Any exception will returns false.
                return false;
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
                //if (fromCur != "USD")
                //{
                //    WebClient web = new WebClient();
                //    string url = string.Format("http://finance.yahoo.com/d/quotes.csv?e=.csv&f=sl1d1t1&s={0}{1}=X", fromCur.ToUpper(), toCur.ToUpper());
                //    string response = web.DownloadString(url);
                //    string[] values = Regex.Split(response, ",");
                //    decimal rate = System.Convert.ToDecimal(values[1]);
                //    return rate;
                //}
                //else
                //{
                //HotelRepositoryService currency = new HotelRepositoryService();
                //return currency.GetCurrencyRate();
                //}
                decimal amount = 1;
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
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Currency Error--" + ex.Message);
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
            return val;
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
        public HotelBookingDetails getBookingDetailList(string reference)
        {
            var detailRs = new HotelBookingDetails();
            HotelBookingService hotelBookingService = new HotelBookingService();
            //detailRs = hotelBookingService.getBookingDetailList(reference);
            return detailRs;
        }

        /// <summary>
        /// use to get Agent markuP
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public decimal setAgentMarkup(string code)
        {
            decimal markup = 0;
            using (var db = new HBNEWEntities())
            {
                var x = db.AgentMarkups.Where(p => p.UserID == code).Select(p => p.Presentage).FirstOrDefault();
                markup = decimal.Parse(x.ToString());
            }

           
            return markup;
        }
    }

    public class Ratex
    {
        public string to { get; set; }
        public string from { get; set; }
        public double rate { get; set; }
    }
}