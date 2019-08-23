using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class RolePermission
    {
        [Key] public int RolePermissionId { get; set; }

        public int RoleId { get; set; }

        public int PermissionId { get; set; }

        public virtual Role Role { get; set; }

        public virtual Permission Permission { get; set; }
    }
}