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

            _comparerPredicate = delegate(CategoryEntity entity1, CategoryEntity entity2)
            {
                return entity1.Id.Equals(entity2.Id) &&
                    entity1.Name.Equals(entity2.Name) &&
                    entity1.Description.Equals(entity2.Description);
            };

            _entityComparer = new BaseComparer<CategoryEntity>(_comparerPredicate);
        }

        [TestMethod]
        [Description("Convert To CategoryEntity collection all items are not Null")]
        public void AllItemsAreNotNull()
        {
            // Arrange             
            var categoryModel = new CategoryModel();
            var categoryModels = new List<CategoryModel>()
            {
                categoryModel,
                new CategoryModel()
                {
                     Id = 0,
                     Name = "",
                     Description = null
                }
            };

            // Act
            var actualCategoryEntities = _converter.ConvertFrom(categoryModels);

            // Assert            
            CollectionAssert.AllItemsAreNotNull(actualCategoryEntities.ToList());
        }

        [TestMethod]
        public void AllFieldsConverted()
        {
            // Arrange
            var categoryModel = new CategoryModel()
            {
                Id = 1,
                Name = "Name 1 !@~#$%^&*()_+=-\\||'\"?/.><,",
                Description = "Name 1 !@~#$%^&*()_+=-\\||'\"?/.><,"
            };
            var categoryModel2 = new CategoryModel()
            {
                Id = 0,
                Name = "",
                Description = ""
            };
            var categoryModels = new List<CategoryModel>()
            {
                categoryModel, categoryModel2
            };
            var categoryEntity = new CategoryEntity()
            {
                Id = 1,
                Name = "Name 1 !@~#$%^&*()_+=-\\||'\"?/.><,",
                Description = "Name 1 !@~#$%^&*()_+=-\\||'\"?/.><,"
            };
            var categoryEntity2 = new CategoryEntity()
            {
                Id = 0,
                Name = "",
                Description = ""
            };            
            var expected = new List<CategoryEntity> { categoryEntity, categoryEntity2 };

            // Act
            var actual = _converter.ConvertFrom(categoryModels).ToList();

            // Assert            
            CollectionAssert.AreEqual(expected, actual, _entityComparer);
        }
    }
}
