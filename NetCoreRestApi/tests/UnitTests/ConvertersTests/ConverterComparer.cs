using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace UnitTests.ConvertersTests
{
    public class ConverterComparer : IComparer
    {       
        private Func<object, object, int> _function;

        public ConverterComparer(Expression<Func<object, object, int>> expression)
        {
            _function = expression.Compile();
        }

        public int Compare(object x, object y)
        {
            return _function(x, y);
        }
    }
}
