using System.Collections.Generic;
using HB.ApiModel.auto.common;
using HB.ApiModel.auto.messages;
using HB.ApiModel.auto.model;

namespace HB.ApiSDK.helpers
{
    public class Booking
    {
        private List<ConfirmRoom> rooms;
        public Holder holder { get; set; }
        public string clientReference { get; set; }
        public string remark { get; set; }
        public string cardType { get; set; }
        public string cardNumber { get; set; }
        public string cardHolderName { get; set; }
        public string expiryDate { get; set; }
        public string cardCVC { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }

        public BookingRQ toBookingRQ()
        {
            var bookingRQ = new BookingRQ();
            bookingRQ.holder = holder;
            bookingRQ.clientReference = clientReference;
            bookingRQ.remark = remark;
            if (!string.IsNullOrEmpty(cardType) && !string.IsNullOrEmpty(cardNumber) &&
                !string.IsNullOrEmpty(cardHolderName) && !string.IsNullOrEmpty(expiryDate) && cardCVC != null ||
                !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(phoneNumber))
            {
                var paymentData = new PaymentData();
                if (!string.IsNullOrEmpty(cardType) && !string.IsNullOrEmpty(cardNumber) &&
                    !string.IsNullOrEmpty(cardHolderName) && !string.IsNullOrEmpty(expiryDate) &&
                    !string.IsNullOrEmpty(cardCVC))
                    paymentData.paymentCard = new PaymentCard
                    {
                        cardType = cardType,
                        cardNumber = cardNumber,
                        cardHolderName = cardHolderName,
                        expiryDate = expiryDate,
                        cardCVC = cardCVC
                    };

                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(phoneNumber))
                    paymentData.contactData = new PaymentContactData {email = email, phoneNumber = phoneNumber};

                bookingRQ.paymentData = paymentData;
            }

            for (var i = 0; i < rooms.Count; i++)
            {
                var room = new BookingRoom();
                room.rateKey = rooms[i].rateKey;
                room.paxes = new List<Pax>();
                for (var p = 0; p < rooms[i].details.Count; p++)
                {
                    var pax = new Pax();
                    pax.type = rooms[i].details[p].getType() == RoomDetail.GuestType.ADULT
                        ? SimpleTypes.HotelbedsCustomerType.AD
                        : SimpleTypes.HotelbedsCustomerType.CH;
                    pax.age = rooms[i].details[p].getAge();
                    pax.name = rooms[i].details[p].getName();
                    pax.surname = rooms[i].details[p].getSurname();
                    pax.roomId = rooms[i].details[p].getRoomId();
                    room.paxes.Add(pax);
                }
                bookingRQ.rooms.Add(room);
            }

            bookingRQ.Validate();

            return bookingRQ;
        }

        public void createHolder(string name, string surname)
        {
            holder = new Holder {name = name, surname = surname};
        }

        public void addRoom(string rateKey, ConfirmRoom room)
        {
            if (rooms == null)
                rooms = new List<ConfirmRoom>();

            room.rateKey = rateKey;
            rooms.Add(room);
        }
    }
}