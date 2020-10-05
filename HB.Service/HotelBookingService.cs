﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using HB.ApiModel.auto.common;
using HB.ApiModel.auto.messages;
using HB.ApiModel.auto.model;
using HB.ApiModel.Content;
using HB.ApiSDK;
using HB.ApiSDK.helpers;
using HB.WebApiModel;
using Repositories;
using Repositories.Model;
using Repositories.Service;
using WebApiModel;
using CheckRateRS = HB.ApiModel.auto.messages.CheckRateRS;
using System.Net;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
namespace HB.Service
{
    public class HotelBookingService
    {
        string filePath = @"C:\Test\Error.txt";
        public AvailabilityRS AvailabilityRequest(HotelBooking hotelBooking, List<HotelRep> hotelsRs)  //List<HotelRep> hotelsRs
        {
            var client = new HotelApiClient();
            var status = client.status();

            //if (status != null && status.error == null)
            //    Console.WriteLine("StatusRS: " + status.status);
            //else if (status != null && status.error != null)
            //{
            //    Console.WriteLine("StatusRS: " + status.status + " " + status.error.code + ": " +
            //                      status.error.message);
            //    return;
            //}
            //else if (status == null)
            //{
            //    Console.WriteLine("StatusRS: Is not available.");
            //    return;
            //}

            List<Tuple<string, string>> param;

            Availability avail = new Availability();

            DateTime dtDepartureDate = DateTime.ParseExact(hotelBooking.DepartureDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime dtReturnDate = DateTime.ParseExact(hotelBooking.ReturnDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            //avail.checkIn = DateTime.Now.AddDays(10);
            //avail.checkOut = DateTime.Now.AddDays(13);


            //string stringDate = hotelBooking.DepartureDate.Substring(0, hotelBooking.DepartureDate.IndexOf("Z"));
            //var a = stringDate + "GMT+0530";

            //var dt = DateTime.ParseExact(a, "ddd MMM dd yyyy HH:mm:ss 'GMT'zzz", System.Globalization.CultureInfo.InvariantCulture);

            //var stringReturnDate = hotelBooking.ReturnDate.Substring(0, hotelBooking.ReturnDate.IndexOf("Z"));
            //var aReturnDate = stringReturnDate + "GMT+0530";

            //var dtReturnDate = DateTime.ParseExact(aReturnDate, "ddd MMM dd yyyy HH:mm:ss 'GMT'zzz", System.Globalization.CultureInfo.InvariantCulture);

            avail.checkIn = Convert.ToDateTime(dtDepartureDate);
            avail.checkOut = Convert.ToDateTime(dtReturnDate);


            //avail.destination = hotelBooking.Destination; // "PMI";
            //avail.zone = 90;


            avail.language = "ENG";
            //avail.shiftDays = 2;

            for (int i = 0; i < hotelBooking.Rooms; i++)
            {
                AvailRoom room = new AvailRoom();
                if (i == 0)
                {
                    room.adults = hotelBooking.Adults1;

                    room.children = hotelBooking.Children1; /*hotelBooking.Children;*/

                    room.details = new List<RoomDetail>();

                    for (int count = 0; count < hotelBooking.Children1; count++)
                    {
                        if (count == 0)
                        { room.childOf(hotelBooking.C1Age1); }
                        if (count == 1)
                        { room.childOf(hotelBooking.C1Age2); }
                        if (count == 2)
                        { room.childOf(hotelBooking.C1Age3); }
                        if (count == 3)
                        { room.childOf(hotelBooking.C1Age4); }
                    }

                    for (int count = 0; count < hotelBooking.Adults1; count++)
                    {
                        room.adultOf(30);
                    }
                }


                if (i == 1)
                {
                    room.adults = hotelBooking.Adults2;

                    room.children = hotelBooking.Children2; /*hotelBooking.Children;*/

                    room.details = new List<RoomDetail>();

                    for (int count = 0; count < hotelBooking.Children2; count++)
                    {
                        if (count == 0)
                        { room.childOf(hotelBooking.C2Age1); }
                        if (count == 1)
                        { room.childOf(hotelBooking.C2Age2); }
                        if (count == 2)
                        { room.childOf(hotelBooking.C2Age3); }
                        if (count == 3)
                        { room.childOf(hotelBooking.C2Age4); }
                    }

                    for (int count = 0; count < hotelBooking.Adults2; count++)
                    {
                        room.adultOf(30);
                    }
                }

                if (i == 2)
                {
                    room.adults = hotelBooking.Adults3;

                    room.children = hotelBooking.Children3; /*hotelBooking.Children;*/

                    room.details = new List<RoomDetail>();

                    for (int count = 0; count < hotelBooking.Children3; count++)
                    {
                        if (count == 0)
                        { room.childOf(hotelBooking.C3Age1); }
                        if (count == 1)
                        { room.childOf(hotelBooking.C3Age2); }
                        if (count == 2)
                        { room.childOf(hotelBooking.C3Age3); }
                        if (count == 3)
                        { room.childOf(hotelBooking.C3Age4); }
                    }

                    for (int count = 0; count < hotelBooking.Adults3; count++)
                    {
                        room.adultOf(30);
                    }
                }

                //room.adultOf(30);
                //room.adultOf(30);
                room.numberOfRooms = hotelBooking.Rooms; // 2;
                avail.rooms.Add(room);

            }



            //room = new AvailRoom();
            //room.adults = 2;
            //room.children = 0;
            //room.details = new List<RoomDetail>();
            //room.adultOf(30);
            //room.adultOf(30);
            //room.numberOfRooms = 1;
            //avail.rooms.Add(room);
            avail.payed = Availability.Pay.AT_WEB;
            //avail.ofTypes = new HashSet<SimpleTypes.AccommodationType>();
            //avail.ofTypes.Add(SimpleTypes.AccommodationType.HOTEL);
            //avail.ofTypes.Add(SimpleTypes.AccommodationType.APARTMENT);

            //avail.minCategory = 4;
            //avail.limitHotelsTo = 10;
            //avail.numberOfTripAdvisorReviewsHigherThan = 2;
            //avail.tripAdvisorScoreHigherThan = 2

            //avail.matchingKeywords = new HashSet<int>();
            //avail.matchingKeywords.Add(34);
            //avail.matchingKeywords.Add(81);
            //avail.keywordsMatcher = Availability.Matcher.ALL;

            avail.includeHotels = new List<int>();
            //avail.includeHotels.Add(111637);
            //avail.includeHotels.Add(2818);
            //avail.includeHotels.Add(138465);
            //avail.includeHotels.Add(164471);

            for (int i = 0; i < hotelsRs.Count; i++)
            {
                //avail.includeHotels = new List<int>();
                avail.includeHotels.Add(hotelsRs[i].code);
            }


            //avail.excludeHotels = new List<int>();
            //avail.excludeHotels.Add(187013);
            //avail.excludeHotels.Add(188330);

            //avail.useGiataCodes = false;
            //avail.limitHotelsTo = 250;
            //avail.limitRoomsPerHotelTo = 5;
            //avail.limitRatesPerRoomTo = 5;
            //avail.ratesHigherThan = 50;
            //avail.ratesLowerThan = 350;

            //avail.hbScoreHigherThan = 3;
            //avail.hbScoreLowerThan = 5;
            //avail.numberOfHBReviewsHigherThan = 50;

            //avail.tripAdvisorScoreHigherThan = 1;
            //avail.tripAdvisorScoreLowerThan = 4;
            //avail.numberOfHBReviewsHigherThan = 50;

            //avail.withinThis = new Availability.Circle() { latitude = 2.646633999999949, longitude = 39.57119, radiusInKilometers = 50 };
            //avail.withinThis = new Availability.Square() { northEastLatitude = 45.37680856570233, northEastLongitude = -2.021484375, southWestLatitude = 38.548165423046584, southWestLongitude = 8.658203125 };

            //avail.includeBoards = new List<string>();
            //avail.includeBoards.Add("R0-E10");
            //avail.includeBoards.Add("BB-E10");
            //avail.excludeBoards = new List<string>();
            //avail.excludeBoards.Add("RO");

            //avail.includeRoomCodes = new List<string>();
            //avail.includeRoomCodes.Add("DBL.ST");
            //avail.includeRoomCodes.Add("DBL.SU");
            ////avail.includeRoomCodes.AddRange(new string[]{ "DBL.ST", "DBL.SU" });
            //avail.excludeRoomCodes = new List<string>();
            //avail.excludeRoomCodes.Add("TPL.ST");

            var availabilityRQ = avail.toAvailabilityRQ();
            if (availabilityRQ == null)
                throw new Exception("Availability RQ can't be null", new ArgumentNullException());

            //Console.WriteLine("Availability Request:");
            //Console.WriteLine(JsonConvert.SerializeObject(availabilityRQ, Formatting.Indented, new JsonSerializerSettings() { DefaultValueHandling = DefaultValueHandling.Ignore }));

            //////Console.WriteLine(JsonConvert.SerializeObject(availabilityRQ, Formatting.Indented,
            //////    new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore }));
            var responseAvail = client.doAvailability(availabilityRQ);

            if (responseAvail != null && responseAvail.hotels != null && responseAvail.hotels.hotels != null && responseAvail.hotels.hotels.Count > 0)
            {
                var x = responseAvail.hotels.hotels;

            }

            HotelApiClient apiClient = new HotelApiClient();



            return responseAvail;



        }


        public AvailabilityRS AvailabilityRequestHotelDetails(HotelBooking hotelBooking, List<HotelRep> hotelsRs)
        {
            AvailabilityRS availabilityRs = new AvailabilityRS();
            Availability avail = new Availability();
            try
            {
                var client = new HotelApiClient();
                var status = client.status();

                //if (status != null && status.error == null)
                //    Console.WriteLine("StatusRS: " + status.status);
                //else if (status != null && status.error != null)
                //{
                //    Console.WriteLine("StatusRS: " + status.status + " " + status.error.code + ": " +
                //                      status.error.message);
                //    return;
                //}
                //else if (status == null)
                //{
                //    Console.WriteLine("StatusRS: Is not available.");
                //    return;
                //}

                List<Tuple<string, string>> param;



                //DateTime dtDepartureDate = DateTime.ParseExact(hotelBooking.DepartureDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                //DateTime dtReturnDate = DateTime.ParseExact(hotelBooking.ReturnDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);

                //avail.checkIn = DateTime.Now.AddDays(10);
                //avail.checkOut = DateTime.Now.AddDays(13);


                //string stringDate = hotelBooking.DepartureDate.Substring(0, hotelBooking.DepartureDate.IndexOf("Z"));
                //var a = stringDate + "GMT+0530";

                //var dt = DateTime.ParseExact(a, "ddd MMM dd yyyy HH:mm:ss 'GMT'zzz", System.Globalization.CultureInfo.InvariantCulture);

                //var stringReturnDate = hotelBooking.ReturnDate.Substring(0, hotelBooking.ReturnDate.IndexOf("Z"));
                //var aReturnDate = stringReturnDate + "GMT+0530";

                //var dtReturnDate = DateTime.ParseExact(aReturnDate, "ddd MMM dd yyyy HH:mm:ss 'GMT'zzz", System.Globalization.CultureInfo.InvariantCulture);





                DateTime varDepartureDate = DateTime.ParseExact(hotelBooking.DepartureDate, "dd/MM/yyyy", null);
                DateTime varReturnDate = DateTime.ParseExact(hotelBooking.ReturnDate, "dd/MM/yyyy", null);

                //string strDepartureDate = varDepartureDate.ToString("MM/dd/yyyy");
                //string strReturnDate = VarReturnDate.ToString("MM/dd/yyyy");

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Date converted" + varDepartureDate + "--" + varReturnDate);
                }

                avail.checkIn = varDepartureDate;
                avail.checkOut = varReturnDate;

                //avail.destination = hotelBooking.Destination; // "PMI";
                //avail.zone = 90;

                avail.language = "ENG";
                avail.shiftDays = 2;

                for (int i = 0; i < hotelBooking.Rooms; i++)
                {
                    AvailRoom room = new AvailRoom();

                    if (i == 0)
                    {
                        room.adults = hotelBooking.Adults1;

                        room.children = hotelBooking.Children1; /*hotelBooking.Children;*/

                        room.details = new List<RoomDetail>();

                        for (int count = 0; count < hotelBooking.Children1; count++)
                        {
                            if (count == 0)
                            { room.childOf(hotelBooking.C1Age1); }
                            if (count == 1)
                            { room.childOf(hotelBooking.C1Age2); }
                            if (count == 2)
                            { room.childOf(hotelBooking.C1Age3); }
                            if (count == 3)
                            { room.childOf(hotelBooking.C1Age4); }
                        }

                        for (int count = 0; count < hotelBooking.Adults1; count++)
                        {
                            room.adultOf(30);
                        }
                    }


                    if (i == 1)
                    {
                        room.adults = hotelBooking.Adults2;

                        room.children = hotelBooking.Children2; /*hotelBooking.Children;*/

                        room.details = new List<RoomDetail>();

                        for (int count = 0; count < hotelBooking.Children2; count++)
                        {
                            if (count == 0)
                            { room.childOf(hotelBooking.C2Age1); }
                            if (count == 1)
                            { room.childOf(hotelBooking.C2Age2); }
                            if (count == 2)
                            { room.childOf(hotelBooking.C2Age3); }
                            if (count == 3)
                            { room.childOf(hotelBooking.C2Age4); }
                        }

                        for (int count = 0; count < hotelBooking.Adults2; count++)
                        {
                            room.adultOf(30);
                        }
                    }

                    if (i == 3)
                    {
                        room.adults = hotelBooking.Adults3;

                        room.children = hotelBooking.Children3; /*hotelBooking.Children;*/

                        room.details = new List<RoomDetail>();

                        for (int count = 0; count < hotelBooking.Children3; count++)
                        {
                            if (count == 0)
                            { room.childOf(hotelBooking.C3Age1); }
                            if (count == 1)
                            { room.childOf(hotelBooking.C3Age2); }
                            if (count == 2)
                            { room.childOf(hotelBooking.C3Age3); }
                            if (count == 3)
                            { room.childOf(hotelBooking.C3Age4); }
                        }

                        for (int count = 0; count < hotelBooking.Adults3; count++)
                        {
                            room.adultOf(30);
                        }
                    }


                    //room.pax
                    //room.details = new List<RoomDetail>();



                    room.numberOfRooms = hotelBooking.Rooms; // 2;
                    avail.rooms.Add(room);

                }



                //room = new AvailRoom();
                //room.adults = 2;
                //room.children = 0;
                //room.details = new List<RoomDetail>();
                //room.adultOf(30);
                //room.adultOf(30);
                //room.numberOfRooms = 1;
                //avail.rooms.Add(room);
                avail.payed = Availability.Pay.AT_WEB;
                //avail.ofTypes = new HashSet<SimpleTypes.AccommodationType>();
                //avail.ofTypes.Add(SimpleTypes.AccommodationType.HOTEL);
                //avail.ofTypes.Add(SimpleTypes.AccommodationType.APARTMENT);

                //avail.minCategory = 4;
                //avail.limitHotelsTo = 10;
                //avail.numberOfTripAdvisorReviewsHigherThan = 2;
                //avail.tripAdvisorScoreHigherThan = 2

                //avail.matchingKeywords = new HashSet<int>();
                //avail.matchingKeywords.Add(34);
                //avail.matchingKeywords.Add(81);
                //avail.keywordsMatcher = Availability.Matcher.ALL;

                avail.includeHotels = new List<int>();
                //avail.includeHotels.Add(111637);
                //avail.includeHotels.Add(2818);
                //avail.includeHotels.Add(138465);
                //avail.includeHotels.Add(164471);

                for (int i = 0; i < hotelsRs.Count; i++)
                {
                    //avail.includeHotels = new List<int>();
                    avail.includeHotels.Add(hotelsRs[i].code);
                }


                //avail.excludeHotels = new List<int>();
                //avail.excludeHotels.Add(187013);
                //avail.excludeHotels.Add(188330);

                //avail.useGiataCodes = false;
                //avail.limitHotelsTo = 250;
                //avail.limitRoomsPerHotelTo = 5;
                //avail.limitRatesPerRoomTo = 5;
                //avail.ratesHigherThan = 50;
                //avail.ratesLowerThan = 350;

                //avail.hbScoreHigherThan = 3;
                //avail.hbScoreLowerThan = 5;
                //avail.numberOfHBReviewsHigherThan = 50;

                //avail.tripAdvisorScoreHigherThan = 1;
                //avail.tripAdvisorScoreLowerThan = 4;
                //avail.numberOfHBReviewsHigherThan = 50;

                //avail.withinThis = new Availability.Circle() { latitude = 2.646633999999949, longitude = 39.57119, radiusInKilometers = 50 };
                //avail.withinThis = new Availability.Square() { northEastLatitude = 45.37680856570233, northEastLongitude = -2.021484375, southWestLatitude = 38.548165423046584, southWestLongitude = 8.658203125 };

                //avail.includeBoards = new List<string>();
                //avail.includeBoards.Add("R0-E10");
                //avail.includeBoards.Add("BB-E10");
                //avail.excludeBoards = new List<string>();
                //avail.excludeBoards.Add("RO");

                //avail.includeRoomCodes = new List<string>();
                //avail.includeRoomCodes.Add("DBL.ST");
                //avail.includeRoomCodes.Add("DBL.SU");
                ////avail.includeRoomCodes.AddRange(new string[]{ "DBL.ST", "DBL.SU" });
                //avail.excludeRoomCodes = new List<string>();
                //avail.excludeRoomCodes.Add("TPL.ST");

                var availabilityRQ = avail.toAvailabilityRQ();
                if (availabilityRQ == null)
                    throw new Exception("Availability RQ can't be null", new ArgumentNullException());

                //Console.WriteLine("Availability Request:");
                //Console.WriteLine(JsonConvert.SerializeObject(availabilityRQ, Formatting.Indented, new JsonSerializerSettings() { DefaultValueHandling = DefaultValueHandling.Ignore }));

                //////Console.WriteLine(JsonConvert.SerializeObject(availabilityRQ, Formatting.Indented,
                //////    new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore }));
                var responseAvail = client.doAvailability(availabilityRQ);

                if (responseAvail != null && responseAvail.hotels != null && responseAvail.hotels.hotels != null &&
                    responseAvail.hotels.hotels.Count > 0)
                {
                    var x = responseAvail.hotels.hotels;
                }

                HotelApiClient apiClient = new HotelApiClient();



                return responseAvail;

            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace + "InnerException :" + ex.InnerException +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }
                return availabilityRs;
            }


        }


