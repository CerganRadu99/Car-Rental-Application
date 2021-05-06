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
        
        private IPaymentRepository _paymentRepository;

        private IRentalRepository _rentalRepository;

        private IUserAddressRepository _userAddressRepository;

        private IUserRepository _userRepository;
        
        private ICarRepository _carRepository;
        
        private IStationRepository _stationRepository;
        
        private ICarStationRepository _carstationRepository;
        
        private IStationAddressRepository _stationaddressRepository;

        public RepositoryWrapper(CarContext CarContext)
        {
            this._carContext = CarContext;
        }
       

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

        public IPaymentRepository PaymentRepository
        {
            get
            {
                if (_paymentRepository == null)
                {
                    _paymentRepository = new PaymentRepository(_carContext);
                }
                return _paymentRepository;
            }
        }

        public IRentalRepository RentalRepository
        {
            get
            {
                if (_rentalRepository == null)
                {
                    _rentalRepository = new RentalRepository(_carContext);
                }
                return _rentalRepository;
            }
        }

        public IUserAddressRepository UserAddressRepository
        {
            get
            {
                if (_userAddressRepository == null)
                {
                    _userAddressRepository = new UserAddressRepository(_carContext);
                }
                return _userAddressRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_carContext);
                }
                return _userRepository;
            }
        }

        public ICarRepository CarRepository
        {
            get
            {
                if (_carRepository == null)
                {
                    _carRepository = new CarRepository(_carContext);
                }
                return _carRepository;
            }
        }

        public IStationRepository StationRepository
        {
            get
            {
                if (_stationRepository == null)
                {
                    _stationRepository = new StationRepository(_carContext);
                }
                return _stationRepository;
            }
        }

        public ICarStationRepository CarStationRepository
        {
            get
            {
                if (_carstationRepository == null)
                {
                    _carstationRepository = new CarStationRepository(_carContext);
                }
                return _carstationRepository;
            }
        }

        public IStationAddressRepository StationAddressRepository
        {
            get
            {
                if (_stationaddressRepository == null)
                {
                    _stationaddressRepository = new StationAddressRepository(_carContext);
                }
                return _stationaddressRepository;
            }
        }

        public void Save()
        {
            _carContext.SaveChanges();
        }
    }
}
