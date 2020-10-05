using System.Collections.Generic;
using HB.ApiModel.auto.model;

namespace HB.ApiModel.auto.messages
{
    public class AvailabilityRS : AbstractGenericResponse
    {
        public Hotels hotels;
        public Source source;
        public List<string> providerDetails { get; set; }
    }
}