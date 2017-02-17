<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExcluirPerfil.aspx.cs" Inherits="CartaoTodos.WebForms.ExcluirPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Excluir Perfil</h3>

    <div>
        <hr />
        <dl class="dl-horizontal">
            <dt>Id</dt>

            <dd><%= Perfil.Id %></dd>

            <dt>Nome  </dt>

            <dd><%= Perfil.Nome %> </dd>

            <dt>Ativo</dt>

            <dd><%= Perfil.Ativo ? "Sim" : "Não" %> </dd>

        </dl>
    </div>
    <div class="row">
        <div class="col-md-offset-1 col-ms-4">
            <p>
                <asp:HiddenField ID="IdPerdil" runat="server" />
                <asp:Button CssClass="btn btn-danger" runat="server" ID="btExcluirPerfil" Text="Excluir" OnClick="btExcluirPerfil_Click"/>
                <a href="/Perfil" class="btn btn-default">Voltar</a>
            </p>
        </div>
    </div>


</asp:Content>
