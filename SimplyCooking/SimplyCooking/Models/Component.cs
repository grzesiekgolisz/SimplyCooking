using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimplyCooking.Models
{
    public class Component
    {
        public int ComponentID { get; set; }
        public int RecipeID { get; set; }

        public virtual List<Product> Product { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}