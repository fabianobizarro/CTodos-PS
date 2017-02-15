using CartaoTodos.REST.Common;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CartaoTodos.Mvc.Models
{
    public class CadastroUsuarioViewModel
    {
        public Usuario Usuario { get; set; }

        public int[] PerfisUsuario { get; set; }

        public IEnumerable<Perfil> Perfis { get; set; }

        public SelectList SelectListPerfis()
        {
            if (Perfis == null)
                Perfis = new List<Perfil>();

            return new SelectList(Perfis, "Id", "Nome");
        }
    }
}