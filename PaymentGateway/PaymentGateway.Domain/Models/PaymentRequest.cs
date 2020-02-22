using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace PaymentGateway.Domain.Models
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
        public PaymentRequestSource Source { get; set; }

        /// <summary>
        /// The payment amount. The exact format &lt;a href&#x3D;\&quot;https://docs.checkout.com/docs/calculating-the-value\&quot; target&#x3D;\&quot;blank\&quot;&gt;depends on the currency&lt;/a&gt;. 
        /// </summary>
        /// <value>The payment amount. The exact format &lt;a href&#x3D;\&quot;https://docs.checkout.com/docs/calculating-the-value\&quot; target&#x3D;\&quot;blank\&quot;&gt;depends on the currency&lt;/a&gt;. </value>
        [DataMember(Name="amount")]
        [Range(0, int.MaxValue)]
        public decimal Amount { get; set; }

        /// <summary>
        /// The three-letter &lt;a href&#x3D;\&quot;https://docs.checkout.com/docs/currency-codes\&quot; target&#x3D;\&quot;blank\&quot;&gt;ISO currency code&lt;/a&gt; 
        /// </summary>
        /// <value>The three-letter &lt;a href&#x3D;\&quot;https://docs.checkout.com/docs/currency-codes\&quot; target&#x3D;\&quot;blank\&quot;&gt;ISO currency code&lt;/a&gt; </value>
        [DataMember(Name="currency")]
        [StringLength(3, MinimumLength = 3)]
        public string Currency { get; set; }

        /// <summary>
        /// A reference you can later use to identify this payment, such as an order number.
        /// </summary>
        /// <value>A reference you can later use to identify this payment, such as an order number.</value>
        [DataMember(Name="reference")]
        public string Reference { get; set; }        
    }
}
