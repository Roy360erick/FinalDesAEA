using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class Factura
    {
        [Key]
        public int FacturaId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int ClienteId { get; set; }
        
        public virtual Cliente Cliente { get; set; }


    }
}
