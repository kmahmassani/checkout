using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace PaymentGateway.Domain.HttpModels
{
    /// <summary>
    /// Payment Response
    /// </summary>
    [DataContract]
    public partial class PaymentResponse
    {
        /// <summary>
        /// The payment&#x27;s unique identifier
        /// </summary>
        /// <value>pay_wqo7wb92SLE9irZXpVsvF1U020</value>
        [Required]
        [DataMember(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The payment amount. The exact format &lt;a href&#x3D;\&quot;https://docs.checkout.com/docs/calculating-the-value\&quot; target&#x3D;\&quot;blank\&quot;&gt;depends on the currency&lt;/a&gt;. 
        /// </summary>
        /// <value>120000</value>
        [Required]
        [DataMember(Name = "amount")]
        public int? Amount { get; set; }

        /// <summary>
        /// The three-letter &lt;a href&#x3D;\&quot;https://docs.checkout.com/docs/currency-codes\&quot; target&#x3D;\&quot;blank\&quot;&gt;ISO currency code&lt;/a&gt; of the payment
        /// </summary>
        /// <value>USD</value>
        [Required]
        [DataMember(Name = "currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Whether or not the authorization or capture was successful
        /// </summary>
        /// <value>true</value>
        [Required]
        [DataMember(Name = "approved")]
        public bool? Approved { get; set; }  

        /// <summary>
        /// The status of the payment
        /// </summary>
        /// <value>Authorized</value>
        [Required]
        [DataMember(Name = "status")]
        public string Status { get; set; }

        /// <summary>
        /// The acquirer authorization code if the payment was authorized
        /// </summary>
        /// <value>666</value>
        [DataMember(Name = "auth_code")]
        public string AuthCode { get; set; }

        /// <summary>
        /// The source of the payment
        /// </summary>
        /// <value>The source of the payment</value>
        [DataMember(Name = "source")]
        public PaymentResponseSource Source { get; set; }

        /// <summary>
        /// The date/time the payment was processed
        /// </summary>
        /// <value>2020-02-23 15:26:18.619267</value>
        [Required]
        [DataMember(Name = "processed_on")]
        public DateTime ProcessedOn { get; set; }

        /// <summary>
        /// Your reference for the payment
        /// </summary>
        /// <value>Mustang Payment</value>
        [DataMember(Name = "reference")]
        public string Reference { get; set; }        
    }
}
