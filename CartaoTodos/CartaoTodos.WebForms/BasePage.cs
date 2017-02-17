using CartaoTodos.IoC;
using CartaoTodos.REST;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace CartaoTodos.WebForms
{
    public class BasePage : Page
    {
        private static Container _container;

        protected Container DI
        {
            get
            {
                if (_container == null)
                {
                    _container = DIContainer.GetContainer();
                    // Registrando a interface do cliente REST
                    _container.Register<IApiRestClient, ApiRestClient>();
                }

                return _container;
            }
        }

        protected IApiRestClient _apiClient;

        public BasePage()
        {
            _apiClient = DI.GetInstance<IApiRestClient>();
        }
    }
}