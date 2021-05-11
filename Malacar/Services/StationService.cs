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
            return RepositoryWrapper.StationRepository.FindAll().ToList();
        }

        public List<Station> GetStationsByCondition(Expression<Func<Station, bool>> expression)
        {
            return RepositoryWrapper.StationRepository.FindByCondition(expression).ToList();
        }

        public void AddStation(Station station)
        {
            RepositoryWrapper.StationRepository.Create(station);
        }

        public void UpdateStation(Station station)
        {
            RepositoryWrapper.StationRepository.Update(station);
        }

        public void DeleteStation(Station station)
        {
            RepositoryWrapper.StationRepository.Delete(station);
        }
    }
}
