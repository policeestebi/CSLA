<%@ Page Title="" Language="C#" MasterPageFile="~/msp.EstiloBasico/mspContenido.Master"
    AutoEventWireup="true" CodeBehind="frw_grf_topActividades.aspx.cs" Inherits="CSLA.web.App_pages.mod.Estadistico.frw_grf_topActividades" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="act" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="tituloPagina" runat="server">
    &nbsp;Actividades Top por Proyecto
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cuerpoPagina" runat="server">
    <asp:ScriptManager ID="scr_Man" runat="server">
    </asp:ScriptManager>
    <table id="tbl_Principal">
        <tr>
            <%-- Contenido de agregado Arriba--%>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <%-- Espacio--%>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <%-- GridView o Mantenimiento--%>
                <table id="Table1">
                    <tr align="right">
                        <td>
                            <asp:Label ID="lbl_titulo" runat="server" />
                        </td>
                    </tr>
                </table>
                <table id="Table2">
                    <tr align="right">
                        <td>
                            <asp:Label ID="lbl_proyecto" runat="server" Text="Proyecto: "></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_proyecto" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <table id="Table3">
                    <tr align="left">
                        <td>
                            <asp:Label ID="lbl_fechaInicio" runat="server" Text="Fecha Inicio: "></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_fechaInicio" runat="server"></asp:TextBox>
                            <asp:ImageButton ID="img_cldFechaInicio" runat="server" ImageUrl="../../App_Themes/Basico/botones/img_calendario.png"
                                CausesValidation="false" />
                            <act:CalendarExtender ID="dt_fechaInicio" runat="server" TargetControlID="txt_fechaInicio"
                                PopupButtonID="img_cldFechaInicio" Format="MMMM d, yyyy" />
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfv_fechaInicio" runat="server" ControlToValidate="txt_fechaInicio"
                                ToolTip="Ingrese la fecha inicio de la actividad" ErrorMessage="Fecha inicio es requerida"><img alt="imagen" width="25px" height="20px" src="../../App_Themes/Basico/botones/img_warning.gif" border="none"/></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr align="left">
                        <td>
                            <asp:Label ID="lbl_fechaFin" runat="server" Text="Fecha Fin: "></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_fechaFin" runat="server"></asp:TextBox>
                            <asp:ImageButton ID="img_cldFechaFinal" runat="server" ImageUrl="../../App_Themes/Basico/botones/img_calendario.png"
                                CausesValidation="false" />
                            <act:CalendarExtender ID="dt_fechaFin" runat="server" TargetControlID="txt_fechaFin"
                                PopupButtonID="img_cldFechaFinal" Format="MMMM d, yyyy" />
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="rfv_fechaFin" runat="server" ControlToValidate="txt_fechaFin"
                                ToolTip="Ingrese la fecha fin de la actividad" ErrorMessage="Fecha fin es requerida"><img alt="imagen" width="25px" height="20px" src="../../App_Themes/Basico/botones/img_warning.gif" border="none"/></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <table id="Table4">
                    <tr align="right">
                        <td>
                            <asp:Button ID="btn_generar" CausesValidation="false" OnClick="Generar_Click"
                                runat="server" Text="Generar" />
                        </td>
                    </tr>
                </table>
                <asp:Chart ID="Grafico" runat="server" Height="408px" Width="752px"
                    OnInit="Grafico_Init">
                    <Titles>
                        <asp:Title ShadowOffset="3" Name="Title1" />
                    </Titles>
                    <Legends>
                        <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Leyendas"
                              LegendStyle="Row" />
                    </Legends>
                    <Series>
                        <asp:Series Name="Leyendas"/>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="AreaGrafico" BorderWidth="0" />
                    </ChartAreas>
                </asp:Chart>
            </td>
        </tr>
    </table>
</asp:Content>
