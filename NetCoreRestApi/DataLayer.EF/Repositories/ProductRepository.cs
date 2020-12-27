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

        public override IEnumerable<ProductModel> Create(IEnumerable<ProductModel> models)
        {
            var createdModels = new List<ProductModel>();

            foreach (var model in models)
            {
                var foundProduct = DbSet.FirstOrDefault(p => p.Name == model.Name);

                if (foundProduct == null)
                {
                    var productEntity = UpdateProductCategories(model);
                    var createdProduct = DbSet.Add(productEntity);
                    var createdModel = Сonverter.ConvertTo(createdProduct.Entity);
                    createdModels.Add(createdModel);
                }
            }

            return createdModels;
        }

        public override void Update(IEnumerable<ProductModel> models)
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
        }

        private ProductEntity UpdateProductCategories(ProductModel model)
        {
            var productEntity = Сonverter.ConvertFrom(model);

            foreach (var productCategory in productEntity.ProductCategoryEntities)
            {
                var foundCategory = _categoryDbSet.FirstOrDefault(
                    c => c.Name == productCategory.Category.Name);

                if (foundCategory != null)
                {
                    productCategory.CategoryId = foundCategory.Id;
                    productCategory.Category = foundCategory;
                }
            }

            return productEntity;
        }
    }
}
