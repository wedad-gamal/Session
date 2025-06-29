namespace Session.LINQ
{
    class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }
        public Order()
        {

        }

        public Order(int orderId, DateTime orderDate, decimal total)
        {
            OrderId = orderId;
            OrderDate = orderDate;
            Total = total;
        }

        public override string ToString() => $"OrderId: {OrderId}, OrderDate: {OrderDate.ToShortDateString()}, Total: {Total}\n";
    }
}
