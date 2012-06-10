<%@ Page Title="" Language="C#" MasterPageFile="~/msp.EstiloBasico/mspContenido.Master"
    AutoEventWireup="true" CodeBehind="frw_grf_inversionTiempos.aspx.cs" Inherits="CSLA.web.App_pages.mod.Estadistico.frw_grf_inversionTiempos" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="tituloPagina" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cuerpoPagina" runat="server">
    <asp:ScriptManager ID="srm_principal" runat="server">
    </asp:ScriptManager>
    <table id="Table1">
        <tr align="right">
            <td>
                <asp:Label ID="lbl_titulo" runat="server" Text="Distribución de Tiempos por Proyecto" />
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
                    AutoPostBack="true" OnDataBound="ddlProyecto_DataBound">
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <asp:Chart ID="Chart1" runat="server" Height="300px" Width="400px">
        <Titles>
            <asp:Title ShadowOffset="3" Name="Title1" />
        </Titles>
        <Legends>
            <asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default"
                LegendStyle="Row" />
        </Legends>
        <Series>
            <asp:Series Name="Default" />
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1" BorderWidth="0" />
        </ChartAreas>
    </asp:Chart>
    <table id="Table3">
        <tr align="right">
            <td>
                <asp:Button ID="btn_regresar" CausesValidation="false" OnClick="btn_regresar_Click"
                    runat="server" Text="Regresar" />
            </td>
        </tr>
    </table>
</asp:Content>
