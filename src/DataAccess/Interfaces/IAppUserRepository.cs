using Entities.Concrete;

namespace DataAccess.Interfaces
{
    public interface IAppUserRepository : IGenericRepository<AppUser>
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