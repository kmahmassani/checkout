using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace PaymentGateway.Domain.HttpModels
{
    /// <summary>
    /// A card payment source
    /// </summary>
    [DataContract]
    public partial class PaymentResponseSource
    { 
        /// <summary>
        /// The expiry month
        /// </summary>
        /// <example>12</example>
        [Required]
        [DataMember(Name="expiry_month")]
        public int? ExpiryMonth { get; set; }

        /// <summary>
        /// The expiry year
        /// </summary>
        /// <example>2021</example>
        [Required]
        [DataMember(Name="expiry_year")]
        public int? ExpiryYear { get; set; }

        /// <summary>
        /// The cardholder&#x27;s name
        /// </summary>
        /// <example>John Wick</example>
        [DataMember(Name="name")]
        public string Name { get; set; }

        /// <summary>
        /// The card scheme
        /// </summary>
        /// <example>Visa</example>
        [DataMember(Name="scheme")]
        public string Scheme { get; set; }

        /// <summary>
        /// The last four digits of the card number
        /// </summary>
        /// <example>1111</example>
        [Required]
        [DataMember(Name="last4")]
        public string Last4 { get; set; }        
    }
}
