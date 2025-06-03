using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class Sub_questionConfiguration : IEntityTypeConfiguration<Sub_question>
{
    public void Configure(EntityTypeBuilder<Sub_question> builder)
    {
        builder.ToTable("sub_questions");

        builder.HasKey(sq => sq.Id);

        builder.Property(sq => sq.Id)
            .HasColumnName("id");

        builder.Property(sq => sq.Created_at)
            .HasColumnName("created_at")
            .HasColumnType("timestamp(6)");

        builder.Property(sq => sq.Subquestion_id)
            .HasColumnName("subquestion_id");

        builder.Property(sq => sq.Updated_at)
            .HasColumnName("updated_at")
            .HasColumnType("timestamp(6)");

        builder.Property(sq => sq.Subquestion_number)
            .HasColumnName("subquestion_number")
            .HasMaxLength(10);

        builder.Property(sq => sq.Comment_subquestion)
            .HasColumnName("comment_subquestion");

        builder.Property(sq => sq.Subquestion_text)
            .HasColumnName("subquestiontext")
            .IsRequired();

        builder.HasOne(sq => sq.Question)
            .WithMany(q => q.Sub_questions)
            .HasForeignKey(sq => sq.Subquestion_id)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(sq => sq.Option_questions)
            .WithOne(so => so.Sub_question)
            .HasForeignKey(so => so.Subquestion_id)
            .OnDelete(DeleteBehavior.NoAction);

    }
}