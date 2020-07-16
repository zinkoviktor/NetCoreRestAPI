using Common.Converter;
using DataLayer.EF.Entities;
using DataLayer.Models;
using DataLayer.Repositories;
using DataLayerEF;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.EF.Repositories
{
    public class BaseRepository<TModel, TEntity, TId> : IRepository<TModel, TId> 
        where TModel : BaseModel<TId>
        where TEntity : BaseEntity<TId>
    {
        protected IConverter<TEntity, TModel> Сonverter { get; private set; }
        protected IDbContext<TEntity> DBContext { get; private set; }

        public BaseRepository(IDbContext<TEntity> dbContext, IConverter<TEntity, TModel> converter)
        {
            Сonverter = converter;
            DBContext = dbContext;
        }

        public virtual TModel GetById(TId id)
        {
            var entity = DBContext.GetDbSet().FirstOrDefault(entity => entity.Id.Equals(id));
            return Сonverter.ConvertTo(entity);
        }

        public virtual IQueryable<TModel> GetAll()
        {
            var entities = DBContext.GetDbSet().ToList();
            return Сonverter.ConvertTo(entities).AsQueryable();
        }

        public virtual IQueryable<TModel> Create(ICollection<TModel> models)
        {
            DBContext.GetDbSet().AddRange(Сonverter.ConvertFrom(models));
            var entities = DBContext.Save();
            return Сonverter.ConvertTo(entities).AsQueryable();            
        }

        public virtual IQueryable<TModel> Update(ICollection<TModel> models)
        {
            DBContext.GetDbSet().UpdateRange(Сonverter.ConvertFrom(models));
            var entities = DBContext.Save();
            return Сonverter.ConvertTo(entities).AsQueryable();
        }

        public virtual IQueryable<TModel> Delete(ICollection<TModel> models)
        {
            DBContext.GetDbSet().RemoveRange(Сonverter.ConvertFrom(models));
            var entities = DBContext.Save();
            return Сonverter.ConvertTo(entities).AsQueryable();
        }
    }
}
