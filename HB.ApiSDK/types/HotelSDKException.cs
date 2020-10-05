using System;
using HB.ApiModel.auto.messages;

namespace HB.ApiSDK.types
{
    internal class HotelSDKException : Exception
    {
        public const long serialVersionUID = 1L;
        private readonly HotelbedsError error;

        private HotelSDKException(HotelbedsError error)
        {
            this.error = error;
        }

        private HotelSDKException(HotelbedsError error, string message, Exception innerEx) : base(message, innerEx)
        {
            this.error = error;
        }
    }
}