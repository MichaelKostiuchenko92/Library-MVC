using AutoMapper;

using Library.DLL.Repositories;
using Library.Entities;
using Library.ViewModels.Enums;
using Library.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Library.BLL.Services
{
    public class BookService
    {
        private BookRepository _bookRepository;

        public BookService(string connection)
        {
            _bookRepository = new BookRepository(connection);
        }

        public IEnumerable<BookViewModel> GetAll()
        {
            List<Book> books = _bookRepository.GetAll().ToList();
            var result = Mapper.Map<List<Book>, List<BookViewModel>>(books);
            return result;
        }

        public BookViewModel Get(int id)
        {
            Book book = _bookRepository.Get(id);
            var result = Mapper.Map<Book, BookViewModel>(book);
            return result;
        }

        public void Delete(int id)
        {
            _bookRepository.Delete(id);
        }


        public void Create(BookViewModel bookViewModel)
        {
            var book = Mapper.Map<BookViewModel, Book>(bookViewModel);
            book.Type = LibraryType.Books;
            _bookRepository.Create(book);
        }

        public void Update(BookViewModel bookViewModel)
        {
            var book = Mapper.Map<BookViewModel, Book>(bookViewModel);
            int id = book.BookId;
            book.Type = LibraryType.Books;
            _bookRepository.Update(book);
        }
    }
}
