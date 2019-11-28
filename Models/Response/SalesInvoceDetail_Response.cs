
namespace Models.Response
{ 
    public class SalesInvoceDetail_Response
    {
        public int SalesInvoceDetailID { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public float Quantity { get; set; }
        public int SalesInvoceID { get; set; }
        public bool State { get; set; }
        public int ProductID { get; set; }
        public virtual Product_Response Product { get; set; }
        public virtual SalesInvoce_Response SalesInvoce { get; set; }
    }
}
