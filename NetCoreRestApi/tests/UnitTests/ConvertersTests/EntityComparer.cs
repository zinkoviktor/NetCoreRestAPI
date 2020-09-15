using DataLayer.EF.Entities;
using System.Collections;

namespace UnitTests.ConvertersTests
{
    public class CategoryEntityComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if(x.GetType() != typeof(CategoryEntity))
            {
                return -1;
            }

            if (y.GetType() != typeof(CategoryEntity))
            {
                return -1;
            }

            var entity1 = (CategoryEntity) x;
            var entity2 = (CategoryEntity) y;
            if (entity1.Id.Equals(entity2.Id) &&
                entity1.Name.Equals(entity2.Name) &&
                entity1.Description.Equals(entity2.Description))
            {
                return 0;
            }

            return -1;
        }
    }
}
