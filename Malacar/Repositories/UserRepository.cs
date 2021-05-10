using Malacar.Interfaces;
using Malacar.Models;

namespace Malacar.Repositories
{
    public class UserRepository : RepositoryBase<AppUser>, IUserRepository
    {
        public UserRepository(CarContext CarContext) : base(CarContext)
        {

        }

    }
}
