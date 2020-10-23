using DataLayer.Models;

namespace UnitTests.Helpers.CategoryHelpers
{
    public class CategoryModelComparer : BaseComparer<CategoryModel>
    {
        public static readonly CategoryModelComparer Instance = new CategoryModelComparer();

        private CategoryModelComparer()
        {
        }

        public override bool AreEquals(CategoryModel model1, CategoryModel model2)
        {
            return Instance.AreObjectTypesEquals(model1, model2) &&
                   model1.Id == model2.Id &&
                   model1.Name == model2.Name &&
                   model1.Description == model2.Description;
        }
    }
}
