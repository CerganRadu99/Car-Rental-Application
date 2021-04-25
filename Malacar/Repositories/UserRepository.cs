using Malacar.Interfaces;
using Malacar.Models;

namespace Malacar.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(CarContext CarContext) : base(CarContext)
        {

        }

    }
}
