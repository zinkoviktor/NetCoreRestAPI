using System;
using System.Collections;

namespace UnitTests
{
    public class CollectionEqualsComparer<T> : IComparer
    {
        private Func<T, T, bool> _compareFunc;       
        private const int EQUALS = 0;
        private const int NOT_EQUALS = -1;

        public CollectionEqualsComparer(Func<T, T, bool> compareFunc)
        {
            _compareFunc = compareFunc;
        }

        public int Compare(object object1, object object2)
        {
            if(object1.GetType() != typeof(T))
            {
                return NOT_EQUALS;
            }

            if (object2.GetType() != typeof(T))
            {
                return NOT_EQUALS;
            }

            var entity1 = (T) object1;
            var entity2 = (T) object2;

            if (_compareFunc(entity1, entity2))
            {
                return EQUALS;
            }

            return NOT_EQUALS;
        }
    }
}
