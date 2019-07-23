using GraphQLDemo.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.Models
{
    public class StringModel
    {
        public string Value { get; set; }
    }

    public class PcpDbContext : DbContext
    {
        public DbQuery<StringModel> StringModels { get; set; }

        public DbSet<LessonPlan> LessonPlan { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public PcpDbContext(DbContextOptions<PcpDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
