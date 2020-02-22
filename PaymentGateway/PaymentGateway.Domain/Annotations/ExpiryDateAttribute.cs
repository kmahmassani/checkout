using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PaymentGateway.Domain.Annotations
{
    public class ExpiryDateAttribute : RangeAttribute
    {
        public ExpiryDateAttribute() : base(DateTime.Now.Year, DateTime.Now.Year + 10)
        {
        }
    }
}
