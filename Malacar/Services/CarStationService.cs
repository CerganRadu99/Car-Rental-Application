using Malacar.Interfaces;
using Malacar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Malacar.Services
{
    public class CarStationService : BaseService
    {
        public CarStationService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<CarStation> GetCarStations()
        {
            return RepositoryWrapper.CarStationRepository.FindAll().ToList();
        }

        public List<CarStation> GetCarStationsByCondition(Expression<Func<CarStation, bool>> expression)
        {
            return RepositoryWrapper.CarStationRepository.FindByCondition(expression).ToList();
        }

        public void AddCarStation(CarStation carstation)
        {
            RepositoryWrapper.CarStationRepository.Create(carstation);
        }

        public void UpdateCarStation(CarStation carstation)
        {
            RepositoryWrapper.CarStationRepository.Update(carstation);
        }

        public void DeleteCarStation(CarStation carstation)
        {
            RepositoryWrapper.CarStationRepository.Delete(carstation);
        }
    }
}
