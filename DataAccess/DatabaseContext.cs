using DataAccess.EntityConfigurations;
using Domain.ToDo.Entity;
using Domain.User.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaskConfiguration());
        }

        public DbSet<ToDo> ToDo { get; set; }
        public DbSet<User> User { get; set; }
    }
}