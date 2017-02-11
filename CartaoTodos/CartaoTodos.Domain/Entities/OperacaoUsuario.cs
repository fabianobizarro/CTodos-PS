using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartaoTodos.Domain.Entities
{
    public class OperacaoUsuario
    {
        public int IdOperacao { get; set; }
        public DateTime DataLog { get; set; }
        public int IdUsuario { get; set; }

        public Usuario Usuario { get; set; }
    }
}
