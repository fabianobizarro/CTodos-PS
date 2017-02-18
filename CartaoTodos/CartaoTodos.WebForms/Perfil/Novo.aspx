<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Novo.aspx.cs" Inherits="CartaoTodos.WebForms.Perfil.Novo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div class="panel">
	<div class="panel-body">

        <h4>Cadasrar Perfil</h4>

        <div class="form-horizontal">

            <div class="form-group">
                <label class="control-label col-md-2">Nome</label>
                <div class="col-md-4">
                    <asp:TextBox runat="server" CssClass="form-control" ID="Nome"/>
                </div>
            </div>

            <div class="form-group">
                <label class="control-label col-md-2">Ativo</label>
                <div class="col-md-4">
                    <asp:CheckBox runat="server" ID="Ativo"/>
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-offset-2 col-md-4">
                    <asp:Button Text="Cadastrar" CssClass="btn btn-success" runat="server" ID="btCadastrarPerfil" OnClick="btCadastrarPerfil_Click"/> |
                    <a href="/Perfil" class="btn btn-default">Voltar</a>
                </div>
            </div>

        </div>

    </div>
</div>
</asp:Content>
