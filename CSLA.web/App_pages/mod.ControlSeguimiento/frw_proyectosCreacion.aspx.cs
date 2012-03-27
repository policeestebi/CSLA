using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using COSEVI.CSLA.lib.accesoDatos.App_InterfaceComunes;
using ExceptionManagement.Exceptions;
using COSEVI.CSLA.lib.entidades.mod.ControlSeguimiento;
using COSEVI.CSLA.lib.accesoDatos.mod.ControlSeguimiento;

using CSLA.web.App_Variables;
using CSLA.web.App_Constantes;
using System.Data;
using COSEVI.CSLA.lib.entidades.mod.Administracion;


// =========================================================================
// COSEVI - Consejo de Seguridad Vial. - 2011
// Sistema CSLA (Sistema para el Control y Seguimiento de Labores)
//
// frw_permiso.aspx.cs
//
// Explicación de los contenidos del archivo.
// =========================================================================
// Historial
// PERSONA 			           MES – DIA - AÑO		DESCRIPCIÓN
// Esteban Ramírez Gónzalez  	03 – 06  - 2011	 	Se crea la clase
// Cristian Arce Jiménez  	    27 – 11  - 2011	 	Se agrega el manejo de excepciones personalizadas
// Cristian Arce Jiménez  	    23 – 01  - 2012	 	Se agrega el manejo de filtros
// 
//								
//								
//
// =========================================================================

namespace CSLA.web.App_pages.mod.ControlSeguimiento
{
    public partial class frw_proyectosCreacion : System.Web.UI.Page
    {

        #region enumerados

        public enum WizardNavigationTempContainer
        {
            StartNavigationTemplateContainerID = 1,
            StepNavigationTemplateContainerID = 2,
            FinishNavigationTemplateContainerID = 3
        }

        #endregion

        #region Inicialización

