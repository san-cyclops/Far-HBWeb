using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HB.HotelRez.Models
{
    public class UnabailableList
    {
        public string RoomID { get; set; }

        public List<string> UnavailableDates { get; set; }

        [Required(ErrorMessage = "Required.")]
        public List<SelectListItem> Rooms { get; set; }
    }
}