using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentGateway.Domain.Annotations;

namespace PaymentGateway.DomainTests.Annotations
{
    [TestClass]
    public class CurrencyAttributeTests
    {
        [TestMethod]
        public void EmptyAndNullShouldNotValidate()
        {
            var attr = new ISOCurrencyAttribute();

            Assert.IsNotNull(attr.IsValid(""));
            Assert.IsNotNull(attr.IsValid(null));
        }

        [TestMethod]
        public void InvalidCodeShouldNotValidate()
        {
            var attr = new ISOCurrencyAttribute();

            Assert.IsFalse(attr.IsValid("gold"));
            Assert.IsFalse(attr.IsValid("CAPS"));
        }

        [TestMethod]
        public void AllValidCodesShouldValidate()
        {
            var codes = new string[] {"AFN","EUR","ALL","DZD","USD","EUR","AOA","XCD","XCD","ARS","AMD","AWG","AUD","EUR","AZN","BSD","BHD",
                "BDT","BBD","BYN","EUR","BZD","XOF","BMD","INR","BTN","BOB","USD","BAM","BWP","NOK","BRL","USD","BND","BGN","XOF","BIF","CVE",
                "KHR","XAF","CAD","KYD","XAF","XAF","CLP","CNY","AUD","AUD","COP","KMF","CDF","XAF","NZD","CRC","XOF","HRK","CUP","ANG","EUR",
                "CZK","DKK","DJF","XCD","DOP","USD","EGP","USD","XAF","ERN","EUR","ETB","EUR","FKP","DKK","FJD","EUR","EUR","EUR","XPF","EUR",
                "XAF","GMD","GEL","EUR","GHS","GIP","EUR","DKK","XCD","EUR","USD","GTQ","GBP","GNF","XOF","GYD","HTG","USD","AUD","EUR","HNL",
                "HKD","HUF","ISK","INR","IDR","XDR","IRR","IQD","EUR","GBP","ILS","EUR","JMD","JPY","GBP","JOD","KZT","KES","AUD","KPW","KRW",
                "KWD","KGS","LAK","EUR","LBP","ZAR","LRD","LYD","CHF","EUR","EUR","MOP","MKD","MGA","MWK","MYR","MVR","XOF","EUR","USD","EUR",
                "MRU","MUR","EUR","MXN","USD","MDL","EUR","MNT","EUR","XCD","MAD","MZN","MMK","NAD","ZAR","AUD","NPR","EUR","XPF","NZD","NIO",
                "XOF","NGN","NZD","AUD","USD","NOK","OMR","PKR","USD","PAB","USD","PGK","PYG","PEN","PHP","NZD","PLN","EUR","USD","QAR","EUR",
                "RON","RUB","RWF","EUR","SHP","XCD","XCD","EUR","EUR","XCD","WST","EUR","STN","SAR","XOF","RSD","SCR","SLL","SGD","ANG",
                "EUR","EUR","SBD","SOS","ZAR","SSP","EUR","LKR","SDG","SRD","NOK","SZL","SEK","CHF","SYP","TWD","TJS","TZS","THB",
                "USD","XOF","NZD","TOP","TTD","TND","TRY","TMT","USD","AUD","UGX","UAH","AED","GBP","USD","USD","UYU","UZS",
                "VUV","VES","VND","USD","USD","XPF","MAD","YER","ZMW"};
            var attr = new ISOCurrencyAttribute();

            foreach (var code in codes)
            {
                Assert.IsTrue(attr.IsValid(code), code);
            }           
        }
    }
}
