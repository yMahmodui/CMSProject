using System.Data.Entity;

namespace Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("Data Source=.;Initial Catalog=MvcDB;Integrated Security=true;")
        {
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
    }
}