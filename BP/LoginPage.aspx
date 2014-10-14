<%@ Page Title="" Language="C#" MasterPageFile="~/BPCore.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="BP.LoginPage" %>
<%@ MasterType VirtualPath="~/BPCore.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMaster" runat="server">
    <div class="info">
        <h1>Inicio de Sesi&oacute;n</h1>
        <p class="byline"><small>Autenticaci&oacute;n de Usuario</small></p>
    </div>
    <ul>
        <li>
            <p>Estimado usuario: ingrese su nombre de usuario y su clave de acceso para iniciar su sesión de trabajo en el sistema.</p>
        </li>
        <li>
            <div>
                <asp:Login ID="logBP" runat="server" CssClass="LoginStyle"
                    UserNameLabelText="Usuario " PasswordLabelText="Contraseña " 
                    RememberMeText="Recordar la próxima vez" 
                    LoginButtonType="Image" LoginButtonImageUrl="~/images/btn_enter.gif" 
                    Font-Names="Verdana" Font-Size="11px" TextLayout="TextOnTop"
                    TitleText="Validar Usuario" 
                    TextBoxStyle-Width="160px"
                    PasswordRequiredErrorMessage="La contraseña es requerinda."
                    UserNameRequiredErrorMessage="El Nombre de usuario es requerido."
                    FailureText="Credenciales inválidas. Por favor intente de nuevo." RememberMeSet="false"
                    BorderColor="#4d91c6" BorderStyle="None" BorderWidth="1px" Width="300px" 
                    ForeColor="Black" OnAuthenticate="LogBpsAuthenticate"  >
                    <TitleTextStyle BackColor="#4D91C6" ForeColor="White" Height="20px" />
                    <CheckBoxStyle CssClass="LoginStyle" />
                    <LabelStyle CssClass="LoginStyle" />
                    <TextBoxStyle CssClass="LoginTextBoxStyle" />
                </asp:Login>
            </div>
        </li>
    </ul>
</asp:Content>
