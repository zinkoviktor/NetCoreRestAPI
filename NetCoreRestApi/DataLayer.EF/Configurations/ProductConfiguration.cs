using DataLayer.EF.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.EF.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasMany(p => p.Categories).WithOne();
            builder.Property(p => p.Id).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(150);           
            builder.HasData(
                    new
                    {
                        Id = 221,
                        Name = "HP 410",
                        Description = "All-in-One Wireless Ink Tank Color Printer",
                        Price = 90m,
                        AvailableCount = 9
                    },                   
                    new {
                        Id = 222,
                        Name = "Epson L3152",
                        Description = "WiFi All in One Ink Tank Printer",
                        Price = 60m,
                        AvailableCount = 19
                    },
                    new {
                        Id = 322,
                        Name = "Dell Inspiron 3583",
                        Description = "15.6-inch FHD Laptop",
                        Price = 50m,
                        AvailableCount = 5
                    }
                    );
        }
    }
}
