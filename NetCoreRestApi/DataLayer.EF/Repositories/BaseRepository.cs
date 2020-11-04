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
        protected IConverter<TEntity, TModel> converter;
        protected DbSet<TEntity> dbSet;

        public BaseRepository(IDbContext dbContext, IConverter<TEntity, TModel> converter)
        {
            this.converter = converter;
            dbSet = dbContext.GetDbSet<TEntity>();
        }

        public virtual TModel GetById(TId id)
        {
            var entity = dbSet.FirstOrDefault(entity => entity.Id.Equals(id));
            return converter.ConvertTo(entity);
        }

        public virtual IEnumerable<TModel> GetAll()
        {
            var entities = dbSet.ToList();
            return converter.ConvertTo(entities).AsQueryable();
        }

        public virtual IQueryable<TModel> Create(IEnumerable<TModel> models)
        {
            var entities = converter.ConvertFrom(models);
            dbSet.AddRange(entities);

            return models.AsQueryable();
        }

        public abstract int Update(IEnumerable<TModel> models);

        public virtual int Delete(IEnumerable<TModel> models)
        {
            var entities = converter.ConvertFrom(models);
            var foundEntitiesToDelete = new List<TEntity>();

            foreach (var entity in entities)
            {
                var foundEntity = dbSet.Find(entity.Id);

                if (foundEntity != null)
                {
                    foundEntitiesToDelete.Add(foundEntity);
                }
            }

            dbSet.RemoveRange(foundEntitiesToDelete);

            return foundEntitiesToDelete.Count;
        }
    }
}
