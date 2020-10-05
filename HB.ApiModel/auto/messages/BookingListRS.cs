using HB.ApiModel.auto.model;

namespace HB.ApiModel.auto.messages
{
    public class BookingListRS : AbstractGenericResponse
    {
        public Bookings bookings { get; set; }
    }
}