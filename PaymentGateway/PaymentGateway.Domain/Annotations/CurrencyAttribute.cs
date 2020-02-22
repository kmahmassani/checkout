using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;

namespace PaymentGateway.Domain.Annotations
{
    public class ISOCurrencyAttribute : ValidationAttribute
    {
        public ISOCurrencyAttribute()
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var curr = value?.ToString();

            if (string.IsNullOrEmpty(curr))
                return new ValidationResult("Missing Currency Code");

            return CurrencyTools.TryGetCurrencySymbol(curr) ? null : new ValidationResult("Missing Currency Code"); //Only specific cultures contain region information
        }
    }


    public static class CurrencyTools
    {
        private static string[] map;
        static CurrencyTools()
        {
            map = CultureInfo
                .GetCultures(CultureTypes.AllCultures)
                .Where(c => !c.IsNeutralCulture)
                .Select(culture =>
                {
                    try
                    {
                        return new RegionInfo(culture.Name);
                    }
                    catch
                    {
                        return null;
                    }
                })
                .Where(ri => ri != null)
                .Select(ri => ri.ISOCurrencySymbol)
                .Distinct().OrderBy(x => x).ToArray();
        }
        public static bool TryGetCurrencySymbol(string ISOCurrencySymbol)
        {
            return map.Contains(ISOCurrencySymbol.ToUpper());
        }
    }
}