        public AvailabilityRS AvailabilityOfDestination(List<HotelRep> hotelRepList)
        {
            var client = new HotelApiClient();
            var status = client.status();

            //if (status != null && status.error == null)
            //    Console.WriteLine("StatusRS: " + status.status);
            //else if (status != null && status.error != null)
            //{
            //    Console.WriteLine("StatusRS: " + status.status + " " + status.error.code + ": " +
            //                      status.error.message);
            //    return;
            //}
            //else if (status == null)
            //{
            //    Console.WriteLine("StatusRS: Is not available.");
            //    return;
            //}

            //List<Tuple<string, string>> param;

            Availability avail = new Availability();
            //avail.checkIn = DateTime.Now.AddDays(10);
            //avail.checkOut = DateTime.Now.AddDays(13);



            avail.checkIn = DateTime.Now.AddDays(50);
            avail.checkOut = DateTime.Now.AddDays(51);


            //avail.destination = hotelBooking.Destination; // "PMI";
            //avail.zone = 90;


            avail.language = "ENG";
            avail.shiftDays = 2;

            for (int i = 0; i < 1; i++)
            {
                AvailRoom room = new AvailRoom();
                room.adults = 1;

                room.children = 0;/*hotelBooking.Children;*/

                room.details = new List<RoomDetail>();

                for (int count = 0; count < 0; count++)
                {
                    room.childOf(6);
                }


                //room.pax

                //room.details = new List<RoomDetail>();

                for (int count = 0; count < 1; count++)
                {
                    room.adultOf(30);
                }
                //room.adultOf(30);
                //room.adultOf(30);
                room.numberOfRooms = 1; // 2;
                avail.rooms.Add(room);

            }



            //room = new AvailRoom();
            //room.adults = 2;
            //room.children = 0;
            //room.details = new List<RoomDetail>();
            //room.adultOf(30);
            //room.adultOf(30);
            //room.numberOfRooms = 1;
            //avail.rooms.Add(room);
            //avail.payed = Availability.Pay.AT_WEB;
            //avail.ofTypes = new HashSet<hotel_api_model.auto.common.SimpleTypes.AccommodationType>();
            //avail.ofTypes.Add(hotel_api_model.auto.common.SimpleTypes.AccommodationType.HOTEL);
            //avail.ofTypes.Add(hotel_api_model.auto.common.SimpleTypes.AccommodationType.APARTMENT);

            //avail.minCategory = 4;
            avail.limitHotelsTo = 12;
            //avail.numberOfTripAdvisorReviewsHigherThan = 2;
            //avail.tripAdvisorScoreHigherThan = 2

            //avail.matchingKeywords = new HashSet<int>();
            //avail.matchingKeywords.Add(34);
            //avail.matchingKeywords.Add(81);
            //avail.keywordsMatcher = Availability.Matcher.ALL;

            avail.includeHotels = new List<int>();
            //avail.includeHotels.Add(111637);
            //avail.includeHotels.Add(2818);
            //avail.includeHotels.Add(138465);
            //avail.includeHotels.Add(164471);

            for (int i = 0; i < hotelRepList.Count; i++)
            {
                //avail.includeHotels = new List<int>();
                avail.includeHotels.Add(hotelRepList[i].code);
            }

            avail.packaging = true;

            //avail.excludeHotels = new List<int>();
            //avail.excludeHotels.Add(187013);
            //avail.excludeHotels.Add(188330);

            //avail.useGiataCodes = false;
            //avail.limitHotelsTo = 250;
            //avail.limitRoomsPerHotelTo = 5;
            //avail.limitRatesPerRoomTo = 5;
            //avail.ratesHigherThan = 50;
            //avail.ratesLowerThan = 350;

            //avail.hbScoreHigherThan = 3;
            //avail.hbScoreLowerThan = 5;
            //avail.numberOfHBReviewsHigherThan = 50;

            //avail.tripAdvisorScoreHigherThan = 1;
            //avail.tripAdvisorScoreLowerThan = 4;
            //avail.numberOfHBReviewsHigherThan = 50;

            //avail.withinThis = new Availability.Circle() { latitude = 2.646633999999949, longitude = 39.57119, radiusInKilometers = 50 };
            //avail.withinThis = new Availability.Square() { northEastLatitude = 45.37680856570233, northEastLongitude = -2.021484375, southWestLatitude = 38.548165423046584, southWestLongitude = 8.658203125 };

            //avail.includeBoards = new List<string>();
            //avail.includeBoards.Add("R0-E10");
            //avail.includeBoards.Add("BB-E10");
            //avail.excludeBoards = new List<string>();
            //avail.excludeBoards.Add("RO");

            //avail.includeRoomCodes = new List<string>();
            //avail.includeRoomCodes.Add("DBL.ST");
            //avail.includeRoomCodes.Add("DBL.SU");
            ////avail.includeRoomCodes.AddRange(new string[]{ "DBL.ST", "DBL.SU" });
            //avail.excludeRoomCodes = new List<string>();
            //avail.excludeRoomCodes.Add("TPL.ST");


            var availabilityRQ = avail.toAvailabilityRQ();
            if (availabilityRQ == null)
                throw new Exception("Availability RQ can't be null", new ArgumentNullException());

            //Console.WriteLine("Availability Request:");
            //Console.WriteLine(JsonConvert.SerializeObject(availabilityRQ, Formatting.Indented, new JsonSerializerSettings() { DefaultValueHandling = DefaultValueHandling.Ignore }));

            //////Console.WriteLine(JsonConvert.SerializeObject(availabilityRQ, Formatting.Indented,
            //////    new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore }));
            var responseAvail = client.doAvailability(availabilityRQ);

            //if (responseAvail != null && responseAvail.hotels != null && responseAvail.hotels.hotels != null && responseAvail.hotels.hotels.Count > 0)
            //{
            //    var x = responseAvail.hotels.hotels;

            //}

            HotelApiClient apiClient = new HotelApiClient();



            return responseAvail;



        }


