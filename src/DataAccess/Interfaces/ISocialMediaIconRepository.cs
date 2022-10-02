using System.Collections.Generic;
using Entities.Concrete;

namespace DataAccess.Interfaces
{
    public interface ISocialMediaIconRepository : IGenericRepository<SocialMediaIcon>
    {
        /// <summary>
        /// Get By User Id All Social Media Icons
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<SocialMediaIcon> GetByUserId(int userId);
    }
}