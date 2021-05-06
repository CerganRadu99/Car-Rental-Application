using Malacar.Interfaces;
using Malacar.Models;

namespace Malacar.Repositories
{
    public class UserAddressRepository : RepositoryBase<UserAddress>, IUserAddressRepository
    {
        public UserAddressRepository(CarContext CarContext) : base(CarContext)
        {

        }
    }
}
