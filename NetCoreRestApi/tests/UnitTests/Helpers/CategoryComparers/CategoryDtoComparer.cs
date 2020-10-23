using ServiceLayer.DataTransferObjects;

namespace UnitTests.Helpers.CategoryHelpers
{
    public class CategoryDtoComparer : BaseComparer<CategoryDto>
    {
        public static readonly CategoryDtoComparer Instance = new CategoryDtoComparer();

        private CategoryDtoComparer()
        {
        }

        public override bool AreEquals(CategoryDto model1, CategoryDto model2)
        {
            return Instance.AreObjectTypesEquals(model1, model2) &&
                   model1.Id == model2.Id &&
                   model1.Name == model2.Name &&
                   model1.Description == model2.Description;
        }
    }
}
