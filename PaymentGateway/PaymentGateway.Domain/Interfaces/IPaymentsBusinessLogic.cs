﻿using PaymentGateway.Domain.HttpModels;
using System.Threading.Tasks;

namespace PaymentGateway.Domain.Interfaces
{
    public interface IPaymentsBusinessLogic
    {
        Task<PaymentResponse> GetPaymentById(string id);
        Task<string> CreatePayment(PaymentRequest payment);
    }
}
