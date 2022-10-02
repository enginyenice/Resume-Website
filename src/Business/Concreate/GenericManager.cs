using System.Collections.Generic;
using Business.Interfaces;
using DataAccess.Interfaces;
using Entities.Interfaces;

namespace Business.Concreate
{
    public class GenericManager<TEntity>: IGenericService<TEntity> where TEntity: class,ITable,new()
    {
        private readonly IGenericRepository<TEntity> _genericRepository;

        public GenericManager(IGenericRepository<TEntity> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public List<TEntity> GetAll()
        {
            return _genericRepository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _genericRepository.GetById(id);
        }

        public void Insert(TEntity entity)
        {
            _genericRepository.Insert(entity);
        }

        public void Update(TEntity entity)
        {
            _genericRepository.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _genericRepository.Delete(entity);
        }
    }
}