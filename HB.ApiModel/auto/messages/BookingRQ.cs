﻿using System;
using System.Collections.Generic;
using HB.ApiModel.auto.model;

namespace HB.ApiModel.auto.messages
{
    public class BookingRQ : AbstractGenericRequest
    {
        public BookingRQ()
        {
            rooms = new List<BookingRoom>();
        }

        public Holder holder { get; set; }
        public List<BookingRoom> rooms { get; set; }
        public PaymentData paymentData { get; set; }
        public string clientReference { get; set; }
        public string remark { get; set; }

        public void Validate()
        {
            if (holder == null || string.IsNullOrEmpty(holder.name) || string.IsNullOrEmpty(holder.surname))
                throw new ArgumentException("Holder object can't be null");

            if (rooms == null || rooms.Count == 0)
                throw new ArgumentException("Rooms list can't be null");

            for (var r = 0; r < rooms.Count; r++)
            {
                if (string.IsNullOrEmpty(rooms[r].rateKey))
                    throw new ArgumentException("RateKey Room can't be null");

                if (rooms[r].paxes == null || rooms[r].paxes.Count == 0)
                    throw new ArgumentException("Paxes list can't be null");

                for (var p = 0; p < rooms[r].paxes.Count; p++)
                {
                    if (rooms[r].paxes[p].type == null)
                        throw new ArgumentException("Paxes Type can't be null");

                    if (string.IsNullOrEmpty(rooms[r].paxes[p].name))
                        throw new ArgumentException("Paxes name can't be null");

                    if (string.IsNullOrEmpty(rooms[r].paxes[p].surname))
                        throw new ArgumentException("Paxes surname can't be null");

                    if (!rooms[r].paxes[p].age.HasValue)
                        throw new ArgumentException("Paxes age can't be null");

                    if (!rooms[r].paxes[p].roomId.HasValue)
                        throw new ArgumentException("RoomId can't be null");
                }
            }

            if (string.IsNullOrEmpty(clientReference))
                throw new ArgumentException("Client Reference can't be null");

            if (paymentData != null)
            {
                if (paymentData.paymentCard == null)
                    throw new ArgumentException("PaymentCard can't be null");

                if (string.IsNullOrEmpty(paymentData.paymentCard.cardType))
                    throw new ArgumentException("CardType can't be null");

                if (string.IsNullOrEmpty(paymentData.paymentCard.cardNumber))
                    throw new ArgumentException("CardNumber can't be null");

                if (string.IsNullOrEmpty(paymentData.paymentCard.expiryDate))
                    throw new ArgumentException("ExpiryDate can't be null");

                if (string.IsNullOrEmpty(paymentData.paymentCard.cardCVC))
                    throw new ArgumentException("CardCVC can't be null");

                if (paymentData.contactData == null)
                    throw new ArgumentException("ContactData can't be null");

                if (string.IsNullOrEmpty(paymentData.contactData.email))
                    throw new ArgumentException("Email can't be null or empty");

                if (string.IsNullOrEmpty(paymentData.contactData.phoneNumber))
                    throw new ArgumentException("PhoneNumber can't be null or empty");
            }
        }
    }
}