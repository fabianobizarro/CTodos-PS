using CartaoTodos.IoC;
using CartaoTodos.REST;
using CartaoTodos.REST.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CartaoTodos.WebForms
{
    public partial class Perfil : System.Web.UI.Page
    {
        private IApiRestClient _client;
        public IEnumerable<CartaoTodos.REST.Common.Perfil> Perfis { get; set; }

        public Perfil()
        {
            var container = DIContainer.GetContainer();
            container.Register<IApiRestClient, ApiRestClient>();
            _client = container.GetInstance<IApiRestClient>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Perfis = _client.ObterPerfis();
        }
    }
}