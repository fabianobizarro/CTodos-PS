using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartaoTodos.Application.Interfaces
{
    public interface IBaseAppService<TViewModel, TEntity> where TEntity : class
    {
        void Add(TViewModel entity);
        void Update(TViewModel entity);
        void Delete(TViewModel entity);
        TViewModel GetEntity(Func<TEntity, bool> predicate);
        IEnumerable<TViewModel> GetAll();
    }
}
