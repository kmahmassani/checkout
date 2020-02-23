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
        /// <value>The payment&#x27;s unique identifier</value>
        [Required]
        [DataMember(Name = "id")]
        public string Id { get; set; }

        /// <summary>
        /// The payment amount. The exact format &lt;a href&#x3D;\&quot;https://docs.checkout.com/docs/calculating-the-value\&quot; target&#x3D;\&quot;blank\&quot;&gt;depends on the currency&lt;/a&gt;. 
        /// </summary>
        /// <value>The payment amount. The exact format &lt;a href&#x3D;\&quot;https://docs.checkout.com/docs/calculating-the-value\&quot; target&#x3D;\&quot;blank\&quot;&gt;depends on the currency&lt;/a&gt;. </value>
        [Required]
        [DataMember(Name = "amount")]
        public int? Amount { get; set; }

        /// <summary>
        /// The three-letter &lt;a href&#x3D;\&quot;https://docs.checkout.com/docs/currency-codes\&quot; target&#x3D;\&quot;blank\&quot;&gt;ISO currency code&lt;/a&gt; of the payment
        /// </summary>
        /// <value>The three-letter &lt;a href&#x3D;\&quot;https://docs.checkout.com/docs/currency-codes\&quot; target&#x3D;\&quot;blank\&quot;&gt;ISO currency code&lt;/a&gt; of the payment</value>
        [Required]
        [DataMember(Name = "currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Whether or not the authorization or capture was successful
        /// </summary>
        /// <value>Whether or not the authorization or capture was successful</value>
        [Required]
        [DataMember(Name = "approved")]
        public bool? Approved { get; set; }

        /// <summary>
        /// The status of the payment
        /// </summary>
        /// <value>The status of the payment</value>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum StatusEnum
        {
            /// <summary>
            /// Enum AuthorizedEnum for Authorized
            /// </summary>
            [EnumMember(Value = "Authorized")]
            AuthorizedEnum = 0,
            /// <summary>
            /// Enum DeclinedEnum for Declined
            /// </summary>
            [EnumMember(Value = "Declined")]
            DeclinedEnum = 1
        }

        /// <summary>
        /// The status of the payment
        /// </summary>
        /// <value>The status of the payment</value>
        [Required]
        [DataMember(Name = "status")]
        public StatusEnum? Status { get; set; }

        /// <summary>
        /// The acquirer authorization code if the payment was authorized
        /// </summary>
        /// <value>The acquirer authorization code if the payment was authorized</value>
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
        /// <value>The date/time the payment was processed</value>
        [Required]
        [DataMember(Name = "processed_on")]
        public DateTime ProcessedOn { get; set; }

        /// <summary>
        /// Your reference for the payment
        /// </summary>
        /// <value>Your reference for the payment</value>
        [DataMember(Name = "reference")]
        public string Reference { get; set; }

        /// <summary>
        /// Gets or Sets Links
        /// </summary>
        [Required]
        [DataMember(Name = "_links")]
        public PaymentResponseLinks Links { get; set; }        
    }
}
