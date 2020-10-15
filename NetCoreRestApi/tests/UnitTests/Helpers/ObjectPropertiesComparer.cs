using System.Collections.Generic;

namespace UnitTests.Helpers
{
    public static class ObjectPropertiesComparer
    {
        public static bool AreEqual(object object1, object object2)
        {
            if (object1 == null && object2 == null)
            {
                return true;
            }

            if (object1 == null || object2 == null)
            {
                return false;
            }

            if (object1.GetType() != object2.GetType())
            {
                return false;
            }

            var Props = object1.GetType().GetProperties();

            foreach (var Prop in Props)
            {

                var aPropValue = Prop.GetValue(object1);
                var bPropValue = Prop.GetValue(object2);

                if (aPropValue?.ToString() != bPropValue?.ToString())
                {
                    return false;
                }
            }
            return true;
        }

        public static bool AreEqual<T>(List<T> objects1, List<T> objects2)
        {
            if (objects1.Count != objects2.Count)
            {
                return false;
            }

            for (var i = 0; i < objects1.Count; i++)
            {
                if (!AreEqual(objects1[i], objects2[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
