using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimplyCooking.Models
{
    public class Recipe
    {
        public int RecipeID { get; set; }
        public string UserID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TypeofdishesID { get; set; }
        public int TypeofmealsID { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Typeofdish Typeofdish { get; set; }
        public virtual Typeofmeal Typeofmeal { get; set; }
        public virtual List<Comment> Comment { get; set; }
        public virtual List<Equipment> Equipment { get; set; }
        public virtual List<Component> Component { get; set; }
        
    }
}