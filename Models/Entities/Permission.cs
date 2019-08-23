using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Permission
    {
        [MaxLength(32)] public string PermissionTitle { get; set; }

        public virtual List<RolePermission> RolePermissions { get; set; }
    }
}