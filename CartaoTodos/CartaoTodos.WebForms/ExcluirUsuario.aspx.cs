using CartaoTodos.REST.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CartaoTodos.WebForms
{
    public partial class ExcluirUsuario : BasePage
    {
        protected Usuario Usuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var id = Convert.ToInt32(Request.QueryString["id"]);

                Usuario = _apiClient.ObterUsuario(id);

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

            _apiClient.ExcluirUsuario(id);

            Response.Redirect("/Usuarios");
        }
    }
}