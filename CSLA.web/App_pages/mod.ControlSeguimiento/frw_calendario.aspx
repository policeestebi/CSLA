<%@ Page Title="" Language="C#" MasterPageFile="~/msp.EstiloBasico/mspContenido.Master"
    AutoEventWireup="true" CodeBehind="frw_calendario.aspx.cs" Inherits="CSLA.web.App_pages.mod.ControlSeguimiento.frm_calendario" %>

<%@ Register Assembly="COSEVI.web.controls" Namespace="COSEVI.web.controls" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="act" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<script type="text/javascript" >

    $(document).ready(function () {
        $(".calendarLink").fancybox({
            'width': '100%',
            'height': '100%',
            'autoScale': false,
            'transitionIn': 'none',
            'transitionOut': 'none',
            'type': 'iframe',
            'closeBtn': true
        });
    });

</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="tituloPagina" runat="server">
Calendario de Actividades
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cuerpoPagina" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="calendarContainer">
        <cc1:ucCalendar runat="server" 
            ID="calendario" Css="calendar" 
            CssHeader="calendarHeader" 
            CssDays="days"
            CssCalendarRow="calendarRow" 
            CssLink = "calendarLink"
            UrlLink = "frw_registroTiempos.aspx"
            UrlSiguiente="/App_Themes/Basico/imagenes/iconos/img_siguiente.png"
            UrlAnterior="/App_Themes/Basico/imagenes/iconos/img_anterior.png"
            UrlBotonCalendario="/App_Themes/Basico/botones/img_calendario.png" 
            OnvoCambioFecha="Unnamed1_voCambioFecha" />
    </div>
</asp:Content>
