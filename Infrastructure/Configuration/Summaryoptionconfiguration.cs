using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration;

public class Summary_optionConfiguration : IEntityTypeConfiguration<Summary_option>
{
    public void Configure(EntityTypeBuilder<Summary_option> builder)
    {
        builder.ToTable("summary_options");

        builder.HasKey(so => so.Id);

        builder.Property(so => so.Id)
            .HasColumnName("id");

        builder.Property(so => so.Id_survey)
            .HasColumnName("id_survey");

        builder.Property(so => so.Code_number)
            .HasColumnName("code_number")
            .HasMaxLength(20);

        builder.Property(so => so.Idquestion)
            .HasColumnName("idquestion");

        builder.Property(so => so.Valuerta)
            .HasColumnName("valuerta");

        builder.HasOne(so => so.Question)
            .WithMany(q => q.Summary_options)
            .HasForeignKey(so => so.Idquestion)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(so => so.Survey)
            .WithMany(s => s.Summary_options)
            .HasForeignKey(so => so.Id_survey)
            .OnDelete(DeleteBehavior.NoAction);


    }
}