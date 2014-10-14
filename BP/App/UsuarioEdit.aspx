<%@ Page Title="" Language="C#" MasterPageFile="~/BPCore.Master" AutoEventWireup="true" CodeBehind="UsuarioEdit.aspx.cs" Inherits="BP.App.UsuarioEdit" Theme="Default" %>
<%@ MasterType VirtualPath="~/BPCore.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMaster" runat="server">
    <div class="info">
        <h1>Usuarios: Edici&oacute;n de Datos</h1>
    <p class="byline"><small>Administraci&oacute;n de Usuarios del SIIP: Editar datos de usuario</small></p>
    </div>
    <ul>
        <li>
            <label class="etiqueta">Nombres:</label>
            <asp:TextBox ID="txtNombre" runat="server" Width="70%"></asp:TextBox>
            <asp:RequiredFieldValidator ID="frvNombre" runat="server" ErrorMessage="Debe digitar el(los) Nombre(s) del Usuario" 
               ControlToValidate="txtNombre" Display="Dynamic">*</asp:RequiredFieldValidator>
        </li>
        <li>
            <label class="etiqueta">Apellidos:</label>
            <asp:TextBox ID="txtApellido" runat="server" Width="70%"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ErrorMessage="Debe digitar el(los) Apellido(s) del Usuario"
               ControlToValidate="txtApellido" Display="Dynamic">*</asp:RequiredFieldValidator>
        </li>
        <li>
            <label class="etiqueta">Usuario Interno DGIP:</label>
            <asp:CheckBox ID="chkEsInterno" runat="server" Checked="false"/>
        </li>
        <li class="leftHalf">
            <label class="etiqueta">Usuario Activo:</label>
            <asp:CheckBox ID="chkHabilitado" runat="server" Checked="true"/>
        </li>
        <li class="rightHalf">
            <label class="etiqueta">Fecha de Ultimo Acceso:</label>
            <asp:Label ID="txtUltimoAcceso" runat="server" Text="-"></asp:Label>
        </li>
        <li>
            <label class="etiqueta">Instituci&oacute;n:</label>
            <asp:DropDownList ID="ddlInstitucion" runat="server" CssClass="listEntry100">
            </asp:DropDownList>
        </li>
        <li>
            <label class="etiqueta">Email:</label>
           <asp:TextBox ID="txtEmail" runat="server" Width="50%"></asp:TextBox>
        </li>
        <li>
            <label class="etiqueta">Cuenta de Usuario:</label>
            <asp:TextBox ID="txtLogin" runat="server" Width="30%"></asp:TextBox>
        </li>
        <li class="buttons">
            <asp:ImageButton ID="btnSalvar" runat="server" ImageUrl="~/Images/btn_save.gif" 
                ImageAlign="Middle" AlternateText="Salvar" OnClick="BtnSalvarClick" />
           <asp:ImageButton ID="btnRegresar" runat="server" ImageUrl="~/Images/btn_return.gif" 
                ImageAlign="Middle" AlternateText="Regresar" OnClick="BtnRegresarClick" CausesValidation="false"/>
       </li>
       <li>
            <asp:ValidationSummary ID="RegisterValidationSummary" runat="server" 
            ValidationGroup="RegisterValidationGroup" CssClass="failureNotification" />
            <snip:ErrorList ID="eList" runat="server">
            </snip:ErrorList> 
        </li>
    </ul>
</asp:Content>
