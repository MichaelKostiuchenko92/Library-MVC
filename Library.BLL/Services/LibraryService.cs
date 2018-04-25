using AutoMapper;
using Library.DLL.Entities;
using Library.DLL.Repositories;
using Library.Entities;
using Library.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Services
{
    public class LibraryService
    {
        private BookRepository _bookRepository;
        private BrochureRepository _brochureRepository;
        private MagazineRepository _magazineRepository;

        public LibraryService(string connection)
        {
            _bookRepository = new BookRepository(connection);
            _brochureRepository = new BrochureRepository(connection);
            _magazineRepository = new MagazineRepository(connection);
        }

        public IEnumerable<LibraryViewModel> GetLibrary()
        {
            List<Book> books = _bookRepository.GetAll().ToList();
            var viewBooks = Mapper.Map<List<Book>, List<LibraryViewModel>>(books);

            List<Brochure> brochures = _brochureRepository.GetAll().ToList();
            var viewBrochures = Mapper.Map<List<Brochure>, List<LibraryViewModel>>(brochures);

            List<Magazine> magazines = _magazineRepository.GetAll().ToList();
            var viewMagazines = Mapper.Map<List<Magazine>, List<LibraryViewModel>>(magazines);

            List<LibraryViewModel> library = new List<LibraryViewModel>();

            library.AddRange(viewBooks);
            library.AddRange(viewBrochures);
            library.AddRange(viewMagazines);
            
            return library;
        }
    }
}
