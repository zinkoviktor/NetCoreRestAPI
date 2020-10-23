using DataLayer.Models;

namespace UnitTests.Helpers.ProductHelpers
{
    public class ProductModelComparer : BaseComparer<ProductModel>
    {
        public static readonly ProductModelComparer Instance = new ProductModelComparer();

        private ProductModelComparer()
        {
        }

        public override bool AreEquals(ProductModel model1, ProductModel model2)
        {
            return Instance.AreObjectTypesEquals(model1, model2) &&
                   model1.Id == model2.Id &&
                   model1.Name == model2.Name &&
                   model1.Description == model2.Description &&
                   model1.Price == model2.Price &&
                   model1.AvailableCount == model2.AvailableCount;
        }
    }
}
