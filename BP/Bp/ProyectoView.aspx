<%@ Page Title="" Language="C#" MasterPageFile="~/BPCore.Master" AutoEventWireup="true" CodeBehind="ProyectoView.aspx.cs" Inherits="BP.Bp.ProyectoView" Theme="Default" %>
<%--<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>--%>
<%@ MasterType VirtualPath="~/BPCore.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMaster" runat="server">
    <div class="info">
        <h1>Proyecto</h1>
        <p class="byline"><small>Datos B&aacute;sicos del Proyecto</small></p>
    </div>
    <ul>
        <li class="leftHalf">
            <asp:Label ID="Label7" runat="server" Text="Código SNIP:" CssClass="etiqueta"></asp:Label>
            <div>
                <asp:Label ID="lblCodSnip" runat="server" Text=""></asp:Label>
            </div>
        </li>
        <li class="rightHalf">
            <asp:Label ID="Label8" runat="server" Text="Etapa:" CssClass="etiqueta"></asp:Label>
            <div>
                <asp:Label ID="lblEtapa" runat="server" Text=""></asp:Label>
            </div>        
        </li>
        <li>
            <asp:Label ID="lblTitProyecto" runat="server" Text="Nombre del Proyecto:" CssClass="etiqueta"></asp:Label>
            <div>
                <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label>
            </div>
        </li>
        <li>
            <h2>Datos B&aacute;sicos</h2>
        </li>
        <li>
            <asp:Label ID="lblTitInstitucion" runat="server" Text="Institución:" CssClass="etiqueta"></asp:Label>
            <div>
                <asp:Label ID="lblInstitucion" runat="server" Text=""></asp:Label>
            </div>
        </li>
        <li>
            <asp:Label ID="Label1" runat="server" Text="Sector Económico:" CssClass="etiqueta"></asp:Label>
            <div>
                <asp:Label ID="lblSector" runat="server" Text=""></asp:Label>
            </div>
        </li>
        <li class="leftHalf">
            <asp:Label ID="lblTitFechaIniPrev" runat="server" Text="Fecha de Inicio Prevista:" CssClass="etiqueta"></asp:Label>
            <div>
                <asp:Label ID="lblFechaIniPrev" runat="server" Text=""></asp:Label>
            </div>
        </li>
        <li class="rightHalf">
            <asp:Label ID="lblTitFechaFinPrev" runat="server" Text="Fecha de Finalización Prevista:" CssClass="etiqueta"></asp:Label>
            <div>
                <asp:Label ID="lblFechaFinPrev" runat="server" Text=""></asp:Label>
            </div>
        </li>
        <li class="leftHalf">
            <asp:Label ID="Label2" runat="server" Text="Fecha de Inicio Real:" CssClass="etiqueta"></asp:Label>
            <div>
                <asp:Label ID="lblFechaIniReal" runat="server" Text=""></asp:Label>
            </div>
        </li>
        <li class="rightHalf">
            <asp:Label ID="Label4" runat="server" Text="Fecha de Finalización Real:" CssClass="etiqueta"></asp:Label>
            <div>
                <asp:Label ID="lblFechaFinReal" runat="server" Text=""></asp:Label>
            </div>
        </li>
        <li>
            <ajaxToolkit:TabContainer ID="tbcTextos" runat="server">
                <ajaxToolkit:TabPanel ID="tbpDescripcion" HeaderText="Descripción" runat="server">
                    <ContentTemplate>
                        <div>
                            <asp:Label ID="lblDescripcion" runat="server" Text=""></asp:Label>
                        </div>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="tbpObjetivos" HeaderText="Objetivos" runat="server">
                    <ContentTemplate>
                         <div>
                            <asp:Label ID="Label3" runat="server" Text="Objetivos de Desarrollo:" CssClass="etiqueta"></asp:Label>
                            <div>
                                <asp:Label ID="lblObjetivosDesarrollo" runat="server" Text=""></asp:Label>
                            </div>
                            <br />
                            <asp:Label ID="Label5" runat="server" Text="Objetivos Específicos:" CssClass="etiqueta"></asp:Label>
                            <div>
                                <asp:Label ID="lblObjetivosEspecificos" runat="server" Text=""></asp:Label>
                            </div>
                         </div>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="tbpJustificacion" HeaderText="Justificación" runat="server">
                    <ContentTemplate>
                        <div>
                            <asp:Label ID="lblJustificacion" runat="server" Text=""></asp:Label>
                        </div>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="tbpBeneficios" HeaderText="Justificación" runat="server">
                    <ContentTemplate>
                        <div>
                            <asp:Label ID="lblBeneficios" runat="server" Text=""></asp:Label>
                        </div>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                 <ajaxToolkit:TabPanel ID="tbpAspectosOp" HeaderText="Justificación" runat="server">
                    <ContentTemplate>
                        <div>
                            <asp:Label ID="lblAspectosOperativos" runat="server" Text="[...]"></asp:Label>
                        </div>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
            </ajaxToolkit:TabContainer>

        </li>
<%--        <telerik:RadTabStrip ID="RadTabStrip1" runat="server">
            <Tabs>
                <telerik:RadTab Text="Prueba 1" ImageUrl="../images/ico_bricks.gif">
                       
                </telerik:RadTab>
                <telerik:RadTab Text="Prueba 2">
                </telerik:RadTab>
            </Tabs>
        </telerik:RadTabStrip>--%>          
        <li class="buttons">
           <asp:ImageButton ID="btn_return" runat="server" ImageUrl="~/Images/btn_return.gif" 
                ImageAlign="Middle" AlternateText="Nuevo" OnClick="btnRegresar_Click" />
       </li>
    </ul>   
    <script type="text/javascript">
        $(function () {
            $("#accordion").accordion();
        });
        $("#notaccordion").addClass("ui-accordion ui-accordion-icons ui-widget ui-helper-reset")
            .find("h2")
            .addClass("ui-accordion-header ui-corner-top ui-corner-bottom")
        //.addClass("ui-accordion-header ui-helper-reset ui-state-default ui-corner-top ui-corner-bottom")
            .hover(function () { $(this).toggleClass("ui-accordion-header-hover"); })
            .prepend('<span class="ui-icon ui-icon-triangle-1-e"></span>')
            .click(function () {
                $(this)
            .toggleClass("ui-accordion-header ui-corner-bottom")
                //.toggleClass("ui-accordion-header-active ui-state-active ui-state-default ui-corner-bottom")
            .find("> .ui-icon").toggleClass("ui-icon-triangle-1-e ui-icon-triangle-1-s").end()
            .next().toggleClass("ui-accordion-content-active").slideToggle();
                return false;
            })
        .next()
          .addClass("ui-accordion-content  ui-helper-reset ui-widget-content ui-corner-bottom")
          .hide();
     </script>   
</asp:Content>
