using Malacar.Interfaces;
using Malacar.Models;


namespace Malacar.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private CarContext _carContext;

        private IPaymentRepository _paymentRepository;

        private IRentalRepository _rentalRepository;

        private IUserAddressRepository _userAddressRepository;

        private IUserRepository _userRepository;

        public RepositoryWrapper(CarContext CarContext)
        {
            this._carContext = CarContext;
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

        public void Save()
        {
            _carContext.SaveChanges();
        }
    }
}
