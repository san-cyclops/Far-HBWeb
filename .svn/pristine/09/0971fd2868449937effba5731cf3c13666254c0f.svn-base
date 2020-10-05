using HB.ApiModel.auto.common;
using HB.ApiModel.util;
using Newtonsoft.Json;

namespace HB.ApiModel.auto.model
{
    public class Source
    {
        [JsonProperty("channel", Required = Required.Always)]
        [JsonConverter(typeof (JSonConverters.ChannelTypeConverter))]
        public SimpleTypes.ChannelType? channel { get; set; }

        [JsonProperty("device", Required = Required.Always)]
        [JsonConverter(typeof (JSonConverters.DeviceTypeConverter))]
        public SimpleTypes.DeviceType? device { get; set; }

        public string deviceInfo { get; set; }
    }
}