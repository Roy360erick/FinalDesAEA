
namespace Models.Request
{
    public class SalesInvoceDetail_Request
    {
        public int SalesInvoceDetailID { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public float Quantity { get; set; }
        public int SalesInvoceID { get; set; }
        public int ProductID { get; set; }
    }
}
