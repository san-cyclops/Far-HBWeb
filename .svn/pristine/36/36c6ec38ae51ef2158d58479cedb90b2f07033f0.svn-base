using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HB.ApiModel.auto.common
{
    public class SimpleTypes
    {
        public enum AccommodationType
        {
            HOTEL,
            APARTMENT,
            RURAL,
            HOSTEL,
            APTHOTEL,
            CAMPING,
            HISTORIC,
            PENDING,
            RESORT,
            HOMES
        }

        [JsonConverter(typeof (StringEnumConverter))]
        public enum BookingStatus
        {
            CONFIRMED,
            CANCELLED
        }

        public enum ChannelType
        {
            B2B,
            B2C,
            META,
            NEWSLETTER
        }

        public enum DeviceType
        {
            MOBILE,
            WEB,
            TABLET
        }

        [JsonConverter(typeof (StringEnumConverter))]
        public enum HotelbedsCustomerType
        {
            [EnumMember(Value = "AD")] AD,
            [EnumMember(Value = "CH")] CH
        }

        public enum HotelCodeType
        {
            HOTELBEDS,
            GIATA
        }


        public enum HotelPackage
        {
            YES,
            NO,
            BOTH
        }

        public enum PaymentType
        {
            AT_HOTEL,
            AT_WEB
        }

        public enum RateType
        {
            BOOKABLE,
            RECHECK
        }

        public enum ReviewsType
        {
            TRIPDAVISOR,
            HOTELBEDS
        }


        [JsonConverter(typeof (StringEnumConverter))]
        public enum ShowDirectPaymentType
        {
            [EnumMember(Value = "S")] AT_HOTEL,
            [EnumMember(Value = "N")] AT_WEB,
            [EnumMember(Value = "A")] BOTH
        }

        public enum TaxType
        {
            TAX,
            FEE
        }
    }
}