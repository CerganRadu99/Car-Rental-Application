using Malacar.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Malacar.Services
{
    public class BaseService
    {
        protected IRepositoryWrapper RepositoryWrapper;

        public BaseService(IRepositoryWrapper RepositoryWrapper)
        {
            this.RepositoryWrapper = RepositoryWrapper;
        }

        public void Save()
        {
            RepositoryWrapper.Save();
        }
    }
}
