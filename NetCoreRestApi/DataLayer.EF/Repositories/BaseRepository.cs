using Common.Converter;
using DataLayer.EF.Entities;
using DataLayer.Models;
using DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.EF.Repositories
{
    public abstract class BaseRepository<TModel, TEntity, TId> : IRepository<TModel, TId>
        where TModel : BaseModel<TId>
        where TEntity : BaseEntity<TId>
    {
        protected IConverter<TEntity, TModel> Сonverter { get; private set; }
        protected DbSet<TEntity> DbSet { get; private set; }

        public BaseRepository(IDbContext dbContext, IConverter<TEntity, TModel> converter)
        {
            Сonverter = converter;
            DbSet = dbContext.GetDbSet<TEntity>();
        }

        public virtual TModel GetById(TId id)
        {
            var entity = DbSet.FirstOrDefault(entity => entity.Id.Equals(id));
            return Сonverter.ConvertTo(entity);
        }

        public virtual IEnumerable<TModel> GetAll()
        {
            var entities = DbSet.ToList();
            return Сonverter.ConvertTo(entities).AsQueryable();
        }

        public virtual IQueryable<TModel> Create(IEnumerable<TModel> models)
        {
            DbSet.AddRange(Сonverter.ConvertFrom(models));
            return models.AsQueryable();
        }

        public abstract IQueryable<TModel> Update(IEnumerable<TModel> models);

        public virtual IQueryable<TModel> Delete(IEnumerable<TModel> models)
        {
            var entities = Сonverter.ConvertFrom(models);
            var foundEntitiesToDelete = new List<TEntity>();

            foreach (var entity in entities)
            {
                var foundEntity = DbSet.Find(entity.Id);

                if (foundEntity != null)
                {
                    foundEntitiesToDelete.Add(foundEntity);
                }
            }

            DbSet.RemoveRange(foundEntitiesToDelete);
            return models.AsQueryable();
        }
    }
}
