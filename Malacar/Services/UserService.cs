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

        public List<User> GetUsers()
        {
            return RepositoryWrapper.UserRepository.FindAll().ToList();
        }

        public List<User> GetUsersByCondition(Expression<Func<User, bool>> expression)
        {
            return RepositoryWrapper.UserRepository.FindByCondition(expression).ToList();
        }

        public void AddUser(User User)
        {
            RepositoryWrapper.UserRepository.Create(User);
        }

        public void UpdateUser(User User)
        {
            RepositoryWrapper.UserRepository.Update(User);
        }

        public void DeleteUser(User User)
        {
            RepositoryWrapper.UserRepository.Delete(User);
        }
    }
}
