using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace Models
{
    public class Role
    {
        [Key] public int RoleId { get; set; }

        public virtual List<User> Users { get; set; }

        public virtual List<Permission> Permissions { get; set; }

        [MaxLength(32)] public string RoleTitle { get; set; }

        internal class Configuration :
            EntityTypeConfiguration<Role>
        {
            public Configuration()
            {
                HasMany(current => current.Permissions)
                    .WithMany(group => group.Roles)
                    .Map(current =>
                    {
                        current.ToTable("RolesOfPermissions");


                        current.MapLeftKey("RoleId");
                        current.MapRightKey("PermissionId");
                    });
            }
        }
    }
}