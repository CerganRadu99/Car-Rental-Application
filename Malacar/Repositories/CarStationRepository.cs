using Malacar.Interfaces;
using Malacar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Malacar.Repositories
{
    public class CarStationRepository : RepositoryBase<CarStation>, ICarStationRepository
    {
        public CarStationRepository(CarContext carContext)
            : base(carContext)
        {
        }
    }
}
