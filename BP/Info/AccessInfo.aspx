<%@ Page Title="" Language="C#" MasterPageFile="~/BPCore.Master" AutoEventWireup="true" CodeBehind="AccessInfo.aspx.cs" Inherits="BP.Info.AccessInfo" %>
<%@ MasterType VirtualPath="~/BPCore.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMaster" runat="server">
    <div class="info">
        <h1>Acceso Denegado!!</h1>
        <p class="byline"><small>Informaci&oacute;n de Acceso al Sistema</small></p>
    </div>
    <div>
        <ul>
            <li>
                <p>Usted no tiene los permisos necesarios para acceder a esta opci&oacute;n del sistema. Contacte al administrador
                del sistema.</p>
            </li>
            <li>
               <asp:ImageButton ID="btnRegresar" runat="server" ImageUrl="~/Images/btn_return.gif" 
                ImageAlign="Middle" AlternateText="Regresar" OnClick="btnRegresar_Click" /> 
            </li>
        </ul>
    </div>
</asp:Content>
