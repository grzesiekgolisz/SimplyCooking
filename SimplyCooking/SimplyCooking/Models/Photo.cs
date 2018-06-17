using System.Web.Mvc;

namespace SimplyCooking.Models
{
    public class Photo
    {
        public int PhotoId { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        [AllowHtml]
        public byte[] Image { get; set; }
        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}