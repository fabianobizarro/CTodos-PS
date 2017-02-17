using CartaoTodos.REST.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CartaoTodos.WebForms
{
    public partial class DetalhesUsuario : BasePage
    {
        //public IEnumerable<CartaoTodos.REST.Common.Perfil> PerfisUsuario;

        protected int Id;
        protected Usuario Usuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            int? idUsuario = Convert.ToInt32(Request.QueryString["id"]);

            if (idUsuario == null)
            {
                Response.Redirect("/Home");
            }

            Usuario = _apiClient.ObterUsuario(idUsuario.GetValueOrDefault());
        }
    }
}