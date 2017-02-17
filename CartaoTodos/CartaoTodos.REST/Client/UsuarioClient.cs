using CartaoTodos.REST.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace CartaoTodos.REST.Client
{
    public class UsuarioClient : BaseClient<Usuario>, IUsuarioClient
    {
        public UsuarioClient()
            :base("/Usuario")
        {

        }
    }
}
