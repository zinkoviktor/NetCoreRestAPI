using BusinessLayer.Models;
using System.Collections.Generic;

namespace BusinessLayer.Manager
{
    public interface IProductManager
    {
        IEnumerable<ProductModel> GetAll();
    }
}