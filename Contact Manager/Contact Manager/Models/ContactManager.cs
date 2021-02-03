using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact_Manager.Models
{
    public class ContactManager
    {
        
        public int Id { get; set; } 
        public string Name { get; set; }
        public DateTime Dateofbirth { get; set; }
        public bool Married { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }

    }
}
