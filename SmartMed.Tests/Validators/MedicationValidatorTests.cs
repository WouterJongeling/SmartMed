using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartMed.ViewModels;
using SmartMed.Validators;
using System;
using SmartMed.Models;

namespace SmartMed.Tests.Validators
{
    [TestClass]
    public class MedicationValidatorTests
    {
        private IFixture _fixture;
        private MedicationValidator _validator;

        [TestInitialize]
        public void Setup()
        {
            _fixture = new Fixture();
            _validator = new MedicationValidator();
        }

        [TestMethod]
        [DataRow(1, true)]
        [DataRow(0, false)]
        [DataRow(-1, false)]
        public void QuantityValidation_ShouldBeCorrect(int quantity, bool expectedResult)
        {
            // Arrange
            var createModel = new Medication(_fixture.Create<Guid>(), _fixture.Create<String>(), quantity, _fixture.Create<DateTime>());

            // Act
            var result = _validator.Validate(createModel);

            // Assert

            result.Should().Be(expectedResult);
        }

    }
}
