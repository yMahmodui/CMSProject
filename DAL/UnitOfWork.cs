using System;
using DAL.Interfaces;
using DAL.Repositories;
using Models;

namespace DAL
{
    internal class UnitOfWork : IDisposable
    {
        private DatabaseContext _context;

        protected virtual DatabaseContext DatabaseContext => _context ?? (_context = new DatabaseContext());

        private IUserRepository _userRepository;

        public IUserRepository UserRepository => _userRepository ?? (_userRepository = new UserRepository(DatabaseContext));

        private IRoleRepository _roleRepository;

        public IRoleRepository RoleRepository => _roleRepository ?? (_roleRepository = new RoleRepository(DatabaseContext));

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            DatabaseContext.SaveChanges();
        }
    }
}