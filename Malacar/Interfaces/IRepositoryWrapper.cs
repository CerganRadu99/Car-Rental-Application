using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Malacar.Interfaces
{
    public interface IRepositoryWrapper
    {
        IPaymentRepository PaymentRepository { get; }

        IRentalRepository RentalRepository { get; }

        IUserAddressRepository UserAddressRepository { get; }

        IUserRepository UserRepository { get; }

        void Save();
    }
}
