using Microsoft.EntityFrameworkCore;
using MockCRM.Models;

namespace Pomelo.EntityFrameworkCore.MySql.IntegrationTests
{
    public class ApplicationDbContext : DbContext
    {
        // database model reference
        public DbSet<User> User { get; set; }
        public DbSet<Data> Data { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public override int SaveChanges()
        {
            foreach(var entry in ChangeTracker.Entries())
            {
                if(entry.Entity is  User user)
                {
                    user.HashPassword();
                }
            }
            base.SaveChanges(); return 0;
        }
    }
}