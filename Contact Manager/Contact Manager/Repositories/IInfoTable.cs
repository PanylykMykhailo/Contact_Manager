using Contact_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact_Manager.Repositories
{
    public interface IInfoTable
    {
        public IEnumerable<ContactManager> GetInformation();
    }
}
