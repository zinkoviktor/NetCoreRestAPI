using DataLayer.Models;
using System.Linq;

namespace BusinessLayer.Managers
{
    public interface ICategoryManager
    {
        IQueryable<CategoryModel> GetAll();
    }
}
