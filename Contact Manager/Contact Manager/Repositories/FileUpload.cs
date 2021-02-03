using Contact_Manager.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact_Manager.Repositories
{
    public class FileUpload:IFileUpload
    {
        private readonly ApplicationContext _context;

        public FileUpload(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<ContactManager> GetContact()
        {
            return _context.FileUpload.ToList();
        }

        public void InsertContact(IFormFile context)
        {
            //_context.FileUpload.Add(context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
