using Malacar.Interfaces;
using Malacar.Models;

namespace Malacar.Repositories
{
    public class RentalRepository : RepositoryBase<Rental>, IRentalRepository
    {
        public RentalRepository(CarContext CarContext) : base(CarContext)
        {

        }
    }
}
