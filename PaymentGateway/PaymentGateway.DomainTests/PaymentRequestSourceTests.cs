using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentGateway.Domain.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PaymentGateway.DomainTests
{
    [TestClass]
    public class PaymentRequestSourceTests
    {
        [TestMethod]
        public void EmptyModelShouldThrowValidationErrors()
        {
            var model = new PaymentRequestSource();

            var results = TestModelHelper.Validate(model);

            Assert.IsTrue(results.Count > 0);
        }

        [TestMethod]
        public void FullModelShouldNotThrowValidationErrors()
        {
            var model = new PaymentRequestSource()
            {
                Cvv = "333",
                ExpiryMonth = 12,
                ExpiryYear = DateTime.Now.Year,
                Name = "Kamal",
                Number = "4111111111111111",
                Type = "card"
            };

            var results = TestModelHelper.Validate(model);

            Assert.IsTrue(results.Count == 0);
        }

        [TestMethod]
        public void CVVShouldBeRequired()
        {
            var model = new PaymentRequestSource()
            {
                ExpiryMonth = 12,
                ExpiryYear = DateTime.Now.Year,
                Name = "Kamal",
                Number = "4111111111111111",
                Type = "card"
            };

            var results = TestModelHelper.Validate(model);

            Assert.IsTrue(results.Count == 1);
            Assert.IsTrue(results[0].MemberNames.Contains("Cvv"));
        }

        [TestMethod]
        public void ExpiryMonthShouldBeRequired()
        {
            var model = new PaymentRequestSource()
            {
                Cvv = "333",
                ExpiryYear = DateTime.Now.Year,
                Name = "Kamal",
                Number = "4111111111111111",
                Type = "card"
            };

            var results = TestModelHelper.Validate(model);

            Assert.IsTrue(results.Count == 1);
            Assert.IsTrue(results[0].MemberNames.Contains("ExpiryMonth"));
        }

        [TestMethod]
        public void ExpiryYearShouldBeRequired()
        {
            var model = new PaymentRequestSource()
            {
                Cvv = "333",
                ExpiryMonth = 12,
                Name = "Kamal",
                Number = "4111111111111111",
                Type = "card"
            };

            var results = TestModelHelper.Validate(model);

            Assert.IsTrue(results.Count == 1);
            Assert.IsTrue(results[0].MemberNames.Contains("ExpiryYear"));
        }

        [TestMethod]
        public void NumberShouldBeRequired()
        {
            var model = new PaymentRequestSource()
            {
                Cvv = "333",
                ExpiryMonth = 12,
                ExpiryYear = DateTime.Now.Year,
                Name = "Kamal",
                Type = "card"
            };

            var results = TestModelHelper.Validate(model);

            Assert.IsTrue(results.Count == 1);
            Assert.IsTrue(results[0].MemberNames.Contains("Number"));
        }

        [TestMethod]
        public void TypeShouldBeRequired()
        {
            var model = new PaymentRequestSource()
            {
                Cvv = "333",
                ExpiryMonth = 12,
                ExpiryYear = DateTime.Now.Year,
                Name = "Kamal",
                Number = "4111111111111111",
            };

            var results = TestModelHelper.Validate(model);

            Assert.IsTrue(results.Count == 1);
            Assert.IsTrue(results[0].MemberNames.Contains("Type"));
        }

        [TestMethod]
        public void CardNumberShouldHaveCorrectFormat()
        {
            var model = new PaymentRequestSource()
            {
                Cvv = "333",
                ExpiryMonth = 12,
                ExpiryYear = DateTime.Now.Year,
                Name = "Kamal",
                Number = "411111111111",
                Type = "card"
            };

            var results = TestModelHelper.Validate(model);

            Assert.IsTrue(results.Count == 1);
            Assert.IsTrue(results[0].MemberNames.Contains("Number"));

            model.Number = "A111111111111111";

            results = TestModelHelper.Validate(model);

            Assert.IsTrue(results.Count == 1);
            Assert.IsTrue(results[0].MemberNames.Contains("Number"));
        }

        [TestMethod]
        public void CVVLength()
        {
            var model = new PaymentRequestSource()
            {
                Cvv = "333",
                ExpiryMonth = 12,
                ExpiryYear = DateTime.Now.Year,
                Name = "Kamal",
                Number = "4111111111111111",
                Type = "card"
            };

            var results = TestModelHelper.Validate(model);

            Assert.IsTrue(results.Count == 0);

            model.Cvv = "33";

            results = TestModelHelper.Validate(model);

            Assert.IsTrue(results.Count == 1);
            Assert.IsTrue(results[0].MemberNames.Contains("Cvv"));

            model.Cvv = "3333";

            results = TestModelHelper.Validate(model);

            Assert.IsTrue(results.Count == 0);

            model.Cvv = "33333";

            results = TestModelHelper.Validate(model);

            Assert.IsTrue(results.Count == 1);
            Assert.IsTrue(results[0].MemberNames.Contains("Cvv"));
        }

        [TestMethod]
        public void ExpiryDateBetweenNowAndTenYears()
        {
            var model = new PaymentRequestSource()
            {
                Cvv = "333",
                ExpiryMonth = 12,
                ExpiryYear = DateTime.Now.Year,
                Name = "Kamal",
                Number = "4111111111111111",
                Type = "card"
            };

            var results = TestModelHelper.Validate(model);

            Assert.IsTrue(results.Count == 0);

            model.ExpiryYear = DateTime.Now.Year - 1;
            results = TestModelHelper.Validate(model);

            Assert.IsTrue(results.Count == 1);
            Assert.IsTrue(results[0].MemberNames.Contains("ExpiryYear"));

            model.ExpiryYear = DateTime.Now.Year + 5;
            results = TestModelHelper.Validate(model);

            Assert.IsTrue(results.Count == 0);

            model.ExpiryYear = DateTime.Now.Year + 10;
            results = TestModelHelper.Validate(model);

            Assert.IsTrue(results.Count == 0);

            model.ExpiryYear = DateTime.Now.Year + 11;
            results = TestModelHelper.Validate(model);

            Assert.IsTrue(results.Count == 1);
            Assert.IsTrue(results[0].MemberNames.Contains("ExpiryYear"));
        }

        [TestMethod]
        public void ExpiryMonthBetweenOneAndTwelve()
        {
            var model = new PaymentRequestSource()
            {
                Cvv = "333",
                ExpiryMonth = 1,
                ExpiryYear = DateTime.Now.Year,
                Name = "Kamal",
                Number = "4111111111111111",
                Type = "card"
            };

            for (int i = 0; i < 14; i++)
            {
                model.ExpiryMonth = i;

                var results = TestModelHelper.Validate(model);
                Assert.IsTrue(results.Count == (i > 0 && i <= 12 ? 0 : 1));
            }
        }
    }
}
