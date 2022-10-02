using Business.Interfaces;
using DataAccess.Interfaces;
using Entities.Concrete;

namespace Business.Concreate
{
    public class AppUserManager : GenericManager<AppUser>, IAppUserService
    {
        private IAppUserRepository _appUserRepository;

        public AppUserManager(IAppUserRepository appUserRepository) : base(appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }

        public bool CheckUser(string userName, string password)
        {
            return _appUserRepository.CheckUser(userName, password);
        }

        public AppUser FindByUserName(string userName)
        {
            return _appUserRepository.FindByUserName(userName);
        }
    }
}