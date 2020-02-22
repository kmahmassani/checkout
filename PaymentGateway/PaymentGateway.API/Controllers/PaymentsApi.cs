using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using PaymentGateway.API.Attributes;
using PaymentGateway.Domain.Models;

namespace PaymentGateway.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class PaymentsApiController : ControllerBase
    { 
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
        public virtual IActionResult PaymentsIdGet([FromHeader][Required()]string authorization, [FromRoute][Required][RegularExpression("/^(pay|sid)_(\\w{26})$/")]string id)
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(PaymentResponse));

            //TODO: Uncomment the next line to return response 401 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(401);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);
            //string exampleJson = null;
            //exampleJson = "{\n  \"reference\" : \"ORD-5023-4E89\",\n  \"amount\" : 6540,\n  \"approved\" : true,\n  \"_links\" : \"{\\"self\\":{\\"href\\":\\"https://api.checkout.com/payments/pay_y3oqhf46pyzuxjbcn2giaqnb44\\"}}\",\n  \"currency\" : \"USD\",\n  \"id\" : \"\",\n  \"source\" : \"\",\n  \"processed_on\" : \"\",\n  \"status\" : \"Authorized\",\n  \"auth_code\" : \"643381\"\n}";
            
            //            var example = exampleJson != null
            //            ? JsonConvert.DeserializeObject<PaymentResponse>(exampleJson)
            //            : default(PaymentResponse);            //TODO: Change the data returned
            return new ObjectResult("");
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
        public virtual IActionResult PaymentsPost([FromHeader][Required()]string authorization, [FromHeader][Required()]string contentType, [FromBody]PaymentRequest body)
        { 
            //TODO: Uncomment the next line to return response 201 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(201, default(PaymentResponse));

            //TODO: Uncomment the next line to return response 401 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(401);

            //TODO: Uncomment the next line to return response 422 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(422, default(ValidationError));

            //TODO: Uncomment the next line to return response 502 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(502);
            string exampleJson = null;
            //exampleJson = "{\n  \"reference\" : \"ORD-5023-4E89\",\n  \"amount\" : 6540,\n  \"approved\" : true,\n  \"_links\" : \"{\\"self\\":{\\"href\\":\\"https://api.checkout.com/payments/pay_y3oqhf46pyzuxjbcn2giaqnb44\\"}}\",\n  \"currency\" : \"USD\",\n  \"id\" : \"\",\n  \"source\" : \"\",\n  \"processed_on\" : \"\",\n  \"status\" : \"Authorized\",\n  \"auth_code\" : \"643381\"\n}";
            
            //            var example = exampleJson != null
            //            ? JsonConvert.DeserializeObject<PaymentResponse>(exampleJson)
            //            : default(PaymentResponse);            //TODO: Change the data returned
            return new ObjectResult("");
        }
    }
}
