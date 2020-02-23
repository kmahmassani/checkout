using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PaymentGateway.Domain.HttpModels
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class ValidationError
    { 
        /// <summary>
        /// Gets or Sets RequestId
        /// </summary>
        [DataMember(Name="request_id")]
        public string RequestId { get; set; }

        /// <summary>
        /// Gets or Sets ErrorType
        /// </summary>
        [DataMember(Name="error_type")]
        public string ErrorType { get; set; }

        /// <summary>
        /// Gets or Sets ErrorCodes
        /// </summary>
        [DataMember(Name="error_codes")]
        public List<string> ErrorCodes { get; set; }        
    }
}
