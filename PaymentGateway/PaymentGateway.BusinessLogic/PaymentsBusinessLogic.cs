using AutoMapper;
using PaymentGateway.Domain.HttpModels;
using PaymentGateway.Domain.Interfaces;
using PaymentGateway.Domain.POCOs;
using System.Threading.Tasks;

namespace PaymentGateway.BusinessLogic
{
    public class PaymentsBusinessLogic : IPaymentsBusinessLogic
    {
        private readonly IPaymentsRepository _repo;
        private readonly IMapper _mapper;

        public PaymentsBusinessLogic(IPaymentsRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<PaymentResponse> GetPaymentById(string id)
        {
            if (string.IsNullOrEmpty(id))
                return null;

            var payment = await _repo.GetPaymentById(id);

            return _mapper.Map<PaymentResponse>(payment);
        }

        public async Task<string> CreatePayment(PaymentRequest paymentRequest)
        {
            if (paymentRequest == null)
                return null;

            var payment = _mapper.Map<Payment>(paymentRequest);



            return await _repo.CreatePayment(payment);
        }
    }
}
