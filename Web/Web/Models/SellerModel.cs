using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class SellerModel
    {
        public int SellerID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime CreateAt { get; set; }
        public bool State { get; set; }
        //[NotMapped]
        public string FullName => $"{Name} {LastName}";
        //[JsonIgnore]
        public virtual ICollection<SalesInvoiceDetailModel> SalesInvoice { get; set; }
    }
}