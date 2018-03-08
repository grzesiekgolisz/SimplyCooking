using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimplyCooking.Models
{
    public class Comments
    {
        public int CommentID { get; set; }
        public string UserID { get; set; }
        public string Comment { get; set; }
        public int RecipeID { get; set; }
    }
}