using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class SurveyConfiguration : IEntityTypeConfiguration<Survey>
{
    public void Configure(EntityTypeBuilder<Survey> builder)
    {
        builder.ToTable("surveys");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id)
                .HasColumnName("id");

          builder.Property(s => s.Created_at)
                .HasColumnName("created_at")
                .HasColumnType("timestamp(6)");

            builder.Property(s => s.Updated_at)
                .HasColumnName("updated_at")
                .HasColumnType("timestamp(6)");

            builder.Property(s => s.Componenthtml)
                .HasColumnName("componenthtml")
                .HasMaxLength(20);

            builder.Property(s => s.Componentreact)
                .HasColumnName("componentreact")
                .HasMaxLength(20);

            builder.Property(s => s.Description)
                .HasColumnName("description");

            builder.Property(s => s.Instruction)
                .HasColumnName("instruction");

            builder.Property(s => s.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.HasMany(s => s.Chapters)
                .WithOne(c => c.Survey)
                .HasForeignKey(c => c.Survey_id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(s => s.Summary_options)
                .WithOne(oq => oq.Survey)
                .HasForeignKey(oq => oq.Id_survey)
                .OnDelete(DeleteBehavior.NoAction);
    }
}