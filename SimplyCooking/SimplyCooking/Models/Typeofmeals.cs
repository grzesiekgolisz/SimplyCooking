using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimplyCooking.Models
{
    public class Typeofmeals
    {
        public int TypeofmealsID { get; set; }
        public string Mealstype { get; set; }

        public virtual List<Recipes> Recipes { get; set; }
    }
}