﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HB.HotelRez.Models
{
    /// <summary>
    /// edited by Anu
    /// </summary>
    public class HotelRezData
    {
      public string HotelName { get; set; }

      public string Address { get; set; }

      public string RoomId { get; set; }

       public string Refference { get; set; }

       public  string BoardType { get; set; }

       public string Aminities { get; set; }

       public  string NearbyName { get; set; }

       public string NearbyDistance { get; set; }

       public string Price { get; set; }

       public string RoomType { get; set; }

        public string AminityType { get; set; }

        // public  AminityData Aminitylist { get; set; }
        public List<Aminities> Aminitylist { get; set; }

       public List<NearByPlacesData> NearByPlaces { get; set; }
    }
}