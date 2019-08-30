using ATINV.Repository;
using System;
using Xunit;
using Moq;
using ATINV.Business;
using ATINV.Model;
using System.Linq;
using ATINV.Utils;

namespace ATINV.Tests
{
    public class MovimentBusinessTests
    {
        [Fact]
        public void ShouldCallRepository()
        {
            var uowMock = new Mock<IUnitOfWork>();
            var repositoryMock = new Mock<IMovimentRepository>();
            
            var obj = new Moviment()
            {
                Amount = 50,
                Cpf = "59732481005",
                Date = DateTime.Today,
                FundId = Guid.NewGuid(),
                MovimentType = MovimentType.Application
            };

            repositoryMock.Setup(i => i.Save(obj)).Verifiable();

            var business = new MovimentBusiness(uowMock.Object, repositoryMock.Object);
            business.Save(obj);

            repositoryMock.Verify(i => i.Save(obj), Times.Once);
        }

        [Fact]
        public void ShouldReturnResponse()
        {
            var uowMock = new Mock<IUnitOfWork>();
            var repositoryMock = new Mock<IMovimentRepository>();

            var obj = new Moviment()
            {
                Amount = 50,
                Cpf = "59732481005",
                Date = DateTime.Today,
                FundId = Guid.NewGuid(),
                MovimentType = MovimentType.Application
            };

            repositoryMock.Setup(i => i.Save(obj)).Verifiable();

            var business = new MovimentBusiness(uowMock.Object, repositoryMock.Object);
            var response = business.Save(obj);

            Assert.True(200 == (int)response.StatusCode
                && response.Messages.Count == 0);
        }

        [Fact]
        public void ShouldValidateCpf()
        {
            var uowMock = new Mock<IUnitOfWork>();
            var repositoryMock = new Mock<IMovimentRepository>();

            var obj = new Moviment()
            {
                Amount = 50,
                Cpf = "59712481005",
                Date = DateTime.Today,
                FundId = Guid.NewGuid(),
                MovimentType = MovimentType.Redemption
            };

            repositoryMock.Setup(i => i.Save(obj)).Verifiable();

            var business = new MovimentBusiness(uowMock.Object, repositoryMock.Object);
            var response = business.Save(obj);

            Assert.True(StatusCode.BadRequest == response.StatusCode
                && response.Messages.Any(i=>i == "É necessário informar um CPF válido"));

            repositoryMock.Verify(i => i.Save(obj), Times.Never);
        }
        [Fact]
        public void ShouldValidateFields()
        {
            var uowMock = new Mock<IUnitOfWork>();
            var repositoryMock = new Mock<IMovimentRepository>();

            var obj = new Moviment();

            repositoryMock.Setup(i => i.Save(obj)).Verifiable();

            var business = new MovimentBusiness(uowMock.Object, repositoryMock.Object);
            var response = business.Save(obj);

            Assert.True(StatusCode.BadRequest == response.StatusCode
                && response.Messages.Any(i => i == "É necessário informar um fundo para aplicação/resgate")
                && response.Messages.Any(i => i == "É necessário informar o CPF para aplicação/resgate")
                && response.Messages.Any(i => i == "É necessário informar a data para aplicação/resgate")
                && response.Messages.Any(i => i == "É necessário informar o valor para aplicação/resgate"));

            repositoryMock.Verify(i => i.Save(obj), Times.Never);
        }
    }
}
