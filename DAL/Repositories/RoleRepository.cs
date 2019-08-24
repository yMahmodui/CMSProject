using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using Models;

namespace DAL.Repositories
{
    internal class RoleRepository : IRoleRepository
    {
        private readonly DatabaseContext DatabaseContext;

        public RoleRepository(DatabaseContext context)
        {
            DatabaseContext = context;
        }

        public void AddRole(Role role)
        {
            DatabaseContext.Roles.Add(role);
        }

        public List<Permission> GetPermissions()
        {
            return DatabaseContext.Permissions.ToList();
        }

        public List<Role> GetRoles()
        {
            return DatabaseContext.Roles.ToList();
        }

        public void AddPermission(Permission permission)
        {
            DatabaseContext.Permissions.Add(permission);
        }

        public void AddPermissionsToRole(Permission[] permissions, Role role)
        {
            //Clear all permission of role
            role.Permissions.Clear();

            foreach (var permission in permissions)
                role.Permissions.Add(permission);
        }
    }
}