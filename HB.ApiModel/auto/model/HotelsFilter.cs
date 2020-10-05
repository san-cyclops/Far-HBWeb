using System.Collections.Generic;
using HB.ApiModel.auto.common;
using HB.ApiModel.util;
using Newtonsoft.Json;

namespace HB.ApiModel.auto.model
{
    public class HotelsFilter
    {
        public List<int> hotel { get; set; }

        [JsonProperty("included", Required = Required.Always)]
        [JsonConverter(typeof (JSonConverters.BooleanConverter))]
        public bool included { get; set; }

        [JsonProperty("type", Required = Required.Always)]
        [JsonConverter(typeof (JSonConverters.HotelCodeTypeConverter))]
        public SimpleTypes.HotelCodeType? type { get; set; }
    }
}