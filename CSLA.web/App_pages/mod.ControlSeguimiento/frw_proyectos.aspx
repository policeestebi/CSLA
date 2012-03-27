<%@ Page Title="" Language="C#" MasterPageFile="~/msp.EstiloBasico/mspContenido.Master"
    AutoEventWireup="true" CodeBehind="frw_proyectos.aspx.cs" Inherits="CSLA.web.App_pages.mod.ControlSeguimiento.frw_proyectos" %>

<%@ Register Assembly="COSEVI.web.controls" Namespace="COSEVI.web.controls" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="act" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="tituloPagina" runat="server">
    Lista de Proyectos
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
                    <act:AccordionPane ID="acp_listadoDatos" runat="server">
                        <Header>
                            <a href="" style="color: #FFFFFF; font-size: 12px;">Listado de Proyectos</a>
                        </Header>
                        <Content>
                            <table id="tbl_contenido">
                                <tr>
                                    <%-- Contenido de agregado Arriba--%>
                                </tr>
                                <tr>
                                    <td>
                                        <%-- Búsqueda--%>
                                        <cc1:ucSearch ID="ucSearchProyecto" runat="server" OnSearchClick="ucSearchProyecto_searchClick" />
                                        <asp:Button ID="btn_agregar" runat="server" Text="Agregar" OnClick="btn_agregar_Click"
                                            CausesValidation="false" />
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
                                        <asp:GridView ID="grd_listaProyecto" AllowPaging="True" runat="server" AutoGenerateColumns="False"
                                            Width="100%" CssClass="Grid" CellSpacing="1" CellPadding="3" OnRowCommand="grd_listaProyecto_RowCommand"
                                            OnPageIndexChanging="grd_listaProyecto_PageIndexChanging">
                                            <PagerSettings PageButtonCount="20" />
                                            <Columns>
                                                <asp:BoundField DataField="pPK_proyecto" HeaderText="Actividad" SortExpression="pPK_proyecto" />
                                                <asp:BoundField DataField="pNombre" HeaderText="Nombre" SortExpression="pNombre" />
                                                <asp:BoundField DataField="pDescripcion" HeaderText="Descripcion" SortExpression="pDescripcion" />
                                                <asp:BoundField DataField="pObjetivo" HeaderText="Objetivo" SortExpression="pObjetivo" />
                                                <asp:BoundField DataField="pMeta" HeaderText="Meta" SortExpression="pMeta" />
                                                <asp:BoundField DataField="pFechaInicio" HeaderText="FechaInicio" SortExpression="pFechaInicio" />
                                                <asp:BoundField DataField="pFechaFin" HeaderText="FechaFin" SortExpression="pFechaFin" />
                                                <asp:BoundField DataField="pHorasAsignadas" HeaderText="HorasAsignadas" SortExpression="pHorasAsignadas" />
                                                <asp:BoundField DataField="pHorasAsigDefectos" HeaderText="HA.Defectos" SortExpression="pHorasAsigDefectos" />
                                                <asp:BoundField DataField="pHorasReales" HeaderText="HorasReales" SortExpression="pHorasReales" />
                                                <asp:BoundField DataField="pHorasRealesDefectos" HeaderText="HR.Defectos" SortExpression="pHorasRealesDefectos" />
                                                <asp:BoundField DataField="pDescripcionEstado" HeaderText="Nombre" SortExpression="pDescripcionEstado" />
                                                <asp:BoundField DataField="pFK_estado" HeaderText="Estado" SortExpression="pFK_estado"
                                                    Visible="false" ShowHeader="false"  />
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton runat="server" ID="btn_ver" CommandName="Ver" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                                            CausesValidation="false" ImageUrl="~/App_Themes/Basico/Botones/img_ver.gif" />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="1px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton runat="server" ID="btn_editar" CommandName="Editar" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                                            CausesValidation="false" ImageUrl="~/App_Themes/Basico/Botones/img_editar.gif" />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="1px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton runat="server" ID="btn_eliminar" CommandName="Eliminar" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                                            CausesValidation="false" ImageUrl="~/App_Themes/Basico/botones/img_eliminar.gif"
                                                            OnClientClick="return confirm('¿Está seguro que desea eliminar este registro?');" />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="1px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton runat="server" ID="btn_crear" CommandName="Crear" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
                                                            CausesValidation="false" ImageUrl="~/App_Themes/Basico/Botones/img_ver.gif" />
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
                        </Content>
                    </act:AccordionPane>
                    <act:AccordionPane ID="acp_edicionDatos" runat="server">
                        <Header>
                            <a href="" style="color: #FFFFFF; font-size: 12px;">Edici&oacute;n de Proyectos</a>
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
                                                <tr align="left">
                                                    <td>
                                                        <asp:Label ID="lbl_estado" runat="server" Text="Estado: "></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddl_estado" runat="server" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr align="left">
                                                    <td>
                                                        <asp:Label ID="lbl_nombre" runat="server" Text="Nombre: "></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txt_nombre" runat="server" Height="15px" Width="150px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_nombre" runat="server" ControlToValidate="txt_nombre"
                                                            ToolTip="Ingrese el nombre del proyecto" ErrorMessage="Nombre es requerido"><img alt="imagen" width="25px" height="20px" src="../../App_Themes/Basico/botones/img_warning.gif" border="none"/></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="rfv_nombrelenght" runat="server" ErrorMessage="La longitud máxima son 100 caracteres." 
                                                            ValidationExpression="^([\S\s]{0,100})$" ControlToValidate="txt_nombre" Display="Dynamic"></asp:RegularExpressionValidator>                                                                                                           
                                                    </td>
                                                </tr>
                                                <tr align="left">
                                                    <td>
                                                        <asp:Label ID="lbl_descripcion" runat="server" Text="Descripcion: "></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txt_descripcion" runat="server" Height="15px" Width="150px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_descripcion" runat="server" ControlToValidate="txt_descripcion"
                                                            ToolTip="Ingrese la descripcion del proyecto" ErrorMessage="Descripcion es requerida"><img alt="imagen" width="25px" height="20px" src="../../App_Themes/Basico/botones/img_warning.gif" border="none"/></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="rfv_descripcionlenght" runat="server" ErrorMessage="La longitud máxima son 100 caracteres." 
                                                            ValidationExpression="^([\S\s]{0,100})$" ControlToValidate="txt_descripcion" Display="Dynamic"></asp:RegularExpressionValidator>                                                
                                                    </td>
                                                </tr>
                                                <tr align="left">
                                                    <td>
                                                        <asp:Label ID="lbl_objetivo" runat="server" Text="Objetivo: "></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txt_objetivo" runat="server" Height="15px" Width="450px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_objetivo" runat="server" ControlToValidate="txt_objetivo"
                                                            ToolTip="Ingrese el objetivo del proyecto" ErrorMessage="Objetivo es requerido"><img alt="imagen" width="25px" height="20px" src="../../App_Themes/Basico/botones/img_warning.gif" border="none"/></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="rfv_objetivolenght" runat="server" ErrorMessage="La longitud máxima son 500 caracteres." 
                                                            ValidationExpression="^([\S\s]{0,500})$" ControlToValidate="txt_objetivo" Display="Dynamic"></asp:RegularExpressionValidator>                                                
                                                    </td>
                                                </tr>
                                                <tr align="left">
                                                    <td>
                                                        <asp:Label ID="lbl_meta" runat="server" Text="Meta: "></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txt_meta" runat="server" Height="15px" Width="450px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:RequiredFieldValidator ID="rfv_meta" runat="server" ControlToValidate="txt_meta"
                                                            ToolTip="Ingrese la meta del proyecto" ErrorMessage="Meta es requerida"><img alt="imagen" width="25px" height="20px" src="../../App_Themes/Basico/botones/img_warning.gif" border="none"/></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="rfv_metalenght" runat="server" ErrorMessage="La longitud máxima son 500 caracteres." 
                                                            ValidationExpression="^([\S\s]{0,500})$" ControlToValidate="txt_objetivo" Display="Dynamic"></asp:RegularExpressionValidator>                                                
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
                                                            ValidationExpression="^[0-9]{1,3}(\.[0-9]{0,2})?$" ControlToValidate="txt_horasAsignadas" Display="Dynamic"></asp:RegularExpressionValidator>                                                
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
                                                            ValidationExpression="^[0-9]{1,3}(\.[0-9]{0,2})?$" ControlToValidate="txt_horasAsigDefectos" Display="Dynamic"></asp:RegularExpressionValidator>                                                
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
                                                            ValidationExpression="^[0-9]{1,3}(\.[0-9]{0,2})?$" ControlToValidate="txt_horasReales" Display="Dynamic"></asp:RegularExpressionValidator>                                                
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
                                                            ValidationExpression="^[0-9]{1,3}(\.[0-9]{0,2})?$" ControlToValidate="txt_horasRealesDef" Display="Dynamic"></asp:RegularExpressionValidator>                                                
                                                    </td>
                                                </tr>                                         
                                                <tr align="left">

                                                    <td>
                                                        <asp:Label ID="Label1" runat="server" Text="Departamentos: "></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:ListBox ID="lbx_depasociados" runat="server" SelectionMode="Multiple" Width="300px" Height="50px">
                                                        </asp:ListBox>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btn_asignarDepto" runat="server" Text="&lt;" OnClick="btn_asignarDepto_Click" Width="35px" colspan="2"/>
                                                        <br />
                                                        <br />
                                                        <asp:Button ID="btn_removerDepto" runat="server" Text="&gt;" OnClick="btn_removerDepto_Click" Width="35px" colspan="2"/>
                                                    </td>
                                                    <td align="left">
                                                        <asp:ListBox ID="lbx_departamentos" runat="server" SelectionMode="Multiple" Width="300px" Height="50px">
                                                        </asp:ListBox>
                                                    </td>
                                                </tr>       


                                          </tr>
                                    </table>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="center">
                                            <%--Contenido Agregado Abajo --%>
                                            <table id="Table2">
                                                <tr align="right">
                                                    <td>
                                                        <asp:Button ID="btn_cancelar" CausesValidation="false" OnClick="btn_cancelar_Click"
                                                            runat="server" Text="Cancelar" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btn_guardar" runat="server" OnClick="btn_guardar_Click" Text="Guardar" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>                                 
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
