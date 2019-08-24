using System.Collections.Generic;
using Models;

namespace DAL.Interfaces
{
    public interface IRoleRepository
    {
        List<Role> GetRoles();

        void AddRole(Role role);

        List<Permission> GetPermissions();

        void AddPermission(Permission permission);

        void AddPermissionsToRole(Permission[] permissions, Role role);
    }
}