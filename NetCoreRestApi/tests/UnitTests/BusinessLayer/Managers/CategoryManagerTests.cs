using BusinessLayer.Managers;
using DataLayer.Models;
using DataLayer.UnitOfWorks.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.BusinessLayer.Managers
{
    [TestClass]
    public class CategoryManagerTests
    {
        private IQueryable<CategoryModel> _models;

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
        }

        [TestMethod]
        public void CategoryManager_GetAll_ReturnListOfCategoryModels()
        {
            // Arrange
            var mock = new Mock<ICategoryUnitOfWork>();
            mock
                .Setup(unit => unit.GetAll())
                .Returns(_models);
            var categoryManager = new CategoryManager(mock.Object);
            var expected = _models;

            // Act
            var actual = categoryManager.GetAll();

            // Assert            
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CategoryManager_Create_ReturnListOfCreatedCategoryModels()
        {
            // Arrange
            var mock = new Mock<ICategoryUnitOfWork>();
            mock
                .Setup(unit => unit.Create(It.IsAny<IEnumerable<CategoryModel>>()))
                .Returns(_models);
            var categoryManager = new CategoryManager(mock.Object);
            var expected = _models;

            // Act
            var actual = categoryManager.Create(_models.AsEnumerable());

            // Assert            
            Assert.AreEqual(expected, actual);
        }
    }
}
