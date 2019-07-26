using GraphQLDemo.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.Models
{
    public class BpfDbContext : DbContext
    {
        public DbSet<BP_EmpInfo> BP_EmpInfo { get; set; }

        public BpfDbContext(DbContextOptions<BpfDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
