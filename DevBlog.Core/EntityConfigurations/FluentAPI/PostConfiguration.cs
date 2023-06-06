using DevBlog.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevBlog.Core.EntityConfigurations.FluentAPI
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(prop => prop.ID);

            builder.Property(prop => prop.Content)
                .IsUnicode()
                .IsRequired();

            builder.Property(prop => prop.PostTumbnailImageUrl)
                .IsRequired();

            builder.Property(prop => prop.PostUrl)
                .IsRequired();

            builder.Property(prop => prop.PublishedDate)
                .IsRequired();

            builder.Property(prop => prop.ShortDescription)
                .IsRequired();

            builder.Property(prop => prop.Title)
                .IsRequired();

            builder.Property(prop => prop.Author)
                .HasMaxLength(20)
                .IsRequired();
        }
    }
}