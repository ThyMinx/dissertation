using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using QualityMonitoringSystem.Controllers;
using QualityMonitoringSystem.Interfaces;
using QualityMonitoringSystem.Models;
using Shouldly;

namespace QualityMonitoringSystem.Tests
{
    [TestClass]
    public class StaffsTests
    {
        private readonly Mock<IDatabaseAccess<Staff>> staffDbMock = new Mock<IDatabaseAccess<Staff>>();

        [TestMethod]
        public async Task Index_Always_CallsGetAllAsync()
        {
            // Arrange
            var staff = new List<Staff> {
                    new Staff{ Email="johnwhelan@hull.ac.uk", Forenames="John", Surname="Whelan", ID=69, Password="wheelanabout"},
                    new Staff{ Email="jamescairns@hull.ac.uk", Forenames="James", Surname="Cairns", ID=79, Password="pokemon8"}
                };
            var sut = SystemUnderTest();
            this.staffDbMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(staff));
            sut.databaseAccess = this.staffDbMock.Object;

            // Act
            var result = await sut.Index();

            // Assert
            this.staffDbMock.Verify(x => x.GetAllAsync(), Times.Once);
        }

        [TestMethod]
        public async Task Index_Always_ReturnsListofStaff()
        {
            // Arrange
            var staff = new List<Staff> {
                    new Staff{ Email="johnwhelan@hull.ac.uk", Forenames="John", Surname="Whelan", ID=69, Password="wheelanabout"},
                    new Staff{ Email="jamescairns@hull.ac.uk", Forenames="James", Surname="Cairns", ID=79, Password="pokemon8"}
                };

            var sut = SystemUnderTest();
            this.staffDbMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(staff));
            sut.databaseAccess = this.staffDbMock.Object;

            // Act
            var result = await sut.Index();

            // Assert
            ((ViewResult)result).Model.ShouldBe(staff);
        }

        private StaffsController SystemUnderTest()
        {
            return new StaffsController();
        }
    }
}
