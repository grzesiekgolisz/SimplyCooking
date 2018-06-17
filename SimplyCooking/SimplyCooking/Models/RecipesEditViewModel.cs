using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimplyCooking.Models
{
    public class RecipesEditViewModel
    {
        public Recipe Recipe { get; set; }
        public IEnumerable<SelectListItem> TypeOfDisches { get; set; }
        public IEnumerable<SelectListItem> TypeOfMeals { get; set; }
    }
}