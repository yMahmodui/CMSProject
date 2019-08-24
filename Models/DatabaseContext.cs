using System.Data.Entity;

namespace Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString)
        {
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new Role.Configuration());
        }
    }
}