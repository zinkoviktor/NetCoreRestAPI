using ServiceLayer.DataTransferObjects;
using System.Collections.Generic;

namespace UnitTests.Helpers.ProductHelpers
{
    public class ProductDtoHelper : BaseComparer<ProductDto>
    {
        public static readonly ProductDtoHelper Instance = new ProductDtoHelper();

        private ProductDtoHelper()
        {
        }

        public override bool AreEquals(ProductDto dto1, ProductDto dto2)
        {            
            return Instance.AreObjectTypesEquals(dto1, dto2) 
                && dto1.Id == dto2.Id
                    && dto1.Name == dto2.Name
                        && dto1.Description == dto2.Description
                            && dto1.Price == dto2.Price
                                && dto1.AvailableCount == dto2.AvailableCount;
        }

        public static List<ProductDto> GetProductDtos()
        {
            var productDtos = new List<ProductDto>()
            {
                new ProductDto()
                {
                    Id = 1,
                    Name = "HP 410",
                    Description = "All-in-One Wireless Ink Tank Color Printer",
                    Price = 90,
                    AvailableCount = 9
                },
                new ProductDto()
                {
                    Id = 2,
                    Name = "Epson L3152",
                    Description = "WiFi All in One Ink Tank Printer",
                    Price = 60,
                    AvailableCount = 19
                }
            };

            return productDtos;
        }        
    }
}
