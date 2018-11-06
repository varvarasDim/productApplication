using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Product.RequestModels
{
    public class ProductPost
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Weight { get; set; }
        public bool Is4G { get; set; }
    }
}