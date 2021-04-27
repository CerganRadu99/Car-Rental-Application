using Malacar.Interfaces;
using Malacar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Malacar.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private CarContext _carContext;
        private IAdminRepository _adminRepository;
        private IAddressRepository _addressRepository;
        private IAdminAddressRepository _adminAddressRepository;
       

        public IAdminRepository AdminRepository
        {
            get
            {
                if (_adminRepository == null)
                {
                    _adminRepository = new AdminRepository(_carContext);
                }
                return _adminRepository;
            }
        }

        public IAddressRepository AddressRepository
        {
            get
            {
                if (_addressRepository == null)
                {
                    _addressRepository = new AddressRepository(_carContext);
                }
                return _addressRepository;
            }
        }

        public IAdminAddressRepository AdminAddressRepository
        {
            get
            {
                if (_adminAddressRepository == null)
                {
                    _adminAddressRepository = new AdminAddressRepository(_carContext);
                }
                return _adminAddressRepository;
            }
        }

        public RepositoryWrapper(CarContext carContext)
        {
            _carContext = carContext;
        }

        public void Save()
        {
            _carContext.SaveChanges();
        }
    }
}