using Common.Converter;
using DataLayer.EF.Entities;
using DataLayer.Models;
using DataLayer.Repositories;

namespace DataLayer.EF.Repositories
{
    public class ProductRepository : BaseRepository<ProductModel, ProductEntity, int>, IProductRepository
    {
        private readonly ICategoryRepository _categoryRepository;
        public ProductRepository(IDbContext dbContext,
            IConverter<ProductEntity, ProductModel> converter, ICategoryRepository categoryRepository)
                : base(dbContext, converter)
        {
            _categoryRepository = categoryRepository;
        }
    }
}
