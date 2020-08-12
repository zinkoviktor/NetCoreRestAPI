using Common.Converter;
using DataLayer.EF.Entities;
using DataLayer.Models;
using DataLayer.Repositories;

namespace DataLayer.EF.Repositories
{
    public class CategoryRepository : BaseRepository<CategoryModel, CategoryEntity, int>, ICategoryRepository
    {
        public CategoryRepository(IDbContext dbContext,
            IConverter<CategoryEntity, CategoryModel> converter)
                : base(dbContext, converter)
        {                        
        }
    }
}
