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
    public class PublicHouseService
    {
        private PublicHouseRepository _publicHouseRepository;
        
        public PublicHouseService(string connection)
        {
            _publicHouseRepository = new PublicHouseRepository(connection);
        }

        public IEnumerable<PublicHouseViewModel> GetAll()
        {
            List<PublicHouse> publicHouses = _publicHouseRepository.GetAll().ToList();
            var result = Mapper.Map<List<PublicHouse>, List<PublicHouseViewModel>>(publicHouses);
            return result;
        }

        public PublicHouseViewModel Get(int id)
        {
            var publicHouse = _publicHouseRepository.Get(id);
            return Mapper.Map<PublicHouse, PublicHouseViewModel>(publicHouse);
        }

        public void Create(PublicHouseViewModel publicHouseViewModel)
        {
            var publicHouse = Mapper.Map<PublicHouseViewModel, PublicHouse>(publicHouseViewModel);
            _publicHouseRepository.Create(publicHouse);
        }

        public void Update(PublicHouseViewModel publicHouseViewModel)
        {
            var publicHouse = Mapper.Map<PublicHouseViewModel, PublicHouse>(publicHouseViewModel);
            _publicHouseRepository.Update(publicHouse);
        }

        public void Delete(int id)
        {
            _publicHouseRepository.Delete(id);
        }
    }
}
