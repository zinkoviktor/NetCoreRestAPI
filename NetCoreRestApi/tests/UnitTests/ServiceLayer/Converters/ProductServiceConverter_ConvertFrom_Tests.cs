using Common.Converter;
using DataLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLayer.Converters;
using ServiceLayer.DataTransferObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.ServiceLayer.Converters
{
    [TestClass]
    public class ProductServiceConverter_ConvertFrom_Tests
    {
        private IConverter<ProductDto, ProductModel> _productConverter;
        private IComparer _comparer;
        private Func<ProductDto, ProductDto, bool> _comparerPredicate;

        [TestInitialize]
        public void TestInitialize()
        {
            _productConverter = new ProductServiceConverter();

            _comparerPredicate = delegate (ProductDto dto1, ProductDto dto2)
            {
                return dto1.Id.Equals(dto2.Id) &&
                    dto1.Name.Equals(dto2.Name) &&
                    dto1.Description == dto2.Description &&
                    dto1.Price.Equals(dto2.Price) &&
                    dto1.AvailableCount.Equals(dto2.AvailableCount) &&
                    dto1.Categories == dto2.Categories;
            };

            _comparer = new CollectionEqualsComparer<ProductDto>(_comparerPredicate);
        }

        [TestMethod]
        public void Convert_FromProductModel_ItemsAreNotNull()
        {
            // Arrange           
            var productModels = new List<ProductModel>()
            {
                new ProductModel(),
                new ProductModel()
                {
                     Id = 1,
                    Name = "Test Name",
                    Description = "Test Description",
                    AvailableCount = 5,
                    Price = 19
                }
            };

            // Act
            var actual = _productConverter.ConvertFrom(productModels);

            // Assert            
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void Convert_FromProductEntities_ToProductModels()
        {
            // Arrange
            var productModels = new List<ProductModel>()
            {
                new ProductModel()
                {
                    Id = 1,
                    Name = "Test Name",
                    Description = "Test Description",
                    AvailableCount = 5,
                    Price = 19,
                    CategoryList = new List<CategoryModel>()
                    {
                        new CategoryModel()
                        {
                            Id = 1,
                            Name = "Name 1",
                            Description = "Description"
                        },
                        new CategoryModel()
                        {
                            Name = "Name 2"
                        }
                    }
                },
                new ProductModel()
                {
                    Id = 0,
                    Name = "",
                    Description = "",
                    AvailableCount = -9,
                    Price = 9.999m
                }
            };

            var expected = new List<ProductDto>()
            {
                new ProductDto()
                {
                    Id = 1,
                    Name = "Test Name",
                    Description = "Test Description",
                    AvailableCount = 5,
                    Price = 19,
                    Categories = "Name 1, Name 2"
                },
                new ProductDto()
                {
                    Id = 0,
                    Name = "",
                    Description = "",
                    AvailableCount = -9,
                    Price = 9.999m,
                    Categories = ""
                }
            };

            // Act
            var actual = _productConverter.ConvertFrom(productModels).ToList();

            // Assert     
            CollectionAssert.AreEqual(expected, actual, _comparer);
        }
    }
}
