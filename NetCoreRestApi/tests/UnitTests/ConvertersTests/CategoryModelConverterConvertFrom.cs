using Common.Converter;
using DataLayer.EF.Converters;
using DataLayer.EF.Entities;
using DataLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.ConvertersTests
{
    [TestClass]    
    public class CategoryModelConverterConvertFrom
    {
        IConverter<CategoryEntity, CategoryModel> _converter;
        IComparer _entityComparer;

        [TestInitialize]
        public void TestInitialize()
        {
            _converter = new CategoryModelConverter();
            _entityComparer = new CategoryEntityComparer();
        }

        [TestMethod]
        public void ConvertToCategoryEntityCollectionAllItemsAreNotNull()
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
        [Description("Is Id property value converted correct")]       
        public void ConvertToCategoryEntityIdPropertyValueInCollectionIsSameId()
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
