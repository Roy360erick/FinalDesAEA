using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class SalesInvoceDetail
    {
        public int SalesInvoceDetailID { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Price { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        public float Quantity { get; set; }

        public int SalesInvoceID { get; set; }

        public bool State { get; set; }

        public int ProductID { get; set; }

        public virtual Product Product { get; set; }

        [JsonIgnore]
        public virtual SalesInvoce SalesInvoce { get; set; }


    }
}
