using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID{ get; set; }

        [Required]
        public  string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime Birthdate{ get; set; }

        public DateTime CreateAt { get; set; }

        public bool State { get; set; }

        [NotMapped]
        public string FullName => $"{Name} {LastName}";

        [JsonIgnore]
        public virtual ICollection<SalesInvoce> SalesInvoces { get; set; }
    }
}
