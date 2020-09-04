using DataLayer.EF.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.EF.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<ProductCategoryEntity> builder)
        {
            builder
                .HasKey(pc => new { pc.CategoryId, pc.ProductId });
            builder
                 .HasOne(pc => pc.Product)
                 .WithMany(p => p.ProductCategoryEntities)
                 .HasForeignKey(pc => pc.ProductId);
            builder
                 .HasOne(pc => pc.Category)
                 .WithMany(c => c.ProductCategoryEntities)
                 .HasForeignKey(pc => pc.CategoryId);
        }
    }
}
