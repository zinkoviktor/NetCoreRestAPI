using Common.Converter;
using DataLayer.EF.Converters;
using DataLayer.EF.Entities;
using DataLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.DataLayer.EF.Converters
{
    [TestClass]
    public class PoductModelConverter_ConvertTo_Tests
    {
        private IConverter<CategoryEntity, CategoryModel> _categoryConverter;
        private IConverter<ProductEntity, ProductModel> _productConverter;
        private IComparer _comparer;
        private Func<ProductModel, ProductModel, bool> _comparerPredicate;

        [TestInitialize]
        public void TestInitialize()
        {
            _categoryConverter = new CategoryModelConverter();
            _productConverter = new ProductModelConverter(_categoryConverter);

            _comparerPredicate = delegate (ProductModel model1, ProductModel model2)
            {
                return model1.Id.Equals(model2.Id) &&
                    model1.Name.Equals(model2.Name) &&
                    model1.Description.Equals(model2.Description) &&
                    model1.Price.Equals(model2.Price) &&
                    model1.AvailableCount.Equals(model2.AvailableCount);
            };                

            _comparer = new BaseComparer<ProductModel>(_comparerPredicate);
        }
        
        [TestMethod]       
        public void CategoryAddedToModel()
        {
            // Arrange           
            var productEntityStub = new ProductEntity()
            {
                Id = 1,
                Name = "Test Name",
                Description = "Test Description",
                AvailableCount = 5,
                Price = 19
            };
            var categoryEntityStub = new CategoryEntity()
            {
                Id = 1,
                Name = "Test Name",
                Description = "Test Description",
            };
            var productCategoryEntityStub = new ProductCategoryEntity()
            {
                Product = productEntityStub,
                ProductId = productEntityStub.Id,
                Category = categoryEntityStub,
                CategoryId = categoryEntityStub.Id
            };

            productEntityStub.ProductCategoryEntities = new List<ProductCategoryEntity>
            {
                productCategoryEntityStub
            };
            var productEntitiesStub = new List<ProductEntity>()
            {
                productEntityStub
            };

            // Act
            var actual = _productConverter.ConvertTo(productEntityStub);

            // Assert     
            Assert.IsTrue(actual.CategoryList.Any(categoryModel => 
                categoryModel.Name.Equals(categoryEntityStub.Name)));
        }

        [TestMethod]        
        public void AllFieldsConverted()
        {
            // Arrange
            var productEntityStub = new ProductEntity()
            {
                Id = 1,
                Name = "Test Name",
                Description = "Test Description",
                AvailableCount = 5,
                Price = 19
            };
            var productEntitiesStub = new List<ProductEntity>()
            {
                productEntityStub,
                new ProductEntity()
                {
                        Id = 0,
                        Name = "",
                        Description = "",
                        AvailableCount = -9,
                        Price = 9.999m
                }
            };

            var categoryEntityStub = new CategoryEntity()
            {
                Id = 1,
                Name = "Test Name",
                Description = "Test Description",
            };
            var productCategoryEntityStub = new ProductCategoryEntity()
            {
                Product = productEntityStub,
                ProductId = productEntityStub.Id,
                Category = categoryEntityStub,
                CategoryId = categoryEntityStub.Id
            };

            foreach (var pe in productEntitiesStub)
            {
                pe.ProductCategoryEntities = new List<ProductCategoryEntity>
                {
                    productCategoryEntityStub
                };
            }

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
            var actual = _productConverter.ConvertTo(productEntitiesStub).ToList();

            // Assert     
            CollectionAssert.AreEqual(expected, actual, _comparer);            
        }
    }
}
