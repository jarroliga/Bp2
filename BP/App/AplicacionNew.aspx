<%@ Page Title="" Language="C#" MasterPageFile="~/BPCore.Master" AutoEventWireup="true" CodeBehind="AplicacionNew.aspx.cs" Inherits="BP.App.AplicacionNew" Theme="Default"%>
<%@ MasterType VirtualPath="~/BPCore.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMaster" runat="server">
     <div class="info">
         <h1>Aplicaci&oacute;n</h1>
	     <p class="byline"><small>Cat&aacute;logo de Aplicaciones: Registrar Nueva Aplicación</small></p>
	 </div>
	 <ul>
	    <li>
             <asp:Label ID="lblCodigo" runat="server" Text="Codigo:" AssociatedControlID="txtCodigo" CssClass="etiqueta"></asp:Label>
             <div>
                <asp:TextBox ID="txtCodigo" runat="server" Width="100px" Enabled="false"></asp:TextBox>
             </div>
        </li>
        <li>
            <asp:Label ID="Label2" runat="server" Text="Identificador:" AssociatedControlID="txtId" CssClass="etiqueta"></asp:Label>
             <div>
                 <asp:TextBox ID="txtId" runat="server" Width="100px" CssClass="field"></asp:TextBox>
                 <ajaxToolkit:MaskedEditExtender ID="meeId" runat="server" TargetControlID="txtId"
                        MaskType="None" Mask="?{3}" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                        ClearTextOnInvalid="true" PromptCharacter="">
                 </ajaxToolkit:MaskedEditExtender>
             </div>
             <asp:RequiredFieldValidator ID="rfvId" runat="server" ErrorMessage="Debe digitar el Id de la aplicacion" ControlToValidate="txtId" Display="Dynamic"></asp:RequiredFieldValidator>
        </li>
        <li>
             <asp:Label ID="Label1" runat="server" Text="Nombre:" AssociatedControlID="txtNombre" CssClass="etiqueta"></asp:Label>
             <div>
                 <asp:TextBox ID="txtNombre" runat="server" Width="650px" CssClass="field"></asp:TextBox>
                 <ajaxToolkit:MaskedEditExtender ID="meeNombre" runat="server" TargetControlID="txtNombre"
                        MaskType="None" Mask="?{150}" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError"
                        ClearTextOnInvalid="true" PromptCharacter="">
                 </ajaxToolkit:MaskedEditExtender>
             </div>
             <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="Debe digitar el nombre de la aplicacion" ControlToValidate="txtNombre" Display="Dynamic" ></asp:RequiredFieldValidator> 
         </li>
         <li class="buttons">
            <asp:ImageButton ID="btnSalvar" runat="server" ImageUrl="~/Images/btn_save.gif" 
                 ImageAlign="Middle" AlternateText="Salvar" onclick="btnSalvar_Click" />
            <asp:ImageButton ID="btnCancelar" runat="server" ImageUrl="~/Images/btn_exit.gif" 
                 ImageAlign="Middle" AlternateText="Salvar" onclick="btnCancelar_Click" CausesValidation="false"/>
         </li>
     </ul>
</asp:Content>
