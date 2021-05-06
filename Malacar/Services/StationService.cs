using Malacar.Interfaces;
using Malacar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Malacar.Services
{
    public class StationService : BaseService
    {
        public StationService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<Station> GetStations()
        {
            return repositoryWrapper.StationRepository.FindAll().ToList();
        }

        public List<Station> GetStationsByCondition(Expression<Func<Station, bool>> expression)
        {
            return repositoryWrapper.StationRepository.FindByCondition(expression).ToList();
        }

        public void AddStation(Station station)
        {
            repositoryWrapper.StationRepository.Create(station);
        }

        public void UpdateStation(Station station)
        {
            repositoryWrapper.StationRepository.Update(station);
        }

        public void DeleteStation(Station station)
        {
            repositoryWrapper.StationRepository.Delete(station);
        }
    }
}
