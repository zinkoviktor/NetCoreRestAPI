using DataLayer.EF.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.EF.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder
                .HasKey(c => c.Id);
            builder
                .Property(c => c.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder
                .Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired();
            builder
                .Property(c => c.Description)
                .HasMaxLength(150);            
        }
    }
}
