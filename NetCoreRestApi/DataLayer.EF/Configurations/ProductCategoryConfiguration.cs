using DataLayer.EF.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.EF.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder
                .HasKey(pc => new { pc.CategoryId, pc.ProductId });
            builder
                 .HasOne(pc => pc.Product)
                 .WithMany(p => p.ProductCategory)
                 .HasForeignKey(pc => pc.ProductId);
            builder
                 .HasOne(pc => pc.Category)
                 .WithMany(c => c.ProductCategory)
                 .HasForeignKey(pc => pc.CategoryId);
        }
    }
}
