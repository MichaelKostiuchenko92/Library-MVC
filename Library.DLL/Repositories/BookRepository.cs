using Library.DLL.Entities;
using Library.DLL.Interfaces;
using Library.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DLL.Repositories
{
    public class BookRepository : GenericRepository<Book>
    {
        private LibraryContext _databaseLibraryContext;

        public BookRepository(string connection) : base(connection)
        {
            _databaseLibraryContext = new LibraryContext(connection);
        }

        public override void Create(Book book)
        {
            book.PublicHouses = _databaseLibraryContext.PublicHouses.Where(p => book.PubHouses.Contains(p.PublicHouseId)).ToList();
            _databaseLibraryContext.Books.Add(book);
            _databaseLibraryContext.SaveChanges();
        }

        public override void Update(Book book)
        {
            var bookForUpdate = _databaseLibraryContext.Books.Where(x => x.BookId == book.BookId).Include(p => p.PublicHouses).FirstOrDefault();
            bookForUpdate.Name = book.Name;
            bookForUpdate.AuthorName = book.AuthorName;
            bookForUpdate.YearOfPublishing = book.YearOfPublishing;
            bookForUpdate.Type = book.Type;
            bookForUpdate.PublicHouses = _databaseLibraryContext.PublicHouses.Where(p => book.PubHouses.Contains(p.PublicHouseId)).ToList();
            _databaseLibraryContext.SaveChanges();
        }
    }
}
