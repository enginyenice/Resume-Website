using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper.Contrib.Extensions;
using DataAccess.Interfaces;
using Entities.Interfaces;

namespace DataAccess.Concrete.Dapper
{
    public class DpGenericRepository<TEntity>: IGenericRepository<TEntity> where TEntity: class,ITable,new()
    {
        private readonly IDbConnection _dbConnection;

        public DpGenericRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public List<TEntity> GetAll()
        {
            return _dbConnection.GetAll<TEntity>().OrderByDescending(p => p.Id).ToList();
        }

        public TEntity GetById(int id)
        {
            return _dbConnection.Get<TEntity>(id: id);
        }

        public void Insert(TEntity entity)
        {
            _dbConnection.Insert(entity);
        }

        public void Update(TEntity entity)
        {
            _dbConnection.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbConnection.Delete(entity);
        }
    }
}
