using System;
using System.Collections.Generic;
using HB.ApiModel.auto.model;

namespace HB.ApiModel.auto.messages
{
    public class CheckRateRQ : AbstractGenericRequest
    {
        public bool upselling { get; set; }
        public List<BookingRoom> rooms { get; set; }

        public void Validate()
        {
            if (rooms == null)
                throw new ArgumentException("Rooms list can't be null");

            for (var r = 0; r < rooms.Count; r++)
            {
                if (string.IsNullOrEmpty(rooms[r].rateKey))
                    throw new ArgumentException("RateKey Room can't be null or empty");
            }
        }
    }
}