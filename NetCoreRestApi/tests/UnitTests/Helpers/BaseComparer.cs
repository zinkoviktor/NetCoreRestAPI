namespace UnitTests.Helpers
{
    public class BaseComparer
    {
        public bool AreObjectTypesEquals<T>(object object1, object object2)
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
    }
}
