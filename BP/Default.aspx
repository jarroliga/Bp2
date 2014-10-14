<%@ Page Title="" Language="C#" MasterPageFile="~/BPCore.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BP.Default" Theme="Default" %>
<%@ MasterType VirtualPath="~/BPCore.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMaster" runat="server">
        <div class="info">
            <h1>Sistema de Informaci&oacute;n de Inversi&oacute;n P&uacute;blica</h1>
            <p class="byline"><small>Sistema de Seguimiento Fisico Financiero del Banco de Proyectos</small></p>
        </div>
        <asp:Panel ID="pnlInicio" runat="server" ScrollBars="None" Width="100%"> 
            <img src="images/dario.gif" alt="" width="160" height="225" class="right" />
            <p>Bienvenido al <b>M&oacute;dulo de Licitaciones</b> del <b>Sistema de Seguimiento</b> del <b>Banco de Proyectos</b>. 
                Este módulo que forma parte del Sistema de Informaci&oacute;n del Banco de Proyectos del SNIP, pretende ser una herramienta de apoyo para facilitar el seguimiento
                de la inversi&oacute;n p&uacute;blica nacional, que brinda informaci&oacute;n gerencial a los tomadores de decisi&oacute;n para el an&aacute;lisis y acciones correspondientes.</p>
            <br />
            <asp:LoginView ID="lgvInicio" runat="server">
                <AnonymousTemplate>
                    <asp:HyperLink ID="hlkLogin" runat="server" NavigateUrl="~/LoginPage.aspx">
                        <img id="imgLogin" runat="server" src="~/images/icon_padlock.gif" style="margin-right:5px; vertical-align:middle;" alt="padlock" />Iniciar Sesi&oacute;n en el Sistema</asp:HyperLink>
                </AnonymousTemplate>
            </asp:LoginView>

            <asp:HyperLink ID="hlkAlertaReg" runat="server" NavigateUrl="~/bps/AlertaEstadoList.aspx">
                <img id="imgAlerta1" runat="server" src="~/images/icon_padlock.gif" style="margin-right:5px; vertical-align:middle;" alt="padlock" /></asp:HyperLink>
            <br /><br />
            <asp:HyperLink ID="hlkAlertaEta" runat="server" NavigateUrl="~/bps/AlertaEtapaList.aspx" >
                <img id="imgAlerta2" runat="server" src="~/images/icon_padlock.gif" style="margin-right:5px; vertical-align:middle;" alt="padlock" /></asp:HyperLink>                        
            <br /><br />
            <asp:HyperLink ID="hlkAlertaRpg" runat="server" NavigateUrl="~/bps/AlertaReprogramacionList.aspx" >
                <img id="imgAlerta3" runat="server" src="~/images/icon_padlock.gif" style="margin-right:5px; vertical-align:middle;" alt="padlock" /></asp:HyperLink>                        
            <br />
        </asp:Panel> 
        <br /><br />
</asp:Content>
