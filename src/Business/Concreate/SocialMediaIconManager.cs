using System.Collections.Generic;
using Business.Interfaces;
using DataAccess.Interfaces;
using Entities.Concrete;

namespace Business.Concreate
{
    public class SocialMediaIconManager : GenericManager<SocialMediaIcon> , ISocialMediaIconService
    {
        private ISocialMediaIconRepository _socialMediaIconRepository;

        public SocialMediaIconManager(ISocialMediaIconRepository socialMediaIconRepository) : base(socialMediaIconRepository)
        {
            _socialMediaIconRepository = socialMediaIconRepository;
        }

        public List<SocialMediaIcon> GetByUserId(int userId)
        {
            return _socialMediaIconRepository.GetByUserId(userId);
        }
    }
}