<%@ Page Title="" Language="C#" MasterPageFile="~/msp.EstiloBasico/mspContenido.Master" AutoEventWireup="true" CodeBehind="frw_permisosMant1.aspx.cs" Inherits="CSLA.web.App_pages.mod.Administracion.frw_permisosMant" %>
<%@ Import Namespace="CSLA.web.App_Constantes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="tituloPagina" runat="server">
    Mantenimiento de Permisos
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cuerpoPagina" runat="server">

    <script type="text/javascript" language="javascript">

        function generarGuardarPermiso() 
        {
            permiso = document.getElementById("<%=hdf_codigo.ClientID %>").value;
            permisoNombre = urlencode(document.getElementById("<%=txt_nombre.ClientID %>").value);
            modo = document.getElementById("<%=hdf_modo.ClientID %>").value;
            
            url = "/App_pages/mod.Administracion/frw_permisosMant.aspx";
            params = "permiso=" + permiso + "&" + "pN=" + permisoNombre + "&" + "modo=" + modo;

            loadPage(url, params);
        }



    </script>

    <form id="frm_principal" action="/App_pages/mod.Administracion/frw_principal.aspx" runat="server">
        <asp:ScriptManager ID="srp_man" runat="server" EnablePartialRendering="true"/>
         <asp:UpdatePanel ID="upd_panel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
            <ContentTemplate>
                <table id="tbl_mantPermisos">
                                <tr>
                                    <%-- Contenido de agregado Arriba--%>
                                </tr>
                                <tr>
                                    <td>
                                        <%-- GridView o Mantenimiento--%>
                                        <table id="tbl_mantenimiento">
                                            <tr align="left">
                                                <td>
                                                    <asp:HiddenField ID="hdf_codigo" runat="server" />
                                                    <asp:HiddenField ID="hdf_modo" runat="server" />
                                                    <asp:Label ID="lbl_nombre" runat="server" Text="Nombre: "></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txt_nombre" runat="server"></asp:TextBox>       
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfv_nombre" runat="server" ControlToValidate="txt_nombre"
                                                        ToolTip="Ingrese el nombre del permiso" ErrorMessage="Nombre es requerido"><img alt="imagen" src="../../App_Themes/Basico/botones/img_alerta.png" border="none"/></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <%--Contenido Agregado Abajo --%>
                                        <table id="tbl_botones" align="right">
                                            <tr align="right">
                                                <td>
                                                    <input type="button" id="btn_guardar"  value="Guardar" onclick="return generarGuardarPermiso();"/>
                                                </td>
                                                <td>
                                                    <input type="button" id="btn_cancelar"  value="Regresar" onclick="return loadPage('/App_pages/mod.Administracion/frw_permisosLista.aspx','');"/>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
            </ContentTemplate>
         </asp:UpdatePanel>
    </form>
</asp:Content>
