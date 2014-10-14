<%@ Page Title="" Language="C#" MasterPageFile="~/BPCore.Master" AutoEventWireup="true" CodeBehind="ProyectoList.aspx.cs" Inherits="BP.Bp.ProyectoList" Theme="Default" %>
<%@ MasterType VirtualPath="~/BPCore.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMaster" runat="server">
    <div class="info">
        <h1>Proyectos</h1>
        <p class="byline"><small>Listado de Proyectos en el PIP</small></p>
    </div>
    <ul>
        <li class="leftHalf">
            <asp:Label ID="Label1" runat="server" Text="PIP:" CssClass="etiqueta"></asp:Label>
            <div>
                <asp:DropDownList ID="ddlListaPip" runat="server" Width="80%" AutoPostBack="true" OnSelectedIndexChanged="ListaPipSelectedIndexChanged">
                </asp:DropDownList>                  
            </div>
        </li>
        <li class="rightHalf">
           <asp:Label ID="lblFiltro" runat="server" Text="Buscar:" CssClass="etiqueta"></asp:Label>
           <asp:TextBox ID="txtFiltro" runat="server" Text="" AutoPostBack="true" OnTextChanged="FiltroTextChanged" ></asp:TextBox>
           <asp:ImageButton ID="btnFiltro" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/ico_find.gif" OnClick="FiltroClick" />
        </li>
        <li>
            <asp:Label ID="lblTitulo" runat="server" Text="Listado de Proyectos:" AssociatedControlID="grdList" CssClass="etiqueta"></asp:Label>
            <asp:UpdatePanel ID="upGrd" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div>
                        <asp:GridView ID="grdList" runat="server" AutoGenerateColumns="False" DataKeyNames="Codigo" AllowSorting="true"
                                OnRowCreated="grdList_RowCreated" OnRowCommand="grdList_RowCommand" OnSorting="grdList_Sorted" AllowPaging="False">
                                <Columns>
                                    <asp:TemplateField ItemStyle-Height="18px" ItemStyle-Width="24px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgEdit" runat="server" CommandName="Editar" ImageUrl="~/Images/page_edit.gif" CausesValidation="true" />
                                        </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Height="18px" Width="24px"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Height="18px" ItemStyle-Width="24px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgRead" runat="server" CommandName="Consultar" ImageUrl="~/Images/page.gif" CausesValidation="true" />
                                        </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Height="18px" Width="24px"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Codigo" Visible="false" HeaderText="Codigo"/>
                                    <asp:BoundField DataField="CodSnip" Visible="true" HeaderText="Codigo" ItemStyle-Width="10%" ItemStyle-CssClass="colapsable" SortExpression="CodSnip"/>
                                    <asp:BoundField DataField="Nombre" Visible="true" HeaderText="Nombre" SortExpression="Nombre">
                                        <ItemStyle CssClass="colapsable" Width="95%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Siglas" Visible="true" HeaderText="Institución" SortExpression="Siglas" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="Center" NullDisplayText="--" >
                                        <ItemStyle HorizontalAlign="Center" Width="15%"></ItemStyle>
                                    </asp:BoundField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <p>No hay registros que mostrar</p>
                                </EmptyDataTemplate>
                       </asp:GridView>
                       <asp:Panel ID="pnlNavigation" runat="server">
                            <div class="grdNavBar">
                            Mostrar filas:
                            <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PageSizeSelectedIndexChanged">
                                <asp:ListItem Value="5"/>
                                <asp:ListItem Value="10" Selected="True"/>
                                <asp:ListItem Value="20"/>
                                <asp:ListItem Value="30"/>
                                <asp:ListItem Text="Todos" Value="0"/>
                            </asp:DropDownList>
                            &nbsp;
                            Ir a:
                            &nbsp;
                            <asp:TextBox ID="txtPageNumber" runat="server" Text="" Width="20px" OnTextChanged="grdList_PageNumberChanged" AutoPostBack="true"></asp:TextBox>
                            de
                            &nbsp;
                            <asp:Label ID="lblMaxPageNumber" runat="server" Text=""></asp:Label>
                            &nbsp;
                            <asp:Button ID="btnFirst" runat="server" Text="" CommandName="Page" CommandArgument="First" OnCommand="grdList_PageIndexChanged" ToolTip="Ir a la primera página" CssClass="pagfirst" />
                            <asp:Button ID="btnPrev" runat="server" Text="" CommandName="Page" CommandArgument="Prev" OnCommand="grdList_PageIndexChanged" ToolTip="Ir a la página anterior" CssClass="pagprev" />
                            <asp:Button ID="btnNext" runat="server" Text="" CommandName="Page" CommandArgument="Next" OnCommand="grdList_PageIndexChanged" ToolTip="Ir a la página siguiente" CssClass="pagnext" />
                            <asp:Button ID="btnLast" runat="server" Text="" CommandName="Page" CommandArgument="Last" OnCommand="grdList_PageIndexChanged" ToolTip="Ir a la última página" CssClass="paglast" />
                            <asp:Label ID="lblTotalRegistros" runat="server" Text="Total:" Font-Size="98%" style="margin-left:15px;"></asp:Label>
                          </div>
                      </asp:Panel>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="txtFiltro" EventName="TextChanged" />
                <asp:AsyncPostBackTrigger ControlID="btnFiltro" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="ddlListaPip" EventName="SelectedIndexChanged" />
            </Triggers>
          </asp:UpdatePanel>
       </li>
<%--       <li>
           <asp:Label ID="lblTotalRegistros" runat="server" Text=""></asp:Label>
       </li>
--%>       <li class="buttons">
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
