
using System;
using System.Collections.Generic;

namespace Models.Request
{ 
    public class Seller_Request
    {
        public int SellerID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
