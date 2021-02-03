using Contact_Manager.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact_Manager.Repositories
{
    public interface IFileUpload:IDisposable
    {
        IEnumerable<ContactManager> GetContact();

        void InsertContact(IFormFile contactManager);

        void Save();
    }
}
