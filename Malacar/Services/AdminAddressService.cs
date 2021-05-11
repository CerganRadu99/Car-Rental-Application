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
            return RepositoryWrapper.AdminAddressRepository.FindAll().ToList();
        }

        public List<AdminAddress> GetAdminAddressesByCondition(Expression<Func<AdminAddress, bool>> expression)
        {
            return RepositoryWrapper.AdminAddressRepository.FindByCondition(expression).ToList();
        }

        public void AddAdminAddress(AdminAddress adminAddress)
        {
            RepositoryWrapper.AdminAddressRepository.Create(adminAddress);
        }

        public void UpdateAdminAddress(AdminAddress adminAddress)
        {
            RepositoryWrapper.AdminAddressRepository.Update(adminAddress);
        }

        public void DeleteAdminAddress(AdminAddress adminAddress)
        {
            RepositoryWrapper.AdminAddressRepository.Delete(adminAddress);
        }
    }
}
