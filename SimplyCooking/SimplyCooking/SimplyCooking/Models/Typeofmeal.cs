using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimplyCooking.Models
{
    public class Typeofmeal
    {
        public int TypeofmealID { get; set; }
        public string Mealstype { get; set; }

        public virtual List<Recipe> Recipes { get; set; }
    }
}