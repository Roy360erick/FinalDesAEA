using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class SalesInvoce
    {
        [Key]
        public int SalesInvoceID { get; set; }
        
        public string Reason { get; set; }
 
        public DateTime CreateAt { get; set; }

        public bool State { get; set; }

        public int CustomerID { get; set; }

        public int SellerID { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Seller Seller { get; set; }
        public virtual ICollection<SalesInvoceDetail> SalesInvoceDetails { get; set; }
    }
}
