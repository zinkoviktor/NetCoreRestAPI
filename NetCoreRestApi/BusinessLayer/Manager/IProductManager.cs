using BusinessLayer.Models;
using System.Collections.Generic;

namespace BusinessLayer.Manager
{
    interface IProductManager
    {
        public IEnumerable<ProductModel> GetAll();
    }
}