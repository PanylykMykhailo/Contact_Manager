using Contact_Manager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact_Manager.Repositories
{
    public class InfoTable:IInfoTable
    {
        private readonly ApplicationContext _dbContext;
        public InfoTable(ApplicationContext dbContex)
        {
            _dbContext = dbContex;
        }
        public IEnumerable<ContactManager> GetInformation()
        {
            var info = _dbContext.FileUpload.ToList();
            //var infoTableView= new InfoTableViewModel { informationTable = info };
            return info;

        }
    }
}
