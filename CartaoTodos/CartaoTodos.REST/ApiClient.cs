using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CartaoTodos.REST.Common;
using CartaoTodos.REST.Client;

namespace CartaoTodos.REST
{
    public class ApiClient : IApiClient
    {
        public ApiClient()
        {
            Perfil = new PerfilClient();
            PerfilUsuario = new PerfilUsuarioClient();
            Usuario = new UsuarioClient();
        }
        public IPerfilClient Perfil { get; set; }
        public IPerfilUsuarioClient PerfilUsuario { get; set; }
        public IUsuarioClient Usuario { get; set; }
    }
}
