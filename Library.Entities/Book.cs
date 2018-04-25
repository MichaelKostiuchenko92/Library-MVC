using Library.ViewModels.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Entities
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public int YearOfPublishing { get; set; }

        public LibraryType Type { get; set; }

        public List<int> PubHouses { get; set; }

        public virtual ICollection<PublicHouse> PublicHouses { get; set; }

    }
}
