using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        public string Name { get; set; }

        public int Stock { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public Decimal Price { get; set; }

        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }
        
        public DateTime CreateAt { get; set; }

        public bool State { get; set; }

        [JsonIgnore]
        public virtual ICollection<SalesInvoceDetail> SalesInvoceDetails { get; set; }
    }
}
