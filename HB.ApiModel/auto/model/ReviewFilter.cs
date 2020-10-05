using HB.ApiModel.auto.common;
using HB.ApiModel.util;
using Newtonsoft.Json;

namespace HB.ApiModel.auto.model
{
    public class ReviewFilter
    {
        [JsonProperty("type", Required = Required.Always)]
        [JsonConverter(typeof (JSonConverters.AccommodationTypeConverter))]
        public SimpleTypes.ReviewsType? type { get; set; }

        public decimal minRate { get; set; }
        public decimal maxRate { get; set; }
        public int minReviewCount { get; set; }
    }
}