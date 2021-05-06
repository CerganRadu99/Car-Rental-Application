using Malacar.Interfaces;
using Malacar.Models;

namespace Malacar.Repositories
{
    public class PaymentRepository : RepositoryBase<Payment>, IPaymentRepository
    {
        public PaymentRepository(CarContext CarContext) : base(CarContext)
        {

        }
    }
}
