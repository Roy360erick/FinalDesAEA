using System;
using System.Collections.Generic;

namespace Models.Request
{
    public class Product_Request
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public Decimal Price { get; set; }
        public string Remarks { get; set; }
    }
}
