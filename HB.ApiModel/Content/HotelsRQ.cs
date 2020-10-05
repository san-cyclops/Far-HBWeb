using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.ApiModel.Content
{
    public class HotelsRQ : AbstractGenericContentResponse
    {

        public String destinationCode;

        public String countryCode;

        public string language;

        public List<String> chainCodes;

        public List<String> boardCodes;

        public List<int> segmentCodes;

        public List<String> languageDescriptions;

        public long minTripadvisorRate;

        public long maxTripadvisorRate;

        public int minTripadvisorReviewCount;

        public List<String> accomodationTypes;

        public List<String> imageTypes;

        public List<String> categoryCodes;

        public List<String> categoryGroupCodes;

        public List<String> sureToCare;

        public int minImages;

        public Boolean allIncluded;

        public DateTime creationTime;

        public List<String> rooms;

        public int roomCapacity;

        public int maxPax;

        public int minPax;

        public int maxAdults;

        public int minAdults;

        public int maxChildren;

        public LiberateType liberate;
    }
}
