
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Request
{
    public class Customer_Request
    {
        public int CustomerID{ get; set; }
        public  string Name { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate{ get; set; }
    }
}
