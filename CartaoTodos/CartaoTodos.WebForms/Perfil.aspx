<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="CartaoTodos.WebForms.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <h3>Perfis</h3>
    <p>
        <a href="/NovoPerfil" class="btn btn-success">
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
                    <a href="/EditarPerfil?id=<%= perfil.Id %>">Editar</a> | 
                    <a href="/ExcluirPerfil?id=<%= perfil.Id %>">Excluir</a>  
                </td>
            </tr>
        <% } %>
    </table>



</asp:Content>
