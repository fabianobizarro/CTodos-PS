<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExcluirUsuario.aspx.cs" Inherits="CartaoTodos.WebForms.ExcluirUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <h3>Excluir Usuário</h3>

      <h2>Detalhes</h2>

    <div>
        <hr />
        <dl class="dl-horizontal">
            <dt>Login</dt>

            <dd><%= Usuario.Login %></dd>

            <dt>Nome  </dt>

            <dd><%= Usuario.Nome %> </dd>

            <dt>Email</dt>

            <dd><%= Usuario.Email %> </dd>

            <dt>Senha</dt>

            <dd><%= Usuario.Senha %> </dd>

            <dt>Ativo</dt>

            <dd><%= Usuario.Ativo ? "Sim" : "Não" %> </dd>

            <% if (Usuario.Perfis != null)
                {%>

            <% if (Usuario.Perfis.Count > 0)
                { %>

            <dt>Perfis </dt>

            <dd>
                <ul>
                    <%foreach (var perfil in Usuario.Perfis)
                        { %>
                    <li><%= perfil.Nome %></li>
                    <%} %>
                </ul>
            </dd>

            <% } %>

            <% } %>
        </dl>
    </div>
    <div class="row">
        <div class="col-md-offset-1 col-ms-4">
            <p>
                <asp:HiddenField ID="IdUsuario" runat="server" />
                <asp:Button ID="btExcluirUsuario" runat="server" CssClass="btn btn-danger" OnClick="btExcluirUsuario_Click" Text="Excluir"/>
                <a href="/Usuarios" class="btn btn-default">Voltar</a>
            </p>
        </div>
    </div>

</asp:Content>
