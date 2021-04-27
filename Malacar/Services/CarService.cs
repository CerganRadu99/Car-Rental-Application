using Malacar.Interfaces;
using Malacar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Malacar.Services
{
    public class CarService : BaseService
    {
        public CarService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<Car> GetCars()
        {
            return repositoryWrapper.CarRepository.FindAll().ToList();
        }

        public List<Car> GetCarsByCondition(Expression<Func<Car, bool>> expression)
        {
            return repositoryWrapper.CarRepository.FindByCondition(expression).ToList();
        }

        public void AddCar(Car car)
        {
            repositoryWrapper.CarRepository.Create(car);
        }

        public void UpdateCar(Car car)
        {
            repositoryWrapper.CarRepository.Update(car);
        }

        public void DeleteCar(Car car)
        {
            repositoryWrapper.CarRepository.Delete(car);
        }
    }
}
