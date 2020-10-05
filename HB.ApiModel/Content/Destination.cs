using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HB.ApiModel.Content
{
    public class Destinations
    {
        public String code;
        public Content name;
        public String countryCode;
        public String isoCode;
        public List<Zone> zones;
        public List<GroupZone> groupZones;

    }
}
