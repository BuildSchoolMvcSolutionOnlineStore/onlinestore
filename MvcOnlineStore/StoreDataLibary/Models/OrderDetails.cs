namespace BuildSchool.MvcSolution.OnlineStore.Models.Models
{
    class OrderDetails
    {
        public string OrderID { get; set; }
        public string ProductID { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
    }
}