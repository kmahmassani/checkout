using PaymentGateway.Domain.POCOs;
using System.Threading.Tasks;

namespace PaymentGateway.Domain.Interfaces
{
    public interface IPaymentsRepository
    {
        Task<Payment> GetPaymentById(string id);
        Task<string> CreatePayment(Payment payment);
    }
}
