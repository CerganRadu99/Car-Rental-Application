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
        private ICarRepository _carRepository;
        private IStationRepository _stationRepository;
        private ICarStationRepository _carstationRepository;
        private IStationAddressRepository _stationaddressRepository;

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