        public HotelRsRep GetHotelDestinationLocal(string DesCode)
        {
            HotelRepositoryService hotelRepositoryService = new HotelRepositoryService();

            HotelRsRep hotelRsRep = new HotelRsRep();

            hotelRsRep = hotelRepositoryService.getHotelDetails(DesCode);

            return hotelRsRep;

        }


        public CheckRateRS CheckRates(string rateKey, string Rooms, string Adults1, string Children1, string C1Age1, string C1Age2, string C1Age3, string C1Age4, string Adults2, string Children2, string C2Age1, string C2Age2, string C2Age3, string C2Age4, string Adults3, string Children3, string C3Age1, string C3Age2, string C3Age3, string C3Age4)
        {
            var client = new HotelApiClient();
            var status = client.status();

            CheckRateRS checkRateRs = new CheckRateRS();

            HotelApiClient apiClient = new HotelApiClient();
            var confirmRoom = new ConfirmRoom();
            confirmRoom.details = new List<RoomDetail>();

            for (int count = 1; count <= int.Parse(Rooms); count++)
            {
                if (count == 1)
                {
                    for (int countAd = 1; countAd < int.Parse(Adults1)+1; countAd++)
                    {

                        confirmRoom.detailed(RoomDetail.GuestType.ADULT, 30, "NombrePasajer"+ countAd.ToString(), "ApellidoPasajer"+ countAd.ToString(),
                            count);
                    }
                    for (int countCh = 1; countCh < int.Parse(Children1)+1; countCh++)
                    {

                        confirmRoom.detailed(RoomDetail.GuestType.CHILD, 10, "NochilPasajer"+ countCh.ToString(), "child" + countCh.ToString(),
                            count);
                    }
                }
                if (count == 2)
                {
                    for (int countAd = 1; countAd < int.Parse(Adults2)+1; countAd++)
                    {

                        confirmRoom.detailed(RoomDetail.GuestType.ADULT, 30, "NombrePasajer" + countAd.ToString(), "ApellidoPasajer" + countAd.ToString(),
                            count);
                    }
                    for (int countCh = 1; countCh < int.Parse(Children2)+1; countCh++)
                    {

                        confirmRoom.detailed(RoomDetail.GuestType.CHILD, 10, "NochilPasajer" + countCh.ToString(), "child" + countCh.ToString(),
                            count);
                    }
                }
                if (count == 3)
                {
                    for (int countAd = 1; count < int.Parse(Adults3)+1; countAd++)
                    {

                        confirmRoom.detailed(RoomDetail.GuestType.ADULT, 30, "NombrePasajer" + countAd.ToString(), "ApellidoPasajer" + countAd.ToString(),
                            count);
                    }
                    for (int countCh = 1; count < int.Parse(Children3)+1; countCh++)
                    {

                        confirmRoom.detailed(RoomDetail.GuestType.CHILD, 10, "NochilPasajer" + countCh.ToString(), "child" + countCh.ToString(),
                            count);
                    }
                }
                 

            } 

            var bookingCheck = new BookingCheck();
            bookingCheck.addRoom(rateKey, confirmRoom);
            var checkRateRQ = bookingCheck.toCheckRateRQ();

            if (checkRateRQ != null)
            {
                checkRateRs = client.doCheck(checkRateRQ);

            }

            return checkRateRs;

        }



