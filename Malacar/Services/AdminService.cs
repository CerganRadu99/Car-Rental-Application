using Malacar.Interfaces;
using Malacar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Malacar.Services
{
    public class AdminService : BaseService
    {
        public AdminService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<Admin> GetAdmins()
        {
            return repositoryWrapper.AdminRepository.FindAll().ToList();
        }

        public List<Admin> GetAdminsByCondition(Expression<Func<Admin, bool>> expression)
        {
            return repositoryWrapper.AdminRepository.FindByCondition(expression).ToList();
        }

        public void AddAdmin(Admin admin)
        {
            repositoryWrapper.AdminRepository.Create(admin);
        }

        public void UpdateAdmin(Admin admin)
        {
            repositoryWrapper.AdminRepository.Update(admin);
        }

        public void DeleteAdmin(Admin admin)
        {
            repositoryWrapper.AdminRepository.Delete(admin);
        }
    }
}
