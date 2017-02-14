using AutoMapper;
using CartaoTodos.Application.Interfaces;
using CartaoTodos.Domain.Interfaces.Services;
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

        public virtual void Add(TViewModel viewModel)
        {
            var entity = Mapper.Map<TViewModel, TEntity>(viewModel);
            _service.Add(entity);
        }

        public virtual void Delete(TViewModel viewModel)
        {
            var entity = Mapper.Map<TViewModel, TEntity>(viewModel);
            _service.Delete(entity);
        }

        public virtual IEnumerable<TViewModel> GetAll()
        {
            var entities = _service.GetAll().ToList();

            return Mapper.Map<IEnumerable<TEntity>, IEnumerable<TViewModel>>(entities);
        }

        public virtual TViewModel GetEntity(Func<TEntity, bool> predicate)
        {
            var result = _service.GetEntity(predicate);

            return Mapper.Map<TEntity, TViewModel>(result);
        }

        public virtual void Update(TViewModel viewModel)
        {
            var entity = Mapper.Map<TViewModel, TEntity>(viewModel);
            _service.Update(entity);
        }
    }
}
