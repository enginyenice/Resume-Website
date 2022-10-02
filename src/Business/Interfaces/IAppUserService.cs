using Entities.Concrete;

namespace Business.Interfaces
{
    public interface IAppUserService : IGenericService<AppUser>
    {
        /// <summary>
        /// If user is exist return true else false
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool CheckUser(string userName, string password);

        /// <summary>
        /// Get By AppUser
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>AppUser | null</returns>
        AppUser FindByUserName(string userName);
    }
}