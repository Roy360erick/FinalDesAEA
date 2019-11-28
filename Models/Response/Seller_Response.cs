
using System;
using System.Collections.Generic;

namespace Models.Response
{
    public class Seller_Response
    {

        public int SellerID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime CreateAt { get; set; }
        public bool State { get; set; }
        public string FullName => $"{Name} {LastName}";
        public virtual ICollection<SalesInvoce_Response> SalesInvoces { get; set; }
    }
}
