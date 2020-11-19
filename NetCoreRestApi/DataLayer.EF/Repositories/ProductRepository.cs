using Common.Converter;
using DataLayer.EF.Entities;
using DataLayer.Models;
using DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.EF.Repositories
{
    public class ProductRepository : BaseRepository<ProductModel, ProductEntity, int>, IProductRepository
    {
        private DbSet<CategoryEntity> _categoryDbSet;

        public ProductRepository(IDbContext dbContext, IConverter<ProductEntity, ProductModel> converter)
            : base(dbContext, converter)
        {
            _categoryDbSet = dbContext.GetDbSet<CategoryEntity>();
        }

        public override IQueryable<ProductModel> Create(IEnumerable<ProductModel> models)
        {
            var createdModels = new List<ProductModel>();

            foreach (var model in models)
            {
                var foundProduct = DbSet.FirstOrDefault(p => p.Name == model.Name);

                if (foundProduct == null)
                {
                    var product = Сonverter.ConvertFrom(model);
                    bool isAddProduct = false;

                    foreach (var productCategory in product.ProductCategoryEntities)
                    {
                        var foundCategory = _categoryDbSet.FirstOrDefault(
                            c => c.Name == productCategory.Category.Name);

                        if (foundCategory != null)
                        {
                            productCategory.CategoryId = foundCategory.Id;
                            productCategory.Category = foundCategory;
                            isAddProduct = true;
                        }
                        else
                        {
                            isAddProduct = false;
                            break;
                        }
                    }

                    if (isAddProduct)
                    {
                        var createdProduct = DbSet.Add(product);
                        var createdModel = Сonverter.ConvertTo(createdProduct.Entity);
                        createdModels.Add(createdModel);
                    }
                }
            }

            return createdModels.AsQueryable();
        }

        public override IQueryable<ProductModel> Update(IEnumerable<ProductModel> models)
        {
            var entities = Сonverter.ConvertFrom(models);
            var foundEntitiesToUpdate = new List<ProductEntity>();

            foreach (var entity in entities)
            {
                var foundEntity = DbSet.Find(entity.Id);

                if (foundEntity != null)
                {
                    foundEntity.Name = entity.Name;
                    foundEntity.Description = entity.Description;
                    foundEntity.Price = entity.Price;
                    foundEntity.AvailableCount = entity.AvailableCount;

                    foundEntitiesToUpdate.Add(foundEntity);
                }
            }

            DbSet.UpdateRange(foundEntitiesToUpdate);
            return models.AsQueryable();
        }
    }
}
