using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartMed.Dbo;
using SmartMed.Dto;
using SmartMed.Models;
using System;

namespace SmartMed.Tests.Mapper
{
    [TestClass]
    public class MapperTests
    {
        private IFixture _fixture;
        private IMapper _mapper;
        
        [TestInitialize]
        public void Setup()
        {
            _fixture = new Fixture();
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile(new SmartMedMapperProfile())).CreateMapper();
        }

        [TestMethod]
        public void Test_EntityToViewModelMap()
        {
            // Arrange
            var entity = _fixture.Create<Medication>();

            // Act
            var result = _mapper.Map<MedicationViewModel>(entity);

            // Assert
            result.Id.Should().Be(entity.Id);
            result.Name.Should().Be(entity.Name);
            result.Quantity.Should().Be(entity.Quantity);
            result.CreationDate.Should().Be(entity.CreationDate);
        }

        [TestMethod]
        public void Test_CreateModelToEntityMap()
        {
            // Arrange
            var createModel = _fixture.Create<MedicationCreateModel>();

            // Act
            var result = _mapper.Map<Medication>(createModel);

            // Assert
            result.Id.Should().Be(new Guid());
            result.Name.Should().Be(createModel.Name);
            result.Quantity.Should().Be(createModel.Quantity);
            result.CreationDate.Should().Be(new DateTime());
        }

        [TestMethod]
        public void Test_EntityToDboMap()
        {
            // Arrange
            var entity = _fixture.Create<Medication>();

            // Act
            var result = _mapper.Map<MedicationDbo>(entity);

            // Assert
            result.Id.Should().Be(entity.Id);
            result.Name.Should().Be(entity.Name);
            result.Quantity.Should().Be(entity.Quantity);
            result.CreationDate.Should().Be(entity.CreationDate);
        }

        [TestMethod]
        public void Test_DboToEntityMap()
        {
            // Arrange
            var dbo = _fixture.Create<MedicationDbo>();

            // Act
            var result = _mapper.Map<Medication>(dbo);

            // Assert
            result.Id.Should().Be(dbo.Id);
            result.Name.Should().Be(dbo.Name);
            result.Quantity.Should().Be(dbo.Quantity);
            result.CreationDate.Should().Be(dbo.CreationDate);
        }
    }
}
