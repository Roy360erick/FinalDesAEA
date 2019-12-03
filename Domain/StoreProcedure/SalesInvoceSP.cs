using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.StoreProcedure
{
    public class SalesInvoceSP
    {
        public int SalesInvoceID { get; set; }

        public string Number { get; set; }

        public DateTime CreateAt { get; set; }

        public string Seller { get; set; }

        public string Customer { get; set; }

        public double SubTotal { get; set; }

        public int Discount { get; set; }

        public double Total { get; set; }

        public bool Payed { get; set; }
    }
}
