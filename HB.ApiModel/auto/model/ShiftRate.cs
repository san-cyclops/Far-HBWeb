﻿using System;

namespace HB.ApiModel.auto.model
{
    public class ShiftRate : BasicRate
    {
        public DateTime checkIn { get; set; }
        public DateTime checkOut { get; set; }
    }
}