using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using PaymentGateway.API.Attributes;
using PaymentGateway.Domain.HttpModels;
using PaymentGateway.Domain.Interfaces;
using System.Threading.Tasks;
using AutoMapper;
using PaymentGateway.Domain.POCOs;

namespace PaymentGateway.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class PaymentsApiController : ControllerBase
    {
        private readonly IPaymentsBusinessLogic _businessLogic;       

        public PaymentsApiController(IPaymentsBusinessLogic businessLogic)
        {
            _businessLogic = businessLogic;
        }            



        /// <summary>
        /// Get payment details
        /// </summary>
        /// <remarks>Returns the details of the payment with the specified identifier string.  If the payment method requires a redirection to a third party (e.g., 3D Secure), the redirect URL back to your site will include a &#x60;cko-session-id&#x60; query parameter containing a payment session ID that can be used to obtain the details of the payment, for example:  http://example.com/success?cko-session-id&#x3D;sid_ubfj2q76miwundwlk72vxt2i7q. </remarks>
        /// <param name="authorization">Your valid merchant account secret key</param>
        /// <param name="id">The payment or payment session identifier</param>
        /// <response code="200">Payment retrieved successfully</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="404">Payment not found</response>
        [HttpGet]
        [Route("/payments/{id}")]
        [ValidateModelState]
        [SwaggerOperation("PaymentsIdGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(PaymentResponse), description: "Payment retrieved successfully")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public virtual async Task<IActionResult> PaymentsIdGet([FromHeader][Required()]string authorization, [FromRoute][Required][RegularExpression(@"^(pay|sid)_(\w{26})$")]string id)
        {             
            var payment = await _businessLogic.GetPaymentById(id);

            if (payment == null)
            {
                return StatusCode(404);
            }                      

            return new ObjectResult(payment);
        }

        /// <summary>
        /// Request a payment
        /// </summary>
        /// <remarks>To verify the success of the payment, check the &#x60;approved&#x60; field in the response. </remarks>
        /// <param name="authorization">Your valid merchant account secret key</param>
        /// <param name="contentType"></param>
        /// <param name="body"></param>
        /// <response code="201">Payment processed successfully</response>
        /// <response code="401">Unauthorized</response>
        /// <response code="422">Invalid data was sent</response>
        /// <response code="502">Bad gateway</response>
        [HttpPost]
        [Route("/payments")]
        [ValidateModelState]
        [SwaggerOperation("PaymentsPost")]
        [SwaggerResponse(statusCode: 201, type: typeof(PaymentResponse), description: "Payment processed successfully")]
        [SwaggerResponse(statusCode: 422, type: typeof(ValidationError), description: "Invalid data was sent")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public virtual async Task<IActionResult> PaymentsPost([FromHeader][Required()]string authorization, [FromBody]PaymentRequest body)
        {             
            var payment = await _businessLogic.CreatePayment(body);

            var response = new ObjectResult(payment);
            response.StatusCode = 201;
            
            return response;
        }
    }
}
