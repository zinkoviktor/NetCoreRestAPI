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
    public class CategoryModelConverter_ConvertFrom_Tests
    {
        private IConverter<CategoryEntity, CategoryModel> _converter;
        private IComparer _entityComparer;
        private Func<CategoryEntity, CategoryEntity, bool> _comparerPredicate;

        [TestInitialize]
        public void TestInitialize()
        {
            _converter = new CategoryModelConverter();

            _comparerPredicate = delegate (CategoryEntity entity1, CategoryEntity entity2)
            {
                return entity1.Id.Equals(entity2.Id) &&
                    entity1.Name.Equals(entity2.Name) &&
                    entity1.Description.Equals(entity2.Description);
            };

            _entityComparer = new CollectionEqualsComparer<CategoryEntity>(_comparerPredicate);
        }

        [TestMethod]
        [Description("Convert To CategoryEntity collection all items are not Null")]
        public void Convert_FromCategoryModels_ItemsAreNotNull()
        {
            // Arrange
            var categoryModels = new List<CategoryModel>()
            {
                new CategoryModel(),
                new CategoryModel()
                {
                     Id = 0,
                     Name = "",
                     Description = null
                }
            };

            // Act
            var actual = _converter.ConvertFrom(categoryModels);

            // Assert            
            CollectionAssert.AllItemsAreNotNull(actual.ToList());
        }

        [TestMethod]
        public void Convert_FromCategoryModels_ToCategoryEntities()
        {
            // Arrange
            var categoryModels = new List<CategoryModel>()
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

            var expected = new List<CategoryEntity>
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

            // Act
            var actual = _converter.ConvertFrom(categoryModels).ToList();

            // Assert            
            CollectionAssert.AreEqual(expected, actual, _entityComparer);
        }

        [TestMethod]
        public void Convert_FromNull_ToEmptyList()
        {
            // Arrange
            List<CategoryModel> categoryModels = null;
            var expected = new List<CategoryEntity>();
            // Act
            var actual = _converter.ConvertFrom(categoryModels).ToList();

            // Assert            
            CollectionAssert.AreEquivalent(expected, actual);
        }

        [TestMethod]
        public void Convert_FromNull_ToEmptyEntity()
        {
            // Arrange
            CategoryModel categoryModel = null;
            var expected = new CategoryEntity();
            // Act
            var actual = _converter.ConvertFrom(categoryModel);

            // Assert            
            Assert.IsNull(actual);
        }
    }
}
