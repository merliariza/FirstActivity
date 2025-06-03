using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class Option_questionConfiguration : IEntityTypeConfiguration<Option_question>
{
    public void Configure(EntityTypeBuilder<Option_question> builder)
    {
        builder.ToTable("option_questions");

        builder.HasKey(oq => oq.Id);

        builder.Property(oq => oq.Id)
            .HasColumnName("id");

        builder.Property(oq => oq.Created_at)
            .HasColumnName("created_at")
            .HasColumnType("timestamp(6)");

        builder.Property(oq => oq.Option_id)
            .HasColumnName("option_id");

        builder.Property(oq => oq.Optioncatalog_id)
            .HasColumnName("optioncatalog_id");

        builder.Property(oq => oq.Optionquestion_id)
            .HasColumnName("optionquestion_id");

        builder.Property(oq => oq.Subquestion_id)
            .HasColumnName("subquestion_id");

        builder.Property(oq => oq.Updated_at)
            .HasColumnName("updated_at")
            .HasColumnType("timestamp(6)");

        builder.Property(oq => oq.Comment_options)
            .HasColumnName("comment_options");

        builder.Property(oq => oq.Numberoption)
            .HasColumnName("numberoption")
            .HasMaxLength(20);


        builder.HasOne(oq => oq.Sub_question)
            .WithMany(sq => sq.Option_questions)
            .HasForeignKey(oq => oq.Optionquestion_id)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(oq => oq.Categories_catalogs)
            .WithMany(cc => cc.Option_questions)
            .HasForeignKey(oq => oq.Optioncatalog_id)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(oq => oq.Question)
           .WithMany(q => q.Option_questions)
           .HasForeignKey(oq => oq.Optionquestion_id)
           .OnDelete(DeleteBehavior.NoAction);
            
         builder.HasOne(oq => oq.Options_responses)
            .WithMany(or => or.Option_questions)
            .HasForeignKey(oq => oq.Option_id)
            .OnDelete(DeleteBehavior.NoAction);

    }
}