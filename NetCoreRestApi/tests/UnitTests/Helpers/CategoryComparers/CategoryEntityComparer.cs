using DataLayer.EF.Entities;

namespace UnitTests.Helpers.CategoryHelpers
{
    public class CategoryEntityComparer : BaseComparer<CategoryEntity>
    {
        public static readonly CategoryEntityComparer Instance = new CategoryEntityComparer();

        private CategoryEntityComparer()
        {
        }

        public override bool AreEquals(CategoryEntity entity1, CategoryEntity entity2)
        {
            return Instance.AreObjectTypesEquals(entity1, entity2) &&
                   entity1.Id == entity2.Id &&
                   entity1.Name == entity2.Name &&
                   entity1.Description == entity2.Description;
        }
    }
}
