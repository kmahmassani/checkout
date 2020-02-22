using System;
using System.ComponentModel.DataAnnotations;

namespace PaymentGateway.Domain.Annotations
{
    public class ExpiryDateAttribute : RangeAttribute
    {
        public ExpiryDateAttribute() : base(DateTime.Now.Year, DateTime.Now.Year + 10)
        {            
        }
    }
}
