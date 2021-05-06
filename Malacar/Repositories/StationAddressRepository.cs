using Malacar.Interfaces;
using Malacar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Malacar.Repositories
{
    public class StationAddressRepository : RepositoryBase<StationAddress>, IStationAddressRepository
    {
        public StationAddressRepository(CarContext carContext)
            : base(carContext)
        {
        }
    }
}
