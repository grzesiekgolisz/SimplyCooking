using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimplyCooking.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string UserID { get; set; }
        public string Comment_ { get; set; }
        public int RecipeID { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Recipe Recipe { get; set; }

    }
}