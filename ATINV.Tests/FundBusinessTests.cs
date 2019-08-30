using ATINV.Repository;
using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using ATINV.Business;
using ATINV.Model;
using System.Linq;

namespace ATINV.Tests
{
    public class FundBusinessTests
    {
        [Fact]
        public void ShouldCallRepository()
        {
            var uowMock = new Mock<IUnitOfWork>();
            var repositoryMock = new Mock<IFundRepository>();
            var fundId = Guid.NewGuid();
            var fundName = "XPTO";
            var fundMinContr = 500;
            var fundCnpj = "38970657000154";

            repositoryMock.Setup(i => i.List()).Returns(new List<Fund>()
            {
                new Fund(){ Id = fundId, Name = fundName, MinInicialContribution = fundMinContr, Cnpj = fundCnpj}
            }).Verifiable();
            var business = new FundBusiness(uowMock.Object, repositoryMock.Object);
            business.List();

            repositoryMock.Verify(i => i.List(), Times.Once);
        }

        [Fact]
        public void ShouldReturnResponse()
        {
            var uowMock = new Mock<IUnitOfWork>();
            var repositoryMock = new Mock<IFundRepository>();
            var fundId = Guid.NewGuid();
            var fundName = "XPTO";
            var fundMinContr = 500;
            var fundCnpj = "38970657000154";

            repositoryMock.Setup(i => i.List()).Returns(new List<Fund>()
            {
                new Fund(){ Id = fundId, Name = fundName, MinInicialContribution = fundMinContr, Cnpj = fundCnpj}
            }).Verifiable();
            var business = new FundBusiness(uowMock.Object, repositoryMock.Object);
            var response = business.List();

            Assert.True(200 == (int)response.StatusCode
                && response.Messages.Count == 0
                && response.Entity.First().Cnpj == fundCnpj
                && response.Entity.First().Id == fundId
                && response.Entity.First().MinInicialContribution == fundMinContr
                && response.Entity.First().Name == fundName);
        }
    }
}
