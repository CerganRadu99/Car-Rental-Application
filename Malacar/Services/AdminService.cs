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
            return RepositoryWrapper.AdminRepository.FindAll().ToList();
        }

        public List<Admin> GetAdminsByCondition(Expression<Func<Admin, bool>> expression)
        {
            return RepositoryWrapper.AdminRepository.FindByCondition(expression).ToList();
        }

        public void AddAdmin(Admin admin)
        {
            RepositoryWrapper.AdminRepository.Create(admin);
        }

        public void UpdateAdmin(Admin admin)
        {
            RepositoryWrapper.AdminRepository.Update(admin);
        }

        public void DeleteAdmin(Admin admin)
        {
            RepositoryWrapper.AdminRepository.Delete(admin);
        }
    }
}
