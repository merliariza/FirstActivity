using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class Category_optionConfiguration : IEntityTypeConfiguration<Category_option>
{
    public void Configure(EntityTypeBuilder<Category_option> builder)
    {
        builder.ToTable("category_option");

        builder.HasKey(co => co.Id);

        builder.Property(co => co.Id)
            .HasColumnName("id");

        builder.Property(co => co.Catalogoptions_id)
            .HasColumnName("catalogoptions_id");

        builder.Property(co => co.Categoriesoptions_id)
            .HasColumnName("categoriesoptions_id");

        builder.Property(co => co.Created_at)
            .HasColumnName("created_at")
            .HasColumnType("timestamp(6)");

        builder.Property(co => co.Updated_at)
            .HasColumnName("updated_at")
            .HasColumnType("timestamp(6)");


        builder.HasOne(co => co.Options_responses)
            .WithMany(cc => cc.Category_options)
            .HasForeignKey(co => co.Categoriesoptions_id)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(co => co.Categories_catalogs)
            .WithMany(cc => cc.Category_options)
            .HasForeignKey(co => co.Catalogoptions_id)
            .OnDelete(DeleteBehavior.NoAction);

    }
}