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

        public virtual IQueryable<TModel> GetAll(int pageIndex, int pageSize)
        {
            var entities = DbSet.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            var models = Сonverter.ConvertTo(entities);
            return models.AsQueryable();
        }

        public virtual IQueryable<TModel> Create(IEnumerable<TModel> models)
        {            
            var createdModels = new List<TModel>();

            foreach (var model in models)
            {
                var foundEntity = DbSet.Find(model.Id);

                if (foundEntity == null)
                {
                    var entity = Сonverter.ConvertFrom(model);                    
                    var createdEntity = DbSet.Add(entity);
                    var createdModel = Сonverter.ConvertTo(createdEntity.Entity);
                    createdModels.Add(createdModel);
                }
            }

            return createdModels.AsQueryable();
        }

        public abstract IQueryable<TModel> Update(IEnumerable<TModel> models);

        public virtual IQueryable<TModel> Delete(IEnumerable<TModel> models)
        {
            var entities = Сonverter.ConvertFrom(models);           

            foreach (var entity in entities)
            {
                var foundEntity = DbSet.Find(entity.Id);

                if (foundEntity != null)
                {
                    DbSet.Remove(foundEntity);
                }
            }
            
            return models.AsQueryable();
        }
    }
}
