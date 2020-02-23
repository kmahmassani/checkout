using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace PaymentGateway.Domain.HttpModels
{
    /// <summary>
    /// The links related to the payment
    /// </summary>
    [DataContract]
    public partial class PaymentResponseLinks
    { 
        /// <summary>
        /// The URI of the payment
        /// </summary>
        /// <value>The URI of the payment</value>
        [Required]
        [DataMember(Name="self")]
        public Link Self { get; set; }
    }
}
