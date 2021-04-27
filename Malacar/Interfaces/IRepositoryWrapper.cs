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
      

        void Save();
    }
}