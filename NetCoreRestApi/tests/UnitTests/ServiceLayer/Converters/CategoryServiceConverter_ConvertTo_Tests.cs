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
    public class CategoryServiceConverter_ConvertTo_Tests
    {
        private IConverter<CategoryDto, CategoryModel> _converter;
        private IComparer _entityComparer;
        private Func<CategoryModel, CategoryModel, bool> _comparerPredicate;

        [TestInitialize]
        public void TestInitialize()
        {
            _converter = new CategoryServiceConverter();

            _comparerPredicate = delegate (CategoryModel model1, CategoryModel model2)
            {
                return model1.Id.Equals(model2.Id) &&
                    model1.Name.Equals(model2.Name) &&
                    model1.Description.Equals(model2.Description);
            };

            _entityComparer = new CollectionEqualsComparer<CategoryModel>(_comparerPredicate);
        }


        [TestMethod]
        public void Convert_ToCategoryModel_ItemsAreNotNull()
        {
            // Arrange
            var categoryEntities = new List<CategoryDto>()
            {
                new CategoryDto(),
                new CategoryDto()
                {
                     Id = 0,
                     Name = "",
                     Description = null
                }
            };

            // Act
            var actual = _converter.ConvertTo(categoryEntities);

            // Assert            
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void Convert_ToCategoryModels_FromCategoryDtos()
        {
            // Arrange            
            var categoryDtos = new List<CategoryDto>
            {
                new CategoryDto()
                {
                    Id = 1,
                    Name = "Name 1",
                    Description = "Name 1"
                },
                new CategoryDto()
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
            var actual = _converter.ConvertTo(categoryDtos).ToList();

            // Assert            
            CollectionAssert.AreEqual(expected, actual, _entityComparer);
        }
    }
}
