<%@ Page Title="" Language="C#" MasterPageFile="~/BPCore.Master" AutoEventWireup="true" CodeBehind="ProyectoList.aspx.cs" Inherits="BP.Bpm.ProyectoList" Theme="Default" %>
<%@ MasterType VirtualPath="~/BPCore.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMaster" runat="server">
        <div class="info">
            <h1>Proyectos Municipales</h1>
            <p class="byline"><small>Iniciativas de Proyectos de los Municipios</small></p>
        </div>
        <ul>
            <li class="buttons">
           <asp:ImageButton ID="btnRegresar" runat="server" ImageUrl="~/Images/btn_return.gif" 
                ImageAlign="Middle" AlternateText="Nuevo" OnClick="BtnRegresar_Click" />
            </li>
       </ul>
</asp:Content>
