using HB.ApiModel.auto.common;
using HB.ApiModel.util;
using Newtonsoft.Json;

namespace HB.ApiModel.auto.model
{
    public class CreditCard
    {
        public string code { get; set; }
        public string name { get; set; }

        [JsonProperty("paymentType", Required = Required.Always)]
        [JsonConverter(typeof (JSonConverters.PaymentTypeConverter))]
        public SimpleTypes.PaymentType paymentType { get; set; }
    }
}