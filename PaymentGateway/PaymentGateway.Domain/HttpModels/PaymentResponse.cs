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
        /// <example>pay_wqo7wb92SLE9irZXpVsvF1U020</example>
        [Required]
        [DataMember(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The payment amount. The exact format &lt;a href&#x3D;\&quot;https://docs.checkout.com/docs/calculating-the-value\&quot; target&#x3D;\&quot;blank\&quot;&gt;depends on the currency&lt;/a&gt;. 
        /// </summary>
        /// <example>120000</example>
        [Required]
        [DataMember(Name = "amount")]
        public int? Amount { get; set; }

        /// <summary>
        /// The three-letter &lt;a href&#x3D;\&quot;https://docs.checkout.com/docs/currency-codes\&quot; target&#x3D;\&quot;blank\&quot;&gt;ISO currency code&lt;/a&gt; of the payment
        /// </summary>
        /// <example>USD</example>
        [Required]
        [DataMember(Name = "currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Whether or not the authorization or capture was successful
        /// </summary>
        /// <example>true</example>
        [Required]
        [DataMember(Name = "approved")]
        public bool? Approved { get; set; }  

        /// <summary>
        /// The status of the payment
        /// </summary>
        /// <example>Authorized</example>
        [Required]
        [DataMember(Name = "status")]
        public string Status { get; set; }

        /// <summary>
        /// The acquirer authorization code if the payment was authorized
        /// </summary>
        /// <example>666</example>
        [DataMember(Name = "auth_code")]
        public string AuthCode { get; set; }

        /// <summary>
        /// The acquirer authorization code if the payment was authorized
        /// </summary>
        /// <example>666</example>
        [DataMember(Name = "response_code")]
        public string ResponseCode { get; set; }

        /// <summary>
        /// The source of the payment
        /// </summary>
        /// <example>The source of the payment</example>
        [DataMember(Name = "source")]
        public PaymentResponseSource Source { get; set; }

        /// <summary>
        /// The date/time the payment was processed
        /// </summary>
        /// <example>2020-02-23 15:26:18.619267</example>
        [Required]
        [DataMember(Name = "processed_on")]
        public DateTime ProcessedOn { get; set; }

        /// <summary>
        /// Your reference for the payment
        /// </summary>
        /// <example>Mustang Payment</example>
        [DataMember(Name = "reference")]
        public string Reference { get; set; }        
    }
}
