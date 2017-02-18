<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VincularPerfil.aspx.cs" Inherits="CartaoTodos.WebForms.Usuario.VincularPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div class="panel">
	<div class="panel-body">

        <h4>Vincular Perfil</h4>

        <div class="form-horizontal">

            <div class="form-group">
                <div class="col-md-6">
                    <label>Usuário: </label> <%= Usuario.Nome %>
                </div>
            </div>

            <div class="form-group">
                <div class="col-md-5">
                    <label>Adicionar Perfil</label>
                    <asp:ListBox ID="listBoxPerfis" runat="server" CssClass="form-control" Rows="1"></asp:ListBox>
                    <br />
                    <asp:Button ID="btAdicionarPerfil" Text="Adicionar" CssClass="btn btn-primary" runat="server" OnClick="btAdicionarPerfil_Click" />
                </div>

                <div class="col-md-6">
                    <label>Perfis vinculados</label>
                    <asp:RadioButtonList runat="server" ID="radioListPerfis">
                    </asp:RadioButtonList>
                    <br />
                    <asp:Button Text="Remover Perfil" runat="server" CssClass="btn btn-danger" ID="btRemoverPerfil" OnClick="btRemoverPerfil_Click"/>
                </div>
            </div>

            <hr />

            <div class="form-group">
                <div class="col-md-12">
                    <a href="/Usuario" class="btn btn-default">Voltar</a>
                </div>
            </div>

        </div>
        
	</div>
</div>

</asp:Content>
