using Malacar.Interfaces;
using Malacar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace Malacar.Services
{
    public class UserAddressService : BaseService
    {
        public UserAddressService(IRepositoryWrapper RepositoryWrapper) : base(RepositoryWrapper)
        {

        }

        public List<UserAddress> GetUserAddresses()
        {
            return RepositoryWrapper.UserAddressRepository.FindAll().ToList();
        }

        public List<UserAddress> GetUserAddressesByCondition(Expression<Func<UserAddress, bool>> expression)
        {
            return RepositoryWrapper.UserAddressRepository.FindByCondition(expression).ToList();
        }

        public void AddUserAddress(UserAddress UserAddress)
        {
            RepositoryWrapper.UserAddressRepository.Create(UserAddress);
        }

        public void UpdateUserAddress(UserAddress UserAddress)
        {
            RepositoryWrapper.UserAddressRepository.Update(UserAddress);
        }

        public void DeleteUserAddress(UserAddress UserAddress)
        {
            RepositoryWrapper.UserAddressRepository.Delete(UserAddress);
        }
    }
}
