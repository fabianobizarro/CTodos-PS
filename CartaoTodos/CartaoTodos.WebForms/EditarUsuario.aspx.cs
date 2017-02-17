using CartaoTodos.REST.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CartaoTodos.WebForms
{
    public partial class EditarUsuario : BasePage
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
                    Nome.Text = Usuario.Nome;
                    Email.Text = Usuario.Email;
                    Login.Text = Usuario.Login;
                    Senha.Text = Usuario.Senha;
                }
            }
        }

        protected void btEditarUsuario_Click(object sender, EventArgs e)
        {
            bool formularioValido = ValidarFormulario();

            if (formularioValido)
            {
                var usuario = new Usuario()
                {
                    Id = Convert.ToInt32(IdUsuario.Value),
                    Nome = Nome.Text,
                    Email = Email.Text,
                    Login = Login.Text,
                    Senha = Senha.Text
                };

                _apiClient.EditarUsuario(usuario);

                Response.Redirect("/Usuarios");
            }
        }

        private bool ValidarFormulario()
        {
            bool valid = true;

            if (string.IsNullOrEmpty(Nome.Text))
            {
                MensagemNome.Text = "O nome é obrigatório";
                valid = false;
            }
            else if (Nome.Text.Length > 100)
            {
                MensagemNome.Text = "O nome deve conter no máximo 100 caracteres";
                valid = false;
            }

            if (string.IsNullOrEmpty(Email.Text))
            {
                MensagemEmail.Text = "O email é obrigatório";
                valid = false;
            }
            else if (Email.Text.Length > 70)
            {
                MensagemEmail.Text = "O nome deve conter no máximo 70 caracteres";
                valid = false;
            }

            if (string.IsNullOrEmpty(Login.Text))
            {
                MensagemLogin.Text = "O login é obrigatório";
                valid = false;
            }
            else if (Login.Text.Length > 50)
            {
                MensagemLogin.Text = "O login deve conter no máximo 50 caracteres";
                valid = false;
            }

            return valid;
        }
    }
}