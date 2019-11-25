using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class ProductModel
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string Remarks { get; set; }
        public DateTime CreateAt { get; set; }
        public bool State { get; set; }
        public virtual ICollection<SalesInvoiceDetailModel> SalesInvoiceDetails { get; set; }
    }
}