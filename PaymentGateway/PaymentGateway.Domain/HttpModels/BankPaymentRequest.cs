using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.Domain.HttpModels
{
    public class BankPaymentRequest
    {
        /// <summary>
        /// The payment amount. The exact format <a href=\"https://docs.checkout.com/docs/calculating-the-value\" target=\"blank\">depends on the currency</a>. 
        /// </summary>
        /// <example>120</example>    
        [JsonProperty(PropertyName = "amount")]
        public int? Amount { get; set; }

        /// <summary>
        /// The three-letter <a href=\"https://docs.checkout.com/docs/currency-codes\" target=\"blank\">ISO currency code</a> 
        /// </summary>
        /// <example>USD</example>    
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        /// <summary>
        /// The card number (without separators)
        /// </summary>
        /// <example>4111111111111111</example>    
        [JsonProperty(PropertyName = "number")]
        public string Number { get; set; }

        /// <summary>
        /// The expiry month of the card
        /// </summary>
        /// <example>12</example>    
        [JsonProperty(PropertyName = "expiry_month")]
        public int? ExpiryMonth { get; set; }

        /// <summary>
        /// The expiry year of the card
        /// </summary>
        /// <example>2021</example>    
        [JsonProperty(PropertyName = "expiry_year")]
        public int? ExpiryYear { get; set; }

        /// <summary>
        /// The name of the cardholder
        /// </summary>
        /// <example>John Wick</example>    
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// The card verification value/code. 3 digits, except for Amex (4 digits)
        /// </summary>
        /// <example>666</example>    
        [JsonProperty(PropertyName = "cvv")]
        public string Cvv { get; set; }

    }
}
