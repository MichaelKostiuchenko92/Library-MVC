using Library.DLL.Entities;
using Library.DLL.Interfaces;
using Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DLL.Repositories
{
    public class MagazineRepository : GenericRepository<Magazine>
    {

        public MagazineRepository(string connection) : base(connection)
        {
        
        }
    }
}
