using ServiceLayer.DataTransferObjects;

namespace UnitTests.Helpers.ProductHelpers
{
    public class ProductDtoComparer : BaseComparer<ProductDto>
    {
        public static readonly ProductDtoComparer Instance = new ProductDtoComparer();

        private ProductDtoComparer()
        {
        }

        public override bool AreEquals(ProductDto dto1, ProductDto dto2)
        {
            return Instance.AreObjectTypesEquals(dto1, dto2) &&
                   dto1.Id == dto2.Id &&
                   dto1.Name == dto2.Name &&
                   dto1.Description == dto2.Description &&
                   dto1.Price == dto2.Price &&
                   dto1.AvailableCount == dto2.AvailableCount;
        }
    }
}
