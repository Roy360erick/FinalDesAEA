using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class CustomerModel
    {
        public int CustomerID { get; set; }
        public string Name { get; set; } 
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime CreateAt { get; set; }
        public bool State { get; set; }
        public string FullName { get; set; }
    }
}