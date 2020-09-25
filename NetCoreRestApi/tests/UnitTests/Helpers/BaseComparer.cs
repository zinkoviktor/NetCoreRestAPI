using System;
using System.Collections;

namespace UnitTests
{
    public class BaseComparer<T> : IComparer
    {
        private Func<T, T, bool> _compareFunc;
        private const int LESS_THAN  = -1;
        private const int EQUALS = 0;

        public BaseComparer(Func<T, T, bool> compareFunc)
        {
            _compareFunc = compareFunc;
        }

        public int Compare(object object1, object object2)
        {
            if(object1.GetType() != typeof(T))
            {
                return LESS_THAN;
            }

            if (object2.GetType() != typeof(T))
            {
                return LESS_THAN;
            }

            var entity1 = (T) object1;
            var entity2 = (T) object2;

            if (_compareFunc(entity1, entity2))
            {
                return EQUALS;
            }

            return LESS_THAN;
        }
    }
}
