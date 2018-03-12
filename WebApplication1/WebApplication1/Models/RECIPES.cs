using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class RECIPES
    {
        public int RecipeId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CommentList { get; set; }
        public string EquipmentList { get; set; }
        public string ComponentList { get; set; }
        public int TypeofdishesId { get; set; }
        public int TypeofmealsId { get; set; }
       

       // public virtual List<DodatkowaKlasa> DodatkowaKlasa { get; set; }
    }
}
