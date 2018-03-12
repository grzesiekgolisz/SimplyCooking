﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimplyCooking.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int UnitID { get; set; }
        public int Value { get; set; }

        public virtual List<Component> Components { get; set; }
    }
}