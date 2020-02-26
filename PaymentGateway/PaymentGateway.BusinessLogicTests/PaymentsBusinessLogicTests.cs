using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PaymentGateway.BusinessLogic;
using PaymentGateway.Domain.HttpModels;
using PaymentGateway.Domain.Interfaces;
using PaymentGateway.Domain.Mappings;
using PaymentGateway.Domain.POCOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentGateway.BusinessLogicTests
{
    [TestClass]
    public class PaymentsBusinessLogicTests
    {
        protected static IMapper mapper;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            var config = new MapperConfiguration(opts =>
            {
                opts.AddProfile(typeof(MappingProfiles));
            });

            mapper = config.CreateMapper();
        }

        [TestMethod]
        public async Task GetPaymentByIdWithNullOrEmptyShouldReturnNullDirectly()
        {
            Mock<IPaymentsRepository> paymentRepoMock = new Mock<IPaymentsRepository>();
            Mock<IBank> bankRepoMock = new Mock<IBank>();
            Mock<IMapper> mapperMock = new Mock<IMapper>();
            Mock<ILogger<IPaymentsBusinessLogic>> loggerMock = new Mock<ILogger<IPaymentsBusinessLogic>>();

            PaymentsBusinessLogic logic = new PaymentsBusinessLogic(paymentRepoMock.Object, bankRepoMock.Object, mapperMock.Object, loggerMock.Object);

            Assert.IsNull(await logic.GetPaymentById(null));
            Assert.IsNull(await logic.GetPaymentById(String.Empty));

            paymentRepoMock.VerifyNoOtherCalls();
            bankRepoMock.VerifyNoOtherCalls();
            mapperMock.VerifyNoOtherCalls();
            loggerMock.VerifyNoOtherCalls();
        }

        [TestMethod]
        public async Task GetPaymentByIdWithNonExistantPaymentShouldReturnNullGracefully()
        {
            Mock<IPaymentsRepository> paymentRepoMock = new Mock<IPaymentsRepository>();
            Mock<IBank> bankRepoMock = new Mock<IBank>();
            Mock<IMapper> mapperMock = new Mock<IMapper>();
            Mock<ILogger<IPaymentsBusinessLogic>> loggerMock = new Mock<ILogger<IPaymentsBusinessLogic>>();

            paymentRepoMock.Setup(x => x.GetPaymentById(It.IsAny<string>())).Returns(Task.FromResult<Payment>(null));

            PaymentsBusinessLogic logic = new PaymentsBusinessLogic(paymentRepoMock.Object, bankRepoMock.Object, mapperMock.Object, loggerMock.Object);
            Assert.IsNull(await logic.GetPaymentById("abcd"));

            paymentRepoMock.Verify(x => x.GetPaymentById("abcd"));

            paymentRepoMock.VerifyNoOtherCalls();
        }

        [TestMethod]
        public async Task GetPaymentByIdShouldReturnPaymentFromRepo()
        {
            Mock<IPaymentsRepository> paymentRepoMock = new Mock<IPaymentsRepository>();
            Mock<IBank> bankRepoMock = new Mock<IBank>();
            Mock<ILogger<IPaymentsBusinessLogic>> loggerMock = new Mock<ILogger<IPaymentsBusinessLogic>>();

            var testPayment = new Payment()
            {
                Id = "pay_id",
                Amount = 100
            };

            paymentRepoMock.Setup(x => x.GetPaymentById("pay_id")).Returns(Task.FromResult<Payment>(testPayment));

            PaymentsBusinessLogic logic = new PaymentsBusinessLogic(paymentRepoMock.Object, bankRepoMock.Object, mapper, loggerMock.Object);

            var result = await logic.GetPaymentById("pay_id");

            Assert.IsNotNull(result);

            Assert.IsTrue(result.Id == "pay_id");

            paymentRepoMock.Verify(x => x.GetPaymentById("pay_id"));

            paymentRepoMock.VerifyNoOtherCalls();
        }

        [TestMethod]
        public async Task CreatePaymentWithNullOrEmptyShouldReturnNullDirectly()
        {
            Mock<IPaymentsRepository> paymentRepoMock = new Mock<IPaymentsRepository>();
            Mock<IBank> bankRepoMock = new Mock<IBank>();
            Mock<IMapper> mapperMock = new Mock<IMapper>();
            Mock<ILogger<IPaymentsBusinessLogic>> loggerMock = new Mock<ILogger<IPaymentsBusinessLogic>>();

            PaymentsBusinessLogic logic = new PaymentsBusinessLogic(paymentRepoMock.Object, bankRepoMock.Object, mapperMock.Object, loggerMock.Object);

            Assert.IsNull(await logic.CreatePayment(null));

            paymentRepoMock.VerifyNoOtherCalls();
            bankRepoMock.VerifyNoOtherCalls();
            mapperMock.VerifyNoOtherCalls();
            loggerMock.VerifyNoOtherCalls();
        }

        [TestMethod]
        public async Task CreatePaymentShouldFirstSaveThePaymentAsCaptured()
        {
            Mock<IPaymentsRepository> paymentRepoMock = new Mock<IPaymentsRepository>();
            Mock<IBank> bankRepoMock = new Mock<IBank>();
            Mock<ILogger<IPaymentsBusinessLogic>> loggerMock = new Mock<ILogger<IPaymentsBusinessLogic>>();

            PaymentsBusinessLogic logic = new PaymentsBusinessLogic(paymentRepoMock.Object, bankRepoMock.Object, mapper, loggerMock.Object);

            var invocations = new List<string>();

            paymentRepoMock
                .Setup(x => x.CreatePayment(It.IsAny<Payment>()))
                .Callback<Payment>(x => invocations.Add(x.Status))
                .Returns((Payment x) => Task.FromResult<Payment>(x));

            paymentRepoMock
                .Setup(x => x.UpdatePaymentStatus(It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Callback((string id, bool appr, string auth, string status, string resp) => invocations.Add(status))
                .Returns((string id, bool appr, string auth, string status, string resp) => Task.FromResult<Payment>(new Payment()
                    {
                        Id = id,
                        Amount = 100,
                        Approved = appr,
                        AuthCode = auth,
                        Status = status, 
                        ResponseCode = resp
                    })
                );

            bankRepoMock
                .Setup(x => x.ProcessCardPost(It.IsAny<BankPaymentRequest>()))
                .Returns(Task.FromResult<BankPaymentResponse>(
                    new BankPaymentResponse()
                    {
                        Approved = true,
                        AuthCode = "123",
                        ResponseCode = "10000",
                        Id = "9999"
                    }
                 ));

            var testPaymentRequest = new PaymentRequest()
            {
                Amount = 100,
                Currency = "USD",
                Reference = "",
                Source = new PaymentRequestSource()
                {
                    Cvv = "123",
                    ExpiryMonth = 12,
                    ExpiryYear = 2020,
                    Name = "Test",
                    Number = "5555555555554444",
                    Type = "Visa"
                }
            };

            var result = await logic.CreatePayment(testPaymentRequest);

            Assert.IsNotNull(result);

            Assert.AreEqual(PaymentStatus.Captured, invocations[0]);
            Assert.AreEqual(PaymentStatus.Authorized, invocations[1]);

            paymentRepoMock.Verify(x => x.CreatePayment(It.IsAny<Payment>()), Times.Exactly(1));
            paymentRepoMock.Verify(x => x.UpdatePaymentStatus(It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(1));            
        }
    }
}
