/*
 * Bank API Mock
 *
 * Mock of a Bank API  
 *
 * OpenAPI spec version: 1.0.0
 * Contact: kmahmassani@gmail.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace BankAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class PaymentRequest
    { 
        /// <summary>
        /// The payment amount. The exact format &lt;a href&#x3D;\&quot;https://docs.checkout.com/docs/calculating-the-value\&quot; target&#x3D;\&quot;blank\&quot;&gt;depends on the currency&lt;/a&gt;. 
        /// </summary>
        /// <value>The payment amount. The exact format &lt;a href&#x3D;\&quot;https://docs.checkout.com/docs/calculating-the-value\&quot; target&#x3D;\&quot;blank\&quot;&gt;depends on the currency&lt;/a&gt;. </value>
        [Required]
        [DataMember(Name="amount")]
        public int? Amount { get; set; }

        /// <summary>
        /// The three-letter &lt;a href&#x3D;\&quot;https://docs.checkout.com/docs/currency-codes\&quot; target&#x3D;\&quot;blank\&quot;&gt;ISO currency code&lt;/a&gt; 
        /// </summary>
        /// <value>The three-letter &lt;a href&#x3D;\&quot;https://docs.checkout.com/docs/currency-codes\&quot; target&#x3D;\&quot;blank\&quot;&gt;ISO currency code&lt;/a&gt; </value>
        [Required]
        [DataMember(Name="currency")]
        public string Currency { get; set; }

        /// <summary>
        /// The card number (without separators)
        /// </summary>
        /// <value>The card number (without separators)</value>
        [Required]
        [DataMember(Name="number")]
        public string Number { get; set; }

        /// <summary>
        /// The expiry month of the card
        /// </summary>
        /// <value>The expiry month of the card</value>
        [Required]
        [DataMember(Name="expiry_month")]
        public int? ExpiryMonth { get; set; }

        /// <summary>
        /// The expiry year of the card
        /// </summary>
        /// <value>The expiry year of the card</value>
        [Required]
        [DataMember(Name="expiry_year")]
        public int? ExpiryYear { get; set; }

        /// <summary>
        /// The name of the cardholder
        /// </summary>
        /// <value>The name of the cardholder</value>
        [DataMember(Name="name")]
        public string Name { get; set; }

        /// <summary>
        /// The card verification value/code. 3 digits, except for Amex (4 digits)
        /// </summary>
        /// <value>The card verification value/code. 3 digits, except for Amex (4 digits)</value>
        [Required]
        [DataMember(Name="cvv")]
        public string Cvv { get; set; }               
    }
}
