using CartaoTodos.REST.Common;
using CartaoTodos.WebForms.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CartaoTodos.WebForms
{
    public partial class VincularPerfil : BasePage
    {
        protected Usuario Usuario = new Usuario();
        protected IEnumerable<REST.Common.Perfil> ListaPerfis;

        protected void Page_Load(object sender, EventArgs e)
        {
            int idUsuario = Convert.ToInt32(Request.QueryString["idUsuario"]);
            Usuario = _apiClient.ObterUsuario(idUsuario);

            if (!IsPostBack)
            {
                if (Usuario == null)
                {
                    Response.Redirect("/Usuarios");
                }
                else
                {
                    ListaPerfis = _apiClient.ObterPerfis();

                    listBoxPerfis.DataSource = ListaPerfis.Except(Usuario.Perfis, new PerfilComparer());
                    listBoxPerfis.DataTextField = "Nome";
                    listBoxPerfis.DataValueField = "Id";
                    listBoxPerfis.DataBind();

                    radioListPerfis.DataSource = Usuario.Perfis;
                    radioListPerfis.DataValueField = "Id";
                    radioListPerfis.DataTextField = "Nome";
                    radioListPerfis.DataBind();
                }
            }
        }

        protected void btAdicionarPerfil_Click(object sender, EventArgs e)
        {
            var perfilSelecionado = Convert.ToInt32(listBoxPerfis.SelectedItem.Value);

            _apiClient.AdicionarPerfil(Usuario.Id, perfilSelecionado);

            Response.Redirect(Request.RawUrl);
        }

        protected void btRemoverPerfil_Click(object sender, EventArgs e)
        {
            var perfilSelecionado = Convert.ToInt32(radioListPerfis.SelectedItem.Value);

            _apiClient.RemoverPerfil(Usuario.Id, perfilSelecionado);

            Response.Redirect(Request.RawUrl);
        }
    }
}