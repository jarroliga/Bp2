<%@ Page Title="" Language="C#" MasterPageFile="~/BPCore.Master" AutoEventWireup="true" CodeBehind="RegisterInfo.aspx.cs" Inherits="BP.Info.RegisterInfo" Theme="Default" %>
<%@ MasterType VirtualPath="~/BPCore.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMaster" runat="server">
    <div class="info">
        <h1>Pendientes de Registro</h1>
        <p class="byline"><small>Informaci&oacute;n de Alerta de Registro</small></p>
    </div>
    <div>
        <ul>
            <li>
                <p>Usted no puede registrar en este momento la informaci&oacute;n de las obras, as&iacute; como tampoco la programaci&oacute;n de desembolsos 
                de las mismas. Primero debe completar el registro del Cronograma con los tiempos estimados para el proceso de la licitaci&oacute;n.</p>
            </li>
            <li>
               <asp:ImageButton ID="btnRegresar" runat="server" ImageUrl="~/Images/btn_return.gif" 
                ImageAlign="Middle" AlternateText="Regresar" OnClick="btnRegresar_Click" /> 
            </li>
        </ul>
    </div>
</asp:Content>
