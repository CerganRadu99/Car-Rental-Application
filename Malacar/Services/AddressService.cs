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
            return RepositoryWrapper.AddressRepository.FindAll().ToList();
        }

        public List<Address> GetAddressesByCondition(Expression<Func<Address, bool>> expression)
        {
            return RepositoryWrapper.AddressRepository.FindByCondition(expression).ToList();
        }

        public void AddAddress(Address address)
        {
            RepositoryWrapper.AddressRepository.Create(address);
        }

        public void UpdateAddress(Address address)
        {
            RepositoryWrapper.AddressRepository.Update(address);
        }

        public void DeleteAddress(Address address)
        {
            RepositoryWrapper.AddressRepository.Delete(address);
        }
    }
}
