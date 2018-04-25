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
    public class MagazineService
    {
        private MagazineRepository _magazineRepository;

        public MagazineService(string connection)
        {
            _magazineRepository = new MagazineRepository(connection);
        }

        public IEnumerable<MagazineViewModel> GetAll()
        {
            List<Magazine> magazines = _magazineRepository.GetAll().ToList();
            var result = Mapper.Map<List<Magazine>, List<MagazineViewModel>>(magazines);
            return result;
        }

        public MagazineViewModel Get(int id)
        {
            Magazine magazine = _magazineRepository.Get(id);
            var result = Mapper.Map<Magazine, MagazineViewModel>(magazine);
            return result;
        }

        public void Create(MagazineViewModel magazineViewModel)
        {
            var magazine = Mapper.Map<MagazineViewModel, Magazine>(magazineViewModel);
            magazine.Type = LibraryType.Magazines;
            _magazineRepository.Create(magazine);
        }

        public void Delete(int id)
        {
            _magazineRepository.Delete(id);
        }

        public void Update(MagazineViewModel magazineViewModel)
        {
            var magazine = Mapper.Map<MagazineViewModel, Magazine>(magazineViewModel);
            int id = magazine.MagazineId;
            magazine.Type = LibraryType.Magazines;
            _magazineRepository.Update(magazine);
        }
    }
}
