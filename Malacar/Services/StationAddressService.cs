using Malacar.Interfaces;
using Malacar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Malacar.Services
{
    public class StationAddressService : BaseService
    {
        public StationAddressService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<StationAddress> GetStationAddresses()
        {
            return repositoryWrapper.StationAddressRepository.FindAll().ToList();
        }

        public List<StationAddress> GetStationAddressesByCondition(Expression<Func<StationAddress, bool>> expression)
        {
            return repositoryWrapper.StationAddressRepository.FindByCondition(expression).ToList();
        }

        public void AddStationAddress(StationAddress stationaddress)
        {
            repositoryWrapper.StationAddressRepository.Create(stationaddress);
        }

        public void UpdateStationAddress(StationAddress stationaddress)
        {
            repositoryWrapper.StationAddressRepository.Update(stationaddress);
        }

        public void DeleteStationAddress(StationAddress stationaddress)
        {
            repositoryWrapper.StationAddressRepository.Delete(stationaddress);
        }
    }
}
