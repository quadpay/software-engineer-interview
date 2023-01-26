using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Zip.InstallmentsService.DomainObjects;
using Zip.InstallmentsService.Interface;
using Zip.InstallmentsService.Test.TestHelpers;
using ZipPayment.API.Business.Services;
using ZipPayment.API.DataAccess.Entities;
using ZipPayment.API.DataAccess.Services;
using ZipPayment.API.MapperProfiles;
using ZipPayment.API.Models;

namespace Zip.InstallmentsService.Test
{
    public class PaymentServiceTests
    {
        private Mock<IPaymentFactory> _paymentFactoryMock;
        private Mock<IPaymentRepository> _paymentRepositoryMock;
        private Mock<IMapper> _iMapperMock;
        private Mock<IPaymentPlanner> _paymentPlannerMock;

        public PaymentServiceTests()
        {
            _paymentFactoryMock = new Mock<IPaymentFactory>();
            _paymentRepositoryMock = new Mock<IPaymentRepository>();
            _iMapperMock = new Mock<IMapper>();
            _paymentPlannerMock = new Mock<IPaymentPlanner>();
        }

        [Fact]
        public void Given_PaymentFactory_PaymentRepository_And_Null_Mapper_Object_Instance_When_Create_Instance_Then_Throws_ArgumentNullException()
        {
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => new PaymentService(_paymentFactoryMock.Object, _paymentRepositoryMock.Object, null));
        }

