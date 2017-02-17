<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="CartaoTodos.WebForms.Pages.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>Usuários</h2>

<p>
    <a href="/NovoUsuario" class="btn btn-success">Adicionar</a>
</p>
<table class="table table-striped">
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
                    <a href="/DetalhesUsuario?id=<%=usuario.Id %>">Detalhes</a> |
                    <a href="/VincularPerfil?idUsuario=<%=usuario.Id %>">Vincular Perfis</a> |
                    <a href="/EditarUsuario?id=<%=usuario.Id %>">Editar</a> |
                    <a href="/ExcluirUsuario?id=<%=usuario.Id %>">Excluir</a>
                </td>
            </tr>

        <% } %>

    
    <%} %>

</table>


</asp:Content>
