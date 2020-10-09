using BusinessLayer.Managers;
using Common.Converter;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ServiceLayer.DataTransferObjects;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Controllers;

namespace UnitTests.WebApi.Controllers
{
    [TestClass]
    public class CategoriesControllerTests
    {
        private IQueryable<CategoryModel> _models;
        private IEnumerable<CategoryDto> _dtos;

        [TestInitialize]
        public void TestInitialize()
        {
            var categoryModelsList = new List<CategoryModel>()
            {
                new CategoryModel()
                {
                    Id = 1,
                    Name = "First"
                },
                new CategoryModel()
                {
                    Id = 1,
                    Name = "Second"
                }
            };
            _models = categoryModelsList.AsQueryable();

            var categoryDtosList = new List<CategoryDto>()
            {
                new CategoryDto()
                {
                    Id = 1,
                    Name = "First"
                },
                new CategoryDto()
                {
                    Id = 1,
                    Name = "Second"
                }
            };
            _dtos = categoryDtosList.AsQueryable();
        }

        [TestMethod]
        public void CategoriesController_Get_ReturnsCategoryDtosList()
        {
            // Arrange
            var managerMock = new Mock<ICategoryManager>();
            managerMock
                .Setup(m => m.GetAll())
                .Returns(_models);

            var converterMock = new Mock<IConverter<CategoryDto, CategoryModel>>();
            converterMock
                .Setup(c => c.ConvertFrom(It.IsAny<IEnumerable<CategoryModel>>()))
                .Returns(_dtos);

            var categoriesController = new CategoriesController(managerMock.Object, converterMock.Object);

            var expected = _dtos;

            // Act
            var result = categoriesController.Get();
            var actual = result as OkObjectResult;

            // Assert            
            Assert.AreEqual(expected, actual.Value);
        }

        [TestMethod]
        public void CategoriesController_Get_ReturnsStatusCode200()
        {
            // Arrange
            var managerMock = new Mock<ICategoryManager>();
            managerMock
                .Setup(m => m.GetAll())
                .Returns(_models);

            var converterMock = new Mock<IConverter<CategoryDto, CategoryModel>>();
            converterMock
                .Setup(c => c.ConvertFrom(It.IsAny<IEnumerable<CategoryModel>>()))
                .Returns(_dtos);

            var categoriesController = new CategoriesController(managerMock.Object, converterMock.Object);

            // Act
            var result = categoriesController.Get();
            var actual = result as OkObjectResult;

            // Assert            
            Assert.AreEqual(200, actual.StatusCode);
        }
    }
}
