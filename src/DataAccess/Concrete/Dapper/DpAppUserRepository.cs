using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using DataAccess.Interfaces;
using Entities.Concrete;

namespace DataAccess.Concrete.Dapper
{
	public class DpAppUserRepository : DpGenericRepository<AppUser>, IAppUserRepository
    {
        private readonly IDbConnection _dbConnection;
        public DpAppUserRepository(IDbConnection dbConnection) : base(dbConnection)
        {
            _dbConnection = dbConnection;
        }


        public bool CheckUser(string userName, string password)
        {
            var user = _dbConnection.QueryFirstOrDefault("Select * From AppUsers where UserName=@userName and Password=@password", new
            {
                userName = userName,
                password = password
            });
            return user != null;
        }

        public AppUser FindByUserName(string userName)
        {
            var user = _dbConnection.QueryFirstOrDefault<AppUser>("Select * From AppUsers where UserName=@userName", new
            {
                userName = userName
            });
            return user;
        }
    }
}