        public BookingRS BookingCconfirmation(HotelBookingConfirmation hotelBookingConfirmation)
        {

            var bookingRq = new BookingRQ();
            BookingRS responseBooking = new BookingRS();
            try
            {
                string DocNo = "";
                string GetNewCode = "";


                using (var db = new HBNEWEntities())
                {
                    HotelRepositoryService hotelRepositoryService = new HotelRepositoryService();
                    DocumentRep documentRep = new DocumentRep();
                    documentRep = hotelRepositoryService.GetDocumentNoByForm("BookingConferm");

                    GetNewCode = "B" + new StringBuilder().Insert(0, "0", (6 - (1 + DocNo.Length))) +
                                 documentRep.DocumentNo;
                }




                var client = new HotelApiClient();
                var status = client.status();



                ConfirmRoom confirmRoom = new ConfirmRoom();
                confirmRoom.details = new List<RoomDetail>();


                int rooms = Convert.ToInt32(hotelBookingConfirmation.Rooms);

                for (int i = 0; i < rooms; i++)
                {
                    if (i == 0)
                    {
                        confirmRoom.detailed(RoomDetail.GuestType.ADULT, 30, hotelBookingConfirmation.Adults1name, hotelBookingConfirmation.Adults1surname, 1);

                    }
                    if (i == 1)
                    {

                        confirmRoom.detailed(RoomDetail.GuestType.ADULT, 30, hotelBookingConfirmation.Adults2name, hotelBookingConfirmation.Adults2surname, 2);
                    }
                    if (i == 2)
                    {

                        confirmRoom.detailed(RoomDetail.GuestType.ADULT, 30, hotelBookingConfirmation.Adults3name, hotelBookingConfirmation.Adults3surname, 3);
                    }
                }


                BookingCheck bookingCheck = new BookingCheck();
                bookingCheck.addRoom(hotelBookingConfirmation.rateKey1, confirmRoom);
                CheckRateRQ checkRateRQ = bookingCheck.toCheckRateRQ();


                if (checkRateRQ != null)
                {
                    CheckRateRS responseRate = client.doCheck(checkRateRQ);
                    if (responseRate != null && responseRate.error == null)
                    {
                        HB.ApiSDK.helpers.Booking booking = new HB.ApiSDK.helpers.Booking();
                        booking.createHolder(hotelBookingConfirmation.Adults1name, hotelBookingConfirmation.Adults1surname);
                        booking.clientReference = GetNewCode; // hotelBookingConfirmation.ClientReference; //Your internal booking reference
                        booking.remark = "Comments";







                        booking.addRoom(hotelBookingConfirmation.rateKey1, confirmRoom);
                        BookingRQ bookingRQ = booking.toBookingRQ();

                        //bookingRQ.language = "CAS";

                        if (bookingRQ != null)
                        {
                            responseBooking = client.confirm(bookingRQ);

                            if (responseBooking != null && responseBooking.error == null &&
                                responseBooking.booking != null)
                            {


                            }
                        }

                    }
                }

                return responseBooking;


            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace + "InnerException :" + ex.InnerException +
                       "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                }
                return responseBooking;
            }


        }

