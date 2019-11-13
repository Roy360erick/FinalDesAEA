using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }

        [Required]
        public string Nombre { get; set; }

        public int Cantidad { get; set; }

        public Decimal Precio { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
