using PaymentGateway.Domain.HttpModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Domain.Interfaces
{
    public interface IBank
    {
        /// <summary>
        /// Process a card payment Processes a payment and returns success or failure 
        /// </summary>
        /// <param name="paymentRequest"></param>
        /// <returns>BankPaymentResponse</returns>
        Task<BankPaymentResponse> ProcessCardPost(BankPaymentRequest paymentRequest);
    }
}
