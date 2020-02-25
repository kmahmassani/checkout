using PaymentGateway.Domain.HttpModels;
using PaymentGateway.Domain.POCOs;
using Swashbuckle.AspNetCore.Examples;
using System;

namespace PaymentGateway.API.Swagger
{
    public class PaymentResponseExample : IExamplesProvider
    {
        public object GetExamples()
        {
            return new PaymentResponse()
            {
                Id = "pay_mbabizu24mvu3mela5njyhpit4",
                Approved = true,
                Amount = 10000000,
                AuthCode = "563792",
                Currency = "USD",
                ProcessedOn = DateTime.Now,
                Reference = "MUSTANG-1",
                ResponseCode = "10000",
                Status = PaymentStatus.Authorized,
                Source = new PaymentResponseSource()
                {                   
                    ExpiryMonth= 1,
                    ExpiryYear= 2021,
                    Name = "John Wick",                    
                    Last4 = "1111",
                    Scheme = "Visa"
                }
            };
        }
    }
}
