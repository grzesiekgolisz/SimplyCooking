using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimplyCooking.Models
{
    public class RecipeDetailsViewModel
    {
        public Recipe Recipe { get; set; }
        public Photo Photo { get; set; }
        public Equipment Equipment {get; set;}
    }
}