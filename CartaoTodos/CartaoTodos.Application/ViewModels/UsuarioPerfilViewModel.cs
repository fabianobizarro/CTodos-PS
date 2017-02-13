using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartaoTodos.Application.ViewModels
{
    public class UsuarioPerfilViewModel
    {
        public int IdPerfil { get; set; }
        public int IdUsuario { get; set; }
        public bool Ativo { get; set; }

        public PerfilViewModel Perfil { get; set; }
        public UsuarioViewModel Usuario { get; set; }
    }
}
