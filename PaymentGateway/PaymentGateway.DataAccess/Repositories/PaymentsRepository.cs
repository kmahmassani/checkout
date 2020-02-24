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
            var paymentSql = "SELECT id, amount, currency, approved, payment_status as status, auth_code, processed_on as ProcessedOn, reference, source_id, resp_code as ResponseCode FROM public.payments WHERE id = @id";
           
            try
            {
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();

                var payment = (await _connection.QueryAsync<Payment>(paymentSql, new { id = id })).FirstOrDefault();
                if (payment != null)
                {
                    var source = await GetPaymentSourceAsync(payment.Source_Id);
                    payment.Source = source;
                }

                return payment;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                _connection.Close();
            }
        }


        public async Task<Payment> CreatePayment(Payment payment)
        {
            var sourceSql = "INSERT INTO public.payment_sources (card_type, expiry_month, expiry_year, card_name, last4, scheme) " +
                            "VALUES (@type, @expiry_Month, @expiry_Year, @name, @last4, @scheme) " +
                            "RETURNING id, card_type as type, expiry_month, expiry_year, card_name as name, last4, scheme;";

            var paymentSql = "INSERT INTO public.payments (amount, currency, approved, payment_status, auth_code, reference, source_id, resp_code) " +
                                "VALUES (@amount, @currency, @approved, @status, @auth_code, @reference, @source_id, @resp_code) " +
                                "RETURNING id, amount, currency, approved, payment_status as status, auth_code, processed_on as ProcessedOn, reference, source_id, resp_code as ResponseCode;";

            try
            {
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();

                using (var transaction = _connection.BeginTransaction())
                {
                    var source = (await _connection.QueryAsync<PaymentSource>(sourceSql,
                        new
                        {
                            type = payment.Source.Type,
                            expiry_Month = payment.Source.Expiry_Month,
                            expiry_Year = payment.Source.Expiry_Year,
                            name = payment.Source.Name,
                            last4 = payment.Source.Last4,
                            scheme = payment.Source.Scheme
                        })).FirstOrDefault();

                    var savedPayment = (await _connection.QueryAsync<Payment>(paymentSql,
                        new
                        {
                            amount = payment.Amount,
                            currency = payment.Currency,
                            approved = payment.Approved,
                            status = payment.Status,
                            auth_code = payment.AuthCode,
                            reference = payment.Reference,
                            source_id = source.Id,
                            resp_code = payment.ResponseCode
                        })).FirstOrDefault();


                    transaction.Commit();

                    return savedPayment;
                }

            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                _connection.Close();
            }

        }

        public async Task<Payment> UpdatePaymentStatus(string paymentId, bool approved, string authCode, string status, string resp_code)
        {
            var sql = "UPDATE public.payments SET approved=@approved, payment_status=@status, auth_code=@authCode, resp_code=@resp_code WHERE id = @id " +
                "RETURNING id, amount, currency, approved, payment_status as status, auth_code, processed_on as ProcessedOn, reference, source_id, resp_code as ResponseCode;";

            try
            {
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();

                var savedPayment = (await _connection.QueryAsync<Payment>(sql,
                        new
                        {
                            id = paymentId,
                            approved = approved,
                            authCode = authCode, //maybe null so need to cast it
                            status = status,
                            resp_code = resp_code
                        })).FirstOrDefault();

                savedPayment.Source = await GetPaymentSourceAsync(savedPayment.Source_Id);

                return savedPayment;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                _connection.Close();
            }
            
        }

        private async Task<PaymentSource> GetPaymentSourceAsync(string sourceId)
        {
            var sourceSql = "SELECT id, card_type as type, expiry_month, expiry_year, card_name as name, last4, scheme FROM public.payment_sources WHERE id = @id";
            try
            {
                if (_connection.State == ConnectionState.Closed)
                    _connection.Open();
                
                var source = (await _connection.QueryAsync<PaymentSource>(sourceSql, new { id = sourceId })).FirstOrDefault();
                   
                return source;
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
