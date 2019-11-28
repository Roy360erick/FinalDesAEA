using System;
using System.Collections.Generic;


namespace Models.Response
{
    public class Product_Response
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public Decimal Price { get; set; }
        public string Remarks { get; set; }
        public DateTime CreateAt { get; set; }
        public bool State { get; set; }
        public virtual ICollection<SalesInvoceDetail_Response> SalesInvoceDetails { get; set; }
    }
}
