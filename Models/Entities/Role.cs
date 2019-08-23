using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Role
    {
        [Key] public int RoleId { get; set; }

        [MaxLength(32)] public string RoleTitle { get; set; }

        public virtual List<User> Users { get; set; }

        public virtual List<RolePermission> RolePermissions { get; set; }
    }
}