using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTests.Helpers.tests
{
    [TestClass]
    public class CollectionEqualsComparerTests
    {
        [TestMethod]
        public void Compare_IntValues_AreEqual()
        {
            // Arrange
            Func<int, int, bool> predicate = delegate (int number1, int number2)
            {
                return number1 == number2;
            };
            var comparer = new CollectionEqualsComparer<int>(predicate);

            // Act
            var expected = new List<int>()
            {
                0,
                1               
            };
            var actual = new List<int>(expected);

            // Assert            
            CollectionAssert.AreEqual(expected, actual, comparer);
        }

        [TestMethod]
        public void Compare_IntValues_AreNotEqual()
        {
            // Arrange
            Func<int, int, bool> predicate = delegate (int number1, int number2)
            {
                return number1 == number2;
            };
            var comparer = new CollectionEqualsComparer<int>(predicate);

            // Act
            var expected = new List<int>()
            {
                0,
                1
            };
            var actual = new List<int>()
            {
                1,
                1
            };

            // Assert            
            CollectionAssert.AreNotEqual(expected, actual, comparer);
        }
    }
}
