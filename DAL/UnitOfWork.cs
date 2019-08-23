using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL
{
    class UnitOfWork : IDisposable
    {
        private DatabaseContext _context;

        protected virtual Models.DatabaseContext DatabaseContext => _context ?? (_context = new Models.DatabaseContext());

        public void Save()
        {
            DatabaseContext.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
