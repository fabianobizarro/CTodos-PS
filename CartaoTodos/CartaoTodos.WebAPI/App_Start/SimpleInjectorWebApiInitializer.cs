[assembly: WebActivator.PostApplicationStartMethod(typeof(CartaoTodos.WebAPI.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace CartaoTodos.WebAPI.App_Start
{
    using System.Web.Http;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    using IoC;

    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = DIContainer.GetContainer(new WebApiRequestLifestyle());

            InitializeContainer(container);

            //container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
            
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
       
            container.Verify();
            
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
     
        private static void InitializeContainer(Container container)
        {
            
        }
    }
}