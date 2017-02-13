using CartaoTodos.Application.Interfaces;
using CartaoTodos.Application.Services;
using CartaoTodos.Data.Repositories;
using CartaoTodos.Domain.Interfaces.Repositories;
using CartaoTodos.Domain.Interfaces.Services;
using CartaoTodos.Domain.Services;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartaoTodos.IoC
{
    public class DIContainer
    {
        public static Container GetContainer(ScopedLifestyle lifestyle)
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = lifestyle;

            container.Register(typeof(IBaseService<>), typeof(BaseService<>));
            container.Register<IPerfilService, PerfilService>();
            container.Register<IUsuarioService, UsuarioService>();

            container.Register(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            container.Register<IPerfilRepository, PerfilRepository>();
            container.Register<IUsuarioRepository, UsuarioRepository>();

            container.Register(typeof(IBaseAppService<,>), typeof(BaseAppService<,>));
            container.Register<IUsuarioAppService, UsuarioAppService>();
            container.Register<IPerfilAppService, PerfilAppService>();

            return container;
            
        }

    }
}
