//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Repositories
{
    using System;
    using System.Collections.Generic;
    
    public partial class HotelRoomFacilityRep
    {
        public long HotelRoomFacilityRepID { get; set; }
        public int HotelCode { get; set; }
        public string roomCode { get; set; }
        public int facilityCode { get; set; }
        public int facilityGroupCode { get; set; }
        public string description { get; set; }
        public bool indLogic { get; set; }
        public bool indFee { get; set; }
        public int number { get; set; }
        public int order { get; set; }
        public bool indYesOrNo { get; set; }
    }
}
