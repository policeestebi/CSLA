<%@ Page Title="" Language="C#" MasterPageFile="~/msp.EstiloBasico/mspContenido.Master"
    AutoEventWireup="true" CodeBehind="frw_asignacionActividad.aspx.cs" Inherits="CSLA.web.App_pages.mod.ControlSeguimiento.frw_asignacionActividad" %>

<%@ Register Assembly="COSEVI.web.controls" Namespace="COSEVI.web.controls" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="act" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="tituloPagina" runat="server">
    Asignación de Actividades
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cuerpoPagina" runat="server">
    <asp:ScriptManager ID="scr_Man" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upd_Principal" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
        <ContentTemplate>
            <act:Accordion ID="ard_principal" runat="server" SelectedIndex="0" FadeTransitions="false"
                FramesPerSecond="40" TransitionDuration="250" AutoSize="None" RequireOpenedPane="false"
                SuppressHeaderPostbacks="true" HeaderCssClass="encabezadoAcordeon" ContentCssClass="contenidoAcordeon"
                HeaderSelectedCssClass="encabezadoSeleccionadoAcordeon">
                <Panes>
                    <act:AccordionPane ID="acp_edicionDatos" runat="server">
                        <Header>
                            <a href="" style="color: #FFFFFF; font-size: 12px;">Asignaci&oacute;n de Actividades</a>
                        </Header>
                        <Content>
                            <table id="Table1">
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
                                        <table id="tbl_mantenimiento">
                                            <tr align="left">
                                                <td>
                                                    <asp:Label ID="lbl_proyecto" runat="server" Text="Proyecto: "></asp:Label>
                                                
                                                    <asp:TextBox ID="txt_proyecto" runat="server" ReadOnly="true"></asp:TextBox>
                                                </td>
                                            
                                                <td>
                                                    <asp:Label ID="lbl_paquete" runat="server" Text="Paquete: "></asp:Label>
                                                    
                                                    <asp:DropDownList ID="ddl_paquete" runat="server" OnSelectedIndexChanged="ddlPaquete_SelectedIndexChanged" AutoPostBack = "true" OnDataBound="ddlPaquete_DataBound">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr align="left">
                                                <td>
                                                    <asp:Label ID="lbl_actividades" runat="server" Text="Actividades: "></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:ListBox ID="lbx_actividades" runat="server" SelectionMode="Single" Width="200px" Height="150px" AutoPostBack = "true" OnSelectedIndexChanged="lbx_actividades_SelectedIndexChanged"> 
                                                    </asp:ListBox>                                                
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_usuariosAsociados" runat="server" Text="Asociados: "></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:ListBox ID="lbx_usuariosAsociados" runat="server" SelectionMode="Single" Width="200px" Height="150px" AutoPostBack = "true">
                                                    </asp:ListBox>                                                
                                                </td>
                                                <td>
                                                        <asp:Button ID="btn_asignarUsuario" runat="server" Text="&lt;" OnClick="btn_asignarUsuario_Click" Width="35px" colspan="2"/>
                                                        <br />
                                                        <asp:Button ID="btn_removerUsuario" runat="server" Text="&gt;" OnClick="btn_removerUsuario_Click" Width="35px" colspan="2"/>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_usuarios" runat="server" Text="Usuarios: "></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:ListBox ID="lbx_usuarios" runat="server" SelectionMode="Single" Width="200px" Height="150px" AutoPostBack = "true">
                                                    </asp:ListBox>                                                
                                                </td>
                                            </tr>
                                            <tr align="left">
                                                <td>
                                                    <asp:Label ID="lbl_descripcion" runat="server" Text="Descripcion: "></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txt_descripcion" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfv_descripcion" runat="server" ControlToValidate="txt_descripcion"
                                                        ToolTip="Ingrese la descripcion de la actividad" ErrorMessage="Descripcion es requerida"><img alt="imagen" width="25px" height="20px" src="../../App_Themes/Basico/botones/img_warning.gif" border="none"/></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr align="left">
                                                <td>
                                                    <asp:Label ID="lbl_fechaInicio" runat="server" Text="Fecha Inicio: "></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txt_fechaInicio" runat="server"></asp:TextBox>
                                                    <act:CalendarExtender  ID="dt_fechaInicio" runat="server" TargetControlID="txt_fechaInicio" Format="MMMM d, yyyy" />
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
                                                    <act:CalendarExtender  ID="dt_fechaFin" runat="server" TargetControlID="txt_fechaFin" Format="MMMM d, yyyy" />
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="rfv_fechaFin" runat="server" ControlToValidate="txt_fechaFin"
                                                        ToolTip="Ingrese la fecha fin de la actividad" ErrorMessage="Fecha fin es requerida"><img alt="imagen" width="25px" height="20px" src="../../App_Themes/Basico/botones/img_warning.gif" border="none"/></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr align="left">
                                                    <td>
                                                        <asp:Label ID="lbl_horasAsignadas" runat="server" Text="Horas Asignadas: "></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txt_horasAsignadas" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_horasAsignadas" runat="server" ControlToValidate="txt_horasAsignadas"
                                                            ToolTip="Ingrese la cantidad de horas asignadas para el proyecto" ErrorMessage="Horas asignadas son requeridas"><img alt="imagen" width="25px" height="20px" src="../../App_Themes/Basico/botones/img_warning.gif" border="none"/></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="rfv_horasAsignadaslenght" runat="server" ErrorMessage="Número decimal fuera del rango establecido." 
                                                            ValidationExpression="^[0-9]{1,3}(\,[0-9]{0,2})?$" ControlToValidate="txt_horasAsignadas" Display="Dynamic"></asp:RegularExpressionValidator>                                                
                                                    </td>
                                                </tr>
                                                <tr align="left">
                                                    <td>
                                                        <asp:Label ID="lbl_horasAsigDefectos" runat="server" Text="Horas Asig. Defec: "></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txt_horasAsigDefectos" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_horasAsignadasDefectos" runat="server" ControlToValidate="txt_horasAsigDefectos"
                                                            ToolTip="Ingrese la cantidad de horas asignadas en defectos para el proyecto"
                                                            ErrorMessage="Horas asignadas en defectos son requeridas"><img alt="imagen" width="25px" height="20px" src="../../App_Themes/Basico/botones/img_warning.gif" border="none"/></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="rfv_horasAsignadasDefectoslenght" runat="server" ErrorMessage="Número decimal fuera del rango establecido." 
                                                            ValidationExpression="^[0-9]{1,3}(\,[0-9]{0,2})?$" ControlToValidate="txt_horasAsigDefectos" Display="Dynamic"></asp:RegularExpressionValidator>                                                
                                                    </td>
                                                </tr>
                                                <tr align="left">
                                                    <td>
                                                        <asp:Label ID="lbl_horasReales" runat="server" Text="Horas Reales: "></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txt_horasReales" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_horasReales" runat="server" ControlToValidate="txt_horasReales"
                                                            ToolTip="Ingrese la cantidad de horas realis para el proyecto"
                                                            ErrorMessage="Horas reales son requeridas"><img alt="imagen" width="25px" height="20px" src="../../App_Themes/Basico/botones/img_warning.gif" border="none"/></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="rfv_horasRealeslenght" runat="server" ErrorMessage="Número decimal fuera del rango establecido." 
                                                            ValidationExpression="^[0-9]{1,3}(\,[0-9]{0,2})?$" ControlToValidate="txt_horasReales" Display="Dynamic"></asp:RegularExpressionValidator>                                                
                                                    </td>
                                                </tr>
                                                <tr align="left">
                                                    <td>
                                                        <asp:Label ID="lbl_horasRealesDef" runat="server" Text="Horas Reales Def: "></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txt_horasRealesDef" runat="server"></asp:TextBox>
                                                    </td>
                                                                                                        <td>
                                                        <asp:RequiredFieldValidator ID="rfv_horasRealesDef" runat="server" ControlToValidate="txt_horasRealesDef"
                                                            ToolTip="Ingrese la cantidad de horas reales en defectos para el proyecto"
                                                            ErrorMessage="Horas reales son requeridas"><img alt="imagen" width="25px" height="20px" src="../../App_Themes/Basico/botones/img_warning.gif" border="none"/></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="rfv_horasRealesDeflenght" runat="server" ErrorMessage="Número decimal fuera del rango establecido." 
                                                            ValidationExpression="^[0-9]{1,3}(\,[0-9]{0,2})?$" ControlToValidate="txt_horasRealesDef" Display="Dynamic"></asp:RegularExpressionValidator>                                                
                                                    </td>
                                                </tr>   
                                            <tr align="left">
                                                <td>
                                                    <asp:Label ID="lbl_estado" runat="server" Text="Estado: "></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddl_estado" runat="server" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>                                            
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="center">
                                            <%--Contenido Agregado Abajo --%>
                                            <table id="Table2">
                                                <tr align="right">
                                                    <%--<td>
                                                        <asp:Button ID="btn_eliminar" runat="server" OnClick="btn_eliminar_Click" Text="Eliminar" />
                                                    </td>--%>
                                                    <td>
                                                        <asp:Button ID="btn_regresar" CausesValidation="false" OnClick="btn_regresar_Click"
                                                            runat="server" Text="Regresar" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btn_guardar" runat="server" OnClick="btn_guardar_Click" Text="Guardar" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </Content>
                    </act:AccordionPane>
                </Panes>
            </act:Accordion>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
