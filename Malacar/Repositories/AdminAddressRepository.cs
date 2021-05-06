using Malacar.Interfaces;
using Malacar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Malacar.Repositories
{
    public class AdminAddressRepository : RepositoryBase<AdminAddress>, IAdminAddressRepository
    {
        public AdminAddressRepository(CarContext carContext)
            : base(carContext)
        {
        }
    }
}