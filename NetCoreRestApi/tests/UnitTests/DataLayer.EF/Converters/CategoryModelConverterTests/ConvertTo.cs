using Common.Converter;
using DataLayer.EF.Converters;
using DataLayer.EF.Entities;
using DataLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.DataLayer.EF.Converters.CategoryModelConverterTests
{
    [TestClass]    
    public class ConvertTo
    {
        IConverter<CategoryEntity, CategoryModel> _converter;
        IComparer _entityComparer;

        [TestInitialize]
        public void TestInitialize()
        {
            _converter = new CategoryModelConverter();

            static bool predicate(CategoryModel model1, CategoryModel model2) =>
                model1.Id.Equals(model2.Id) &&
                model1.Name.Equals(model2.Name) &&
                model1.Description.Equals(model2.Description);

            _entityComparer = new BaseComparer<CategoryModel>(predicate);
        }

        [TestMethod]         
        public void AllItemsAreNotNull()
        {
            // Arrange
            var categoryEntity = new CategoryEntity();
            var categoryEntities = new List<CategoryEntity>()
            {
                categoryEntity,
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
        public void AllFieldsConverted()
        {
            // Arrange
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
            var categoryEntities = new List<CategoryEntity> 
            { 
                categoryEntity, 
                categoryEntity2 
            };

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
            var expected = new List<CategoryModel>()
            {
                categoryModel, categoryModel2
            };            

            // Act
            var actual = _converter.ConvertTo(categoryEntities).ToList();

            // Assert            
            CollectionAssert.AreEqual(expected, actual, _entityComparer);
        }
    }
}
