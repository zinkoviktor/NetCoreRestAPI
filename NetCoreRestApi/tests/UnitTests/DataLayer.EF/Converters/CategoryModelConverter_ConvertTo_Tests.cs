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
    public class CategoryModelConverter_ConvertTo_Tests
    {
        private IConverter<CategoryEntity, CategoryModel> _converter;
        private IComparer _entityComparer;
        private Func<CategoryModel, CategoryModel, bool> _comparerPredicate;

        [TestInitialize]
        public void TestInitialize()
        {
            _converter = new CategoryModelConverter();

            _comparerPredicate = delegate(CategoryModel model1, CategoryModel model2)
            {
                return model1.Id.Equals(model2.Id) &&
                    model1.Name.Equals(model2.Name) &&
                    model1.Description.Equals(model2.Description);
            };

            _entityComparer = new CollectionEqualsComparer<CategoryModel>(_comparerPredicate);
        }

        [TestMethod]         
        public void Convert_ToCategoryEntity_ItemsAreNotNull()
        {
            // Arrange           
            var categoryEntities = new List<CategoryEntity>()
            {
                new CategoryEntity(),
                new CategoryEntity()
                {
                     Id = 0,
                     Name = "",
                     Description = null
                }
            };

            var actualCategoryModels = _converter.ConvertTo(categoryEntities);

            // Assert            
            Assert.IsNotNull(actualCategoryModels);
        }

        [TestMethod]
        public void Convert_ToCategoryModels_FromCategoryEntities()
        {
            // Arrange            
            var categoryEntities = new List<CategoryEntity> 
            {
                new CategoryEntity()
                {
                    Id = 1,
                    Name = "Name 1",
                    Description = "Name 1"
                },
                new CategoryEntity()
                {
                    Id = 0,
                    Name = "",
                    Description = ""
                }
            };

            var expected = new List<CategoryModel>()
            {
                new CategoryModel()
                {
                    Id = 1,
                    Name = "Name 1",
                    Description = "Name 1"
                }, 
                new CategoryModel()
                {
                    Id = 0,
                    Name = "",
                    Description = ""
                }
            };            

            // Act
            var actual = _converter.ConvertTo(categoryEntities).ToList();

            // Assert            
            CollectionAssert.AreEqual(expected, actual, _entityComparer);
        }
    }
}
