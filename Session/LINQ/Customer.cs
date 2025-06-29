namespace Session.LINQ
{
    class Customer
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }

        public Order[] Orders { get; set; }
        public Customer()
        {

        }
        public Customer(string customerId, string customerName)
        {
            customerId = customerId;
            customerName = customerName;
            Orders = new Order[10];
        }

        public override string ToString() => $"CustomerId: {CustomerId}, CustomerName: {CustomerName}, Address: {Address}, City: {City}, Region: {Region}, PostalCode: {PostalCode}, Country: {Country}, Phone: {Phone}, Fax: {Fax}\n";
    }
}
