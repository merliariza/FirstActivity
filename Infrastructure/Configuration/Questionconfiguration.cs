using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.ToTable("questions");

        builder.HasKey(q => q.Id);

        builder.Property(q => q.Id)
            .HasColumnName("id");

        builder.Property(q => q.Chapter_id)
            .HasColumnName("chapter_id");

        builder.Property(q => q.Created_at)
            .HasColumnName("created_at")
            .HasColumnType("timestamp(6)");

        builder.Property(q => q.Updated_at)
            .HasColumnName("updated_at")
            .HasColumnType("timestamp(6)");

        builder.Property(q => q.Question_number)
            .HasColumnName("question_number")
            .HasMaxLength(10);

        builder.Property(q => q.Response_type)
            .HasColumnName("response_type")
            .HasMaxLength(10);

        builder.Property(q => q.Comment_question)
            .HasColumnName("comment_question");

        builder.Property(q => q.Question_text)
            .HasColumnName("question_text")
            .IsRequired();

        builder.HasOne(q => q.Chapter)
            .WithMany(c => c.Questions)
            .HasForeignKey(q => q.Chapter_id)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(q => q.Summary_options)
            .WithOne(so => so.Question)
            .HasForeignKey(so => so.Idquestion)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(q => q.Sub_questions)
                .WithOne(sq => sq.Question)
                .HasForeignKey(sq => sq.Subquestion_id)
                .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(q => q.Option_questions)
                .WithOne(oq => oq.Question)
                .HasForeignKey(oq => oq.Option_id)
                .OnDelete(DeleteBehavior.NoAction);
    }
}