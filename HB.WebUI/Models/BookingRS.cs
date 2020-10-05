﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HB.ApiModel.auto.messages;
using HB.ApiModel.auto.model;

namespace WebUI.Models
{
    public class BookingRS : AbstractGenericResponse
    {
        public List<string> providerDetails { get; set; }
        public Booking booking { get; set; }
        public Source source { get; set; }
        public string GuestNames { get; set; }
        public string ChildNames { get; set; }

        public HotelPayment HotelPaymentDetails { get; set; }
    }
}