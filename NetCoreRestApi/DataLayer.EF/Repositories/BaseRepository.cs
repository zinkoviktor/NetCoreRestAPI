using Common.Converter;
using DataLayer.EF.Entities;
using DataLayer.Models;
using DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.EF.Repositories
{
    public class BaseRepository<TModel, TEntity, TId> : IRepository<TModel, TId> 
        where TModel : BaseModel<TId>
        where TEntity : BaseEntity<TId>
    {
        protected IConverter<TEntity, TModel> Сonverter { get; private set; }
        protected DbSet<TEntity> DbSet { get; private set; }

        public BaseRepository(IRepositoryDbContext<TEntity> dbContext, IConverter<TEntity, TModel> converter)
        {
            Сonverter = converter;
            DbSet = dbContext.GetDbSet();
        }

        public virtual TModel GetById(TId id)
        {
            var entity = DbSet.FirstOrDefault(entity => entity.Id.Equals(id));
            return Сonverter.ConvertTo(entity);
        }

        public virtual IQueryable<TModel> GetAll()
        {
            var entities = DbSet.ToList();
            return Сonverter.ConvertTo(entities).AsQueryable();
        }

        public virtual IQueryable<TModel> Create(ICollection<TModel> models)
        {
            DbSet.AddRange(Сonverter.ConvertFrom(models));            
            return models.AsQueryable();            
        }

        public virtual IQueryable<TModel> Update(ICollection<TModel> models)
        {
            DbSet.UpdateRange(Сonverter.ConvertFrom(models));           
            return models.AsQueryable();
        }

        public virtual IQueryable<TModel> Delete(ICollection<TModel> models)
        {
            DbSet.RemoveRange(Сonverter.ConvertFrom(models));
            return models.AsQueryable();
        }
    }
}
