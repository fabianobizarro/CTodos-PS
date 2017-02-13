using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartaoTodos.Domain.Entities
{
    public class UsuarioPerfil
    {
        public int IdPerfil { get; set; }
        public int IdUsuario { get; set; }
        public bool Ativo { get; set; }

        public virtual Perfil Perfil { get; set; }
        public virtual Usuario Usuario { get; set; }

    }
}
