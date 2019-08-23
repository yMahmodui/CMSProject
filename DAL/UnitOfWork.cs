using System;
using Models;

namespace DAL
{
    internal class UnitOfWork : IDisposable
    {
        private DatabaseContext _context;

        protected virtual DatabaseContext DatabaseContext => _context ?? (_context = new DatabaseContext());

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