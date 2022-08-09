using AutoFixture;
using AutoMapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SmartMed.Controllers;
using SmartMed.Dbo;
using SmartMed.Dto;
using SmartMed.Models;
using SmartMed.Repositories;
using System;
using System.Linq;

namespace SmartMed.Tests.Controllers
{
    [TestClass]
    public class MedicationControllerTests
    {
        private IFixture _fixture;
        private Mock<IMapper> _mapperMock;
        private Mock<IRepository<Medication>> _repositoryMock;
        private MedicationController _controller;

        [TestInitialize]
        public void Setup()
        {
            _fixture = new Fixture();
            _mapperMock = new Mock<IMapper>();
            _repositoryMock = new Mock<IRepository<Medication>>();
            _controller = new MedicationController(_mapperMock.Object, _repositoryMock.Object);
        }

        [TestMethod]
        public void GetAll_ShouldReturnCorrectViewModels()
        {
            // Arrange
            var entities = _fixture.CreateMany<Medication>(3).ToArray();
            var viewModels = _fixture.CreateMany<MedicationViewModel>(3).ToArray();

            for(int i = 0; i < entities.Length; i++)
            {
                _mapperMock.Setup(m => m.Map<MedicationViewModel>(entities[i])).Returns(viewModels[i]);
            }
            _repositoryMock.Setup(r => r.GetAll()).Returns(entities);

            // Act
            var result = _controller.GetAllMedications();

            // Assert
            result.Should().BeEquivalentTo(viewModels);
        }

        [TestMethod]
        public void Create_ShouldCreateId_AndAddToRepository()
        {
            // Arrange
            var createModel = _fixture.Create<MedicationCreateModel>();
            var entity1 = _fixture.Create<Medication>();
            var entity2 = _fixture.Create<Medication>();
            var viewModel = _fixture.Create<MedicationViewModel>();
            _mapperMock.Setup(m => m.Map<Medication>(createModel)).Returns(entity1);
            _mapperMock.Setup(m => m.Map<MedicationViewModel>(entity2)).Returns(viewModel);
            _repositoryMock.Setup(r => r.Add(entity1)).Returns(entity2);

            // Act
            var result = _controller.CreateMedication(createModel);

            // Assert
            result.Should().Be(viewModel);
            _repositoryMock.Verify(r => r.Add(entity1), Times.Once);
        }

        [TestMethod]
        public void Delete_ShouldCallRepository()
        {
            // Arrange
            var guid = Guid.NewGuid();

            // Act
            _controller.Delete(guid);

            // Assert
            _repositoryMock.Verify(r => r.Delete(guid), Times.Once);
        }
    }
}