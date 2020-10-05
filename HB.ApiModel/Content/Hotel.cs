using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using HB.ApiModel.auto.model;

namespace HB.ApiModel.Content
{
    public class HotelModel
    {

        public int code;

        public Content name;

        public Content description;

        public String countryCode;

        public Country country;

        public String destinationCode;

        public short zoneCode;

        public Destination destination;

        public GeoLocation coordinates;

        public String categoryCode;

        public String categoryGroupCode;

        public String chainCode;

        public String accommodationTypeCode;

        public List<String> boardCodes;

        public List<int> segmentCodes;

        public List<Segment> segments;

        public Content address;

        public String postalCode;

        public Content city;

        public String email;

        public String license;

        public int giataCode;

        public List<HotelPhone> phones;

        public List<HotelRoom> rooms;

        public List<HotelFacility> facilities;

        public List<HotelPointOfInterest> interestPoints;

        public List<Image> images;


        public List<HotelTerminal> terminals;



    }
}
