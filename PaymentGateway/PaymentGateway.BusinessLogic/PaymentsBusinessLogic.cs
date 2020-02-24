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

        public async Task<PaymentResponse> CreatePayment(PaymentRequest paymentRequest)
        {
            if (paymentRequest == null)
                return null;

            var payment = _mapper.Map<Payment>(paymentRequest);

            payment.Status = PaymentStatus.Captured;

            payment = await _paymentsRepo.CreatePayment(payment);

            var bankRequest = _mapper.Map<BankPaymentRequest>(paymentRequest);
            var bankResponse = await _bankRepo.ProcessCardPost(bankRequest);

            if (bankResponse != null)
            {
                payment.Approved = bankResponse.Approved;
                payment.AuthCode = bankResponse.AuthCode;
                payment.Status = bankResponse.Approved ? PaymentStatus.Authorized : PaymentStatus.Declined;
            }

            payment = await _paymentsRepo.UpdatePaymentStatus(payment.Id, payment.Approved, payment.AuthCode, payment.Status);

            var response = _mapper.Map<PaymentResponse>(payment);

            return response;
        }
    }
}
