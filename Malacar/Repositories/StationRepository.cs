using Malacar.Interfaces;
using Malacar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Malacar.Repositories
{
    public class StationRepository : RepositoryBase<Station>, IStationRepository
    {
        public StationRepository(CarContext carContext)
            : base(carContext)
        {
        }
    }
}
