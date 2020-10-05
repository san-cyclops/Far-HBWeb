using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiModel
{
    public class Guest
    {
        public int id { get; set; }
        public Titile titile { get; set; }
        public string question { get; set; }
        public string name { get; set; }
        public string surname { get; set; }

    }

    public class Titile
    {
        public string name { get; set; }
    }
}
