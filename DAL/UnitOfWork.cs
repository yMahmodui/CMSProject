using System;
using System.Collections.Generic;
using DAL.Interfaces;
using DAL.Repositories;
using Dtx.Security;
using Models;

namespace DAL
{
    public class UnitOfWork : IDisposable
    {
        private DatabaseContext _context;

        private IRoleRepository _roleRepository;

        private IUserRepository _userRepository;

        private DatabaseContext DatabaseContext => _context ?? (_context = new DatabaseContext());

        public IUserRepository UserRepository =>
            _userRepository ?? (_userRepository = new UserRepository(DatabaseContext));

        public IRoleRepository RoleRepository =>
            _roleRepository ?? (_roleRepository = new RoleRepository(DatabaseContext));

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            DatabaseContext.SaveChanges();
        }

        public void Initialize()
        {
            var users = UserRepository.GetUsers();
            var roles = RoleRepository.GetRoles();
            var permissions = RoleRepository.GetPermissions();

            var ReadFullPassage = new Permission
            {
                PermissionId = (int)Dtx.Enums.Permission.ReadFullPassage,
                PermissionTitle = "ReadFullPassage"
            };
            var GetUsers = new Permission
            {
                PermissionId = (int)Dtx.Enums.Permission.GetUsers,
                PermissionTitle = "GetUsers"
            };
            var adminRole = new Role
            {
                RoleId = 1,
                RoleTitle = "Admin",
                Permissions = new List<Permission> {GetUsers, ReadFullPassage}
            };
            var userRole = new Role
            {
                RoleId = 2,
                RoleTitle = "User",
                Permissions = new List<Permission> {ReadFullPassage}
            };

            if (permissions.Count == 0)
            {
                RoleRepository.AddPermission(ReadFullPassage);
                RoleRepository.AddPermission(GetUsers);
                Save();
            }

            if (roles.Count == 0)
            {
                RoleRepository.AddRole(adminRole);
                RoleRepository.AddRole(userRole);
                Save();
            }

            if (users.Count == 0)
            {
                UserRepository.AddUser(new User
                {
                    UserId = 1,
                    Email = "admin@localhost.com",
                    Password = Hashing.GetSha1(Hashing.GetMD5("password").ToLower() + "ConstValue"),
                    Role = adminRole,
                    RegisterDate = DateTime.Now.ToString("MM/dd/yyyy HH:mm")
                });
                UserRepository.AddUser(new User
                {
                    UserId = 2,
                    Email = "test@localhost.com",
                    Password = Hashing.GetSha1(Hashing.GetMD5("password").ToLower() + "ConstValue"),
                    Role = userRole,
                    RegisterDate = DateTime.Now.ToString("MM/dd/yyyy HH:mm")
                });
                Save();
            }
        }
    }
}