        public BookingListRS getBookingList(HotelBookingList hotelBookingList)
        {
            BookingRQ bookingRq = new BookingRQ();
            List<Tuple<string, string>> param;
            HotelApiClient hotelApiClient = new HotelApiClient();
            BookingListRS bookingListRs = new BookingListRS();

            //  try {
            /*  param = new List<Tuple<string, string>>
              {
                  new Tuple<string, string>("${start}", DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd")),
                  new Tuple<string, string>("${end}", DateTime.Now.ToString("yyyy-MM-dd")),
                  new Tuple<string, string>("${status}", "ALL"),
                 // new Tuple<string, string>("${includeCancelled}", "true"),
                  new Tuple<string, string>("${filterType}", "CREATION"),
                  new Tuple<string, string>("${from}", "1"),
                  new Tuple<string, string>("${to}", "25"),
                  new Tuple<string, string>("${clientReference}", "25"),
                  new Tuple<string, string>("${country}", "25"),
                  new Tuple<string, string>("${destination}", "25"),
                  new Tuple<string, string>("${hotel}", "25"),

              };
              */


            param = new List<Tuple<string, string>>
                {
                    new Tuple<string, string>("${start}", hotelBookingList.start.ToString("yyyy-MM-dd")),
                    new Tuple<string, string>("${end}", hotelBookingList.end.ToString("yyyy-MM-dd")),

                   // new Tuple<string, string>("${start}", DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd")),
                   // new Tuple<string, string>("${end}", DateTime.Now.ToString("yyyy-MM-dd")),

                   // new Tuple<string, string>("${status}", hotelBookingList.status),
                    new Tuple<string, string>("${includeCancelled}", "true"),
                    new Tuple<string, string>("${filterType}", hotelBookingList.filterType),
                    new Tuple<string, string>("${from}", hotelBookingList.from.ToString()),
                    new Tuple<string, string>("${to}", hotelBookingList.to.ToString()),

                    new Tuple<string, string>("${clientReference}",hotelBookingList.clientReference),
                    new Tuple<string, string>("${country}", hotelBookingList.country),
                    new Tuple<string, string>("${destination}", hotelBookingList.destination),
                    new Tuple<string, string>("${hotel}", hotelBookingList.hotel),

                };

            BookingListRS bookingListRS = hotelApiClient.List(param);

            //if (bookingListRS != null)
            //{
            //    //Console.WriteLine(JsonConvert.SerializeObject(bookingListRS, Formatting.Indented, new JsonSerializerSettings() { DefaultValueHandling = DefaultValueHandling.Ignore }));
            //    foreach (HB.ApiModel.auto.model.Booking booking in bookingListRS.bookings.bookings)
            //    {
            //        param = new List<Tuple<string, string>>
            //            {
            //                new Tuple<string, string>("${bookingId}", booking.reference)
            //            };
            //        BookingDetailRS bookingDetailRS = hotelApiClient.Detail(param);
            //        if (bookingDetailRS != null)
            //        {




            //           // Console.WriteLine(JsonConvert.SerializeObject(bookingDetailRS, Formatting.Indented, new JsonSerializerSettings() { DefaultValueHandling = DefaultValueHandling.Ignore }));
            //        }
            //    }
            //}


            return bookingListRS;
            // }
            //  catch (Exception e)
            //  {

            //  Console.WriteLine("Error: " + e.Message + " " + e.StackTrace);
            //   Console.WriteLine("InnerException: " + e.InnerException);

            //    }www

        }

