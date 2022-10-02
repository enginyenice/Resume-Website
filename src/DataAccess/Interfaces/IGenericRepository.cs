using System;
using System.Collections.Generic;
using System.Text;
using Entities.Interfaces;

namespace DataAccess.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity: class,ITable,new()
    {
        List<TEntity> GetAll();
        TEntity GetById(int id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
