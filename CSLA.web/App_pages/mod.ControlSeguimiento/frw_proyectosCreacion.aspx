<%@ Page Title="" Language="C#" MasterPageFile="~/msp.EstiloBasico/mspContenido.Master"
    AutoEventWireup="true" CodeBehind="frw_proyectosCreacion.aspx.cs" Inherits="CSLA.web.App_pages.mod.ControlSeguimiento.frw_proyectosCreacion" %>

<%@ Register Assembly="COSEVI.web.controls" Namespace="COSEVI.web.controls" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="act" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="tituloPagina" runat="server">
    Creación de Proyectos
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
                    <act:AccordionPane ID="acp_creacionProyectos" runat="server">
                        <Header>
                            <a href="" style="color: #FFFFFF; font-size: 12px;">Creaci&oacute;n de Proyectos</a>
                        </Header>
                        <Content>
                            <div class="left">
                                <table id="tbl_Proyecto" width="10px">
                                    <tr align="left">
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                        <td align="left">
                                            <asp:Label ID="lbl_proyecto" runat="server" Text="Proyecto: "></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txt_proyecto" runat="server" Width="100px" Enabled="false">
                                            </asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <%--Contenido Agregado Abajo --%>
                            <%--Define the wizard properties--%>
                            <asp:Wizard ID="wiz_creacion" runat="server" ActiveStepIndex="0" BackColor="#FFFBD6"
                                BorderColor="#FFDFAD" Width="80%" SideBarStyle-BorderWidth="50" DisplaySideBar="false"
                                SideBarStyle-BorderStyle="None" SideBarStyle-HorizontalAlign="Left" SideBarButtonStyle-Font-Size="Small"
                                SideBarButtonStyle-Font-Bold="true" HeaderStyle-BackColor="Black" SideBarStyle-Width="100px"
                                SideBarStyle-BackColor="AliceBlue" SideBarStyle-BorderColor="Black" OnFinishButtonClick="wiz_creacion_FinishButtonClick"
                                OnActiveStepChanged="OnActiveStepChanged" CancelButtonText="Cancelar" FinishCompleteButtonText="Finalizar"
                                StartNextButtonText="Siguiente" StepNextButtonText="Siguiente" StepPreviousButtonText="Atrás">
                                <WizardSteps>
                                    <asp:WizardStep ID="wzs_inicio" runat="server" Title="Inicio" StepType="Auto">
                                        <div class="centrado">
                                            <table id="tblInicio" style="display: block;" class="advertencia">
                                                <br />
                                                <br />
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblAdvertencia" CssClass="label" runat="server" Text="Wizard de Creación de Proyectos"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Image ID="img_creacion" AlternateText="imgCreacionProyecto" runat="server" ImageUrl="~/App_Themes/Basico/imagenes/iconos/img_proyecto.png" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblAdvertenciaContenido" runat="server" Text="El siguiente Wizard le permitirá la creación de un Proyecto. En los siguientes pasos deberá realizar la asignación de los entregables, componentes, paquetes y actividades que compondrán el proyecto."></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <br />
                                        </div>
                                    </asp:WizardStep>
                                    <asp:WizardStep ID="wzs_entregables" runat="server" Title="Entregables" StepType="Step">
                                        <div class="centrado">
                                            <table id="tblMensajeEntregables" style="display: block;" class="advertencia">
                                                <br />
                                                <br />
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblEntregablesTitulo" CssClass="label" runat="server" Text="Agregar Entregables"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblEntregablesMensaje" runat="server" Text="Seleccione los entragables desplagados a las derecha y agreguélos por medio de los botones a la lista de la izquierda."></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <br />
                                        </div>
                                        <div class="center">
                                            <table id="tbl_asignacionEntregables">
                                                <tr align="left">
                                                    <td>
                                                        <asp:Label ID="lbl_entregables" runat="server" Text="Entregables Asociados: "></asp:Label>
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lbl_listaEntregables" runat="server" Text="Entregables: "></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:ListBox ID="lbx_entasociados" runat="server" SelectionMode="Multiple" Width="200px"
                                                            Height="150px"></asp:ListBox>
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btn_asignarEntregable" runat="server" Text="&lt;" OnClick="btn_asignarEntregable_Click"
                                                            Width="35px" colspan="2" />
                                                        <br />
                                                        <asp:Button ID="btn_removerEntregable" runat="server" Text="&gt;" OnClick="btn_removerEntregable_Click"
                                                            Width="35px" colspan="2" />
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:ListBox ID="lbx_entregables" runat="server" SelectionMode="Multiple" Width="200px"
                                                            Height="150px"></asp:ListBox>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <br />
                                        </div>
                                    </asp:WizardStep>
                                    <asp:WizardStep ID="wzs_componentes" runat="server" Title="Componentes" StepType="Step">
                                        <div class="centrado">
                                            <table id="tblMensajeComponentes" style="display: block;" class="advertencia">
                                                <br />
                                                <br />
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_componentesTitulo" CssClass="label" runat="server" Text="Agregar Componentes"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_componentesMensaje" runat="server" Text="La primera lista contiene los entregables seleccionados en el paso anterior, seleccione alguno de estos y se desplegaran los componentes que pueden ser agregados por medio de los botones."></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <br />
                                        </div>
                                        <div class="center">
                                            <table id="tbl_componentes">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblEntregables" runat="server" Text="Entregables Asignados"></asp:Label>
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblComponentesAsignados" runat="server" Text="Componentes Asignados"></asp:Label>
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                    </td>
                                                    &nbsp;
                                                    <td>
                                                        <asp:Label ID="lblComponentes" runat="server" Text="Componentes"></asp:Label>
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:ListBox ID="lbx_entregablesasociados" runat="server" SelectionMode="Multiple"
                                                            Width="200px" Height="150px" OnSelectedIndexChanged="lbx_entregables_SelectedIndexChanged"
                                                            AutoPostBack="true"></asp:ListBox>
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:ListBox ID="lbx_compasociados" runat="server" SelectionMode="Multiple" Width="200px"
                                                            Height="150px"></asp:ListBox>
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btn_asignarComponente" runat="server" Text="&lt;" OnClick="btn_asignarComponente_Click"
                                                            Width="35px" colspan="2" />
                                                        <br />
                                                        <asp:Button ID="btn_removerComponente" runat="server" Text="&gt;" OnClick="btn_removerComponente_Click"
                                                            Width="35px" colspan="2" />
                                                    </td>
                                                    &nbsp;
                                                    <td>
                                                        <asp:ListBox ID="lbx_componentes" runat="server" SelectionMode="Multiple" Width="200px"
                                                            Height="150px"></asp:ListBox>
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <br />
                                        </div>
                                    </asp:WizardStep>
                                    <asp:WizardStep ID="wzs_paquetes" runat="server" Title="Paquetes" StepType="Step">
                                        <div class="centrado">
                                            <table id="tbl_mensajePaquetes" style="display: block;" class="advertencia">
                                                <br />
                                                <br />
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_PaqueteTitulo" CssClass="label" runat="server" Text="Agregar Paquetes"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_PaqueteMensaje" runat="server" Text="La primera lista contiene los componentes seleccionados en el paso anterior, seleccione alguno de estos y se desplegaran los paquetes que pueden ser agregados por medio de los botones."></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <br />
                                        </div>
                                        <div class="center">
                                            <table id="tbl_paquetes">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblComponentesAsociados" runat="server" Text="Componentes Asociados"></asp:Label>
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblPaquetesAsociados" runat="server" Text="Paquetes Asociados"></asp:Label>
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                    </td>
                                                    &nbsp;
                                                    <td>
                                                        <asp:Label ID="lblPaquetes" runat="server" Text="Paquetes"></asp:Label>
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:ListBox ID="lbx_componentesasociados" runat="server" SelectionMode="Multiple"
                                                            Width="200px" Height="150px" OnSelectedIndexChanged="lbx_componentes_SelectedIndexChanged"
                                                            AutoPostBack="true"></asp:ListBox>
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:ListBox ID="lbx_paqasociados" runat="server" SelectionMode="Multiple" Width="200px"
                                                            Height="150px"></asp:ListBox>
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btn_asignarPaquete" runat="server" Text="&lt;" OnClick="btn_asignarPaquete_Click"
                                                            Width="35px" colspan="2" />
                                                        <br />
                                                        <asp:Button ID="btn_removerPaquete" runat="server" Text="&gt;" OnClick="btn_removerPaquete_Click"
                                                            Width="35px" colspan="2" />
                                                    </td>
                                                    &nbsp;
                                                    <td>
                                                        <asp:ListBox ID="lbx_paquetes" runat="server" SelectionMode="Multiple" Width="200px"
                                                            Height="150px"></asp:ListBox>
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <br />
                                        </div>
                                    </asp:WizardStep>
                                    <asp:WizardStep ID="wzs_actividades" runat="server" Title="Actividades" StepType="Step">
                                        <div class="centrado">
                                            <table id="tbl_mensajeActividades" style="display: block;" class="advertencia">
                                                <br />
                                                <br />
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_tituloActividades" CssClass="label" runat="server" Text="Agregar Actividades"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_actividadesMensaje" runat="server" Text="La primera lista contiene los paquetes seleccionados en el paso anterior, seleccione alguno de estos y se desplegaran las actividades que pueden ser agregados por medio de los botones."></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <br />
                                        </div>
                                        <div class="center">
                                            <table id="Table1">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblPaquetesAsignados" runat="server" Text="Paquetes Asignados"></asp:Label>
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblActividadesAsignadas" runat="server" Text="Actividades Asignadas"></asp:Label>
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                    </td>
                                                    &nbsp;
                                                    <td>
                                                        <asp:Label ID="lblActividades" runat="server" Text="Actividades"></asp:Label>
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:ListBox ID="lbx_paquetesasociados" runat="server" SelectionMode="Multiple" Width="200px"
                                                            Height="150px" OnSelectedIndexChanged="lbx_paquetes_SelectedIndexChanged" AutoPostBack="true">
                                                        </asp:ListBox>
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:ListBox ID="lbx_actasociadas" runat="server" SelectionMode="Multiple" Width="200px"
                                                            Height="150px"></asp:ListBox>
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btn_asignarActividad" runat="server" Text="&lt;" OnClick="btn_asignarActividad_Click"
                                                            Width="35px" colspan="2" />
                                                        <br />
                                                        <asp:Button ID="btn_removerActividad" runat="server" Text="&gt;" OnClick="btn_removerActividad_Click"
                                                            Width="35px" colspan="2" />
                                                    </td>
                                                    &nbsp;
                                                    <td>
                                                        <asp:ListBox ID="lbx_actividades" runat="server" SelectionMode="Multiple" Width="200px"
                                                            Height="150px"></asp:ListBox>
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <br />
                                        </div>
                                    </asp:WizardStep>
                                    <asp:WizardStep ID="wzs_finalizacion" runat="server" Title="Finalización" StepType="Finish">
                                        <div class="centrado">
                                            <table id="tbl_mensajeFinalizacion" style="display: block;" class="advertencia">
                                                <br />
                                                <br />
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_tituloFinalizacion" CssClass="label" runat="server" Text="Finalización del Wizard"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_finalizacionMensaje" runat="server" Text="Finalización del Wizard de Creación de Proyecto, al dar click en el botón de Finalizar, se modificará el proyecto según el desglose realizado en los pasos anteriores."></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <br />
                                        </div>
                                    </asp:WizardStep>
                                </WizardSteps>
                                <StartNavigationTemplate>
                                    <table cellpadding="3" cellspacing="3">
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancelar" CausesValidation="false"
                                                    OnClientClick="return confirm('Seguro que desea cancelar la creación del proyecto?');"
                                                    OnClick="btnCancel_Click" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btnNext" runat="server" Text="Siguiente >>" CausesValidation="true"
                                                    CommandName="MoveNext" OnCommand="btnNext_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </StartNavigationTemplate>
                                <StepNavigationTemplate>
                                    <table cellpadding="3" cellspacing="3">
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancelar" CausesValidation="false"
                                                    OnClientClick="return confirm('Seguro que desea cancelar la creación del proyecto?');"
                                                    OnClick="btnCancel_Click" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btnPrevious" runat="server" Text="<< Anterior" CausesValidation="false"
                                                    CommandName="MovePrevious" OnInit="btnPrev_Click" />
                                                <asp:Button ID="btnNext" runat="server" Text="Siguiente >>" CausesValidation="true"
                                                    CommandName="MoveNext" OnInit="btnNext_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </StepNavigationTemplate>
                                <FinishNavigationTemplate>
                                    <table cellpadding="3" cellspacing="3">
                                        <tr>
                                            <td>
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancelar" CausesValidation="false"
                                                    OnClientClick="return confirm('Seguro que desea cancelar la creación del proyecto?');"
                                                    OnClick="btnCancel_Click" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btnFinish" runat="server" Text="Finalizar" CausesValidation="true"
                                                    CommandName="MoveComplete" />
                                            </td>
                                        </tr>
                                    </table>
                                </FinishNavigationTemplate>
                            </asp:Wizard>
                        </Content>
                    </act:AccordionPane>
                </Panes>
            </act:Accordion>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
