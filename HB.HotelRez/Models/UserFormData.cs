using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HB.HotelRez.Models
{
    public class UserFormData
    {

        public string UserName { get; set; }

        public string Password { get; set; }

         public string UserType { get; set; }

        public string HotelCode { get; set; }

        public List<SelectListItem> HotelCodes { get; set; }

        public List<SelectListItem> UserNames { get; set; }

    }
}