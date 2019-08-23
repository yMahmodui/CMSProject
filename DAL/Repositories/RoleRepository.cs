using System.Linq;
using DAL.Interfaces;
using Models;

namespace DAL.Repositories
{
    internal class RoleRepository : IRoleRepository
    {
        public RoleRepository(DatabaseContext context)
        {
            DatabaseContext = context;
        }

        protected DatabaseContext DatabaseContext { get; set; }

        public void AddRole(Role role)
        {
            DatabaseContext.Roles.Add(role);
        }

        public void AddPermission(Permission permission)
        {
            DatabaseContext.Permissions.Add(permission);
        }

        public void AddPermissionsToRole(Permission[] permissions, Role role)
        {
            //Clear all permission of role
            DatabaseContext.RolePermissions.Where(r => r.RoleId == role.RoleId).ToList()
                .ForEach(r => DatabaseContext.RolePermissions.Remove(r));

            foreach (var permission in permissions)
                DatabaseContext.RolePermissions.Add(new RolePermission
                {
                    RoleId = role.RoleId,
                    PermissionId = permission.PermissionId
                });
        }
    }
}