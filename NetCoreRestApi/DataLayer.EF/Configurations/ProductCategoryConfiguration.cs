using DataLayer.EF.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.EF.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategoriesEntity>
    {
        public void Configure(EntityTypeBuilder<ProductCategoriesEntity> builder)
        {
            builder
                .HasKey(pc => new { pc.CategoryId, pc.ProductId });
            builder
                 .HasOne(pc => pc.Product)
                 .WithMany(p => p.ProductCategoriesEntities)
                 .HasForeignKey(pc => pc.ProductId);
            builder
                 .HasOne(pc => pc.Category)
                 .WithMany(c => c.ProductCategoriesEntities)
                 .HasForeignKey(pc => pc.CategoryId);
        }
    }
}
