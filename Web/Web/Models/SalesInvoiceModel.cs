using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class SalesInvoiceModel
    {
        public int SalesInvoceID { get; set; }

        public string Number { get; set; }

        public bool Payed { get; set; }

        public int discount { get; set; }

        public string Reason { get; set; }

        public DateTime CreateAt { get; set; }

        public bool State { get; set; }

        public int CustomerID { get; set; }

        public int SellerID { get; set; }

        public virtual CustomerModel Customer { get; set; }
        public virtual SellerModel Seller { get; set; }
        public virtual ICollection<SalesInvoiceDetailModel> SalesInvoiceDetails { get; set; }
    }
}