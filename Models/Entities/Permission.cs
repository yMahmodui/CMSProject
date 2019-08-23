using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Permission
    {
        [Key] public int PermissionId { get; set; }

        [MaxLength(32)] public string PermissionTitle { get; set; }

        public virtual List<RolePermission> RolePermissions { get; set; }
    }
}