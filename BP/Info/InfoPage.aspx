<%@ Page Title="" Language="C#" MasterPageFile="~/BPCore.Master" AutoEventWireup="true" CodeBehind="InfoPage.aspx.cs" Inherits="BP.Info.InfoPage" %>
<%@ MasterType VirtualPath="~/BPCore.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMaster" runat="server">
    <div class="info">
        <h1>Informaci&oacute;n</h1>
	    <p class="byline"><small>Informaci&oacute;n de los eventos del sistema</small></p>
	</div>
	<ul>
	<li>
	<asp:Image ID="Image1" runat="server" CssClass="left" ImageUrl="~/Images/ae_info.gif"/>
    <asp:Label ID="Label1" runat="server" Text="Descripción del Evento:" CssClass="etiqueta"></asp:Label>
    <div>
        <asp:Label ID="labErrorMessage" runat="server" Text=""></asp:Label>
    </div>
    <asp:Label ID="Label2" runat="server" Text="Origen del Evento:" CssClass="etiqueta"></asp:Label>
    <div>
        <asp:Label ID="lblFuenteEvento" runat="server" Text=""></asp:Label>
    </div>
    </li>    
    </ul>  
</asp:Content>
