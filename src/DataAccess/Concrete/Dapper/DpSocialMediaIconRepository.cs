using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using DataAccess.Interfaces;
using Entities.Concrete;

namespace DataAccess.Concrete.Dapper
{
    public class DpSocialMediaIconRepository : DpGenericRepository<SocialMediaIcon>, ISocialMediaIconRepository
    {
        private readonly IDbConnection _dbConnection;
        public DpSocialMediaIconRepository(IDbConnection dbConnection) : base(dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public List<SocialMediaIcon> GetByUserId(int userId)
        {
            return _dbConnection.Query<SocialMediaIcon>("Select * from SocialMediaIcons where AppUserId=@id", new
            {
                id = userId,
            }).OrderByDescending(p => p.Id).ToList();
        }
    }
}