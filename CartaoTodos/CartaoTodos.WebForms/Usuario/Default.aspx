<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CartaoTodos.WebForms.Usuario.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div class="panel">
	<div class="panel-body">

        <h4>Usuários</h4>

        <p>
            <a href="/Usuario/Novo" class="btn btn-success btn-sm">Adicionar</a>
        </p>
        <table class="table table-striped">
            <thead>
            <tr>
                <th>
                    Login
                </th>
                <th>
                    Nome
                </th>
                <th>
                    Email
                </th>
                <th>
                    Perfis
                </th>
                <th>Opções</th>
            </tr>
            </thead>
            <tbody>
            <%if (ListaUsuarios != null) { %>

                <% foreach (var usuario in ListaUsuarios) { %>

                    <tr>
                        <td>
                            <%= usuario.Login %>
                        </td>
                        <td>
                            <%= usuario.Nome %>
                        </td>
                        <td>
                            <%= usuario.Email %>
                        </td>
                        <td>
                            <%= usuario.Perfis == null ? 0 : usuario.Perfis.Count %>
                        </td>
                        <td>
                            <a href="/Usuario/Detalhes?id=<%=usuario.Id %>">Detalhes</a> |
                            <a href="/Usuario/VincularPerfil?idUsuario=<%=usuario.Id %>">Vincular Perfis</a> |
                            <a href="/Usuario/Editar?id=<%=usuario.Id %>">Editar</a> |
                            <a href="/Usuario/Excluir?id=<%=usuario.Id %>">Excluir</a>
                        </td>
                    </tr>

                <% } %>

    
            <%} %>

            </tbody>

        </table>

    
	</div>
</div>



</asp:Content>
