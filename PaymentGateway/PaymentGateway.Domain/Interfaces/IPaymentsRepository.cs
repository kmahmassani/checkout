using PaymentGateway.Domain.POCOs;
using System.Threading.Tasks;

namespace PaymentGateway.Domain.Interfaces
{
    public interface IPaymentsRepository
    {
        Task<Payment> GetPaymentById(string id);
        Task<Payment> CreatePayment(Payment payment);
        Task<Payment> UpdatePaymentStatus(string paymentId, bool approved, string authCode, string status, string resp_code);
    }
}
