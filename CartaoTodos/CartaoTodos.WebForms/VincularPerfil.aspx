<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VincularPerfil.aspx.cs" Inherits="CartaoTodos.WebForms.VincularPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Vincular Perfil</h3>

    <div class="form-horizontal">

        <div class="form-group">
            <div class="col-md-6">
                <label>Usuário: </label> <%= Usuario.Nome %>
            </div>
        </div>


        <div class="form-group">
            <div class="col-md-6">
                <p>Adicionar Perfil</p>
                <asp:ListBox ID="listBoxPerfis" runat="server" CssClass="form-control" Rows="1"></asp:ListBox>
                <br />
                <asp:Button ID="btAdicionarPerfil" Text="Adicionar" CssClass="btn btn-primary" runat="server" OnClick="btAdicionarPerfil_Click" />
            </div>
        </div>

        <hr />

        <div class="form-group">
            <div class="col-md-6">
                <p>Perfis vinculados</p>
                <asp:RadioButtonList runat="server" ID="radioListPerfis">
                </asp:RadioButtonList>
                <br />
                <asp:Button Text="Remover Perfil" runat="server" CssClass="btn btn-danger" ID="btRemoverPerfil" OnClick="btRemoverPerfil_Click"/>
            </div>
        </div>

    </div>


</asp:Content>
