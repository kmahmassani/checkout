using PaymentGateway.Domain.Interfaces;
using PaymentGateway.Domain.POCOs;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace PaymentGateway.DataAccess.Repositories
{
    public class PaymentsRepository : IPaymentsRepository
    {
        private IDbConnection _connection;

        public PaymentsRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<Payment> GetPaymentById(string id)
        {
            var paymentSql = "SELECT id, amount, currency, approved, payment_status as status, auth_code, processed_on as ProcessedOn, reference, source_id FROM public.payments WHERE id = @id";
            var sourceSql = "SELECT id, card_type as type, expiry_month, expiry_year, card_name as name, last4, scheme FROM public.payment_sources WHERE id = @id";
            try
            {
                _connection.Open();
                var payment = (await _connection.QueryAsync<Payment>(paymentSql, new { id = id })).FirstOrDefault();
                if (payment != null)
                {
                    var source = (await _connection.QueryAsync<PaymentSource>(sourceSql, new { id = payment.Source_Id })).FirstOrDefault();
                    payment.Source = source;
                }

                return payment;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<string> CreatePayment(Payment payment)
        {
            var sourceSql = "INSERT INTO public.payment_sources (card_type, expiry_month, expiry_year, card_name, last4, scheme) VALUES (@type, @expiry_Month, @expiry_Year, @name, @last4, @scheme) RETURNING id;";
            var paymentSql = "INSERT INTO public.payments (amount, currency, approved, payment_status, auth_code, reference, source_id) VALUES (@amount, @currency, @approved, @status, @auth_code, @reference, @source_id) RETURNING id;";

            try
            {
                _connection.Open();
                using (var transaction = _connection.BeginTransaction())
                {
                    var sourceId = (await _connection.QueryAsync<string>(sourceSql,
                        new
                        {
                            type = payment.Source.Type,
                            expiry_Month = payment.Source.Expiry_Month,
                            expiry_Year = payment.Source.Expiry_Year,
                            name = payment.Source.Name,
                            last4 = payment.Source.Last4,
                            scheme = payment.Source.Scheme
                        })).FirstOrDefault();

                    var paymentId = (await _connection.QueryAsync<string>(paymentSql,
                        new
                        {
                            amount = payment.Amount,
                            currency = payment.Currency,
                            approved = payment.Approved,
                            status = payment.Status,
                            auth_code = payment.AuthCode,
                            reference = payment.Reference,
                            source_id = sourceId
                        })).FirstOrDefault();


                    transaction.Commit();

                    return paymentId;
                }

            }
            catch (Exception e)
            {
                return null;
            }

        }
    }
}
