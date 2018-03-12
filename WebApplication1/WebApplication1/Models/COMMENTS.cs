using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class COMMENTS
    {
        public int CommentID { get; set; }
        public int UserID { get; set; }
        public string Comment { get; set; }
        public int RecipeId { get; set; }
    }
}
