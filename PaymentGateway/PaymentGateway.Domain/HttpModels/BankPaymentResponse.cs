using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
