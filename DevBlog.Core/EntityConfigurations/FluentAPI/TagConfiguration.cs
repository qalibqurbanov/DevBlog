using DevBlog.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevBlog.Core.EntityConfigurations.FluentAPI
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(prop => prop.ID);

            builder.Property(prop => prop.Name)
                .IsRequired();
        }
    }
}