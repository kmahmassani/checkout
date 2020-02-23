using PaymentGateway.DataAccess.ApiClient;
using PaymentGateway.Domain.HttpModels;
using PaymentGateway.Domain.Interfaces;
using System.Threading.Tasks;

namespace PaymentGateway.DataAccess.Repositories
{
    public class BankRepository : IBank
    {
        static BaseApiClient _client;
        public BankRepository(BaseApiClient client)
        {
            _client = client;
        }

        public async Task<BankPaymentResponse> ProcessCardPost(BankPaymentRequest paymentRequest)
        {
            var retval = await _client.PostAsync<BankPaymentResponse>(paymentRequest, "/process-card");

            return retval;
        }
    }
}
