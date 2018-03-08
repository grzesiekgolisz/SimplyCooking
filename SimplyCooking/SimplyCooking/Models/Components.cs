using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimplyCooking.Models
{
    public class Components
    {
        public int ComponetID { get; set; }
        public int RecipeID { get; set; }

        public virtual List<Products> Products { get; set; }
        public virtual Recipes Recipes { get; set; }
    }
}