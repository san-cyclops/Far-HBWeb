using System.Collections.Generic;
using HB.ApiModel.auto.model;

namespace HB.ApiModel.auto.messages
{
    public class CheckRateRS : AbstractGenericResponse
    {
        public List<string> providerDetails { get; set; }
        public Hotel hotel { get; set; }
        public Source source { get; set; }
    }
}