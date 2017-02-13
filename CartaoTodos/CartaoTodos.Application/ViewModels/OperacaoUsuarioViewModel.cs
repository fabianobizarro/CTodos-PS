using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartaoTodos.Application.ViewModels
{
    public class OperacaoUsuarioViewModel
    {
        public int IdOperacao { get; set; }
        public DateTime DataLog { get; set; }
        public int IdUsuario { get; set; }

        public UsuarioViewModel Usuario { get; set; }
    }
}
