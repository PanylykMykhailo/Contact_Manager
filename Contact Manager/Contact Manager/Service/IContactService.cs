using Contact_Manager.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact_Manager.Service
{
    public interface IContactService
    {
        IEnumerable<ContactManagerViewModel> CsvToModel(IFormFile contact);
    }
}
