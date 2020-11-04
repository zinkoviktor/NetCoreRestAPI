using Common.Converter;
using DataLayer.EF.Entities;
using DataLayer.Models;
using DataLayer.Repositories;
using System.Collections.Generic;

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

        public override int Update(IEnumerable<ProductModel> models)
        {
            var entities = converter.ConvertFrom(models);
            var foundEntitiesToUpdate = new List<ProductEntity>();

            foreach (var entity in entities)
            {
                var foundEntity = dbSet.Find(entity.Id);

                if (foundEntity != null)
                {
                    foundEntity.Name = entity.Name;
                    foundEntity.Description = entity.Description;
                    foundEntity.Price = entity.Price;
                    foundEntity.AvailableCount = entity.AvailableCount;

                    foundEntitiesToUpdate.Add(foundEntity);
                }
            }

            dbSet.UpdateRange(foundEntitiesToUpdate);

            return foundEntitiesToUpdate.Count;
        }
    }
}
