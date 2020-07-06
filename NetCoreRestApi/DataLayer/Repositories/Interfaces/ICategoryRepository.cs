using DataLayer.Models;

namespace DataLayer.Repositories
{
    public interface ICategoryRepository<TId> : IRepository<CategoryModel<TId>, TId>
    {
    }
}