        public HotelBookingDetails getBookingDetailList(string reference)
        {

            List<Tuple<string, string>> param;
            HotelApiClient hotelApiClient = new HotelApiClient();
            BookingDetailRS bookingDetailRs = new BookingDetailRS();

            HotelBookingDetails hotelBookingList = new HotelBookingDetails();

            param = new List<Tuple<string, string>>
                {
                     new Tuple<string, string>("${bookingId}", reference),

                };

            BookingDetailRS bookingDetailRS = hotelApiClient.Detail(param);

            if (bookingDetailRS != null)
            {
                hotelBookingList = new HotelBookingDetails();
                hotelBookingList.clientReference = bookingDetailRS.booking.clientReference;
                hotelBookingList.cancellationClientReference = bookingDetailRS.booking.cancellationReference;
                hotelBookingList.creationDate = bookingDetailRS.booking.creationDate;
                hotelBookingList.reference = bookingDetailRS.booking.reference;
                hotelBookingList.code = bookingDetailRS.booking.hotel.code;
                hotelBookingList.name = bookingDetailRS.booking.hotel.name;
                hotelBookingList.categoryCode = bookingDetailRS.booking.hotel.categoryCode;
                hotelBookingList.categoryName = bookingDetailRS.booking.hotel.categoryName;
                hotelBookingList.destinationCode = bookingDetailRS.booking.hotel.destinationCode;
                hotelBookingList.destinationName = bookingDetailRS.booking.hotel.destinationName;
                hotelBookingList.hotelName = bookingDetailRS.booking.hotel.name;

                decimal rates = ConvertRate(bookingDetailRS.booking.hotel.currency, "LKR");
                // decimal rate = ConvertRate(bookingDetailRS.booking.hotel.totalNet.ToString(), "LKR");
                hotelBookingList.totalNet = bookingDetailRS.booking.hotel.totalNet * rates;


            }


            return hotelBookingList;
            // }
            //  catch (Exception e)
            //  {

            //  Console.WriteLine("Error: " + e.Message + " " + e.StackTrace);
            //   Console.WriteLine("InnerException: " + e.InnerException);

            //    }www

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
                    writer.WriteLine("Currency Error--" + ex.Message);
                }
                HotelRepositoryService currency = new HotelRepositoryService();
                return currency.GetCurrencyRate();
            }
        }

        public string BookingCancellation(string reference)
        {

            HotelApiClient client = new HotelApiClient();
            List<Tuple<string, string>> param;
            BookingRS responseBooking = new BookingRS();
            //responseBooking.booking.reference = reference;
            try
            {

                param = new List<Tuple<string, string>>
                {
                    new Tuple<string, string>("${bookingId}", reference),
                    new Tuple<string, string>("${flag}", "CANCELLATION")
                };


                BookingCancellationRS bookingCancellationRS = client.Cancel(param);

                if (bookingCancellationRS != null)
                {
                    //Console.WriteLine("Id cancelled: " + responseBooking.booking.reference);
                    //Console.WriteLine(JsonConvert.SerializeObject(bookingCancellationRS, Formatting.Indented, new JsonSerializerSettings() { DefaultValueHandling = DefaultValueHandling.Ignore }));
                    //Console.ReadLine();

                    //Console.WriteLine("Getting detail after cancelation of id " + responseBooking.booking.reference);
                    if (bookingCancellationRS.error == null)
                    {
                        param = new List<Tuple<string, string>>
                        {
                            new Tuple<string, string>("${bookingId}",reference)
                        };
                        BookingDetailRS bookingDetailRS = client.Detail(param);
                        if (bookingDetailRS != null)
                        {
                            //  Console.WriteLine(JsonConvert.SerializeObject(bookingDetailRS, Formatting.Indented, new JsonSerializerSettings() { DefaultValueHandling = DefaultValueHandling.Ignore }));
                            return reference;
                        }

                    }

                    else
                    {
                        var error = bookingCancellationRS.error.message;
                        return error;


                    }

                }
                return reference;
            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" +
                                     ex.StackTrace + "InnerException :" + ex.InnerException +
                                     "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                    writer.WriteLine(Environment.NewLine +
                                     "-----------------------------------------------------------------------------" +
                                     Environment.NewLine);
                }
                return reference;
            }
        }

    }



}