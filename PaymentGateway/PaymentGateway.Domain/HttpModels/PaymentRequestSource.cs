using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using PaymentGateway.Domain.Annotations;

namespace PaymentGateway.Domain.HttpModels
{
    /// <summary>
    /// A card payment source
    /// </summary>
    [DataContract]
    public partial class PaymentRequestSource
    { 
        /// <summary>
        /// The type of payment source. Set this to &#x60;card&#x60;.
        /// </summary>
        /// <value>The type of payment source. Set this to &#x60;card&#x60;.</value>
        [Required]       
        [DataMember(Name="type")]
        public string Type { get; set; }

        /// <summary>
        /// The card number (without separators)
        /// </summary>
        /// <value>The card number (without separators)</value>
        [Required]
        [DataMember(Name="number")]
        [CreditCard]
        public string Number { get; set; }

        /// <summary>
        /// The expiry month of the card
        /// </summary>
        /// <value>The expiry month of the card</value>
        [Required]
        [DataMember(Name="expiry_month")]
        [Range(1, 12)]
        public int? ExpiryMonth { get; set; }

        /// <summary>
        /// The expiry year of the card
        /// </summary>
        /// <value>The expiry year of the card</value>
        [Required]
        [ExpiryDate]
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
        [DataMember(Name="cvv")]
        [StringLength(4, MinimumLength = 3)]
        [Required]
        public string Cvv { get; set; }        
    }
}