        /// <summary>
        /// Función que se ejecuta al cargar
        /// la página
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    this.llenarDatosInicio();
                }
                catch (Exception po_exception)
                {
                    String vs_error_usuario = "Error al inicializar la creación de proyectos.";
                    this.lanzarExcepcion(po_exception, vs_error_usuario);
                } 
            }

            Button btn = wzs_entregables.FindControl("StartNavigationTemplateContainerID").FindControl("btnNext") as Button;
            if (btn != null)
            {
                btn.OnClientClick = "return confirm('Are you sure you want to move away from the beginning?')";
                //btn.OnClientClick = inicializarControles();
            }

        }

        /// <summary>
        /// Función que se ejecuta al inicializar la página.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {

            base.OnInit(e);
            if (!this.DesignMode)
            {
                this.inicializarControles();
            }

        }

        /// <summary>
        /// Método que inicializa los controles 
        ///que se encuentra dentro de los acordeones
        ///esto porque tienen a perderse cuando 
        ///la página se inicializa.
        /// </summary>
        private void inicializarControles()
        {
            try
            {
                //Inicialización de botones de la asignación
                //Entregables
                this.btn_asignarEntregable = (Button)acp_creacionProyectos.FindControl("btn_asignarEntregable");
                this.btn_removerEntregable = (Button)acp_creacionProyectos.FindControl("btn_removerEntregable");

                //Componentes
                this.btn_asignarComponente = (Button)acp_creacionProyectos.FindControl("btn_asignarComponente");
                this.btn_removerComponente = (Button)acp_creacionProyectos.FindControl("btn_removerComponente");

            }
            catch (Exception po_exception)
            {
                String vs_error_usuario = "Ocurrió un error inicializando los controles del mantenimiento.";
                this.lanzarExcepcion(po_exception, vs_error_usuario);
            } 
        }

        #endregion

        #region Métodos Generales

        /// <summary>
        /// Crea un objeto de tipo
        /// cls_proyecto con la informacón
        /// que se encuentra en el formulario
        /// web
        /// </summary>
        /// <returns>cls_proyecto</returns>
        private cls_proyecto crearObjeto()
        {
            cls_proyecto vo_proyecto = new cls_proyecto();

             return vo_proyecto;
        }

        /// <summary>
        /// Método que carga la información
        /// de un proyecto.
        /// </summary>
        private void cargarObjeto()
        {
            try
            {

            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al cargar el registro.", po_exception);
            }

        }

        /// <summary>
        /// Guarda la información se que se encuentra
        /// en el formulario Web, ya sea
        /// para ingresar o actualizarla
        /// </summary>
        /// <returns>Int valor devuelvo por el motor de bases de datos</returns>
        private int guardarDatos()
        {
            int vi_resultado = 1;
            cls_proyecto vo_proyecto = this.crearObjeto();
            try
            {
                switch (cls_variablesSistema.tipoEstado)
                {
                    case cls_constantes.AGREGAR:
                        //
                        break;
                    case cls_constantes.EDITAR:
                        //
                        break;
                    default:
                        break;
                }
                
                return vi_resultado;
            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al guardar el registro.", po_exception);
            } 
        }

        /// <summary>
        /// Método que lanza la excepción personalizada
        /// </summary>
        /// <param name="po_exception">Excepción a levantar</param>
        /// <param name="ps_mensajeUsuario">Mensaje a comunicar al usuario</param>
        private void lanzarExcepcion(Exception po_exception, String ps_mensajeUsuario)
        {
            try
            {
                String vs_error_usuario = ps_mensajeUsuario;
                vs_error_usuario = vs_error_usuario.Replace(" ", "_");
                vs_error_usuario = vs_error_usuario.Replace("'", "|");

                String vs_error_tecnico = po_exception.Message;
                vs_error_tecnico = vs_error_tecnico.Replace(" ", "_");
                vs_error_tecnico = vs_error_tecnico.Replace("'", "|");

                String vs_script = "window.showModalDialog(\"../../frw_error.aspx?vs_error_usuario=" + vs_error_usuario + "&vs_error_tecnico=" + vs_error_tecnico + "\",\"Ventana\",\"dialogHeight:450px;dialogWidth:625px;center:yes;status:no;menubar:no;resizable:no;scrollbars:yes;toolbar:no;location:no;directories:no\");";
                ScriptManager.RegisterClientScriptBlock(this.upd_Principal, this.upd_Principal.GetType(), "jsKeyScript", vs_script, true);

                throw new GeneralException("GeneralException", po_exception);
            }
            catch (GeneralException po_general_exception)
            {
                ExceptionManagement.ExceptionManager.Publish(po_general_exception);
            }
        }

        private void llenarDatosInicio()
        {

            try
            {
                cargarProyecto();
                cargarListaEntregables();
                CargarEntregablesProyecto();

            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al cargar el registro.", po_exception);
            }

        }

        private void llenarDatosComponentes()
        {
            try
            {
                cargarEntregablesAsociados();
            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al cargar el registro.", po_exception);
            }
        }

        private void cargarProyecto()
        {
            try
            {
                txt_proyecto.Text = cls_variablesSistema.vs_proyecto.pNombre;
            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al cargar los datos del proyecto.", po_exception);
            }
        }

        #endregion Métodos Generales

        #region Eventos Generales

        /// <summary>
        /// Evento que se ejecuta cuando se 
        /// guarda un nuevo proyecto.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.guardarDatos();

                this.upd_Principal.Update();

                this.ard_principal.SelectedIndex = 0;

            }
            catch (Exception po_exception)
            {
                String vs_error_usuario = "Ocurrió un error mientras se guardaba el registro.";
                this.lanzarExcepcion(po_exception, vs_error_usuario);
            } 
        }

        /// <summary>
        /// Evento que se ejecuta cuando se le da
        /// en el botón de cancelar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.upd_Principal.Update();

                this.ard_principal.SelectedIndex = 0;
            }
            catch (Exception po_exception)
            {
                String vs_error_usuario = "Ocurrió un error al cancelar la operación.";
                this.lanzarExcepcion(po_exception, vs_error_usuario);
            } 
        }

        protected void ddlProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.ddl_estado.Text = ((DropDownList)sender).SelectedValue;
        }

        protected void wiz_creacion_FinishButtonClick(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // Do something with the click ...
            Response.Redirect("frw_proyectos.aspx", false);
        }

        private Control GetControlFromWizard(Wizard wizard, WizardNavigationTempContainer wzdTemplate, string controlName)
        {
            System.Text.StringBuilder strCtrl = new System.Text.StringBuilder();
            strCtrl.Append(wzdTemplate);
            strCtrl.Append("$");
            strCtrl.Append(controlName);

            return wizard.FindControl(strCtrl.ToString());
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {

        }

        //protected void OnFinishButtonClick(Object sender, WizardNavigationEventArgs e)
        //{
        //    // The OnFinishButtonClick method is a good place to collect all
        //    // the data from the completed pages and persist it to the data store. 

        //    // For this example, write a confirmation message to the Complete page
        //    // of the Wizard control.
        //    Label tempLabel = (Label)Wizard1.FindControl("CompleteMessageLabel");
        //    if (tempLabel != null)
        //    {
        //        tempLabel.Text = "Your order has been placed. An e-mail confirmation will be sent to "
        //        + (EmailAddress.Text.Length == 0 ? "your e-mail address" : EmailAddress.Text) + ".";
        //    }
        //}

        //protected void OnGoBackButtonClick(object sender, EventArgs e)
        //{
        //    // The GoBackButtonClick event is raised when the GoBackButton
        //    // is clicked on the Finish page of the Wizard.  

        //    // Check the value of Step1's AllowReturn property.
        //    if (Step1.AllowReturn)
        //    {
        //        // Return to Step1.
        //        Wizard1.ActiveStepIndex = Wizard1.WizardSteps.IndexOf(this.Step1);
        //    }
        //    else
        //    {
        //        // Step1 is not a valid step to return to; go to Step2 instead.
        //        Wizard1.ActiveStepIndex = Wizard1.WizardSteps.IndexOf(this.Step2);
        //        Response.Write("ActiveStep is set to Step2 because Step1 has AllowReturn set to false.");
        //    }
        //}

        protected void OnActiveStepChanged(object sender, EventArgs e)
        {
            // If the ActiveStep is changing to Step3, check to see whether the 
            // SeparateShippingCheckBox is selected.  If it is not, skip to the
            // Finish step.
            if (wiz_creacion.ActiveStepIndex == wiz_creacion.WizardSteps.IndexOf(this.wzs_entregables))
            {
                llenarDatosInicio();
            }
            
            if (wiz_creacion.ActiveStepIndex == wiz_creacion.WizardSteps.IndexOf(this.wzs_componentes))
            {
                llenarDatosComponentes();
            }
        }

        #endregion Eventos Generales



        #region Métodos Entregables


        private void cargarListaEntregables()
        {
            DataSet vo_dataSet = new DataSet();

            try
            {
                lbx_entregables.DataSource = cls_gestorEntregable.listarEntregable(); ;
                lbx_entregables.DataTextField = "pNombre";
                lbx_entregables.DataValueField = "pPK_entregable";
                lbx_entregables.DataBind();
            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al cargar los datos de la lista de departamentos del proyecto.", po_exception);
            }

        }

        private void CargarEntregablesProyecto()
        {
            DataSet vo_dataSet = new DataSet();

            try
            {
                if(cls_variablesSistema.vs_proyecto.pProyectoEntregableLista.Count > 0)
                {
                    lbx_entasociados.DataSource = cls_variablesSistema.vs_proyecto.pProyectoEntregableLista;
                    lbx_entasociados.DataTextField = "pNombreEntregable";
                    lbx_entasociados.DataValueField = "pPK_Entregable";
                }
                else
                {
                    vo_dataSet = cls_gestorProyectoEntregable.selectProyectoEntregable(cls_variablesSistema.vs_proyecto);
                    lbx_entasociados.DataSource = vo_dataSet;
                    lbx_entasociados.DataTextField = "nombre";
                    lbx_entasociados.DataValueField = "PK_entregable";
                }

                lbx_entasociados.DataBind();

                if (lbx_entasociados.Items.Count > 0)
                {
                    foreach (ListItem item in lbx_entasociados.Items)
                    {
                        lbx_entregables.Items.Remove(item);
                    }
                }
            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al cargar los entregables asociados al proyecto.", po_exception);
            }
        }

        #endregion Métodos Entregables

        #region Eventos Entregables


        protected void lbx_departamentos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btn_asignarEntregable_Click(object sender, EventArgs e)
        {
            for (int i = lbx_entregables.Items.Count - 1; i >= 0; i--)
            {
                if (lbx_entregables.Items[i].Selected == true)
                {
                    cls_entregable vo_entregable = new cls_entregable();
                    vo_entregable.pPK_entregable = Convert.ToInt32(lbx_entregables.Items[i].Value.ToString());
                    vo_entregable.pNombre = lbx_entregables.Items[i].Text;

                    cls_proyectoEntregable vo_proyectoEntregable = new cls_proyectoEntregable();

                    vo_proyectoEntregable.pEntregable = vo_entregable;

                    if (!(cls_variablesSistema.vs_proyecto.pProyectoEntregableLista.Where(test => test.pPK_Entregable == vo_entregable.pPK_entregable).Count() > 0))
                    {
                        vo_proyectoEntregable.pEntregableList.Add(vo_entregable);
                        cls_variablesSistema.vs_proyecto.pEntregableLista.Add(vo_entregable);
                        cls_variablesSistema.vs_proyecto.pProyectoEntregableLista.Add(vo_proyectoEntregable);
                    }

                    lbx_entasociados.Items.Add(lbx_entregables.Items[i]);
                    ListItem li = lbx_entregables.Items[i];
                    lbx_entregables.Items.Remove(li);

                }
            }
        }

        protected void btn_removerEntregable_Click(object sender, EventArgs e)
        {
            for (int i = lbx_entasociados.Items.Count - 1; i >= 0; i--)
            {
                if (lbx_entasociados.Items[i].Selected == true)
                {

                    cls_entregable vo_entregable = new cls_entregable();
                    vo_entregable.pPK_entregable = Convert.ToInt32(lbx_entasociados.Items[i].Value.ToString());
                    vo_entregable.pNombre = lbx_entasociados.Items[i].Text;

                    cls_proyectoEntregable vo_proyectoEntregable = new cls_proyectoEntregable();

                    vo_proyectoEntregable.pEntregable = vo_entregable;

                    cls_variablesSistema.vs_proyecto.pEntregableLista.RemoveAll(test => test.pPK_entregable == vo_entregable.pPK_entregable);
                    cls_variablesSistema.vs_proyecto.pProyectoEntregableLista.RemoveAll(test => test.pPK_Entregable == vo_entregable.pPK_entregable);

                    lbx_entregables.Items.Add(lbx_entasociados.Items[i]);
                    ListItem li = lbx_entasociados.Items[i];
                    lbx_entasociados.Items.Remove(li);
                }
            }
        }


        #endregion Eventos Entregables



        #region Métodos Componentes

        private void cargarEntregablesAsociados()
        {
            DataSet vo_dataSet = new DataSet();

            try
            {
                lbx_entregablesasociados.DataSource = cls_variablesSistema.vs_proyecto.pProyectoEntregableLista;
                lbx_entregablesasociados.DataTextField = "pNombreEntregable";
                lbx_entregablesasociados.DataValueField = "pPK_entregable";
                lbx_entregablesasociados.DataBind();
            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al cargar los datos de la lista de entregables del proyecto.", po_exception);
            }

        }

        private void cargarListaComponentes()
        {
            DataSet vo_dataSet = new DataSet();

            try
            {
                lbx_componentes.DataSource = cls_gestorComponente.listarComponente();
                lbx_componentes.DataTextField = "pNombre";
                lbx_componentes.DataValueField = "pPK_componente";
                lbx_componentes.DataBind();

                //Se valida dentro de la misma lista de componentes, que si en algunos de los entregables se encuentra asociado, que se encargue de eliminarlo
                //del listbox, para que no llegue a ser tomado en cuenta entre los componentes de algún otro entregable(son únicos por entregable)
                ListBox lbx_pivot = new ListBox();

                lbx_pivot.DataSource = cls_gestorComponente.listarComponente();
                lbx_pivot.DataTextField = "pNombre";
                lbx_pivot.DataValueField = "pPK_componente";
                lbx_pivot.DataBind();

                if (lbx_compasociados.Items.Count > 0)
                {
                    foreach (ListItem item in lbx_compasociados.Items)
                    {
                        lbx_componentes.Items.Remove(item);
                    }
                }

                foreach (ListItem item in lbx_pivot.Items)
                {
                    if (cls_variablesSistema.vs_proyecto.pEntregableComponenteLista.Where(test => test.pPK_Componente.ToString() == item.Value).Count() > 0)
                    {
                        lbx_componentes.Items.Remove(item);
                    }
                }

            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al cargar los datos de la lista de componentes del proyecto.", po_exception);
            }

        }

        private void CargarComponentesEntregable(cls_entregableComponente po_entregableComponente)
        {
            DataSet vo_dataSet = new DataSet();

            try
            {
                if (cls_variablesSistema.vs_proyecto.pEntregableComponenteLista.Where(test => test.pPK_Entregable == po_entregableComponente.pPK_Entregable).Count() > 0)
                {
                    lbx_compasociados.DataSource = cls_variablesSistema.vs_proyecto.pEntregableComponenteLista.Where(test => test.pPK_Entregable == po_entregableComponente.pPK_Entregable);
                    lbx_compasociados.DataTextField = "pNombreComponente";
                    lbx_compasociados.DataValueField = "pPK_Componente";
                }
                else
                {
                    vo_dataSet = cls_gestorEntregableComponente.selectEntregableComponente(po_entregableComponente);
                    lbx_compasociados.DataSource = vo_dataSet;
                    lbx_compasociados.DataTextField = "Nombre";
                    lbx_compasociados.DataValueField = "PK_Entregable";
                }

                //Se realiza el Binding luego de saber de donde se tomarán los datos
                lbx_compasociados.DataBind();

            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al cargar los entregables asociados al proyecto.", po_exception);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void cargarDataSetProyectoEntregable(cls_entregableComponente po_entregableComponente)
        {
            DataSet vo_dataSet = new DataSet();

            try
            {
                vo_dataSet = cls_gestorEntregableComponente.selectEntregableComponente(po_entregableComponente);
                lbx_entasociados.DataSource = vo_dataSet;
                lbx_entasociados.DataTextField = "Nombre";
                lbx_entasociados.DataValueField = "PK_Componente";
                lbx_entasociados.DataBind();

                if (lbx_entasociados.Items.Count > 0)
                {
                    foreach (ListItem item in lbx_entasociados.Items)
                    {
                        lbx_entregables.Items.Remove(item);
                    }
                }
            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al cargar los entregables asociados al proyecto.", po_exception);
            }

        }

        private void CargarComponentesPorEntregable(cls_entregable po_entregable)
        {

            cls_entregableComponente vo_entregableComponente = new cls_entregableComponente();

            vo_entregableComponente.pProyecto = cls_variablesSistema.vs_proyecto;
            vo_entregableComponente.pEntregable = po_entregable;

            CargarComponentesEntregable(vo_entregableComponente);
            cargarListaComponentes();

        }

        #endregion Métodos Componentes

        #region Eventos Componentes

        protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void lbx_entregables_SelectedIndexChanged(object sender, EventArgs e)
        {
            int entregableSeleccionado;
            entregableSeleccionado = Convert.ToInt32(lbx_entregablesasociados.SelectedValue.ToString());

            cls_entregable vo_entregable = new cls_entregable();
            vo_entregable.pPK_entregable = entregableSeleccionado;

            CargarComponentesPorEntregable(vo_entregable);
        }

        protected void btn_asignarComponente_Click(object sender, EventArgs e)
        {
            int entSeleccionado;
            entSeleccionado = Convert.ToInt32(lbx_entregablesasociados.SelectedValue.ToString());

            cls_entregable vo_entregable = new cls_entregable();
            vo_entregable.pPK_entregable = entSeleccionado;

            for (int i = lbx_componentes.Items.Count - 1; i >= 0; i--)
            {
                if (lbx_componentes.Items[i].Selected == true)
                {
                    cls_componente vo_componente = new cls_componente();
                    vo_componente.pPK_componente = Convert.ToInt32(lbx_componentes.Items[i].Value.ToString());
                    vo_componente.pNombre = lbx_componentes.Items[i].Text;

                    cls_entregableComponente vo_entregableComponente = new cls_entregableComponente();

                    vo_entregableComponente.pEntregable = vo_entregable;
                    vo_entregableComponente.pComponente = vo_componente;

                    foreach (cls_proyectoEntregable proyEnt in cls_variablesSistema.vs_proyecto.pProyectoEntregableLista)
                    {
                        if (proyEnt.pEntregableList.Where(test => test.pPK_entregable == vo_entregable.pPK_entregable).Count() > 0)
                        {
                            if (!proyEnt.ComponenteEncontrado(vo_componente))
                            {
                                cls_variablesSistema.vs_proyecto.pEntregableComponenteLista.Add(vo_entregableComponente);
                                proyEnt.pEntregableComponenteList.Add(vo_entregableComponente);
                            }
                        }
                    }

                    lbx_compasociados.Items.Add(lbx_componentes.Items[i]);
                    ListItem li = lbx_componentes.Items[i];
                    lbx_componentes.Items.Remove(li);

                }
            }
        }

        protected void btn_removerComponente_Click(object sender, EventArgs e)
        {
            int entSeleccionado;
            entSeleccionado = Convert.ToInt32(lbx_entregablesasociados.SelectedValue.ToString());

            cls_entregable vo_entregable = new cls_entregable();
            vo_entregable.pPK_entregable = entSeleccionado;

            for (int i = lbx_compasociados.Items.Count - 1; i >= 0; i--)
            {
                if (lbx_compasociados.Items[i].Selected == true)
                {
                    cls_componente vo_componente = new cls_componente();
                    vo_componente.pPK_componente = Convert.ToInt32(lbx_compasociados.Items[i].Value.ToString());
                    vo_componente.pNombre = lbx_compasociados.Items[i].Text;

                    cls_entregableComponente vo_entregableComponente = new cls_entregableComponente();

                    vo_entregableComponente.pEntregable = vo_entregable;
                    vo_entregableComponente.pComponente = vo_componente;

                    foreach (cls_proyectoEntregable proyEnt in cls_variablesSistema.vs_proyecto.pProyectoEntregableLista)
                    {
                        if (proyEnt.pEntregableList.Where(test => test.pPK_entregable == vo_entregable.pPK_entregable).Count() > 0)
                        {
                            if (proyEnt.ComponenteEncontrado(vo_componente))
                            {
                                cls_variablesSistema.vs_proyecto.pEntregableComponenteLista.RemoveAll(test => test.pPK_Componente == vo_componente.pPK_componente);
                                proyEnt.RemoverComponenteEncontrado(vo_componente);
                            }
                        }
                    }

                    lbx_componentes.Items.Add(lbx_compasociados.Items[i]);
                    ListItem li = lbx_compasociados.Items[i];
                    lbx_compasociados.Items.Remove(li);

                }
            }
        }


        #endregion Eventos Componentes

    }
}