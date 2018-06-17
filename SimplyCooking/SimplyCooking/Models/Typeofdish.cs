using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimplyCooking.Models
{
    public class Typeofdish
    {
        public int TypeofdishID { get; set; }
        public string Type { get; set; }
        public Photo Photo { get; set; }
        public Recipe Recipe { get; set; }
        public virtual List<Recipe> Recipes { get; set; }
    }
}