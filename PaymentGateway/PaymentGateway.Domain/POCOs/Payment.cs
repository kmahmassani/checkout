using System;

namespace PaymentGateway.Domain.POCOs
{
    public class Payment
    {
        public string Id { get; set; }
        public int Amount { get; set; }
        public string Currency { get; set; }
        public bool Approved { get; set; }
        public string Status { get; set; }
        public string AuthCode { get; set; }
        public DateTime? ProcessedOn { get; set; }
        public string Reference { get; set; }
        public PaymentSource Source { get; set; }
    }

    public class PaymentStatus
    {
        private PaymentStatus(string value) { Value = value; }        
        public string Value { get; set; }

        public static string Captured   { get { return "Captured"; } }
        public static string Authorized   { get { return "Authorized"; } }
        public static string Declined   { get { return "Declined"; } }        
    }
}
