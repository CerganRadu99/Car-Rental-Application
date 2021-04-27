using Malacar.Interfaces;
using Malacar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Malacar.Services
{
    public class AdminAddressService : BaseService
    {
        public AdminAddressService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<AdminAddress> GetAdminAddresses()
        {
            return repositoryWrapper.AdminAddressRepository.FindAll().ToList();
        }

        public List<AdminAddress> GetAdminAddressesByCondition(Expression<Func<AdminAddress, bool>> expression)
        {
            return repositoryWrapper.AdminAddressRepository.FindByCondition(expression).ToList();
        }

        public void AddAdminAddress(AdminAddress adminAddress)
        {
            repositoryWrapper.AdminAddressRepository.Create(adminAddress);
        }

        public void UpdateAdminAddress(AdminAddress adminAddress)
        {
            repositoryWrapper.AdminAddressRepository.Update(adminAddress);
        }

        public void DeleteAdminAddress(AdminAddress adminAddress)
        {
            repositoryWrapper.AdminAddressRepository.Delete(adminAddress);
        }
    }
}
