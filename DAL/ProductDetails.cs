using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class ProductDetails
    {
        public string Mark { get; set; }
        public string CarModel { get; set; }
        public int Year { get; set; }
        public string Vin { get; set; }
        public DateTime DateAdded { get; set; }
        public string Owner { get; set; }
    }
}
