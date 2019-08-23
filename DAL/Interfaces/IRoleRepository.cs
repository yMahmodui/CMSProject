using Models;

namespace DAL.Interfaces
{
    internal interface IRoleRepository
    {
        void AddRole(Role role);

        void AddPermission(Permission permission);

        void AddPermissionsToRole(Permission[] permissions, Role role);
    }
}