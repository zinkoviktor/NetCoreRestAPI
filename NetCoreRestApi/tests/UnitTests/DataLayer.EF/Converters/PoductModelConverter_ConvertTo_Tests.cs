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

            _comparer = new CollectionEqualsComparer<ProductModel>(_comparerPredicate);
        }

        [TestMethod]
        public void Convert_ToProductModels_CategoryAddedToModel()
        {
            // Arrange           
            var productEntity = new ProductEntity()
            {
                Id = 1,
                Name = "Test Name",
                Description = "Test Description",
                AvailableCount = 5,
                Price = 19
            };
            var categoryEntity = new CategoryEntity()
            {
                Id = 1,
                Name = "Test Name",
                Description = "Test Description",
            };
            var productCategoryEntityStub = new ProductCategoryEntity()
            {
                Product = productEntity,
                ProductId = productEntity.Id,
                Category = categoryEntity,
                CategoryId = categoryEntity.Id
            };

            productEntity.ProductCategoryEntities = new List<ProductCategoryEntity>
            {
                productCategoryEntityStub
            };
            var productEntities = new List<ProductEntity>()
            {
                productEntity
            };

            // Act
            var actual = _productConverter.ConvertTo(productEntity);

            // Assert     
            Assert.IsTrue(actual.CategoryList.Any(categoryModel =>
                categoryModel.Name.Equals(categoryEntity.Name)));
        }

        [TestMethod]
        public void Convert_ToProductModels_FromProductEntities()
        {
            // Arrange
            var productEnteties = GetProductEntities();

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
            var actual = _productConverter.ConvertTo(productEnteties).ToList();

            // Assert     
            CollectionAssert.AreEqual(expected, actual, _comparer);
        }

        private List<ProductEntity> GetProductEntities()
        {
            var productEntity = new ProductEntity()
            {
                Id = 1,
                Name = "Test Name",
                Description = "Test Description",
                AvailableCount = 5,
                Price = 19
            };

            var categoryEntity = new CategoryEntity()
            {
                Id = 1,
                Name = "Test Name",
                Description = "Test Description",
            };

            productEntity.ProductCategoryEntities = new List<ProductCategoryEntity>
            {
                new ProductCategoryEntity()
                {
                    Product = productEntity,
                    ProductId = productEntity.Id,
                    Category = categoryEntity,
                    CategoryId = categoryEntity.Id
                }
            };

            var productEntity2 = new ProductEntity()
            {
                Id = 0,
                Name = "",
                Description = "",
                AvailableCount = -9,
                Price = 9.999m
            };

            var categoryEntity2 = new CategoryEntity()
            {
                Id = 0,
                Name = "Test Name 2 ",
                Description = "Test Description 2",
            };

            productEntity2.ProductCategoryEntities = new List<ProductCategoryEntity>
            {
                new ProductCategoryEntity()
                {
                    Product = productEntity2,
                    ProductId = productEntity2.Id,
                    Category = categoryEntity2,
                    CategoryId = categoryEntity2.Id
                }
            };

            var productEntitiesStub = new List<ProductEntity>()
            {
                productEntity,
                productEntity2
            };

            return productEntitiesStub;
        }
    }
}
