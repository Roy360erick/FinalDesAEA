using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class SalesInvoiceDetailModel
    {
        public int SalesInvoceDetailID { get; set; }

        public string Description { get; set; }
        
        public decimal Price { get; set; }
        
        public float Quantity { get; set; }

        public int SalesInvoceID { get; set; }

        public bool State { get; set; }

        public int ProductID { get; set; }

        public virtual ProductModel Product { get; set; }

        //[JsonIgnore]
        public virtual SalesInvoiceModel SalesInvoce { get; set; }
    }
}