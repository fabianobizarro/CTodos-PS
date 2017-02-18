using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CartaoTodos.WebForms.Usuario
{
    public partial class Excluir : BasePage
    {
        protected REST.Common.Usuario Usuario = new REST.Common.Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var id = Convert.ToInt32(Request.QueryString["id"]);

                Usuario = _apiClient.Usuario.Get(id).Data;

                if (Usuario == null)
                {
                    Response.Redirect("/Usuarios");
                }
                else
                {
                    IdUsuario.Value = Usuario.Id.ToString();
                }
            }
        }

        protected void btExcluirUsuario_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(IdUsuario.Value);

            var response = _apiClient.Usuario.Remove(id);

            Response.Redirect("/Usuarios");
        }
    }
}