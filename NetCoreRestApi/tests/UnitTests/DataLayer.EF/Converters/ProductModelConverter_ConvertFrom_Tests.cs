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
    public class ProductModelConverter_ConvertFrom_Tests
    {
        private IConverter<ProductEntity, ProductModel> _converter;
        private IComparer _comparer;
        private Func<ProductEntity, ProductEntity, bool> _comparerPredicate;

        [TestInitialize]
        public void TestInitialize()
        {
            var categoryConverter = new CategoryModelConverter();
            _converter = new ProductModelConverter(categoryConverter);

            _comparerPredicate = delegate(ProductEntity entity1, ProductEntity entity2)
            {
                return entity1.Id.Equals(entity2.Id) &&
                    entity1.Name.Equals(entity2.Name) &&
                    entity1.Description.Equals(entity2.Description) &&
                    entity1.Price.Equals(entity2.Price) &&
                    entity1.AvailableCount.Equals(entity2.AvailableCount);
            };       

            _comparer = new BaseComparer<ProductEntity>(_comparerPredicate);
        }  

        [TestMethod]        
        public void Convert_FromProductModels_ItemsAreNotNull()
        {
            // Arrange           
            var productModelsStub = new List<ProductModel>()
            {
                new ProductModel()
                {
                    Id = 1,
                    Name = "Test Name",
                    Description = "Test Description",
                    AvailableCount = 5,
                    Price = 19,
                    CategoryList = new List<CategoryModel>
                    {
                        new CategoryModel()
                        {
                            Id = 1,
                            Name = "Name 1!@~#$%^&*()_+=-\\||'\"?/.><,",
                            Description = "Name 1 !@~#$%^&*()_+=-\\||'\"?/.><,"
                        }
                    }
                },
                new ProductModel()
                {
                    Id = 0,
                    Name = "",
                    Description = null,
                    AvailableCount = -9,
                    Price = 9.999m,
                    CategoryList = new List<CategoryModel>
                    {
                        new CategoryModel()
                        {
                            Id = 1,
                            Name = "Name 1!@~#$%^&*()_+=-\\||'\"?/.><,",
                            Description = "Name 1 !@~#$%^&*()_+=-\\||'\"?/.><,"
                        },
                        new CategoryModel()
                        {
                            Id = 2,
                            Name = "Test Name 2",
                            Description = "Test Description 2",
                        }
                    }
                }
            };

            // Act
            var actual = _converter.ConvertFrom(productModelsStub).ToList();

            // Assert                
            CollectionAssert.AllItemsAreNotNull(actual);        
        }

        [TestMethod]
        public void Convert_FromProductModels_ToProductEntities()
        {
            // Arrange
            var productModelsStub = new List<ProductModel>()
            {
                new ProductModel()
                {
                    Id = 1,
                    Name = "Name 1!@~#$%^&*()_+=-\\||'\"?/.><,",
                    Description = "Name 1!@~#$%^&*()_+=-\\||'\"?/.><,",
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

            var expected = new List<ProductEntity>()
            {
                new ProductEntity()
                {
                    Id = 1,
                    Name = "Name 1!@~#$%^&*()_+=-\\||'\"?/.><,",
                    Description = "Name 1!@~#$%^&*()_+=-\\||'\"?/.><,",
                    AvailableCount = 5,
                    Price = 19
                },
                new ProductEntity()
                {
                    Id = 0,
                    Name = "",
                    Description = "",
                    AvailableCount = -9,
                    Price = 9.999m,
                }
            };

            // Act
            var actual = _converter.ConvertFrom(productModelsStub).ToList();

            // Assert                
            CollectionAssert.AreEqual(expected, actual, _comparer);
        }
    }
}
