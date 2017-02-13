using CartaoTodos.Domain.Interfaces.Repositories;
using CartaoTodos.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartaoTodos.Domain.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        protected readonly IBaseRepository<TEntity> _repository;

        public BaseService(IBaseRepository<TEntity> repo)
        {
            _repository = repo;
        }

        public virtual void Add(TEntity entity)
        {
            _repository.Add(entity);
            _repository.Commit();
        }

        public virtual void Delete(TEntity entity)
        {
            _repository.Delete(entity);
            _repository.Commit();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual TEntity GetEntity(Func<TEntity, bool> predicate)
        {
            return _repository.GetEntity(predicate);
        }

        public virtual void Update(TEntity entity)
        {
            _repository.Update(entity);
            _repository.Commit();
        }
    }
}
