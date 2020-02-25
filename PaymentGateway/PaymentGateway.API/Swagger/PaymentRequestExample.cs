using PaymentGateway.Domain.HttpModels;
using Swashbuckle.AspNetCore.Examples;

namespace PaymentGateway.API.Swagger
{
    public class PaymentRequestExample : IExamplesProvider
    {
        public object GetExamples()
        {            
            return new PaymentRequest()
            {
                Source = new PaymentRequestSource () {
                    Type = "card",
                    Number= "4111111111111111",
                    ExpiryMonth= 1,
                    ExpiryYear= 2021,
                    Name = "John Wick",
                    Cvv = "666"
                  },
                  Amount= 10000000,
                  Currency = "USD",
                  Reference = "MUSTANG-1"
            };
        }
    }
}
