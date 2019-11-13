using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class Seller
    {
        [Key]
        public int SellerID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

        public DateTime CreateAt { get; set; }

        public bool State { get; set; }

        [NotMapped]
        public string FullName => $"{Name} {LastName}";

        public virtual ICollection<SalesInvoce> SalesInvoces { get; set; }
    }
}
