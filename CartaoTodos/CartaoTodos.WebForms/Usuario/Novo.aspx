<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Novo.aspx.cs" Inherits="CartaoTodos.WebForms.Pages.Usuario.Novo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
<div class="panel">

    <div class="panel-body">

    <h4>Cadastrar usuário</h4>

    <div class="form-horizontal">
            <hr />
        
            <div class="form-group">
                <label class="control-label col-md-2">Nome</label>
                <div class="col-md-10">
                    <asp:TextBox ID="Nome" class="form-control" runat="server"/>
                    <asp:Label runat="server" ID="MensagemNome" CssClass="validation-message"></asp:Label>
                </div>
            </div>

            <div class="form-group">
                <label class="control-label col-md-2">Email</label>
                <div class="col-md-10">
                    <asp:TextBox ID="Email" class="form-control" runat="server"/>
                    <asp:Label runat="server" ID="MensagemEmail" CssClass="validation-message"></asp:Label>
                </div>
            </div>

            <div class="form-group">
                <label class="control-label col-md-2">Login</label>
                <div class="col-md-10">
                    <asp:TextBox ID="Login" class="form-control" runat="server"/>
                    <asp:Label runat="server" ID="MensagemLogin" CssClass="validation-message"></asp:Label>
                </div>
            </div>

            <div class="form-group">
                <label class="control-label col-md-2">Senha</label>
                <div class="col-md-10">
                    <asp:TextBox ID="Senha" class="form-control" runat="server" TextMode="Password"/>
                    <asp:Label runat="server" ID="MensagemSenha" CssClass="validation-message"></asp:Label>
                </div>
            </div>

            <div class="form-group">
                <label class="control-label col-md-2">Perfis</label>
                <div class="col-md-10">
                    <asp:ListBox ID="Perfis" runat="server" CssClass="form-control" SelectionMode="Multiple" DataTextField="Nome" DataValueField="Id">
                    
                    </asp:ListBox>
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button class="btn btn-success" ID="btCadastrarUsuario" Text="Cadastrar" runat="server" OnClick="btCadastrarUsuario_Click"/> | 
                    <a href="/Usuario" class="btn btn-default">Voltar</a>
                </div>
            </div>
        </div>

  	</div>

</div>

</asp:Content>
