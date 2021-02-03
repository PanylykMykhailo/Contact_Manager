using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contact_Manager.Models
{
    public class ApplicationContext:DbContext
    {
        public DbSet<ContactManager> FileUpload { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            
        }
    }
}
