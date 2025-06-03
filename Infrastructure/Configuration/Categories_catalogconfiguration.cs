using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class Categories_catalogConfiguration : IEntityTypeConfiguration<Categories_catalog>
{
    public void Configure(EntityTypeBuilder<Categories_catalog> builder)
    {
        builder.ToTable("categories_catalog");

        builder.HasKey(cc => cc.Id);

        builder.Property(cc => cc.Id)
            .HasColumnName("id");

        builder.Property(cc => cc.Created_at)
            .HasColumnName("created_at")
            .HasColumnType("timestamp(6)");

        builder.Property(cc => cc.Updated_at)
            .HasColumnName("updated_at")
            .HasColumnType("timestamp(6)");

        builder.Property(cc => cc.Name)
            .HasColumnName("name")
            .HasMaxLength(255);

        builder.HasMany(cc => cc.Option_questions)
            .WithOne(oq => oq.Categories_catalogs)
            .HasForeignKey(oq => oq.Optioncatalog_id)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(cc => cc.Category_options)
            .WithOne(co => co.Categories_catalogs)
            .HasForeignKey(co => co.Catalogoptions_id)
            .OnDelete(DeleteBehavior.NoAction);

    }
}