using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Malacar.Interfaces
{
    public interface IRepositoryWrapper
    {
        IAdminRepository AdminRepository { get; }
      
        IAddressRepository AddressRepository { get; }
      
        IAdminAddressRepository AdminAddressRepository { get; }
      
        IPaymentRepository PaymentRepository { get; }

        IRentalRepository RentalRepository { get; }

        IUserAddressRepository UserAddressRepository { get; }

        IUserRepository UserRepository { get; }

        ICarRepository CarRepository { get; }
      
        IStationRepository StationRepository { get; }
      
        ICarStationRepository CarStationRepository { get; }
      
        IStationAddressRepository StationAddressRepository { get; }

        void Save();
    }
}
