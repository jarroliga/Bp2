<%@ Page Title="Seguridad" Language="C#" MasterPageFile="~/BPCore.Master" AutoEventWireup="true" CodeBehind="UsuarioList.aspx.cs" Inherits="BP.App.UsuarioList" Theme="Default" %>
<%@ MasterType VirtualPath="~/BPCore.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMaster" runat="server">
    <div class="info">
        <h1>Usuarios</h1>
    <p class="byline"><small>Administraci&oacute;n de Usuarios del SIIP</small></p>
    </div>
    <ul>
        <li class="leftHalf">
            <label class="etiqueta">Instituci&oacute;n:</label>
            <div>
                <asp:DropDownList ID="ddlInstitucion" runat="server" Width="100%" AutoPostBack="true" OnSelectedIndexChanged="InstitucionSelectedIndexChanged">
                </asp:DropDownList>                  
            </div>
        </li>
        <li class="rightHalf">
           <asp:Label ID="lblFiltro" runat="server" Text="Buscar:" CssClass="etiqueta"></asp:Label>
           <asp:TextBox ID="txtFiltro" runat="server" Text="" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged" ></asp:TextBox>
           <asp:ImageButton ID="btnFiltro" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/ico_find.gif" OnClick="btnFiltro_Click" />
        </li>
        <li>
            <label for="grdList" class="etiqueta">Listado de Usuarios:</label>
            <asp:UpdatePanel ID="upGrd" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div>
                        <asp:GridView ID="grdList" runat="server" AutoGenerateColumns="False" DataKeyNames="Codigo" AllowSorting="true"
                                OnRowCreated="GrdListRowCreated" OnRowCommand="GrdListRowCommand" OnSorting="GrdListSorted" AllowPaging="False">
                                <Columns>
                                    <asp:TemplateField ItemStyle-Height="18px" ItemStyle-Width="24px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgEdit" runat="server" CommandName="Editar" ImageUrl="~/Images/page_edit.gif" CausesValidation="true" />
                                        </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Height="18px" Width="24px"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Codigo" Visible="false" HeaderText="Codigo"/>
                                    <asp:BoundField DataField="Apellido" Visible="true" HeaderText="Apellido" ItemStyle-Width="20%" ItemStyle-CssClass="colapsable" SortExpression="Apellido"/>
                                    <asp:BoundField DataField="Nombre" Visible="true" HeaderText="Nombre" SortExpression="Nombre" ItemStyle-Width="20%"/>  
                                    <asp:BoundField DataField="Login" Visible="true" HeaderText="Login" ItemStyle-Width="12%" SortExpression="Login"/>
                                    <asp:TemplateField HeaderText="Institución" SortExpression="Siglas">
                                        <ItemTemplate>
                                            <%# String.Format("{0}",Eval("Institucion.Siglas")) %>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="colapsable"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="FechaCreacion" HeaderText="Desde" HtmlEncode="false" DataFormatString="{0:dd/MM/yy}" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="10%"/>
                                    <asp:CheckBoxField DataField="EsInterno" HeaderText="Interno?" ReadOnly="true" ItemStyle-HorizontalAlign="Center" />
                                    <asp:CheckBoxField DataField="Habilitado" HeaderText="Activo?" ReadOnly="true" ItemStyle-HorizontalAlign="Center"/>
                                </Columns>
                                <EmptyDataTemplate>
                                    <p>No hay registros que mostrar</p>
                                </EmptyDataTemplate>
                       </asp:GridView>
                       <asp:Panel ID="pnlNavigation" runat="server">
                            <div class="grdNavBar">
                            Mostrar filas:
                            <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="GrdListPageSizeSelectedIndexChanged">
                                <asp:ListItem Value="5"/>
                                <asp:ListItem Value="10" Selected="True"/>
                                <asp:ListItem Value="20"/>
                                <asp:ListItem Value="30"/>
                                <asp:ListItem Text="Todos" Value="0"/>
                            </asp:DropDownList>
                            &nbsp;
                            Ir a:
                            &nbsp;
                            <asp:TextBox ID="txtPageNumber" runat="server" Text="" Width="20px" OnTextChanged="GrdListPageNumberChanged" AutoPostBack="true"></asp:TextBox>
                            de
                            &nbsp;
                            <asp:Label ID="lblMaxPageNumber" runat="server" Text=""></asp:Label>
                            &nbsp;
                            <asp:Button ID="btnFirst" runat="server" Text="" CommandName="Page" CommandArgument="First" OnCommand="GrdListPageIndexChanged" ToolTip="Ir a la primera página" CssClass="pagfirst" />
                            <asp:Button ID="btnPrev" runat="server" Text="" CommandName="Page" CommandArgument="Prev" OnCommand="GrdListPageIndexChanged" ToolTip="Ir a la página anterior" CssClass="pagprev" />
                            <asp:Button ID="btnNext" runat="server" Text="" CommandName="Page" CommandArgument="Next" OnCommand="GrdListPageIndexChanged" ToolTip="Ir a la página siguiente" CssClass="pagnext" />
                            <asp:Button ID="btnLast" runat="server" Text="" CommandName="Page" CommandArgument="Last" OnCommand="GrdListPageIndexChanged" ToolTip="Ir a la última página" CssClass="paglast" />
                            <asp:Label ID="lblTotalRegistros" runat="server" Text="Total:" Font-Size="98%" style="margin-left:15px;"></asp:Label>
                          </div>
                      </asp:Panel>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="txtFiltro" EventName="TextChanged" />
                <asp:AsyncPostBackTrigger ControlID="btnFiltro" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="ddlInstitucion" EventName="SelectedIndexChanged" />
            </Triggers>
          </asp:UpdatePanel>
       </li>
       <li class="buttons">
           <asp:ImageButton ID="btnRegresar" runat="server" ImageUrl="~/Images/btn_return.gif" 
                ImageAlign="Middle" AlternateText="Nuevo" OnClick="btnRegresar_Click" />
       </li>
    </ul>
    <div >
    <!-- Muestra informacion de prograso de la carga del grid -->
    <asp:UpdateProgress ID="UpdateProg" runat="server" AssociatedUpdatePanelID="upGrd">
         <ProgressTemplate>
           <div class="updateProgressPanel" >
           <img src='<%=Page.ResolveUrl("~/Images/loading.gif") %>' alt="Cargando..." /><br />Procesando...
           </div>
         </ProgressTemplate>
     </asp:UpdateProgress>
     </div>
</asp:Content>
