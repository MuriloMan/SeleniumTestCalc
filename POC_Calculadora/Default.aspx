<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="POC_Calculadora._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Calculadora</h1>
        <p class="lead">Aplicação de exemplo para ambiente DevOps.</p>
    </div>

    <div class="row">

        <b> <asp:Label runat="server" Text="Número 1:"></asp:Label> </b><br />
        <asp:TextBox id="txtNumero1" runat="server" class="form-control" Text="" Width="200px"></asp:TextBox><br />

        <b> <asp:Label runat="server" Text="Número 2:"></asp:Label> </b> <br />
        <asp:TextBox id="txtNumero2" runat="server" class="form-control" Text="" Width="200px"></asp:TextBox><br />

        <b> <asp:Label runat="server" Text="Operação:"></asp:Label> </b> <br />
        <asp:DropDownList ID="ddlOperacao" runat="server" class="form-control" Width="200px" >
            <asp:ListItem Value="0">Selecione</asp:ListItem>
            <asp:ListItem Value="1">Adição</asp:ListItem>
            <asp:ListItem Value="2">Subtração</asp:ListItem>
            <asp:ListItem Value="3">Multiplicação</asp:ListItem>
            <asp:ListItem Value="4">Divisão</asp:ListItem>
        </asp:DropDownList><br />

         <b> <asp:Label runat="server" Text="Resultado:"></asp:Label> </b> <br />
        <asp:TextBox id="txtResultado" runat="server" class="form-control" Text="" Width="200px"></asp:TextBox><br />

        <asp:Button id="BtnCalcular" runat="server" class="btn btn-primary" Text="Calcular" OnClick="BtnCalcular_Click" />
        <asp:Button id="BtnLimpar" runat="server" class="btn btn-default" Text="Limpar" OnClick="BtnLimpar_Click" />

    </div>

</asp:Content>
