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
    public class ProductManagerTests
    {
        private IQueryable<ProductModel> _models;

        [TestInitialize]
        public void TestInitialize()
        {
            var productModelsList = new List<ProductModel>()
            {
                new ProductModel()
                {
                    Id = 1,
                    Name = "First"
                },
                new ProductModel()
                {
                    Id = 1,
                    Name = "Second"
                }
            };
            _models = productModelsList.AsQueryable();
        }

        [TestMethod]
        public void ProductManager_GetAll_ReturnListOfProductModels()
        {
            // Arrange
            var mock = new Mock<IProductUnitOfWork>();
            mock
                .Setup(unit => unit.GetAll())
                .Returns(_models);
            var productManager = new ProductManager(mock.Object);
            var expected = _models;

            // Act
            var actual = productManager.GetAll();

            // Assert            
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ProductManager_Create_ReturnListOfCreatedProductModels()
        {
            // Arrange
            var mock = new Mock<IProductUnitOfWork>();
            mock
                .Setup(unit => unit.Create(It.IsAny<IEnumerable<ProductModel>>()))
                .Returns(_models);
            var productManager = new ProductManager(mock.Object);
            var expected = _models;

            // Act
            var actual = productManager.Create(_models.AsEnumerable());

            // Assert            
            Assert.AreEqual(expected, actual);
        }
    }
}
