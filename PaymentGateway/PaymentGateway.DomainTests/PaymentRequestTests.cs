using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentGateway.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaymentGateway.DomainTests
{
    [TestClass]
    public class PaymentRequestTests
    {
        [TestMethod]
        public void EmptyModelShouldThrowValidationErrors()
        {
            var model = new PaymentRequest();

            var results = TestModelHelper.Validate(model);

            Assert.IsTrue(results.Count > 0);
        }

        [TestMethod]
        public void FullModelShouldNotThrowValidationErrors()
        {
            var model = new PaymentRequest()
            {
                Amount = 10,
                Currency = "GBP",
                Reference = "ref",
                Source = new PaymentRequestSource()
                {
                    Cvv = "333",
                    ExpiryMonth = 12,
                    ExpiryYear = DateTime.Now.Year,
                    Name = "Kamal",
                    Number = "4111111111111111",
                    Type = "card"
                }
            };

            var results = TestModelHelper.Validate(model);

            Assert.IsTrue(results.Count == 0);
        }

        [TestMethod]
        public void ShouldHaveValidCurrency()
        {
            var model = new PaymentRequest()
            {
                Amount = 10,
                Currency = "GBP",
                Reference = "ref",
                Source = new PaymentRequestSource()
                {
                    Cvv = "333",
                    ExpiryMonth = 12,
                    ExpiryYear = DateTime.Now.Year,
                    Name = "Kamal",
                    Number = "4111111111111111",
                    Type = "card"
                }
            };

            var results = TestModelHelper.Validate(model);

            Assert.IsTrue(results.Count == 0);

            model.Currency = "xxx";
            results = TestModelHelper.Validate(model);

            Assert.IsTrue(results.Count == 1);
            
            model.Currency = "USD";
            results = TestModelHelper.Validate(model);

            Assert.IsTrue(results.Count == 0);

            model.Currency = "US";
            results = TestModelHelper.Validate(model);
            Assert.IsTrue(results.Count > 0);

            model.Currency = "USDD";
            results = TestModelHelper.Validate(model);
            Assert.IsTrue(results.Count > 0);
        }

        [TestMethod]
        public void AmountShouldBeAbove0()
        {
            var model = new PaymentRequest()
            {
                Amount = 10,
                Currency = "GBP",
                Reference = "ref",
                Source = new PaymentRequestSource()
                {
                    Cvv = "333",
                    ExpiryMonth = 12,
                    ExpiryYear = DateTime.Now.Year,
                    Name = "Kamal",
                    Number = "4111111111111111",
                    Type = "card"
                }
            };

            var results = TestModelHelper.Validate(model);

            Assert.IsTrue(results.Count == 0);

            model.Amount = 0;

            results = TestModelHelper.Validate(model);

            Assert.IsTrue(results.Count == 1);

            model.Amount = -1;

            results = TestModelHelper.Validate(model);

            Assert.IsTrue(results.Count == 1);
        }

        [TestMethod]
        public void SourceIsRequired()
        {
            var model = new PaymentRequest()
            {
                Amount = 10,
                Currency = "GBP",
                Reference = "ref"               
            };

            var results = TestModelHelper.Validate(model);

            Assert.IsTrue(results.Count == 1);
            Assert.IsTrue(results[0].MemberNames.Contains("Source"));
        }
    }
}
