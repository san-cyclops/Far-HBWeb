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
    
    public partial class ZoneRep
    {
        public long ZoneRepID { get; set; }
        public int zoneCode { get; set; }
        public string name { get; set; }
        public Nullable<long> Description_ContentID { get; set; }
    
        public virtual Content Content { get; set; }
    }
}
