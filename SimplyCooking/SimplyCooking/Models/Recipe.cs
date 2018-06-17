using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SimplyCooking.Models
{
    public class Recipe
    {
        public int RecipeID { get; set; } 
        public string UserID { get; set; }
        public string Name { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        [AllowHtml]
        public string Components { get; set; }
        [AllowHtml]
        public int TypeofdishesID { get; set; }
        public int TypeofmealsID { get; set; }
        public int? EquipmentV2ID { get; set; }
        public int Time { get; set; }
        public DifficultyLevel DifficultyLevel { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Typeofdish Typeofdishes { get; set; }
        public virtual Typeofmeal Typeofmeals { get; set; }
        //public virtual List<Comment> Comment { get; set; }
        public virtual EquipmentV2 Equipment { get; set; }
        [AllowHtml]
        public virtual List<Component> Component { get; set; }
        public virtual List<Photo> Photos { get; set; }

    }
}