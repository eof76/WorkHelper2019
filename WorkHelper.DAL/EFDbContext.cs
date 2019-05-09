using System.Data.Entity;
using WorkHelper.DAL.Entities;

namespace WorkHelper.DAL
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(string connectionString) : base(connectionString) { }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
