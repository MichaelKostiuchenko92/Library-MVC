using AutoMapper;
using Library.DLL.Entities;
using Library.DLL.Repositories;
using Library.Entities;
using Library.ViewModels.Enums;
using Library.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Services
{
    public class BrochureService
    {
        private BrochureRepository _brochureRepository;

        public BrochureService(string connection)
        {
            _brochureRepository = new BrochureRepository(connection);
        }

        public IEnumerable<BrochureViewModel>  GetAll()
        {
            List<Brochure> brochures = _brochureRepository.GetAll().ToList();
            var result = Mapper.Map<List<Brochure>, List<BrochureViewModel>>(brochures);

            return result;
        }

        public BrochureViewModel Get(int id)
        {
            Brochure brochure = _brochureRepository.Get(id);
            var result = Mapper.Map<Brochure, BrochureViewModel>(brochure);
            return result;
        }

        public void Delete(int id)
        {
            _brochureRepository.Delete(id);
        }

        public void Create(BrochureViewModel brochureViewModel)
        {
            var brochure = Mapper.Map<BrochureViewModel, Brochure>(brochureViewModel);
            brochure.Type = LibraryType.Brochures;

            _brochureRepository.Create(brochure);
        }

        public void Update(BrochureViewModel brochureViewModel)
        {
            var brochure = Mapper.Map<BrochureViewModel, Brochure>(brochureViewModel);

            int id = brochure.BrochureId;
            brochure.Type = LibraryType.Brochures;
            _brochureRepository.Update(brochure);
        }
    }
}
