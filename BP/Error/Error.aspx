<%@ Page Title="" Language="C#" MasterPageFile="~/BPCore.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="BP.Error.Error" %>
<%@ MasterType VirtualPath="~/BPCore.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMaster" runat="server">
    <div class="info">
        <h1>Advertencia!</h1>
	    <p class="byline"><small>Descripci&oacute;n del evento</small></p>
	</div>
	<ul>
	    <li>
            <asp:Label ID="Label1" runat="server" Text="Detalle del Evento:" CssClass="etiqueta"></asp:Label>
	        <div>
                <asp:Label ID="labErrorMessage" runat="server" Text=""></asp:Label>
            </div>
	    </li>
	</ul>
</asp:Content>
