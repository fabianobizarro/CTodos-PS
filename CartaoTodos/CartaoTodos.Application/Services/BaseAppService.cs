using CartaoTodos.Application.Interfaces;
using CartaoTodos.Domain.Interfaces.Services;
using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartaoTodos.Application.Services
{
    public class BaseAppService<TViewModel, TEntity> : IBaseAppService<TViewModel, TEntity> where TEntity : class
    {
        protected readonly IBaseService<TEntity> _service;

        public BaseAppService(IBaseService<TEntity> service)
        {
            _service = service;
        }

        public void Add(TViewModel viewModel)
        {
            var entity = TinyMapper.Map<TViewModel, TEntity>(viewModel);
            _service.Add(entity);
        }

        public void Delete(TViewModel viewModel)
        {
            var entity = TinyMapper.Map<TViewModel, TEntity>(viewModel);
            _service.Delete(entity);
        }

        public IEnumerable<TViewModel> GetAll()
        {
            var entities = _service.GetAll().ToList();

            return TinyMapper.Map<List<TEntity>, List<TViewModel>>(entities);
        }

        public TViewModel GetEntity(Func<TEntity, bool> predicate)
        {
            var result = _service.GetEntity(predicate);

            return TinyMapper.Map<TEntity, TViewModel>(result);
        }

        public void Update(TViewModel viewModel)
        {
            var entity = TinyMapper.Map<TViewModel, TEntity>(viewModel);
            _service.Update(entity);
        }
    }
}
