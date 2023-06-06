using DevBlog.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevBlog.Core.EntityConfigurations.FluentAPI
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(prop => prop.ID);

            builder.Property(prop => prop.Name)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}