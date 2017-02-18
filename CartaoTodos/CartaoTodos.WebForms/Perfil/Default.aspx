<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CartaoTodos.WebForms.Perfil.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


<div class="panel">
	<div class="panel-body">

        <h4>Perfis</h4>
        <p>
            <a href="/Perfil/Novo" class="btn btn-success btn-sm">
                Novo Perfil
            </a>
        </p>

        <table class="table table-striped">
            <tr>
                <th>Id </th>
                <th>Nome </th>
                <th>Ativo </th>
                <th>Opções</th>
            </tr>
            <% foreach (var perfil in Perfis) { %>
                <tr>
                    <td><%= perfil.Id %></td>
                    <td><%= perfil.Nome %></td>
                    <td><%= perfil.Ativo %></td>
                    <td>
                        <a href="/Perfil/Editar?id=<%= perfil.Id %>">Editar</a> | 
                        <a href="/Perfil/Excluir?id=<%= perfil.Id %>">Excluir</a>  
                    </td>
                </tr>
            <% } %>
        </table>


	</div>
</div>

</asp:Content>
