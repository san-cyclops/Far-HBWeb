using System;

namespace WebUI.Models
{
    public class HotelBooking
    {
        public long HotelCode { get; set; }
        public string Des { get; set; }
        public string DepartureDate { get; set; }
        public string ReturnDate { get; set; }
        public int Rooms { get; set; }
        public int Adults1 { get; set; }
        public int Children1 { get; set; }
        public int C1Age1 { get; set; }
        public int C1Age2 { get; set; }
        public int C1Age3 { get; set; }
        public int C1Age4 { get; set; }
        public int Adults2 { get; set; }
        public int Children2 { get; set; }
        public int C2Age1 { get; set; }
        public int C2Age2 { get; set; }
        public int C2Age3 { get; set; }
        public int C2Age4 { get; set; }
        public int Adults3 { get; set; }
        public int Children3 { get; set; }
        public int C3Age1 { get; set; }
        public int C3Age2 { get; set; }
        public int C3Age3 { get; set; }
        public int C3Age4 { get; set; }
        public string visitorsCurrency { get; set; }
        public int Markup { get; set; }

    }
}