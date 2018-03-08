using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimplyCooking.Models
{
    public class Equipments
    {
        public int EquipmentID { get; set; }
        public string Equipmentname { get; set; }

        public virtual List<Recipes> Recipes { get; set; }
    }
}