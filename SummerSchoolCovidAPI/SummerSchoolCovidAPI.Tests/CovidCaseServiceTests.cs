using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SummerSchoolCovidAPI.Interfaces;
using SummerSchoolCovidAPI.Models;
using SummerSchoolCovidAPI.Models.DTO;
using SummerSchoolCovidAPI.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SummerSchoolCovidAPI.Tests
{
    [TestClass]
    public class CovidCaseServiceTests
    {
        private CovidAPIContext _dbContext;
        private DbContextOptions<CovidAPIContext> _dbContextOptions;
        private ICovidCaseService _service;

        private readonly InfectedUser _infectedUser = new InfectedUser
        {
            Email = "test-user@test.co.za",
            Id = "user-1",
            Infected = true,
            Location = "Durban",
            MobileNumber = "0382147864",
            Name = "Bheki",
            Surname = "Zulu"
        };

        [TestInitialize]
        public async Task Setup()
        {
            _dbContextOptions = new DbContextOptionsBuilder<CovidAPIContext>().UseInMemoryDatabase(databaseName: "CovidAPI").Options;
            _dbContext = new CovidAPIContext(_dbContextOptions);

            // This ensures that the FabrikMixedContentDbContext is flushed before every test.
            await _dbContext.Database.EnsureDeletedAsync();
            _service = new CovidCaseService(_dbContext);

            _dbContext.InfectedUsers.Add(_infectedUser);

            await _dbContext.SaveChangesAsync();
        }

        [TestMethod]
        public async Task AddCovidCase_GivenValidInput_ShouldAddCovidCaseSuccessfully()
        {
            //Arrange
            var covidCaseDto = new CovidCaseDTO
            {
                DoctorName = "Zama Dlamini",
                Id = "case-1",
                InfectedUserId = _infectedUser.Id,
                TestLocation = "South Africa, Durban",
                DateActioned = DateTime.Now
            };

            //Act
            var entityAdded = await _service.AddCovidCase(covidCaseDto);

            //Assert
            Assert.AreEqual(covidCaseDto.DoctorName, entityAdded.DoctorName);
            Assert.AreEqual(covidCaseDto.Id, entityAdded.Id);
            Assert.AreEqual(covidCaseDto.InfectedUserId, entityAdded.InfectedUserId);
            Assert.AreEqual(covidCaseDto.TestLocation, entityAdded.TestLocation);
            Assert.AreEqual(1, await _dbContext.CovidCases.CountAsync());
        }

        [TestMethod]
        public async Task GetCovidCases_GivenTwoExist_ShouldReturnTwoCovidCases()
        {
            //Arrange
            var covidCaseDto1 = new CovidCaseDTO
            {
                DoctorName = "Zama Dlamini",
                Id = "case-1",
                InfectedUserId = _infectedUser.Id,
                TestLocation = "South Africa, Durban",
                DateActioned = DateTime.Now
            };
            var covidCaseDto2 = new CovidCaseDTO
            {
                DoctorName = "Joe Zuma",
                Id = "case-2",
                InfectedUserId = _infectedUser.Id,
                TestLocation = "South Africa, Durban North",
                DateActioned = DateTime.Now
            };

            await _service.AddCovidCase(covidCaseDto1);
            await _service.AddCovidCase(covidCaseDto2);

            //Act
            var entities = await _service.GetCovidCases();

            //Assert
            Assert.AreEqual(2, entities.Count());
            Assert.IsTrue(entities.Any(a => a.DoctorName == covidCaseDto1.DoctorName));
            Assert.IsTrue(entities.Any(a => a.DoctorName == covidCaseDto2.DoctorName));
            Assert.IsTrue(entities.Any(a => a.TestLocation == covidCaseDto1.TestLocation));
            Assert.IsTrue(entities.Any(a => a.TestLocation == covidCaseDto2.TestLocation));
            Assert.IsTrue(entities.Any(a => a.Id == covidCaseDto1.Id));
            Assert.IsTrue(entities.Any(a => a.Id == covidCaseDto2.Id));
            Assert.AreEqual(2, await _dbContext.CovidCases.CountAsync());
        }
    }
}