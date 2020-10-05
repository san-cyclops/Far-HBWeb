using System.Collections.Generic;
using HB.ApiModel.util;
using Newtonsoft.Json;

namespace HB.ApiModel.auto.model
{
    public class Rooms
    {
        public List<string> room { get; set; }

        [JsonProperty("included", Required = Required.Always)]
        [JsonConverter(typeof (JSonConverters.BooleanConverter))]
        public bool? included { get; set; }
    }
}