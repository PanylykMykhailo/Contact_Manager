using Contact_Manager.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;

namespace Contact_Manager.Service
{
    public class ContactService :IContactService
    {
        public IEnumerable<ContactManagerViewModel> CsvToModel(IFormFile contact)
        {

            using (StreamReader streamReader = new StreamReader(contact.OpenReadStream()))
            {
                using (CsvReader csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    var result = csvReader.GetRecords<ContactManagerViewModel>().ToList();
                    return result;
                }
            }

        }
    }
}
