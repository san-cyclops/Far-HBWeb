using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HB.ApiModel.Content
{
    public class HotelRoom
    {

        public String roomCode;    
        public String description;
        public String roomType;
        public String characteristicCode;
        public List<HotelRoomFacility> roomFacilities;
        public List<HotelRoomStay> roomStays;


    }
}
