using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace PaymentGateway.Domain.HttpModels
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class Link
    { 
        /// <summary>
        /// The link URL
        /// </summary>
        /// <value>The link URL</value>
        [Required]
        [DataMember(Name="href")]
        public string Href { get; set; }       
    }
}
