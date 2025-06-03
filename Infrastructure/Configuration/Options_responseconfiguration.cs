using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class Options_responseConfiguration : IEntityTypeConfiguration<Options_response>
{
    public void Configure(EntityTypeBuilder<Options_response> builder)
    {
        builder.ToTable("Options_response");

        builder.HasKey(or => or.Id);

        builder.Property(or => or.Id)
            .HasColumnName("id");

        builder.Property(or => or.Created_at)
            .HasColumnName("created_at")
            .HasColumnType("timestamp(6)");

        builder.Property(or => or.Updated_at)
            .HasColumnName("updated_at")
            .HasColumnType("timestamp(6)");

        builder.Property(or => or.Optiontext)
            .HasColumnName("optiontext");

        builder.HasMany(or => or.Option_questions)
            .WithOne(oq => oq.Options_responses)
            .HasForeignKey(oq => oq.Option_id)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(or => or.Category_options)
            .WithOne(co => co.Options_responses)
            .HasForeignKey(co => co.Categoriesoptions_id)
            .OnDelete(DeleteBehavior.NoAction);

    }
}