﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace WebUI.Models
{
    public class BookingList
    {
        public char Destination { get; set; }
        public string HotelName { get; set; }
        public string Country { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int NumberofRooms { get; set; }
        public string Adults { get; set; }
        public string Childrens { get; set; }
        public string HolderName { get; set; }
        public string HolderCountry { get; set; }

    }
}