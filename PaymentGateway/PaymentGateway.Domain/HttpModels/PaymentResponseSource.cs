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
        /// <value>The expiry month</value>
        [Required]
        [DataMember(Name="expiry_month")]
        public int? ExpiryMonth { get; set; }

        /// <summary>
        /// The expiry year
        /// </summary>
        /// <value>The expiry year</value>
        [Required]
        [DataMember(Name="expiry_year")]
        public int? ExpiryYear { get; set; }

        /// <summary>
        /// The cardholder&#x27;s name
        /// </summary>
        /// <value>The cardholder&#x27;s name</value>
        [DataMember(Name="name")]
        public string Name { get; set; }

        /// <summary>
        /// The card scheme
        /// </summary>
        /// <value>The card scheme</value>
        [DataMember(Name="scheme")]
        public string Scheme { get; set; }

        /// <summary>
        /// The last four digits of the card number
        /// </summary>
        /// <value>The last four digits of the card number</value>
        [Required]
        [DataMember(Name="last4")]
        public string Last4 { get; set; }        
    }
}
