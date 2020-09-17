using System;
using System.Collections;

namespace UnitTests
{
    public class BaseComparer<T> : IComparer
    {
        private Func<T, T, bool> _compareFunc;

        public BaseComparer(Func<T, T, bool> compareFunc)
        {
            _compareFunc = compareFunc;
        }

        public int Compare(object x, object y)
        {
            if(x.GetType() != typeof(T))
            {
                return -1;
            }

            if (y.GetType() != typeof(T))
            {
                return -1;
            }

            var entity1 = (T) x;
            var entity2 = (T) y;

            if (_compareFunc(entity1, entity2))
            {
                return 0;
            }

            return -1;
        }
    }
}
