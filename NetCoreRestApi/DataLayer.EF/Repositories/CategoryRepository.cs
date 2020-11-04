using Common.Converter;
using DataLayer.EF.Entities;
using DataLayer.Models;
using DataLayer.Repositories;
using System.Collections.Generic;

namespace DataLayer.EF.Repositories
{
    public class CategoryRepository : BaseRepository<CategoryModel, CategoryEntity, int>, ICategoryRepository
    {
        public CategoryRepository(IDbContext dbContext,
            IConverter<CategoryEntity, CategoryModel> converter)
                : base(dbContext, converter)
        {
        }

        public override int Update(IEnumerable<CategoryModel> models)
        {
            var entities = converter.ConvertFrom(models);
            var foundEntitiesToUpdate = new List<CategoryEntity>();

            foreach (var entity in entities)
            {
                var foundEntity = dbSet.Find(entity.Id);

                if (foundEntity != null)
                {
                    foundEntity.Name = entity.Name;
                    foundEntity.Description = entity.Description;

                    foundEntitiesToUpdate.Add(foundEntity);
                }
            }

            dbSet.UpdateRange(foundEntitiesToUpdate);

            return foundEntitiesToUpdate.Count;
        }
    }
}
