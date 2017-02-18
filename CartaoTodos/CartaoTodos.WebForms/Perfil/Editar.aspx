<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="CartaoTodos.WebForms.Perfil.Editar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div class="panel">
	<div class="panel-body">

        <h4>Editar Perfil</h4>

        <div class="form-horizontal">
            <div class="form-group">
                <label class="control-label col-md-2">Nome</label>
                <div class="col-md-4">
                    <asp:TextBox runat="server" ID="Nome" CssClass="form-control" />
                </div>
            </div>

            <div class="form-group">
                <label class="control-label col-md-2">Ativo</label>
                <div class="col-md-4">
                    <asp:CheckBox runat="server" ID="Ativo" />
                </div>
            </div>

            <asp:HiddenField runat="server" ID="IdPerfil"/>        

            <div class="form-group">
                <div class="col-md-offset-2 col-md-4">
                    <asp:Button Text="Editar" runat="server" CssClass="btn btn-warning" ID="btEditarPerfil" OnClick="btEditarPerfil_Click"/> | 
                    <a href="/Perfil" class="btn btn-default">Voltar</a>
                </div>
            </div>
        </div>
    </div>
</div>

</asp:Content>
