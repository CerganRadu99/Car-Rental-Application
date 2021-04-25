using Malacar.Interfaces;
using Malacar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Malacar.Services
{
    public class RentalService : BaseService
    {
        public RentalService(IRepositoryWrapper RepositoryWrapper) : base(RepositoryWrapper)
        {

        }

        public List<Rental> GetRentals()
        {
            return RepositoryWrapper.RentalRepository.FindAll().ToList();
        }

        public List<Rental> GetRentalsByCondition(Expression<Func<Rental, bool>> expression)
        {
            return RepositoryWrapper.RentalRepository.FindByCondition(expression).ToList();
        }

        public void AddRental(Rental Rental)
        {
            RepositoryWrapper.RentalRepository.Create(Rental);
        }

        public void UpdateRental(Rental Rental)
        {
            RepositoryWrapper.RentalRepository.Update(Rental);
        }

        public void DeleteRental(Rental Rental)
        {
            RepositoryWrapper.RentalRepository.Delete(Rental);
        }
    }
}
