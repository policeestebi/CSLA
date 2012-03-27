<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frw_permisosLista1.aspx.cs"
    Inherits="CSLA.web.App_pages.mod.Administracion.frw_permisosLista1" %>

<%@ Import Namespace="CSLA.web.App_Constantes" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="Stylesheet" type="text/css" href="../../App_Themes/Basico/css/pages_style.css"
        media="screen" />
    <title>Permisos</title>
</head>
<body id="bod_listado" style="margin: 0px;">
    <div>
        <div class="post">
            <div class="post_title">
                <h1 class="left">
                    Lista de Permisos
                </h1>
                <div class="clearer">
                    &ndsp;</div>
            </div>
            <div class="post_body" align="center">
                <form id="Form1" action="/App_pages/mod.Administracion/frw_permisosLista1.aspx" runat="server">
                <asp:ScriptManager ID="srp_man" runat="server" EnablePartialRendering="true" OnAsyncPostBackError="srp_man_AsyncPostBackError" />
                <asp:UpdatePanel ID="upd_panel" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                    <ContentTemplate>
                        <script type="text/javascript" language="javascript">

                            function prueba() {

                                grid = document.getElementById("ctl00_cuerpoPagina_grd_listaPermisos");

                                if (grid != null) {
                                    alert("Lo encontró.");
                                }
                                else {
                                    alert("No existe");
                                }

                            }

                        </script>
                        <table id="tbl_contenido">
                            <tr>
                                <%-- Contenido de agregado Arriba--%>
                            </tr>
                            <tr>
                                <td>
                                    <%-- Búsqueda--%>
                                    <asp:Label ID="lbl_buscar" runat="server" Text="Búsqueda: "></asp:Label>
                                    &nbsp;
                                    <asp:TextBox ID="txt_buscar" runat="server"></asp:TextBox>
                                    &nbsp;
                                    <asp:DropDownList ID="ddl_filtro" runat="server" AutoPostBack="True">
                                        <asp:ListItem Value="PK_permiso">Permiso</asp:ListItem>
                                        <asp:ListItem Value="nombre">Nombre</asp:ListItem>
                                    </asp:DropDownList>
                                    &nbsp;
                                    <asp:Button ID="btn_buscar" runat="server" Text="Buscar" OnClick="btn_buscar_Click"
                                        CausesValidation="false" />
                                    &nbsp; &nbsp; &nbsp;
                                    <asp:Button ID="btn_agregar" runat="server" Text="Agregar" OnClientClick='<%# this.devolverFuncion("/App_pages/mod.Administracion/frw_permisosMant.aspx","HOLA",cls_constantes.AGREGAR) %>'
                                        CausesValidation="false" />
                                    <input type="button" onclick="return prueba();" value="Prueba" id="hola" />
                                    <input type="text" id="esteban" />
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
                                    <asp:GridView ID="grd_listaPermisos" AllowPaging="True" runat="server" AutoGenerateColumns="False"
                                        Width="100%" CssClass="Grid" CellSpacing="1" CellPadding="3" OnRowCommand="grd_listaPermisos_RowCommand"
                                        OnPageIndexChanging="grd_listaPermisos_PageIndexChanging" AllowSorting="True"
                                        OnSorting="grd_listaPermisos_Sorting" EnableModelValidation="True">
                                        <PagerSettings PageButtonCount="20" />
                                        <Columns>
                                            <asp:BoundField DataField="pPK_permiso" HeaderText="Permiso" SortExpression="pPK_permiso" />
                                            <asp:BoundField DataField="pNombre" HeaderText="Nombre" SortExpression="pNombre" />
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton runat="server" ID="btn_ver" CommandName="Ver" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                                        CausesValidation="false" ImageUrl="~/App_Themes/Basico/Botones/img_ver.gif" OnClientClick='<%# this.devolverFuncion("/App_pages/mod.Administracion/frw_permisosMant.aspx",Eval("pPK_permiso").ToString(),cls_constantes.VER) %>' />
                                                </ItemTemplate>
                                                <ItemStyle Width="1px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton runat="server" ID="btn_editar" CommandName="Editar" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                                        ImageUrl="~/App_Themes/Basico/Botones/img_editar.gif" OnClientClick='<%# this.devolverFuncion("/App_pages/mod.Administracion/frw_permisosMant.aspx",Eval("pPK_permiso").ToString(),cls_constantes.EDITAR) %>' />
                                                </ItemTemplate>
                                                <ItemStyle Width="1px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton runat="server" ID="btn_eliminar" CommandName="Eliminar" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                                        CausesValidation="false" ImageUrl="~/App_Themes/Basico/botones/img_eliminar.gif"
                                                        OnClientClick='<%# this.devolverFuncion("/App_pages/mod.Administracion/frw_permisosLista.aspx",Eval("pPK_permiso").ToString(),cls_constantes.ELIMINAR) %>' />
                                                </ItemTemplate>
                                                <ItemStyle Width="1px" />
                                            </asp:TemplateField>
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
                    </ContentTemplate>
                </asp:UpdatePanel>
                </form>
                <div class="post_metadata">
                    <div class="content">
                        <div class="clearer">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--  </form>--%>
</body>
</html>
