using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class ChapterConfiguration : IEntityTypeConfiguration<Chapter>
{
    public void Configure(EntityTypeBuilder<Chapter> builder)
      {
            builder.ToTable("chapters");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("id");

            builder.Property(c => c.Survey_id)
                .HasColumnName("survey_id");

            builder.Property(c => c.Created_at)
                .HasColumnName("created_at")
                .HasColumnType("timestamp(6)");

            builder.Property(c => c.Updated_at)
                .HasColumnName("updated_at")
                .HasColumnType("timestamp(6)");

            builder.Property(c => c.Componenthtml)
                .HasColumnName("componenthtml")
                .HasMaxLength(20);

            builder.Property(c => c.Componentreact)
                .HasColumnName("componentreact")
                .HasMaxLength(20);

            builder.Property(c => c.Chapter_number)
                .HasColumnName("chapter_number")
                .HasMaxLength(50);

            builder.Property(c => c.Chapter_title)
                .HasColumnName("chapter_title")
                .IsRequired();


            builder.HasOne(c => c.Survey)
                .WithMany(s => s.Chapters)
                .HasForeignKey(c => c.Survey_id)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(c => c.Questions)
                .WithOne(q => q.Chapter)
                .HasForeignKey(q => q.Chapter_id)
                .OnDelete(DeleteBehavior.NoAction);
        }
}