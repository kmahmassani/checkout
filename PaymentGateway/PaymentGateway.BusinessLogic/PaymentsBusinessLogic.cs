using AutoMapper;
using PaymentGateway.Domain.HttpModels;
using PaymentGateway.Domain.Interfaces;
using PaymentGateway.Domain.POCOs;
using System;
using System.Threading.Tasks;

namespace PaymentGateway.BusinessLogic
{
    public class PaymentsBusinessLogic : IPaymentsBusinessLogic
    {
        private readonly IPaymentsRepository _paymentsRepo;
        private readonly IBank _bankRepo;
        private readonly IMapper _mapper;

        public PaymentsBusinessLogic(IPaymentsRepository paymentsRepo, IBank bankRepo, IMapper mapper)
        {
            _paymentsRepo = paymentsRepo;
            _bankRepo = bankRepo;
            _mapper = mapper;
        }

        public async Task<PaymentResponse> GetPaymentById(string id)
        {
            if (string.IsNullOrEmpty(id))
                return null;

            try
            {
                var payment = await _paymentsRepo.GetPaymentById(id);

                return _mapper.Map<PaymentResponse>(payment);
            }
            catch (Exception e)
            {
                return null;
            }            
        }

        public async Task<string> CreatePayment(PaymentRequest paymentRequest)
        {
            if (paymentRequest == null)
                return null;

            var payment = _mapper.Map<Payment>(paymentRequest);



            return await _paymentsRepo.CreatePayment(payment);
        }
    }
}
