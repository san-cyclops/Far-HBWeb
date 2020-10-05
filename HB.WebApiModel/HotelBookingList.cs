using System;

namespace HB.WebApiModel
{
    public class HotelBookingList
    {
        public DateTime start { get; set; }

        public DateTime end { get; set; }

        public string status { get; set; }

        public string filterType { get; set; }

        public int from { get; set; }

        public int to { get; set; }

        public string clientReference { get; set; }

        public string country { get; set; }

        public string destination { get; set; }

        public string hotel { get; set; }

    }
}