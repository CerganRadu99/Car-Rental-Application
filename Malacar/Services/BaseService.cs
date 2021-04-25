using Malacar.Interfaces;

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
