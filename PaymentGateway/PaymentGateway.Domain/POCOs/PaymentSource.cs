namespace PaymentGateway.Domain.POCOs
{
    public class PaymentSource
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public int Expiry_Month { get; set; }
        public int Expiry_Year { get; set; }
        public string Name { get; set; }
        public string Last4 { get; set; }
        public string Scheme { get; set; }
    }
}
