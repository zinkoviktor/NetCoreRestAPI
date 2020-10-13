using DataLayer.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTests.Helpers.Tests
{
    [TestClass]
    public class PerformanceTests
    {
        List<CategoryModel> models1 = new List<CategoryModel>();
        List<CategoryModel> models2 = new List<CategoryModel>();

        [TestInitialize]
        public void TestInitialize()
        {
            for (var i = 0; i < 10000000; i++)
            {
                models1.Add(new CategoryModel { Id = i });
            }

            for (var i = 0; i < 10000000; i++)
            {
                models2.Add(new CategoryModel { Id = i });
            }
        }

        [TestMethod]
        public void Performance_ClassComparer_TimeOnCompareObjects()
        {
            var result = ModelComparer.AreCategoryModelEquals(models1, models2);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Performance_ReflectionComparer_TimeOnCompareObjects()
        {
            var x = ObjectPropertiesComparer.AreEqual(models1, models2);
            Assert.IsTrue(x);
        }
    }
}
