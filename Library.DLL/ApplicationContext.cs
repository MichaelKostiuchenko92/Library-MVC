using Library.DLL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DLL
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(string conectionString) : base("LibraryContext")
        {

        }

        public ApplicationContext()
        {

        }
        public DbSet<ClientProfile> ClientProfiles { get; set; }
    }
}
