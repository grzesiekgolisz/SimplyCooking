using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimplyCooking.Models
{
    public class Typeofdishes
    {
        public int TypeofdishesID { get; set; }
        public string Type { get; set; }

        public virtual List<Recipes> Recipes { get; set; }
    }
}