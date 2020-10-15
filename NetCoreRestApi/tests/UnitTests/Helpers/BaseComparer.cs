using System.Collections.Generic;

namespace UnitTests.Helpers
{
    public abstract class BaseComparer<T>
    {
        public bool AreObjectTypesEquals(object object1, object object2)
        {
            if (object1.GetType() != typeof(T))
            {
                return false;
            }

            if (object2.GetType() != typeof(T))
            {
                return false;
            }

            return true;
        }

        public abstract bool AreEquals(T dto1, T dto2);

        public  virtual bool AreEquals(List<T> list1, List<T> list2)
        {
            if (list1.Count != list2.Count)
            {
                return false;
            }

            for (var i = 0; i < list1.Count; i++)
            {
                if (!AreEquals(list1[i], list2[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public virtual bool AreEquals(List<T> models1, object object2)
        {
            if (object2.GetType() != models1.GetType())
            {
                return false;
            }

            return AreEquals(models1, object2 as List<T>);
        }
    }
}
