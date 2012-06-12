<%@ Page Title="" Language="C#" MasterPageFile="~/msp.EstiloBasico/mspContenido.Master"
    AutoEventWireup="true" CodeBehind="frw_grf_inversionTiempos.aspx.cs" Inherits="CSLA.web.App_pages.mod.Estadistico.frw_grf_inversionTiempos" %>

<%@ Register Assembly="System.Web.DataVisualization" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="act" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="tituloPagina" runat="server">
    &nbsp;Distribución de Tiempos por Proyecto
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
                            <asp:DropDownList ID="ddl_proyecto" runat="server" OnSelectedIndexChanged="ddlProyecto_SelectedIndexChanged"
                                AutoPostBack="true">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <asp:Chart ID="Grafico" runat="server" Height="393px" Width="540px"  OnClick="Grafico_Click"
                    oninit="Grafico_Init">
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
