<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="CartaoTodos.WebForms.Usuario.Editar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div class="panel">

	<div class="panel-body">

        <h4>Editar usuário</h4>

        <div class="form-horizontal">
            <hr />

            <div class="form-group">
                <label class="control-label col-md-2">Nome</label>
                <div class="col-md-10">
                    <asp:TextBox ID="Nome" class="form-control" runat="server" />
                    <asp:Label runat="server" ID="MensagemNome" CssClass="validation-message"></asp:Label>
                </div>
            </div>

            <div class="form-group">
                <label class="control-label col-md-2">Email</label>
                <div class="col-md-10">
                    <asp:TextBox ID="Email" class="form-control" runat="server" />
                    <asp:Label runat="server" ID="MensagemEmail" CssClass="validation-message"></asp:Label>
                </div>
            </div>

            <div class="form-group">
                <label class="control-label col-md-2">Login</label>
                <div class="col-md-10">
                    <asp:TextBox ID="Login" class="form-control" runat="server" />
                    <asp:Label runat="server" ID="MensagemLogin" CssClass="validation-message"></asp:Label>
                </div>
            </div>

            <div class="form-group">
                <label class="control-label col-md-2">Senha</label>
                <div class="col-md-10">
                    <asp:TextBox ID="Senha" class="form-control" runat="server" TextMode="Password" />
                    <asp:Label runat="server" ID="MensagemSenha" CssClass="validation-message"></asp:Label>
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:HiddenField ID="IdUsuario" runat="server"/>
                    <asp:Button class="btn btn-warning" ID="btEditarUsuario" Text="Editar" runat="server" OnClick="btEditarUsuario_Click" /> | 
                    <a href="/Usuario" class="btn btn-default">Voltar</a>
                </div>
            </div>
        </div>
    
	</div>

</div>




</asp:Content>
