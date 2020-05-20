using BusinessLayer.Models;
using System.Collections.Generic;

namespace BusinessLayer.Manager
{
    public class ProductManager : IProductManager
    {
        public IEnumerable<ProductModel> GetAll()
        {
            List<ProductModel> productModels = new List<ProductModel>();
            productModels.Add(new StubProductModel("first product"));
            productModels.Add(new StubProductModel("second product"));
            productModels.Add(new StubProductModel("third product"));           
            return productModels;
        }
        
        private class StubProductModel : ProductModel
        {
            internal StubProductModel(string name)
            {
                Name = name;
                Description = "Description for " + name;
                CategoryList = new List<CategoryModel>();
                CategoryList.Add(new CategoryModel() { Name = "first category name", Description = "description" });
                CategoryList.Add(new CategoryModel() { Name = "second category name", Description = "description" });
                Price = 100.99m;
                AvailableCount = 9;
            }
        }
    }
}