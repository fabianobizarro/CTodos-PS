<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalhes.aspx.cs" Inherits="CartaoTodos.WebForms.Usuario.Detalhes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <% Page.Title = "Detalhes"; %>

<div class="panel">
	<div class="panel-body">

        <h4>Detalhes</h4>

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
                        <a href="/Usuario/Editar?id=<%= Usuario.Id %>" class="btn btn-warning">Editar</a> | 
                        <a href="/Usuario" class="btn btn-default">Voltar</a>
                    </p>
                </div>
            </div>

	</div>
</div>

</asp:Content>
