using System.Collections.Generic;
using HB.ApiModel.auto.common;
using HB.ApiModel.auto.messages;
using HB.ApiModel.auto.model;
using HB.ApiSDK.types;

namespace HB.ApiSDK.helpers
{
    public class BookingCheck
    {
        public List<ConfirmRoom> rooms;

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public CheckRateRQ toCheckRateRQ()
        {
            try
            {
                var checkRateRQ = new CheckRateRQ();
                checkRateRQ.rooms = new List<BookingRoom>();

                for (var i = 0; i < rooms.Count; i++)
                {
                    var bookingRoom = new BookingRoom();
                    bookingRoom.rateKey = rooms[i].rateKey;
                    bookingRoom.paxes = new List<Pax>();
                    var paxes = new Pax[rooms[i].details.Count];
                    for (var d = 0; d < rooms[i].details.Count; d++)
                    {
                        var pax = new Pax();
                        pax.type = rooms[i].details[d].getType() == RoomDetail.GuestType.ADULT
                            ? SimpleTypes.HotelbedsCustomerType.AD
                            : SimpleTypes.HotelbedsCustomerType.CH;
                        pax.age = rooms[i].details[d].getAge();
                        pax.name = rooms[i].details[d].getName();
                        pax.surname = rooms[i].details[d].getSurname();
                        paxes[d] = pax;
                    }
                    bookingRoom.paxes.AddRange(paxes);
                    checkRateRQ.rooms.Add(bookingRoom);
                }

                checkRateRQ.Validate();

                return checkRateRQ;
            }
            catch (HotelSDKException e)
            {
                throw e;
            }
        }

        public void addRoom(string rateKey, ConfirmRoom confirmRoom)
        {
            if (rooms == null)
                rooms = new List<ConfirmRoom>();

            confirmRoom.rateKey = rateKey;
            rooms.Add(confirmRoom);
        }
    }
}