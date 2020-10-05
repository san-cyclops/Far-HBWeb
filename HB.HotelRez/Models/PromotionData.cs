using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HB.HotelRez.Models
{
    public class PromotionData
    {
        public string PromotionType { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public string DiscountValue { get; set; }
        public string DiscountPercentage { get; set; }
        public List<string> RoomID { get; set; }
        public string HotelName { get; set; }
        public string PromoDate { get; set; }
        public string Hours { get; set; }
        [Required(ErrorMessage = "Required.")]
        public List<SelectListItem> Rooms { get; set; }
    }
}