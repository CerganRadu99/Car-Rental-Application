using Malacar.Interfaces;
using Malacar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Malacar.Services
{
    public class UserService : BaseService
    {
        public UserService(IRepositoryWrapper RepositoryWrapper) : base(RepositoryWrapper)
        {

        }

        public List<AppUser> GetUsers()
        {
            return RepositoryWrapper.UserRepository.FindAll().ToList();
        }

        public List<AppUser> GetUsersByCondition(Expression<Func<AppUser, bool>> expression)
        {
            return RepositoryWrapper.UserRepository.FindByCondition(expression).ToList();
        }

        public void AddUser(AppUser User)
        {
            RepositoryWrapper.UserRepository.Create(User);
        }

        public void UpdateUser(AppUser User)
        {
            RepositoryWrapper.UserRepository.Update(User);
        }

        public void DeleteUser(AppUser User)
        {
            RepositoryWrapper.UserRepository.Delete(User);
        }
    }
}
