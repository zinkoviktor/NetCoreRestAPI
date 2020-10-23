using DataLayer.EF.Entities;

namespace UnitTests.Helpers.ProductHelpers
{
    public class ProductEntityComparer : BaseComparer<ProductEntity>
    {
        public static readonly ProductEntityComparer Instance = new ProductEntityComparer();

        private ProductEntityComparer()
        {
        }

        public override bool AreEquals(ProductEntity entity1, ProductEntity entity2)
        {
            return Instance.AreObjectTypesEquals(entity1, entity2) &&
                   entity1.Id == entity2.Id &&
                   entity1.Name == entity2.Name &&
                   entity1.Description == entity2.Description &&
                   entity1.Price == entity2.Price &&
                   entity1.AvailableCount == entity2.AvailableCount;
        }
    }
}
