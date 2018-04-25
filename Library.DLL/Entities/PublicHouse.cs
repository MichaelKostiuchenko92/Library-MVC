using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DLL.Entities
{
    public class PublicHouse
    {
        [Key]
        public int PublicHouseId { get; set; }

        public string PublicHouseName { get; set; }

        public string Country { get; set; }

        public virtual ICollection<Book> Books { get; set; }

    }
}
