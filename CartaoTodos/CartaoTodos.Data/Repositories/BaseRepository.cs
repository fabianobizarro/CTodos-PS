using CartaoTodos.Data.Context;
using CartaoTodos.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartaoTodos.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _db;
        private readonly DbSet<TEntity> _set;

        public BaseRepository()
        {
            _db = new AppContext();
            _set = _db.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            _set.Add(entity);
        }

        public virtual void Commit()
        {
            _db.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            _set.Remove(entity);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _set.AsEnumerable();
        }

        public virtual TEntity GetEntity(Func<TEntity, bool> predicate)
        {
            return _set.Where(predicate).FirstOrDefault();
        }

        public virtual void Update(TEntity entity)
        {
            _db.Entry<TEntity>(entity).State = EntityState.Modified;
        }
    }
}
