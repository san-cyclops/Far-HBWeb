using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Model
{
    public class HotelRsRep
    {

        public List<HotelRep> hotel;

        public CountryRep country;
 
        public DestinationsRep destination;

        public GeoLocationRep coordinates;

        
        public List<HotelBoardCodesRep> boardCodes;

        public List<HotelSegmentRep> segmentCodes;

 
        public List<HotelPhoneRep> phones;

        public List<HotelRoomRep> rooms;

        public List<HotelFacilityRep> facilities;

        public List<ImageRep> images;
    }
}