        [Fact]
        public void Given_PaymentFactory_Null_PaymentRepository_And_Mapper_Object_Instance_When_Create_Instance_Then_Throws_ArgumentNullException()
        {
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => new PaymentService(_paymentFactoryMock.Object, null, _iMapperMock.Object));
        }

        [Fact]
        public void Given_Null_PaymentFactory_PaymentRepository_And_Mapper_Object_Instance_When_Create_Instance_Then_Throws_ArgumentNullException()
        {
            //Act
            //Assert
            Assert.Throws<ArgumentNullException>(() => new PaymentService(null, _paymentRepositoryMock.Object, _iMapperMock.Object));
        }

        [Fact]
        public async Task Given_PaymentFactory_PaymentRepository_And_Mapper_Object_Instance_When_Called_GetAllPaymentPlansAsync_Then_Returns_List_Of_PaymentPlanDto()
        {
            //Arrange
            _paymentRepositoryMock.Setup(t => t.GetPaymentPlansAsync()).ReturnsAsync(TestHelper.GetTestPaymentPlanEntities(100M,50M));
            _iMapperMock.Setup(t => t.Map<PaymentPlanEntity, PaymentPlanDto>(It.IsAny<PaymentPlanEntity>())).Returns(new PaymentPlanDto());
            
            var paymentService = new PaymentService(_paymentFactoryMock.Object, _paymentRepositoryMock.Object, _iMapperMock.Object);

            //Act
            var paymentPlans = await paymentService.GetAllPaymentPlansAsync();

            //Assert
            Assert.All(paymentPlans, t => Assert.True(t.PurchaseAmount == 100M));
        }

        [Fact]
        public async Task Given_PaymentFactory_PaymentRepository_And_Mapper_Object_Instance_When_Called_GetlPaymentPlanAsync_Then_Returns_PaymentPlanDto()
        {
            //Arrange
            var paymentPlanEntity = TestHelper.GetTestPaymentPlanEntities(100M, 50M).FirstOrDefault();
            _paymentRepositoryMock.Setup(t => t.GetPaymentPlanAsync(paymentPlanEntity.Id)).ReturnsAsync(paymentPlanEntity);
            _iMapperMock.Setup(t => t.Map<PaymentPlanEntity, PaymentPlanDto>(It.IsAny<PaymentPlanEntity>())).Returns(new PaymentPlanDto() { Id= paymentPlanEntity .Id, PurchaseAmount= 100M});

            var paymentService = new PaymentService(_paymentFactoryMock.Object, _paymentRepositoryMock.Object, _iMapperMock.Object);

            //Act
            var paymentPlan = await paymentService.GetPaymentPlanAsync(paymentPlanEntity.Id);

            //Assert
            Assert.True(paymentPlan.PurchaseAmount == 100M);
        }

        [Fact]
        public async Task Given_PaymentFactory_PaymentRepository_And_Mapper_Object_Instance_When_Called_GetlPaymentPlanAsync_Then_Returns_Null_PaymentPlanDto()
        {
            //Arrange
            var paymentPlanEntity = TestHelper.GetTestPaymentPlanEntities(100M, 50M).FirstOrDefault();
            _paymentRepositoryMock.Setup(t => t.GetPaymentPlanAsync(paymentPlanEntity.Id)).ReturnsAsync((PaymentPlanEntity)null);
            _iMapperMock.Setup(t => t.Map<PaymentPlanEntity, PaymentPlanDto>(It.IsAny<PaymentPlanEntity>())).Returns(new PaymentPlanDto());

            var paymentService = new PaymentService(_paymentFactoryMock.Object, _paymentRepositoryMock.Object, _iMapperMock.Object);

            //Act
            var paymentPlan = await paymentService.GetPaymentPlanAsync(paymentPlanEntity.Id);

            //Assert
            Assert.Null(paymentPlan);
        }

        [Fact]
        public async Task Given_PaymentFactory_PaymentRepository_And_Mapper_Object_Instance_When_Called_CreatePaymentPlanAsync_Then_Returns_PaymentPlanDto()
        {
            //Arrange
            var paymentPlanEntity = TestHelper.GetTestPaymentPlanEntities(1000M, 50M).FirstOrDefault();
            _paymentRepositoryMock.Setup(t => t.AddPaymentPlan(paymentPlanEntity)).Returns(It.IsAny<Task>());
            _paymentRepositoryMock.Setup(t => t.SaveChangesAsync()).ReturnsAsync(true);

            var installmentIds = new[] { Guid.NewGuid(), Guid.NewGuid() };

            _paymentPlannerMock.Setup(t => t.GetPaymentPlan(2, 4)).Returns(TestHelper.GetInstallments(installmentIds, 1000M, 2));
            _paymentFactoryMock.Setup(t => t.CreatePaymentPlan(1000M)).Returns(_paymentPlannerMock.Object);
            _iMapperMock.Setup(t => t.Map<Installment, InstallmentEntity>(It.IsAny<Installment>())).Returns(new InstallmentEntity(1000M));
            _iMapperMock.Setup(t => t.Map<PaymentPlanEntity, PaymentPlanDto>(It.IsAny<PaymentPlanEntity>())).Returns(new PaymentPlanDto()
                { 
                    Id = paymentPlanEntity.Id, 
                    PurchaseAmount = 1000M 
            });

            var paymentService = new PaymentService(_paymentFactoryMock.Object, _paymentRepositoryMock.Object, _iMapperMock.Object);

            //Act
            var paymentPlan = await paymentService.CreatePaymentPlan(1000M,2,4);

            //Assert
            Assert.NotNull(paymentPlan);
            Assert.True(paymentPlan.PurchaseAmount == 1000M);
            Assert.All(paymentPlan.Installments, t => Assert.True(t.Amount == 500M));
        }

        [Fact]
        public async Task Given_PaymentFactory_PaymentRepository_And_Mapper_Object_Instance_When_Called_CreatePaymentPlanAsync_AndUnable_To_SAve_In_Database_Then_Returns_Null()
        {
            //Arrange
            var paymentPlanEntity = TestHelper.GetTestPaymentPlanEntities(1000M, 50M).FirstOrDefault();
            _paymentRepositoryMock.Setup(t => t.AddPaymentPlan(paymentPlanEntity)).Returns(It.IsAny<Task>());
            _paymentRepositoryMock.Setup(t => t.SaveChangesAsync()).ReturnsAsync(false);

            var installmentIds = new[] { Guid.NewGuid(), Guid.NewGuid() };

            _paymentPlannerMock.Setup(t => t.GetPaymentPlan(2, 4)).Returns(TestHelper.GetInstallments(installmentIds, 1000M, 2));
            _paymentFactoryMock.Setup(t => t.CreatePaymentPlan(1000M)).Returns(_paymentPlannerMock.Object);
            _iMapperMock.Setup(t => t.Map<Installment, InstallmentEntity>(It.IsAny<Installment>())).Returns(new InstallmentEntity(1000M));
            _iMapperMock.Setup(t => t.Map<PaymentPlanEntity, PaymentPlanDto>(It.IsAny<PaymentPlanEntity>())).Returns(new PaymentPlanDto());

            var paymentService = new PaymentService(_paymentFactoryMock.Object, _paymentRepositoryMock.Object, _iMapperMock.Object);

            //Act
            var paymentPlan = await paymentService.CreatePaymentPlan(1000M, 2, 4);

            //Assert
            Assert.Null(paymentPlan);
        }
    }
}
