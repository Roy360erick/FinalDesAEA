using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class DetalleFactura
    {
        public int DetalleFacturaId { get; set; }

        public int FacturaId { get; set; }
        public virtual Factura Factura { get; set; }
    }
}
