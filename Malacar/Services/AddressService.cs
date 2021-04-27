using Malacar.Interfaces;
using Malacar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Malacar.Services
{
    public class AddressService : BaseService
    {
        public AddressService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<Address> GetAddresses()
        {
            return repositoryWrapper.AddressRepository.FindAll().ToList();
        }

        public List<Address> GetAddressesByCondition(Expression<Func<Address, bool>> expression)
        {
            return repositoryWrapper.AddressRepository.FindByCondition(expression).ToList();
        }

        public void AddAddress(Address address)
        {
            repositoryWrapper.AddressRepository.Create(address);
        }

        public void UpdateAddress(Address address)
        {
            repositoryWrapper.AddressRepository.Update(address);
        }

        public void DeleteAddress(Address address)
        {
            repositoryWrapper.AddressRepository.Delete(address);
        }
    }
}
