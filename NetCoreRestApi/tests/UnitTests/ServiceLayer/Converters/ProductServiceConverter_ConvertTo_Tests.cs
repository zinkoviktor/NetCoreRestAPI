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
    public class ProductServiceConverter_ConvertTo_Tests
    {
        private IConverter<ProductDto, ProductModel> _productConverter;
        private IComparer _comparer;
        private Func<ProductModel, ProductModel, bool> _comparerPredicate;

        [TestInitialize]
        public void TestInitialize()
        {
            _productConverter = new ProductServiceConverter();

            _comparerPredicate = delegate (ProductModel model1, ProductModel model2)
            {
                return model1.Id.Equals(model2.Id) &&
                    model1.Name.Equals(model2.Name) &&
                    model1.Description == model2.Description &&
                    model1.Price.Equals(model2.Price) &&
                    model1.AvailableCount.Equals(model2.AvailableCount);
            };

            _comparer = new CollectionEqualsComparer<ProductModel>(_comparerPredicate);
        }

        [TestMethod]
        public void Convert_ToProductModel_ItemsAreNotNull()
        {
            // Arrange           
            var productDtos = new List<ProductDto>()
            {
                new ProductDto(),
                new ProductDto()
                {
                     Id = 1,
                    Name = "Test Name",
                    Description = "Test Description",
                    AvailableCount = 5,
                    Price = 19
                }
            };

            // Act
            var actual = _productConverter.ConvertTo(productDtos);

            // Assert            
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void Convert_ToProductModel_CategoryAddedToModel()
        {
            // Arrange 
            Func<CategoryModel, CategoryModel, bool> predicate =
                delegate (CategoryModel model1, CategoryModel model2)
                {
                    return model1.Id == model2.Id &&
                        model1.Name == model2.Name &&
                        model1.Description == model2.Description;
                };
            var comparer = new CollectionEqualsComparer<CategoryModel>(predicate);

            var productDto = new ProductDto()
            {
                Categories = "category 1, category 2"
            };

            var expected = new List<CategoryModel>()
            {
                new CategoryModel()
                {
                    Name = "category 1"
                },
                new CategoryModel()
                {
                    Name = "category 2"
                }
            };

            // Act
            var actual = _productConverter.ConvertTo(productDto);

            // Assert            
            Assert.IsTrue(actual.CategoryList.Count() == 2);
            CollectionAssert.AreEqual(expected, actual.CategoryList.ToList(), comparer);
        }

        [TestMethod]
        public void Convert_ToProductModels_FromProductEntities()
        {
            // Arrange
            var productDtos = new List<ProductDto>()
            {
                new ProductDto()
                {
                    Id = 1,
                    Name = "Test Name",
                    Description = "Test Description",
                    AvailableCount = 5,
                    Price = 19,
                    Categories = ""
                },
                new ProductDto()
                {
                    Id = 0,
                    Name = "",
                    Description = "",
                    AvailableCount = -9,
                    Price = 9.999m
                }
            };

            var expected = new List<ProductModel>()
            {
                new ProductModel()
                {
                    Id = 1,
                    Name = "Test Name",
                    Description = "Test Description",
                    AvailableCount = 5,
                    Price = 19
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

            // Act
            var actual = _productConverter.ConvertTo(productDtos).ToList();

            // Assert     
            CollectionAssert.AreEqual(expected, actual, _comparer);
        }
    }
}
