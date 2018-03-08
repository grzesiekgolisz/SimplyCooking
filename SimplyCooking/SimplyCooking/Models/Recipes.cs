using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimplyCooking.Models
{
    public class Recipes
    {
        public int RecipeID { get; set; }
        public string UserID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TypeofdishesID { get; set; }
        public int TypeofmealsID { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Typeofdishes Typeofdishes { get; set; }
        public virtual Typeofmeals Typeofmeals { get; set; }
        public virtual List<Comments> Comments { get; set; }
    }
}