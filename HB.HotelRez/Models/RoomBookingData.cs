﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HB.HotelRez.Models
{
    public class RoomBookingData
    {
        public string RoomID { get; set; }

        public string BookingNo { get; set; }
        public string DateFrom { get; set; }

        public string DateTo { get; set; }

        public string Adult1FirastName { get; set; }

        public string Adult1LastName { get; set; }

        public string Adult1Telephone { get; set; }

        public string Adult1Email { get; set; }

        public string Adult1NICNo { get; set; }

        public string Adult1Address { get; set; }

        public string Adult2FirastName { get; set; }

        public string Adult2LastName { get; set; }

        public string Adult2Telephone { get; set; }

        public string Adult2Email { get; set; }

        public string Adult2NICNo { get; set; }

        public string Adult2Address { get; set; }

        public string Adult3FirastName { get; set; }

        public string Adult3LastName { get; set; }

        public string Adult3Telephone { get; set; }

        public string Adult3Email { get; set; }

        public string Adult3NICNo { get; set; }

        public string Adult3Address { get; set; }

        public string Adult4FirastName { get; set; }

        public string Adult4LastName { get; set; }

        public string Adult4Telephone { get; set; }

        public string Adult4Email { get; set; }

        public string Adult4NICNo { get; set; }

        public string Adult4Address { get; set; }

        public string Child1Name { get; set; }

        public string Child1Age { get; set; }

        public string Child2Name { get; set; }

        public string Child2Age { get; set; }

        public string Child3Name { get; set; }

        public string Child3Age { get; set; }

        public string Child4Age { get; set; }

        public string Child4Name { get; set; }
        public bool IsActive { get; set; }
    }
}