using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class FirstActivityDbContext : DbContext
    {
        public FirstActivityDbContext(DbContextOptions<FirstActivityDbContext> options) : base(options)
        {
        }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Sub_question> Sub_questions { get; set; }
        public DbSet<Option_question> Option_questions { get; set; }
        public DbSet<Categories_catalog> Categories_catalogs { get; set; }
        public DbSet<Category_option> Category_options { get; set; }
        public DbSet<Summary_option> Summary_options { get; set; }
        public DbSet<Options_response> Options_responses { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<MemberRols> MemberRols { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}