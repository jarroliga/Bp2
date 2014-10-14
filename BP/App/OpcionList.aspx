<%@ Page Title="" Language="C#" MasterPageFile="~/BPCore.Master" AutoEventWireup="true" CodeBehind="OpcionList.aspx.cs" Inherits="BP.App.OpcionList" Theme="Default" %>
<%@ MasterType VirtualPath="~/BPCore.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMaster" runat="server">
    <div class="info">
        <h1>Opciones</h1>
        <p class="byline"><small>Cat&aacute;logo de Opciones del BP</small></p>
    </div>
    <ul>
        <li>
            <label for="grdList" class="etiqueta">Opciones:</label>
            <div>
                <asp:GridView ID="grdList" runat="server" AllowPaging="false" AllowSorting="false" AutoGenerateColumns="false" DataKeyNames="Codigo"
                   OnRowCreated="grdList_RowCreated" OnRowCommand="grdList_RowCommand">
                        <Columns>
                            <asp:TemplateField ItemStyle-Height="18px" ItemStyle-Width="18px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgEdit" runat="server" CommandName="Editar" ImageUrl="~/Images/page_edit.gif" CausesValidation="true" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-Height="18px" ItemStyle-Width="18px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgDelete" runat="server" CommandName="Borrar" ImageUrl="~/Images/page_delete.gif" CausesValidation="false" OnClientClick="return confirm('Desea eliminar el registro seleccionado?');"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Codigo" Visible="true" HeaderText="Codigo" ItemStyle-Width="8px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="IdOpcion" Visible="true" HeaderText="Identificador" ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Nombre" Visible="true" HeaderText="Nombre" ItemStyle-CssClass="colapsable" />
                            <asp:CheckBoxField DataField="Activa" Visible="true" ReadOnly="true" HeaderText="Activa?" ItemStyle-HorizontalAlign="Center" />
                        </Columns>
                        <EmptyDataTemplate>
                            <p>No hay registros que mostrar</p>
                        </EmptyDataTemplate>
               </asp:GridView>
           </div>
       </li>
       <li class="buttons">
            <asp:ImageButton ID="btnNuevo" runat="server" ImageUrl="~/Images/btn_new.gif" 
                ImageAlign="Middle" AlternateText="Nuevo" OnClick="btnNuevo_Click" />
           <asp:ImageButton ID="btnRegresar" runat="server" ImageUrl="~/Images/btn_return.gif" 
                ImageAlign="Middle" AlternateText="Nuevo" OnClick="btnRegresar_Click" />
       </li>
    </ul>
</asp:Content>
