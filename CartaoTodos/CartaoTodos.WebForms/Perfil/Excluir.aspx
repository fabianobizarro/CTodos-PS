<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Excluir.aspx.cs" Inherits="CartaoTodos.WebForms.Perfil.Excluir" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div class="panel">
	<div class="panel-body">

        <h4>Excluir Perfil</h4>

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
                    <asp:Button CssClass="btn btn-danger" runat="server" ID="btExcluirPerfil" Text="Excluir" OnClick="btExcluirPerfil_Click"/> | 
                    <a href="/Perfil" class="btn btn-default">Voltar</a>
                </p>
            </div>
        </div>

	</div>
</div>

</asp:Content>
