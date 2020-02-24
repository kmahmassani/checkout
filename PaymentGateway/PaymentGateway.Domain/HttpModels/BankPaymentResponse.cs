using Newtonsoft.Json;

namespace PaymentGateway.Domain.HttpModels
{
    public class BankPaymentResponse
    {
        /// <summary>
        /// Banks Id of transaction
        /// </summary>    
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Whether or not the authorization or capture was successful
        /// </summary>            
        [JsonProperty(PropertyName = "approved")]
        public bool Approved { get; set; }
        
        /// <summary>
        /// Banks AuthCode of transaction
        /// </summary>    
        [JsonProperty(PropertyName = "authcode")]
        public string AuthCode { get; set; }

        /// <summary>
        /// Banks Response Code of transaction
        /// </summary>    
        [JsonProperty(PropertyName = "response_code")]
        public string ResponseCode { get; set; }
    }
}
