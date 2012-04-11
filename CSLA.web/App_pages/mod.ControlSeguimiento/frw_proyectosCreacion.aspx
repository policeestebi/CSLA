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
                                <tr align="left" >
                                    <td></td><td></td><td></td>
                                    <td align="left">
                                        <asp:Label ID="lbl_proyecto" runat="server" Text="Proyecto: "></asp:Label>
                                    </td>
                                    <td  align="left" >
                                        <asp:TextBox ID="txt_proyecto" runat="server" Width="100px" Enabled="false">
                                        </asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>

                        <%--Contenido Agregado Abajo --%>
                            <%--Define the wizard properties--%>
                            <asp:Wizard  ID="wiz_creacion" runat="server" ActiveStepIndex="0" BackColor="#FFFBD6" BorderColor="#FFDFAD" Width="80%"
                                    SideBarStyle-BorderWidth="50" DisplaySideBar="false" SideBarStyle-BorderStyle="None" SideBarStyle-HorizontalAlign="Left"
                                SideBarButtonStyle-Font-Size="Small" SideBarButtonStyle-Font-Bold="true"  HeaderStyle-BackColor="Black" SideBarStyle-Width="100px"
                                SideBarStyle-BackColor="AliceBlue" SideBarStyle-BorderColor="Black" OnFinishButtonClick="wiz_creacion_FinishButtonClick" OnActiveStepChanged="OnActiveStepChanged">
                            <%--In this WizardSteps we define how many wizard step we are going to use--%>
                                <WizardSteps>
                                    <asp:WizardStep ID="wzs_entregables" runat="server" Title="Entregables" StepType="Step">
                                        <%--<div class="left">
                                            <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label1" runat="server" Text="Entregables: "></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        </div>--%>
                                        <br />
                                        <br />
                                        <div class="center">
                                            <table id="tbl_asignacionEntregables">
                                                <tr align="left">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label3" runat="server" Text="Entregables: "></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <td align="left">
                                                        <asp:ListBox ID="lbx_entasociados" runat="server" SelectionMode="Multiple" Width="200px" Height="150px">
                                                        </asp:ListBox>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btn_asignarEntregable" runat="server" Text="&lt;" OnClick="btn_asignarEntregable_Click" Width="35px" colspan="2"/>
                                                        <br />
                                                        <br />
                                                        <asp:Button ID="btn_removerEntregable" runat="server" Text="&gt;" OnClick="btn_removerEntregable_Click" Width="35px" colspan="2"/>
                                                    </td>
                                                    <td align="left">
                                                        <asp:ListBox ID="lbx_entregables" runat="server" SelectionMode="Multiple" Width="200px" Height="150px">
                                                        </asp:ListBox>
                                                    </td>
                                                </tr>  
                                           </table>
                                        </div>
                                    </asp:WizardStep>    
                                                              
                                    <asp:WizardStep ID="wzs_componentes" runat="server" Title="Componentes" StepType="Step">
                                        <div class="left">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label2" runat="server" Text="Entregables: "></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <br />
                                        <br />
                                        <div class="center">
                                            <table id="Table1">
                                                <tr align="left">
                                                    <td>
                                                        <asp:ListBox ID="lbx_entregablesasociados" runat="server" SelectionMode="Multiple" Width="200px" Height="150px" OnSelectedIndexChanged="lbx_entregables_SelectedIndexChanged" AutoPostBack="true">
                                                        </asp:ListBox>
                                                    </td>
                                                    <td align="left">
                                                        <asp:ListBox ID="lbx_compasociados" runat="server" SelectionMode="Multiple" Width="200px" Height="150px">
                                                        </asp:ListBox>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btn_asignarComponente" runat="server" Text="&lt;" OnClick="btn_asignarComponente_Click" Width="35px" colspan="2"/>
                                                        <br />
                                                        <br />
                                                        <asp:Button ID="btn_removerComponente" runat="server" Text="&gt;" OnClick="btn_removerComponente_Click" Width="35px" colspan="2"/>
                                                    </td>
                                                    <td align="left">
                                                        <asp:ListBox ID="lbx_componentes" runat="server" SelectionMode="Multiple" Width="200px" Height="150px">
                                                        </asp:ListBox>
                                                    </td>
                                                </tr>  
                                           </table>
                                        </div>
                                    </asp:WizardStep>   
                                              
                                    <asp:WizardStep ID="wzs_paquetes" runat="server" Title="Paquetes" StepType="Step">
                                        <div class="left">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_paquetes" runat="server" Text="Paquetes: "></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <br />
                                        <br />
                                        <div class="center">
                                            <table id="tbl_paquetes">
                                                <tr align="left">
                                                    <td>
                                                        <asp:ListBox ID="lbx_componentesasociados" runat="server" SelectionMode="Multiple" Width="200px" Height="150px" OnSelectedIndexChanged="lbx_componentes_SelectedIndexChanged" AutoPostBack="true">
                                                        </asp:ListBox>
                                                    </td>
                                                    <td align="left">
                                                        <asp:ListBox ID="lbx_paqasociados" runat="server" SelectionMode="Multiple" Width="200px" Height="150px">
                                                        </asp:ListBox>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btn_asignarPaquete" runat="server" Text="&lt;" OnClick="btn_asignarPaquete_Click" Width="35px" colspan="2"/>
                                                        <br />
                                                        <br />
                                                        <asp:Button ID="btn_removerPaquete" runat="server" Text="&gt;" OnClick="btn_removerPaquete_Click" Width="35px" colspan="2"/>
                                                    </td>
                                                    <td align="left">
                                                        <asp:ListBox ID="lbx_paquetes" runat="server" SelectionMode="Multiple" Width="200px" Height="150px">
                                                        </asp:ListBox>
                                                    </td>
                                                </tr>  
                                           </table>
                                        </div>
                                    </asp:WizardStep>      

                                    <asp:WizardStep ID="wzs_actividades" runat="server" Title="Actividades" StepType="Step">
                                        <div class="left">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_actividades" runat="server" Text="Actividades: "></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <br />
                                        <br />
                                        <div class="center">
                                            <table id="tbl_actividades">
                                                <tr align="left">
                                                    <td>
                                                        <asp:ListBox ID="lbx_paquetesasociados" runat="server" SelectionMode="Multiple" Width="200px" Height="150px" OnSelectedIndexChanged="lbx_paquetes_SelectedIndexChanged" AutoPostBack="true">
                                                        </asp:ListBox>
                                                    </td>
                                                    <td align="left">
                                                        <asp:ListBox ID="lbx_actasociadas" runat="server" SelectionMode="Multiple" Width="200px" Height="150px">
                                                        </asp:ListBox>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btn_asignarActividad" runat="server" Text="&lt;" OnClick="btn_asignarActividad_Click" Width="35px" colspan="2"/>
                                                        <br />
                                                        <br />
                                                        <asp:Button ID="btn_removerActividad" runat="server" Text="&gt;" OnClick="btn_removerActividad_Click" Width="35px" colspan="2"/>
                                                    </td>
                                                    <td align="left">
                                                        <asp:ListBox ID="lbx_actividades" runat="server" SelectionMode="Multiple" Width="200px" Height="150px">
                                                        </asp:ListBox>
                                                    </td>
                                                </tr>  
                                           </table>
                                        </div>
                                    </asp:WizardStep>  

                                    <asp:WizardStep ID="wzs_finalizacion" runat="server" Title="Finalización" StepType="Finish">
                                        <div class="left">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lbl_finalizacion" runat="server" Text="Finalizacion del Wizard "></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <br />
                                        <br />
                                    </asp:WizardStep>  

                                </WizardSteps>
                                <StartNavigationTemplate>
                                     <table cellpadding="3" cellspacing="3">
                                         <tr>
                                             <td>
                                                 <asp:Button ID="btnCancel" runat="server" Text="Cancel"
                                                     CausesValidation="false" 
                                                     OnClientClick="return confirm('Seguro que desea cancelar la creación del proyecto?');" 
                                                     OnClick="btnCancel_Click" 
                                                  />
                                             </td>
                                             <td>
                                                 <asp:Button ID="btnNext" runat="server" Text="Next >>"
                                                     CausesValidation="true" 
                                                     CommandName="MoveNext" OnCommand="btnNext_Click"
                                                  />
                                             </td>
                                         </tr>
                                     </table>
                                 </StartNavigationTemplate>
                                 <StepNavigationTemplate>
                                     <table cellpadding="3" cellspacing="3">
                                         <tr>
                                             <td>
                                                 <asp:Button ID="btnCancel" runat="server" Text="Cancel"
                                                     CausesValidation="false" 
                                                     OnClientClick="return confirm('Seguro que desea cancelar la creación del proyecto?');" 
                                                     OnClick="btnCancel_Click" 
                                                  />
                                             </td>
                                             <td>
                                                 <asp:Button ID="btnPrevious" runat="server" Text="<< Prev"
                                                     CausesValidation="false" 
                                                     CommandName="MovePrevious" OnInit="btnPrev_Click"
                                                  />
                                                  <asp:Button ID="btnNext" runat="server" Text="Next >>"
                                                     CausesValidation="true" 
                                                     CommandName="MoveNext" OnInit="btnNext_Click"
                                                  />
                                             </td>
                                         </tr>
                                     </table>
                                 </StepNavigationTemplate>
                                 <FinishNavigationTemplate>
                                     <table cellpadding="3" cellspacing="3">
                                         <tr>
                                             <td>
                                                 <asp:Button ID="btnCancel" runat="server" Text="Cancel"
                                                     CausesValidation="false" 
                                                     OnClientClick="return confirm('Seguro que desea cancelar la creación del proyecto?');" 
                                                     OnClick="btnCancel_Click" 
                                                  />
                                             </td>
                                             <td>
                                                  <asp:Button ID="btnFinish" runat="server" Text="Finish"
                                                     CausesValidation="true" 
                                                     CommandName="MoveComplete" 
                                                  />
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
