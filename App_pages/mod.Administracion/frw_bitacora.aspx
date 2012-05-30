<%@ Page Title="" Language="C#" MasterPageFile="~/msp.EstiloBasico/mspContenido.Master"
    AutoEventWireup="true" CodeBehind="frw_bitacora.aspx.cs" Inherits="CSLA.web.App_pages.mod.Administracion.frw_bitacora" %>

<%@ Register Assembly="COSEVI.web.controls" Namespace="COSEVI.web.controls" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="act" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="tituloPagina" runat="server">
    Lista de Registros
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cuerpoPagina" runat="server">
    <asp:ScriptManager ID="scr_Man" runat="server">
     
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upd_Principal" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
        <ContentTemplate>
            <act:accordion id="ard_principal" runat="server" selectedindex="0" fadetransitions="false"
                framespersecond="40" transitionduration="250" autosize="None" requireopenedpane="false"
                suppressheaderpostbacks="true" headercssclass="encabezadoAcordeon" contentcssclass="contenidoAcordeon"
                headerselectedcssclass="encabezadoSeleccionadoAcordeon">
                <Panes>
                    <act:AccordionPane ID="acp_listadoDatos" runat="server">
                        <Header>
                            <a href="" style="color: #FFFFFF; font-size: 12px;">Listado de Registros</a>
                        </Header>
                        <Content>
            <table id="tbl_contenido">
                <tr>
                    <%-- Contenido de agregado Arriba--%>
                </tr>
                <tr>
                    <td>
                        <%-- Búsqueda--%>
                        &nbsp; &nbsp; &nbsp;
                        <cc1:ucSearch ID="ucSearchBitacora" runat="server" OnSearchClick="ucSearchBitacora_searchClick" />
                        <asp:Button ID="btn_agregar" runat="server" Visible="false" CausesValidation="false" />
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
                        <%-- GridView--%>
                        <asp:GridView ID="grd_listaBitacora" AllowPaging="True" runat="server" AutoGenerateColumns="False"
                            Width="100%" CssClass="Grid" CellSpacing="1" CellPadding="3" OnPageIndexChanging="grd_listaBitacora_PageIndexChanging">
                            <PagerSettings PageButtonCount="20" />
                            <Columns>
                                <asp:BoundField DataField="pPK_bitacora" HeaderText="Bitacora" SortExpression="pPK_bitacora" />
                                <asp:BoundField DataField="pFK_departamento" HeaderText="Departamento" SortExpression="pFK_departamento" />
                                <asp:BoundField DataField="pFK_usuario" HeaderText="Usuario" SortExpression="pFK_usuario" />
                                <asp:BoundField DataField="pAccion" HeaderText="Accion" SortExpression="pAccion" />
                                <asp:BoundField DataField="pFechaAccion" HeaderText="Fecha" SortExpression="pFechaAccion" />
                                <asp:BoundField DataField="pNumeroRegistro" HeaderText="NumeroRegistro" SortExpression="pNumeroRegistro" />
                                <asp:BoundField DataField="pTabla" HeaderText="Tabla" SortExpression="pTabla" />
                                <asp:BoundField DataField="pMaquina" HeaderText="Maquina" SortExpression="pMaquina" />
                            </Columns>
                            <HeaderStyle CssClass="GridHeader"></HeaderStyle>
                            <AlternatingRowStyle CssClass="GridAltItem" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--Contenido Agregado Abajo --%>
                        <table id="tbl_agregado" align="right">
                            <tr align="right">
                                <td>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </Content>
        </act:AccordionPane>
                        </Panes>
            </act:accordion>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>