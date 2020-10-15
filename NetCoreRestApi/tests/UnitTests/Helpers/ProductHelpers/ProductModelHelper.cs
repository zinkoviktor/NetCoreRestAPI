using DataLayer.Models;
using System.Collections.Generic;

namespace UnitTests.Helpers.ProductHelpers
{
    public class ProductModelHelper : BaseComparer<ProductModel>
    {
        public static readonly ProductModelHelper Instance = new ProductModelHelper();

        private ProductModelHelper()
        {
        }

        public override bool AreEquals(ProductModel model1, ProductModel model2)
        {
            return Instance.AreObjectTypesEquals(model1, model2)
               && model1.Id == model2.Id
                   && model1.Name == model2.Name
                       && model1.Description == model2.Description
                           && model1.Price == model2.Price
                               && model1.AvailableCount == model2.AvailableCount;
        }

        public static List<ProductModel> GetProductModels()
        {
            var productModels = new List<ProductModel>()
            {
                new ProductModel()
                {
                    Id = 1,
                    Name = "HP 410",
                    Description = "All-in-One Wireless Ink Tank Color Printer",
                    Price = 90,
                    AvailableCount = 9
                },
                new ProductModel()
                {
                    Id = 2,
                    Name = "Epson L3152",
                    Description = "WiFi All in One Ink Tank Printer",
                    Price = 60,
                    AvailableCount = 19
                }
            };

            return productModels;
        }
    }
}
