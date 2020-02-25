using PaymentGateway.Domain.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace PaymentGateway.Domain.HttpModels
{
    /// <summary>
    /// 
    /// </summary>
    
    [DataContract]
    public partial class PaymentRequest
    { 
        /// <summary>
        /// Gets or Sets Source
        /// </summary>
        [DataMember(Name="source")]
        [Required]
        public PaymentRequestSource Source { get; set; }

        /// <summary>
        /// The payment amount. The exact format &lt;a href&#x3D;\&quot;https://docs.checkout.com/docs/calculating-the-value\&quot; target&#x3D;\&quot;blank\&quot;&gt;depends on the currency&lt;/a&gt;. 
        /// </summary>
        /// <example>120000</example>
        [DataMember(Name="amount")]
        [Range(1, int.MaxValue)]
        public int Amount { get; set; }

        /// <summary>
        /// The three-letter &lt;a href&#x3D;\&quot;https://docs.checkout.com/docs/currency-codes\&quot; target&#x3D;\&quot;blank\&quot;&gt;ISO currency code&lt;/a&gt; 
        /// </summary>
        /// <example>USD</example>
        [DataMember(Name="currency")]
        [StringLength(3, MinimumLength = 3)]
        [ISOCurrency]
        public string Currency { get; set; }

        /// <summary>
        /// A reference you can later use to identify this payment, such as an order number.
        /// </summary>
        /// <example>Mustang Payment</example>
        [DataMember(Name="reference")]
        public string Reference { get; set; }        
    }
}
