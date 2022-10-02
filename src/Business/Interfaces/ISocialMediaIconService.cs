using System.Collections.Generic;
using Entities.Concrete;

namespace Business.Interfaces
{
    public interface ISocialMediaIconService : IGenericService<SocialMediaIcon>
    {
        /// <summary>
        /// Get By User Id All Social Media Icons
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<SocialMediaIcon> GetByUserId(int userId);
    }
}