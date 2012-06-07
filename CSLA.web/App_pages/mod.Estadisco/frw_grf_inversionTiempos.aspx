<%@ Page Title="" Language="C#" MasterPageFile="~/msp.EstiloBasico/mspContenido.Master" AutoEventWireup="true" CodeBehind="frw_grf_inversionTiempos.aspx.cs" Inherits="CSLA.web.App_pages.mod.Estadistico.frw_grf_inversionTiempos" %>

<%@ Register assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="tituloPagina" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cuerpoPagina" runat="server">

<asp:ScriptManager ID="srm_principal" runat="server"></asp:ScriptManager>

  <asp:Chart ID="chtCategoriesProductCount" runat="server" Width="550" Height="350"> 
   <Series> 
      <asp:Series Name="Categories" ChartType="Bar" Palette="Chocolate" ChartArea="MainChartArea"></asp:Series> 
   </Series> 
    
   <ChartAreas> 
      <asp:ChartArea Name="MainChartArea" Area3DStyle-Enable3D="true"> 
      </asp:ChartArea> 
   </ChartAreas> 
</asp:Chart> 

</asp:Content>
