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
        #region Variables

        //Inicialización de botones de la navegación
        Button btnNxt;
        Button btnPrev;

        #endregion Variables

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
                    this.deshabilitarBotonesNavegacion();
                }
                catch (Exception po_exception)
                {
                    String vs_error_usuario = "Error al inicializar la creación de proyectos.";
                    this.lanzarExcepcion(po_exception, vs_error_usuario);
                } 
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

                //Paquetes
                this.btn_asignarPaquete = (Button)acp_creacionProyectos.FindControl("btn_asignarPaquete");
                this.btn_removerPaquete = (Button)acp_creacionProyectos.FindControl("btn_removerPaquete");

                //Actividad
                this.btn_asignarActividad = (Button)acp_creacionProyectos.FindControl("btn_asignarActividad");
                this.btn_removerActividad = (Button)acp_creacionProyectos.FindControl("btn_removerActividad");

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

        private List<cls_proyectoEntregable> crearProyectoEntregableMemoria()
        {
            List<cls_proyectoEntregable> vo_proyectoEntregable = new List<cls_proyectoEntregable>();

            vo_proyectoEntregable = cls_variablesSistema.vs_proyecto.pProyectoEntregableListaMemoria;

            return vo_proyectoEntregable;
        }

        private List<cls_entregableComponente> crearEntregableComponenteMemoria()
        {
            List<cls_entregableComponente> vo_entregableComponente = new List<cls_entregableComponente>();

            vo_entregableComponente = cls_variablesSistema.vs_proyecto.pEntregableComponenteListaMemoria;

            return vo_entregableComponente;
        }

        private List<cls_componentePaquete> crearComponentePaqueteMemoria()
        {
            List<cls_componentePaquete> vo_componentePaquete = new List<cls_componentePaquete>();

            vo_componentePaquete = cls_variablesSistema.vs_proyecto.pComponentePaqueteListaMemoria;

            return vo_componentePaquete;
        }

        private List<cls_paqueteActividad> crearPaqueteActividadMemoria()
        {
            List<cls_paqueteActividad> vo_paqueteActividad = new List<cls_paqueteActividad>();

            vo_paqueteActividad = cls_variablesSistema.vs_proyecto.pPaqueteActividadListaMemoria;

            return vo_paqueteActividad;
        }


        private List<cls_proyectoEntregable> crearProyectoEntregableBaseDatos()
        {
            List<cls_proyectoEntregable> vo_proyectoEntregable = new List<cls_proyectoEntregable>();

            vo_proyectoEntregable = cls_variablesSistema.vs_proyecto.pProyectoEntregableListaBaseDatos;

            return vo_proyectoEntregable;
        }

        private List<cls_entregableComponente> crearEntregableComponenteBaseDatos()
        {
            List<cls_entregableComponente> vo_entregableComponente = new List<cls_entregableComponente>();

            vo_entregableComponente = cls_variablesSistema.vs_proyecto.pEntregableComponenteListaBaseDatos;

            return vo_entregableComponente;
        }

        private List<cls_componentePaquete> crearComponentePaqueteBaseDatos()
        {
            List<cls_componentePaquete> vo_componentePaquete = new List<cls_componentePaquete>();

            vo_componentePaquete = cls_variablesSistema.vs_proyecto.pComponentePaqueteListaBaseDatos;

            return vo_componentePaquete;
        }

        private List<cls_paqueteActividad> crearPaqueteActividadBaseDatos()
        {
            List<cls_paqueteActividad> vo_paqueteActividad = new List<cls_paqueteActividad>();

            vo_paqueteActividad = cls_variablesSistema.vs_proyecto.pPaqueteActividadListaBaseDatos;

            return vo_paqueteActividad;
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
            
            //Se obtiene la llave primaria de proyecto, es decir, PK_proyecto, de la variables del sistema, para luego sólo enviarla por parámetro en los guardar
            int llaveProyecto = cls_variablesSistema.vs_proyecto.pPK_proyecto;  

            //De momento se va a agregar, por defecto
            //cls_variablesSistema.tipoEstado = cls_constantes.AGREGAR;

            try
            {
                switch (cls_variablesSistema.tipoEstado)
                {
                    case cls_constantes.AGREGAR:

                        agregarProyectoEntregable(llaveProyecto);
                        agregarEntregableComponente(llaveProyecto);
                        agregarComponentePaquete(llaveProyecto);
                        agregarPaqueteActividad(llaveProyecto);

                        break;
                    case cls_constantes.EDITAR:

                        editarProyectoEntregable(llaveProyecto);
                        editarEntregableComponente(llaveProyecto);
                        editarComponentePaquete(llaveProyecto);
                        editarPaqueteActividad(llaveProyecto);

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


        private int agregarProyectoEntregable(int ps_llaveProyecto)
        {
            int vi_resultado = 1;

            List<cls_proyectoEntregable> vl_proyectoEntregable = this.crearProyectoEntregableMemoria();

            try
            {
                //Para cada proyecto entregable, se realiza la inserción
                foreach (cls_proyectoEntregable vo_proyectoEntregable in vl_proyectoEntregable)
                {
                    vo_proyectoEntregable.pProyecto.pPK_proyecto = ps_llaveProyecto;
                    vi_resultado = cls_gestorProyectoEntregable.insertProyectoEntregable(vo_proyectoEntregable);
                }

                return vi_resultado;
            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al guardar los entregables del proyecto.", po_exception);
            }
        }

        private int agregarEntregableComponente(int ps_llaveProyecto)
        {
            int vi_resultado = 1;

            List<cls_entregableComponente> vl_entregableComponente = this.crearEntregableComponenteMemoria();

            try
            {
                //Para cada entregable componente, se realiza la inserción
                foreach (cls_entregableComponente vo_entregableComponente in vl_entregableComponente)
                {
                    vo_entregableComponente.pProyecto.pPK_proyecto = ps_llaveProyecto;
                    vi_resultado = cls_gestorEntregableComponente.insertEntregableComponente(vo_entregableComponente);
                }

                return vi_resultado;
            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al guardar los entregables del proyecto.", po_exception);
            }
        }

        private int agregarComponentePaquete(int ps_llaveProyecto)
        {
            int vi_resultado = 1;

            List<cls_componentePaquete> vl_componentePaquete = this.crearComponentePaqueteMemoria();

            try
            {
                //Para cada componente paquete, se realiza la inserción
                foreach (cls_componentePaquete vo_componentePaquete in vl_componentePaquete)
                {
                    vo_componentePaquete.pProyecto.pPK_proyecto = ps_llaveProyecto;
                    vi_resultado = cls_gestorComponentePaquete.insertComponentePaquete(vo_componentePaquete);
                }

                return vi_resultado;
            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al guardar los paquetes del proyecto.", po_exception);
            }
        }

        private int agregarPaqueteActividad(int ps_llaveProyecto)
        {
            int vi_resultado = 1;

            List<cls_paqueteActividad> vl_paqueteActividad = this.crearPaqueteActividadMemoria();

            try
            {
                //Para cada paquete actividad, se realiza la inserción
                foreach (cls_paqueteActividad vo_paqueteActividad in vl_paqueteActividad)
                {
                    vo_paqueteActividad.pProyecto.pPK_proyecto = ps_llaveProyecto;
                    vi_resultado = cls_gestorPaqueteActividad.insertPaqueteActividad(vo_paqueteActividad);
                }

                return vi_resultado;
            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al guardar los paquetes del proyecto.", po_exception);
            }
        }


        private int editarProyectoEntregable(int ps_llaveProyecto)
        {
            int vi_resultado = 1;

            List<cls_proyectoEntregable> vl_proyectoEntregableMemoria = this.crearProyectoEntregableMemoria();
            List<cls_proyectoEntregable> vl_proyectoEntregableBaseDatos = this.crearProyectoEntregableBaseDatos();

            try
            {
                //Para cada proyecto entregable, se realiza la inserción
                foreach (cls_proyectoEntregable vo_proyectoEntregable in vl_proyectoEntregableMemoria)
                {
                    if (!(vl_proyectoEntregableBaseDatos.Where(dep => dep.pPK_Entregable == vo_proyectoEntregable.pPK_Entregable).Count() > 0))
                    {
                        vo_proyectoEntregable.pProyecto.pPK_proyecto = ps_llaveProyecto;
                        vi_resultado = cls_gestorProyectoEntregable.updateProyectEntregable(vo_proyectoEntregable, 1);
                    }
                }

                //Para cada proyecto entregable, se realiza la inserción
                foreach (cls_proyectoEntregable vo_proyectoEntregable in vl_proyectoEntregableBaseDatos)
                {
                    if (!(vl_proyectoEntregableMemoria.Where(dep => dep.pPK_Entregable == vo_proyectoEntregable.pPK_Entregable).Count() > 0))
                    {
                        vo_proyectoEntregable.pProyecto.pPK_proyecto = ps_llaveProyecto;
                        vi_resultado = cls_gestorProyectoEntregable.updateProyectEntregable(vo_proyectoEntregable, 0);
                    }
                }

                return vi_resultado;
            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al guardar los entregables del proyecto.", po_exception);
            }
        }

        private int editarEntregableComponente(int ps_llaveProyecto)
        {
            int vi_resultado = 1;

            List<cls_entregableComponente> vl_entregableComponenteMemoria = this.crearEntregableComponenteMemoria();
            List<cls_entregableComponente> vl_entregableComponenteBaseDatos = this.crearEntregableComponenteBaseDatos();

            try
            {
                //Para cada proyecto entregable, se realiza la inserción
                foreach (cls_entregableComponente vo_entregableComponente in vl_entregableComponenteMemoria)
                {
                    if (!(vl_entregableComponenteBaseDatos.Where(dep => dep.pPK_Componente == vo_entregableComponente.pPK_Componente).Count() > 0))
                    {
                        vo_entregableComponente.pProyecto.pPK_proyecto = ps_llaveProyecto;
                        vi_resultado = cls_gestorEntregableComponente.updateEntregableComponente(vo_entregableComponente, 1);
                    }
                }

                //Para cada proyecto entregable, se realiza la inserción
                foreach (cls_entregableComponente vo_entregableComponente in vl_entregableComponenteBaseDatos)
                {
                    if (!(vl_entregableComponenteMemoria.Where(dep => dep.pPK_Componente == vo_entregableComponente.pPK_Componente).Count() > 0))
                    {
                        vo_entregableComponente.pProyecto.pPK_proyecto = ps_llaveProyecto;
                        vi_resultado = cls_gestorEntregableComponente.updateEntregableComponente(vo_entregableComponente, 0);
                    }
                }

                return vi_resultado;
            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al guardar los entregables del proyecto.", po_exception);
            }
        }

        private int editarComponentePaquete(int ps_llaveProyecto)
        {
            int vi_resultado = 1;

            List<cls_componentePaquete> vl_componentePaqueteMemoria = this.crearComponentePaqueteMemoria();
            List<cls_componentePaquete> vl_componentePaqueteBaseDatos = this.crearComponentePaqueteBaseDatos();

            try
            {
                //Para cada proyecto entregable, se realiza la inserción
                foreach (cls_componentePaquete vo_componentePaquete in vl_componentePaqueteMemoria)
                {
                    if (!(vl_componentePaqueteBaseDatos.Where(dep => dep.pPK_Paquete == vo_componentePaquete.pPK_Paquete).Count() > 0))
                    {
                        vo_componentePaquete.pProyecto.pPK_proyecto = ps_llaveProyecto;
                        vi_resultado = cls_gestorComponentePaquete.updateComponentePaquete(vo_componentePaquete, 1);
                    }
                }

                //Para cada proyecto entregable, se realiza la inserción
                foreach (cls_componentePaquete vo_componentePaquete in vl_componentePaqueteBaseDatos)
                {
                    if (!(vl_componentePaqueteMemoria.Where(dep => dep.pPK_Paquete == vo_componentePaquete.pPK_Paquete).Count() > 0))
                    {
                        vo_componentePaquete.pProyecto.pPK_proyecto = ps_llaveProyecto;
                        vi_resultado = cls_gestorComponentePaquete.updateComponentePaquete(vo_componentePaquete, 0);
                    }
                }

                return vi_resultado;
            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al guardar los entregables del proyecto.", po_exception);
            }
        }

        private int editarPaqueteActividad(int ps_llaveProyecto)
        {
            int vi_resultado = 1;

            List<cls_paqueteActividad> vl_paqueteActividadMemoria = this.crearPaqueteActividadMemoria();
            List<cls_paqueteActividad> vl_componentePaqueteBaseDatos = this.crearPaqueteActividadBaseDatos();

            try
            {
                //Para cada proyecto entregable, se realiza la inserción
                foreach (cls_paqueteActividad vo_paqueteActividad in vl_paqueteActividadMemoria)
                {
                    if (!(vl_componentePaqueteBaseDatos.Where(dep => dep.pPK_Actividad == vo_paqueteActividad.pPK_Actividad).Count() > 0))
                    {
                        vo_paqueteActividad.pProyecto.pPK_proyecto = ps_llaveProyecto;
                        vi_resultado = cls_gestorPaqueteActividad.updatePaqueteActividad(vo_paqueteActividad, 1);
                    }
                }

                //Para cada proyecto entregable, se realiza la inserción
                foreach (cls_paqueteActividad vo_paqueteActividad in vl_componentePaqueteBaseDatos)
                {
                    if (!(vl_paqueteActividadMemoria.Where(dep => dep.pPK_Actividad == vo_paqueteActividad.pPK_Actividad).Count() > 0))
                    {
                        vo_paqueteActividad.pProyecto.pPK_proyecto = ps_llaveProyecto;
                        vi_resultado = cls_gestorPaqueteActividad.updatePaqueteActividad(vo_paqueteActividad, 0);
                    }
                }

                return vi_resultado;
            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al guardar los entregables del proyecto.", po_exception);
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
            //try
            //{
            //    this.guardarDatos();

            //    this.upd_Principal.Update();

            //    this.ard_principal.SelectedIndex = 0;

            //    // Do something with the click ...
            //    Response.Redirect("frw_proyectos.aspx", false);

            //}
            //catch (Exception po_exception)
            //{
            //    String vs_error_usuario = "Ocurrió un error mientras se guardaba el registro.";
            //    this.lanzarExcepcion(po_exception, vs_error_usuario);
            //} 
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

        protected void wiz_creacion_FinishButtonClick(object sender, EventArgs e)
        {
            try
            {
                this.guardarDatos();

                this.upd_Principal.Update();

                this.ard_principal.SelectedIndex = 0;

                // Do something with the click ...
                Response.Redirect("frw_proyectos.aspx", false);

            }
            catch (Exception po_exception)
            {
                String vs_error_usuario = "Ocurrió un error mientras se guardaba el registro.";
                this.lanzarExcepcion(po_exception, vs_error_usuario);
            } 
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
            btnNxt = (Button)sender;
        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            btnPrev = (Button)sender;

            if (wiz_creacion.ActiveStepIndex == wiz_creacion.WizardSteps.IndexOf(this.wzs_entregables))
            {
                if (lbx_entasociados.Items.Count == 0 && btnNxt != null)
                {
                    btnNxt.Enabled = false;
                }

                btnPrev.Visible = false;

            }

            if (wiz_creacion.ActiveStepIndex == wiz_creacion.WizardSteps.IndexOf(this.wzs_componentes))
            {
                if (lbx_compasociados.Items.Count == 0)
                {
                    btnNxt.Enabled = false;
                }

                btnPrev.Visible = true;

            }

            if (wiz_creacion.ActiveStepIndex == wiz_creacion.WizardSteps.IndexOf(this.wzs_paquetes))
            {
                if (lbx_paqasociados.Items.Count == 0)
                {
                    btnNxt.Enabled = false;
                }

                btnPrev.Visible = true;
            }

            if (wiz_creacion.ActiveStepIndex == wiz_creacion.WizardSteps.IndexOf(this.wzs_actividades))
            {
                if (lbx_actasociadas.Items.Count == 0)
                {
                    btnNxt.Enabled = false;
                }

                btnPrev.Visible = true;
            }
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
                llenarDatosEntregables();
            }
            
            if (wiz_creacion.ActiveStepIndex == wiz_creacion.WizardSteps.IndexOf(this.wzs_componentes))
            {
                llenarDatosComponentes();
            }

            if (wiz_creacion.ActiveStepIndex == wiz_creacion.WizardSteps.IndexOf(this.wzs_paquetes))
            {
                llenarDatosPaquetes();
            }

            if (wiz_creacion.ActiveStepIndex == wiz_creacion.WizardSteps.IndexOf(this.wzs_actividades))
            {
                llenarDatosActividades();
            }

        }

        #endregion Eventos Generales



        #region Métodos Entregables

        /// <summary>
        /// Método para habilitar o deshabilitar los botones de anterior y siguiente
        /// </summary>
        private void deshabilitarBotonesNavegacion()
        {
            if (lbx_entasociados.Items.Count == 0)
            {
                btnNxt.Enabled = false;
            }

            if (wiz_creacion.ActiveStepIndex == wiz_creacion.WizardSteps.IndexOf(this.wzs_entregables))
            {
                btnPrev.Visible = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void llenarDatosEntregables()
        {
            try
            {
                cargarProyecto();
                cargarListaEntregables();
                cargarEntregablesPorProyecto();
            }
            /*
                Nota: revisar el manejo de excepxiones personalizadas en este form
            */
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al cargar el registro.", po_exception);
            }
        }

        /// <summary>
        /// Se manda a cargar la totalidad de los entregables del proyecto
        /// </summary>
        private void cargarListaEntregables()
        {
            try
            {
                /*
                 NOta: * Revisar los selects de los listar, para ver que tanto es necesario cambiar los "pNombre" por los nombres de la tabla => "pNombre" - "pNombreEntregable"
                       * Ver si es relevante cambiar los nombres a los listbox
                 */
                lbx_entregables.DataSource = cls_gestorEntregable.listarEntregable(); ;
                lbx_entregables.DataTextField = "pNombre";
                lbx_entregables.DataValueField = "pPK_entregable";
                lbx_entregables.DataBind();
            }
                /*
                 Nota: revisar el manejo de excepxiones personalizadas en este form
                 */
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al cargar los datos de la lista de entregables del proyecto.", po_exception);
            }

        }

        /// <summary>
        /// Se cargan los entregables que están asociados al proyecto, ya sea por Base de Datos o por memoria
        /// </summary>
        private void cargarEntregablesPorProyecto()
        {
            DataSet vo_dataSet = new DataSet();

            try
            {
                if(cls_variablesSistema.vs_proyecto.pProyectoEntregableListaMemoria.Count > 0)
                {
                    //Si la variable en memoria SI posee algún valor, se va a efectuar una "Actualizacion" al proyecto
                    cls_variablesSistema.tipoEstado = cls_constantes.EDITAR;

                    lbx_entasociados.DataSource = cls_variablesSistema.vs_proyecto.pProyectoEntregableListaMemoria;
                    lbx_entasociados.DataTextField = "pNombreEntregable";
                    lbx_entasociados.DataValueField = "pPK_Entregable";
                }
                else
                {

                    vo_dataSet = cls_gestorProyectoEntregable.selectProyectoEntregable(cls_variablesSistema.vs_proyecto);

                    if (vo_dataSet.Tables[0].Rows.Count > 0)
                    {
                        //Si la variable en memoria SI posee algún valor, se va a efectuar una "Actualizacion" al proyecto
                        cls_variablesSistema.tipoEstado = cls_constantes.EDITAR;
                    }
                    else
                    {
                        //Si la variable en memoria NO posee algún valor, se va a efectuar una "Insercion" de proyecto
                        cls_variablesSistema.tipoEstado = cls_constantes.AGREGAR;
                    }

                    foreach (DataRow row in vo_dataSet.Tables[0].Rows)
                    {

                        cls_entregable vo_entregable = new cls_entregable();
                        cls_proyectoEntregable vo_proyectoEntregable = new cls_proyectoEntregable();

                        vo_entregable.pPK_entregable = Convert.ToInt32(row["PK_entregable"]);
                        vo_entregable.pNombre = Convert.ToString(row["nombre"]);

                        vo_proyectoEntregable.pEntregable = vo_entregable;

                        cls_variablesSistema.vs_proyecto.pEntregableLista.Add(vo_entregable);
                        cls_variablesSistema.vs_proyecto.pProyectoEntregableListaMemoria.Add(vo_proyectoEntregable);
                        cls_variablesSistema.vs_proyecto.pProyectoEntregableListaBaseDatos.Add(vo_proyectoEntregable);
                    }

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

                    if (!(cls_variablesSistema.vs_proyecto.pProyectoEntregableListaMemoria.Where(test => test.pPK_Entregable == vo_entregable.pPK_entregable).Count() > 0))
                    {
                        vo_proyectoEntregable.pEntregableList.Add(vo_entregable);
                        cls_variablesSistema.vs_proyecto.pEntregableLista.Add(vo_entregable);
                        cls_variablesSistema.vs_proyecto.pProyectoEntregableListaMemoria.Add(vo_proyectoEntregable);
                    }

                    lbx_entasociados.Items.Add(lbx_entregables.Items[i]);
                    ListItem li = lbx_entregables.Items[i];
                    lbx_entregables.Items.Remove(li);

                }
            }

            if (lbx_entasociados.Items.Count > 0)
            {
                btnNxt.Enabled = true;
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
                    cls_variablesSistema.vs_proyecto.pProyectoEntregableListaMemoria.RemoveAll(test => test.pPK_Entregable == vo_entregable.pPK_entregable);
                    cls_variablesSistema.vs_proyecto.pEntregableComponenteListaMemoria.RemoveAll(test => test.pPK_Entregable == vo_entregable.pPK_entregable);

                    lbx_entregables.Items.Add(lbx_entasociados.Items[i]);
                    ListItem li = lbx_entasociados.Items[i];
                    lbx_entasociados.Items.Remove(li);
                }
            }

            if (lbx_entasociados.Items.Count == 0)
            {
                btnNxt.Enabled = false;
            }

        }


        #endregion Eventos Entregables



        #region Métodos Componentes

        private void llenarDatosComponentes()
        {
            try
            {
                cargarEntregablesAsociados();
            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al cargar los registros.", po_exception);
            }
        }

        /// <summary>
        /// Se obtienen los entregables que se asociaron en el paso anterior del wizard, ya sean provenientes de Base de Datos, o recién asignados
        /// </summary>
        private void cargarEntregablesAsociados()
        {
            DataSet vo_dataSet = new DataSet();
            try
            {
                if (cls_variablesSistema.vs_proyecto.pProyectoEntregableListaMemoria.Count > 0)
                {
                    lbx_entregablesasociados.DataSource = cls_variablesSistema.vs_proyecto.pProyectoEntregableListaMemoria;
                    lbx_entregablesasociados.DataTextField = "pNombreEntregable";
                    lbx_entregablesasociados.DataValueField = "pPK_entregable";
                    lbx_entregablesasociados.DataBind();
                }
                else
                {
                    vo_dataSet = cls_gestorProyectoEntregable.selectProyectoEntregable(cls_variablesSistema.vs_proyecto);
                    lbx_entregablesasociados.DataSource = vo_dataSet;
                    lbx_entregablesasociados.DataTextField = "nombre";
                    lbx_entregablesasociados.DataValueField = "PK_entregable";
                    lbx_entregablesasociados.DataBind();
                }

                cargarComponentesPorEntregable();

            }
            /*
                Nota: revisar el manejo de excepxiones personalizadas en este form
            */
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al cargar los datos de la lista de entregables del proyecto.", po_exception);
            }
        }

        /// <summary>
        /// Se manda a cargar la totalidad de los componentes del proyecto
        /// </summary>
        private void cargarListaComponentes()
        {
            try
            {
                /*
                 NOta: * Revisar los selects de los listar, para ver que tanto es necesario cambiar los "pNombre" por los nombres de la tabla => "pNombre" - "pNombreComponente"
                       * Ver si es relevante cambiar los nombres a los listbox
                 */
                lbx_componentes.DataSource = cls_gestorComponente.listarComponente();
                lbx_componentes.DataTextField = "pNombre";
                lbx_componentes.DataValueField = "pPK_componente";
                lbx_componentes.DataBind();

                //Se valida dentro de la misma lista de componentes, que si en algunos de los entregables se encuentra asociado, que se encargue de eliminarlo
                //del listbox, para que no llegue a ser tomado en cuenta entre los componentes de algún otro entregable(son únicos por entregable
                //Este listBox pivot se incorpora debido a que trabajar sobre el listbox original, por el manejo de punteros en C#, se presentan excepciones no controladas
                ListBox lbx_pivot = new ListBox();

                lbx_pivot.DataSource = cls_gestorComponente.listarComponente();
                lbx_pivot.DataTextField = "pNombre";
                lbx_pivot.DataValueField = "pPK_componente";
                lbx_pivot.DataBind();

                //Si se devuelven componentes asociados, se remueven los mismos del listBox que mantiene la totalidad de componentes, estp para mantener la 
                //pertenencia de un componente a un sólo entregable
                if (lbx_compasociados.Items.Count > 0)
                {
                    foreach (ListItem item in lbx_compasociados.Items)
                    {
                        lbx_componentes.Items.Remove(item);
                    }
                }

                //También se procede a eliminar de la lista de componentes aquellos que se encuentren asignados en memoria
                foreach (ListItem item in lbx_pivot.Items)
                {
                    if (cls_variablesSistema.vs_proyecto.pEntregableComponenteListaMemoria.Where(test => test.pPK_Componente.ToString() == item.Value).Count() > 0)
                    {
                        lbx_componentes.Items.Remove(item);
                    }
                }

            }
            /*
             Nota: revisar el manejo de excepxiones personalizadas en este form
             */
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al cargar los datos de la lista de componentes del proyecto.", po_exception);
            }

        }

        private void inicializarComponentesPorEntregable(cls_entregable po_entregable)
        {
            cls_entregableComponente vo_entregableComponente = new cls_entregableComponente();

            vo_entregableComponente.pProyecto = cls_variablesSistema.vs_proyecto;
            vo_entregableComponente.pEntregable = po_entregable;

            cargarComponentesPorEntregable(vo_entregableComponente);

            cargarListaComponentes();
            
        }

        private void cargarComponentesPorEntregable(cls_entregableComponente po_entregableComponente)
        {
            DataSet vo_dataSet = new DataSet();

            try
            {
                if (cls_variablesSistema.vs_proyecto.pEntregableComponenteListaMemoria.Count == 0)
                {
                    vo_dataSet = cls_gestorEntregableComponente.selectEntregableComponente(cls_variablesSistema.vs_proyecto);

                    foreach (DataRow row in vo_dataSet.Tables[0].Rows)
                    {

                        cls_entregable vo_entregable = new cls_entregable();
                        cls_componente vo_componente = new cls_componente();
                        cls_entregableComponente vo_entregableComponente = new cls_entregableComponente();

                        vo_entregable.pPK_entregable = Convert.ToInt32(row["PK_entregable"]);
                        vo_componente.pPK_componente = Convert.ToInt32(row["PK_componente"]);
                        vo_componente.pNombre = Convert.ToString(row["nombre"]);

                        vo_entregableComponente.pEntregable = vo_entregable;
                        vo_entregableComponente.pComponente = vo_componente;

                        if (cls_variablesSistema.vs_proyecto.pEntregableComponenteListaBaseDatos.Where(test => test.pPK_Entregable == vo_entregableComponente.pPK_Entregable).Count() == 0)
                        {
                            cls_variablesSistema.vs_proyecto.pEntregableComponenteListaBaseDatos.Add(vo_entregableComponente);
                        }

                        if (cls_variablesSistema.vs_proyecto.pProyectoEntregableListaMemoria.Where(test => test.pPK_Entregable == vo_entregableComponente.pPK_Entregable).Count() > 0)
                        {
                            if (cls_variablesSistema.vs_proyecto.pEntregableComponenteListaMemoria.Where(test => test.pPK_Componente == vo_entregableComponente.pPK_Componente).Count() == 0)
                            {
                                cls_variablesSistema.vs_proyecto.pComponenteLista.Add(vo_componente);
                                cls_variablesSistema.vs_proyecto.pEntregableComponenteListaMemoria.Add(vo_entregableComponente);
                            }                      
                        }
                    }

                }

                if (cls_variablesSistema.vs_proyecto.pEntregableComponenteListaMemoria.Where(test => test.pPK_Entregable == po_entregableComponente.pPK_Entregable).Count() > 0)
                {
                    lbx_compasociados.DataSource = cls_variablesSistema.vs_proyecto.pEntregableComponenteListaMemoria.Where(test => test.pPK_Entregable == po_entregableComponente.pPK_Entregable);
                    lbx_compasociados.DataTextField = "pNombreComponente";
                    lbx_compasociados.DataValueField = "pPK_Componente";
                }
                else
                {
                    vo_dataSet = cls_gestorEntregableComponente.selectEntregableComponente(po_entregableComponente);
                    lbx_compasociados.DataSource = vo_dataSet;
                    lbx_compasociados.DataTextField = "Nombre";
                    lbx_compasociados.DataValueField = "PK_Componente";
                }

                //Se realiza el Binding luego de saber de donde se tomarán los datos
                lbx_compasociados.DataBind();

            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al cargar los entregables asociados al proyecto.", po_exception);
            }
        }

        private void cargarComponentesPorEntregable()
        {
            DataSet vo_dataSet = new DataSet();
            int cantidadCompAsociados;
            int cantidadComponentes;

            try
            {
                if (lbx_compasociados.Items.Count > 0)
                {
                    cantidadCompAsociados = lbx_compasociados.Items.Count;

                    for (int i = 0; i < cantidadCompAsociados; i++ )
                    {
                        lbx_compasociados.Items.RemoveAt(0);
                    }
                }

                if (lbx_componentes.Items.Count > 0)
                {
                    cantidadComponentes = lbx_componentes.Items.Count;

                    for (int i = 0; i < cantidadComponentes; i++)
                    {
                        lbx_componentes.Items.RemoveAt(0);
                    }
                }

                vo_dataSet = cls_gestorEntregableComponente.selectEntregableComponente(cls_variablesSistema.vs_proyecto);

                foreach (DataRow row in vo_dataSet.Tables[0].Rows)
                {

                    cls_entregable vo_entregable = new cls_entregable();
                    cls_componente vo_componente = new cls_componente();
                    cls_entregableComponente vo_entregableComponente = new cls_entregableComponente();

                    vo_entregable.pPK_entregable = Convert.ToInt32(row["PK_entregable"]);
                    vo_componente.pPK_componente = Convert.ToInt32(row["PK_componente"]);
                    vo_componente.pNombre = Convert.ToString(row["nombre"]);

                    vo_entregableComponente.pEntregable = vo_entregable;
                    vo_entregableComponente.pComponente = vo_componente;

                    if (cls_variablesSistema.vs_proyecto.pEntregableComponenteListaBaseDatos.Where(test => test.pPK_Entregable == vo_entregableComponente.pPK_Entregable).Count() == 0)
                    {
                        cls_variablesSistema.vs_proyecto.pEntregableComponenteListaBaseDatos.Add(vo_entregableComponente);
                    }

                    if (cls_variablesSistema.vs_proyecto.pProyectoEntregableListaMemoria.Where(test => test.pPK_Entregable == vo_entregableComponente.pPK_Entregable).Count() > 0)
                    {
                        if (cls_variablesSistema.vs_proyecto.pEntregableComponenteListaMemoria.Where(test => test.pPK_Componente == vo_entregableComponente.pPK_Componente).Count() == 0)
                        {
                            cls_variablesSistema.vs_proyecto.pComponenteLista.Add(vo_componente);
                            cls_variablesSistema.vs_proyecto.pEntregableComponenteListaMemoria.Add(vo_entregableComponente);
                        }
                    }
                }
                
            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al cargar los entregables asociados al proyecto.", po_exception);
            }
        }

        #endregion Métodos Componentes

        #region Eventos Componentes

        protected void lbx_entregables_SelectedIndexChanged(object sender, EventArgs e)
        {
            int entregableSeleccionado;
            entregableSeleccionado = Convert.ToInt32(lbx_entregablesasociados.SelectedValue.ToString());

            cls_entregable vo_entregable = new cls_entregable();
            vo_entregable.pPK_entregable = entregableSeleccionado;

            inicializarComponentesPorEntregable(vo_entregable);
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

                    foreach (cls_proyectoEntregable proyEnt in cls_variablesSistema.vs_proyecto.pProyectoEntregableListaMemoria)
                    {
                        if (proyEnt.pPK_Entregable == vo_entregable.pPK_entregable)
                        {
                            if (!proyEnt.ComponenteEncontrado(vo_componente))
                            {
                                proyEnt.pEntregableComponente.pComponenteList.Add(vo_componente);
                                proyEnt.pEntregableComponenteList.Add(vo_entregableComponente);
                                cls_variablesSistema.vs_proyecto.pComponenteLista.Add(vo_componente);
                                cls_variablesSistema.vs_proyecto.pEntregableComponenteListaMemoria.Add(vo_entregableComponente);
                            }
                        }
                    }

                    lbx_compasociados.Items.Add(lbx_componentes.Items[i]);
                    ListItem li = lbx_componentes.Items[i];
                    lbx_componentes.Items.Remove(li);

                }
            }

            if (lbx_compasociados.Items.Count > 0)
            {
                btnNxt.Enabled = true;
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

                    foreach (cls_proyectoEntregable proyEnt in cls_variablesSistema.vs_proyecto.pProyectoEntregableListaMemoria)
                    {
                        if (proyEnt.pPK_Entregable == vo_entregable.pPK_entregable)
                        {
                            if (proyEnt.ComponenteEncontrado(vo_componente))
                            {
                                proyEnt.RemoverComponenteEncontrado(vo_componente);
                                cls_variablesSistema.vs_proyecto.pComponenteLista.RemoveAll(test => test.pPK_componente == vo_componente.pPK_componente);
                                cls_variablesSistema.vs_proyecto.pEntregableComponenteListaMemoria.RemoveAll(test => test.pPK_Componente == vo_componente.pPK_componente);
                            }
                        }
                    }

                    lbx_componentes.Items.Add(lbx_compasociados.Items[i]);
                    ListItem li = lbx_compasociados.Items[i];
                    lbx_compasociados.Items.Remove(li);

                }
            }

            if (lbx_compasociados.Items.Count == 0)
            {
                btnNxt.Enabled = false;
            }
        }


        #endregion Eventos Componentes



        #region Métodos Paquetes

        private void llenarDatosPaquetes()
        {
            try
            {
                cargarComponentesAsociados();
            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al cargar el registro.", po_exception);
            }
        }

        /// <summary>
        /// Se obtienen los componentes que se asociaron en el paso anterior del wizard, ya sean provenientes de Base de Datos, o recién asignados
        /// </summary>
        private void cargarComponentesAsociados()
        {
            DataSet vo_dataSet = new DataSet();
            
            try
            {
                if (cls_variablesSistema.vs_proyecto.pEntregableComponenteListaMemoria.Count > 0)
                {
                    lbx_componentesasociados.DataSource = cls_variablesSistema.vs_proyecto.pEntregableComponenteListaMemoria;
                    lbx_componentesasociados.DataTextField = "pNombreComponente";
                    lbx_componentesasociados.DataValueField = "pPK_Componente";
                    lbx_componentesasociados.DataBind();
                }
                else
                {
                    vo_dataSet = cls_gestorEntregableComponente.selectEntregableComponente(cls_variablesSistema.vs_proyecto);
                    lbx_componentesasociados.DataSource = vo_dataSet;
                    lbx_componentesasociados.DataTextField = "nombre";
                    lbx_componentesasociados.DataValueField = "PK_componente";
                    lbx_componentesasociados.DataBind();

                }
            }
            /*
                Nota: revisar el manejo de excepxiones personalizadas en este form
            */
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al cargar los datos de la lista de componentes del proyecto.", po_exception);
            }

        }

        /// <summary>
        /// Se manda a cargar la totalidad de los paquetes del proyecto
        /// </summary>
        private void cargarListaPaquetes()
        {
            try
            {
                /*
                 NOta: * Revisar los selects de los listar, para ver que tanto es necesario cambiar los "pNombre" por los nombres de la tabla => "pNombre" - "pNombrePaquete"
                       * Ver si es relevante cambiar los nombres a los listbox
                 */
                lbx_paquetes.DataSource = cls_gestorPaquete.listarPaquetes();
                lbx_paquetes.DataTextField = "pNombre";
                lbx_paquetes.DataValueField = "pPK_paquete";
                lbx_paquetes.DataBind();

                //Se valida dentro de la misma lista de paquetes, que si en algunos de los componentes se encuentra asociado, que se encargue de eliminarlo
                //del listbox, para que no llegue a ser tomado en cuenta entre los paquetes de algún otro componente(son únicos por componente)
                //Este listBox pivot se incorpora debido a que trabajar sobre el listbox original, por el manejo de punteros en C#, se presentan excepciones no controladas
                ListBox lbx_pivot = new ListBox();

                lbx_pivot.DataSource = cls_gestorPaquete.listarPaquetes();
                lbx_pivot.DataTextField = "pNombre";
                lbx_pivot.DataValueField = "pPK_paquete";
                lbx_pivot.DataBind();

                //Si se devuelven paquetes asociados, se remueven los mismos del listBox que mantiene la totalidad de paquetes, estp para mantener la 
                //pertenencia de un paquetes a un sólo componente
                if (lbx_paqasociados.Items.Count > 0)
                {
                    foreach (ListItem item in lbx_paqasociados.Items)
                    {
                        lbx_paquetes.Items.Remove(item);
                    }
                }

                //También se procede a eliminar de la lista de paquetes aquellos que se encuentren asignados en memoria
                foreach (ListItem item in lbx_pivot.Items)
                {
                    if (cls_variablesSistema.vs_proyecto.pComponentePaqueteListaMemoria.Where(test => test.pPK_Paquete.ToString() == item.Value).Count() > 0)
                    {
                        lbx_paquetes.Items.Remove(item);
                    }
                }
            }
            /*
             Nota: revisar el manejo de excepxiones personalizadas en este form
             */
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al cargar los datos de la lista de paquetes del proyecto.", po_exception);
            }

        }

        ///// <summary>
        ///// 
        ///// </summary>
        //private void cargarComponentePaqueteAsociados(cls_componentePaquete po_componentePaquete)
        //{
        //    DataSet vo_dataSet = new DataSet();

        //    try
        //    {
        //        vo_dataSet = cls_gestorComponentePaquete.selectComponentePaquete(po_componentePaquete);
        //        lbx_entasociados.DataSource = vo_dataSet;
        //        lbx_entasociados.DataTextField = "Nombre";
        //        lbx_entasociados.DataValueField = "PK_Paquete";
        //        lbx_entasociados.DataBind();

        //        if (lbx_entasociados.Items.Count > 0)
        //        {
        //            foreach (ListItem item in lbx_entasociados.Items)
        //            {
        //                lbx_entregables.Items.Remove(item);
        //            }
        //        }
        //    }
        //    catch (Exception po_exception)
        //    {
        //        throw new Exception("Ocurrió un error al cargar los entregables asociados al proyecto.", po_exception);
        //    }

        //}
        private void inicializarPaquetesPorComponente(cls_componente po_componente)
        {

            cls_componentePaquete vo_componentePaquete = new cls_componentePaquete();

            vo_componentePaquete.pProyecto = cls_variablesSistema.vs_proyecto;
            vo_componentePaquete.pComponente = po_componente;

            cargarPaquetesPorComponente(vo_componentePaquete);
            cargarListaPaquetes();

        }

        private void cargarPaquetesPorComponente(cls_componentePaquete po_componentePaquete)
        {
            DataSet vo_dataSet = new DataSet();

            try
            {
                if (cls_variablesSistema.vs_proyecto.pComponentePaqueteListaMemoria.Count == 0)
                {
                    vo_dataSet = cls_gestorComponentePaquete.selectComponentePaquete(cls_variablesSistema.vs_proyecto);

                    foreach (DataRow row in vo_dataSet.Tables[0].Rows)
                    {

                        cls_entregable vo_entregable = new cls_entregable();
                        cls_componente vo_componente = new cls_componente();
                        cls_paquete vo_paquete = new cls_paquete();
                        cls_componentePaquete vo_componentePaquete = new cls_componentePaquete();

                        vo_entregable.pPK_entregable = Convert.ToInt32(row["PK_entregable"]);
                        vo_componente.pPK_componente = Convert.ToInt32(row["PK_componente"]);
                        vo_paquete.pPK_Paquete = Convert.ToInt32(row["PK_paquete"]);
                        vo_paquete.pNombre = Convert.ToString(row["nombre"]);

                        vo_componentePaquete.pEntregable = vo_entregable;
                        vo_componentePaquete.pComponente = vo_componente;
                        vo_componentePaquete.pPaquete = vo_paquete;

                        cls_variablesSistema.vs_proyecto.pComponentePaqueteListaBaseDatos.Add(vo_componentePaquete);

                        if (cls_variablesSistema.vs_proyecto.pEntregableComponenteListaMemoria.Where(test => test.pPK_Componente == vo_componentePaquete.pPK_Componente).Count() > 0)
                        {
                            cls_variablesSistema.vs_proyecto.pPaqueteLista.Add(vo_paquete);
                            cls_variablesSistema.vs_proyecto.pComponentePaqueteListaMemoria.Add(vo_componentePaquete);
                        }
                    }

                }

                if (cls_variablesSistema.vs_proyecto.pComponentePaqueteListaMemoria.Where(test => test.pPK_Componente == po_componentePaquete.pPK_Componente).Count() > 0)
                {
                    lbx_paqasociados.DataSource = cls_variablesSistema.vs_proyecto.pComponentePaqueteListaMemoria.Where(test => test.pPK_Componente == po_componentePaquete.pPK_Componente);
                    lbx_paqasociados.DataTextField = "pNombrePaquete";
                    lbx_paqasociados.DataValueField = "pPK_Paquete";
                }
                else
                {
                    vo_dataSet = cls_gestorComponentePaquete.selectComponentePaquete(po_componentePaquete);
                    lbx_paqasociados.DataSource = vo_dataSet;
                    lbx_paqasociados.DataTextField = "Nombre";
                    lbx_paqasociados.DataValueField = "PK_Paquete";
                }

                //Se realiza el Binding luego de saber de donde se tomarán los datos
                lbx_paqasociados.DataBind();

            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al cargar los paquetes asociados al proyecto.", po_exception);
            }
        }


        #endregion Métodos Paquetes

        #region Eventos Paquetes

        protected void lbx_componentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int componenteSeleccionado;
            componenteSeleccionado = Convert.ToInt32(lbx_componentesasociados.SelectedValue.ToString());

            cls_componente vo_componente = new cls_componente();
            vo_componente.pPK_componente = componenteSeleccionado;

            inicializarPaquetesPorComponente(vo_componente);
        }

        protected void btn_asignarPaquete_Click(object sender, EventArgs e)
        {
            int compSeleccionado;
            compSeleccionado = Convert.ToInt32(lbx_componentesasociados.SelectedValue.ToString());

            cls_componente vo_componente = new cls_componente();
            vo_componente.pPK_componente = compSeleccionado;

            for (int i = lbx_paquetes.Items.Count - 1; i >= 0; i--)
            {
                if (lbx_paquetes.Items[i].Selected == true)
                {
                    cls_paquete vo_paquete = new cls_paquete();
                    vo_paquete.pPK_Paquete = Convert.ToInt32(lbx_paquetes.Items[i].Value.ToString());
                    vo_paquete.pNombre = lbx_paquetes.Items[i].Text;

                    cls_componentePaquete vo_componentePaquete = new cls_componentePaquete();

                    vo_componentePaquete.pComponente = vo_componente;
                    vo_componentePaquete.pPaquete = vo_paquete;

                    foreach (cls_entregableComponente entComp in cls_variablesSistema.vs_proyecto.pEntregableComponenteListaMemoria)
                    {
                        if (entComp.pPK_Componente == vo_componente.pPK_componente)
                        {
                            if (!entComp.PaqueteEncontrado(vo_paquete))
                            {
                                //Se agrega el entregable al que pertenece el componentePaquete, puesto que se necesita al guardar el registro
                                vo_componentePaquete.pEntregable = entComp.pEntregable;

                                entComp.pComponentePaquete.pPaqueteList.Add(vo_paquete);
                                entComp.pComponentePaqueteList.Add(vo_componentePaquete);
                                cls_variablesSistema.vs_proyecto.pPaqueteLista.Add(vo_paquete);
                                cls_variablesSistema.vs_proyecto.pComponentePaqueteListaMemoria.Add(vo_componentePaquete);
                            }
                        }
                    }

                    lbx_paqasociados.Items.Add(lbx_paquetes.Items[i]);
                    ListItem li = lbx_paquetes.Items[i];
                    lbx_paquetes.Items.Remove(li);

                }
            }

            if (lbx_paqasociados.Items.Count > 0)
            {
                btnNxt.Enabled = true;
            }

        }

        protected void btn_removerPaquete_Click(object sender, EventArgs e)
        {
            int compSeleccionado;
            compSeleccionado = Convert.ToInt32(lbx_componentesasociados.SelectedValue.ToString());

            cls_componente vo_componente = new cls_componente();
            vo_componente.pPK_componente = compSeleccionado;

            for (int i = lbx_paqasociados.Items.Count - 1; i >= 0; i--)
            {
                if (lbx_paqasociados.Items[i].Selected == true)
                {
                    cls_paquete vo_paquete = new cls_paquete();
                    vo_paquete.pPK_Paquete = Convert.ToInt32(lbx_paqasociados.Items[i].Value.ToString());
                    vo_paquete.pNombre = lbx_paqasociados.Items[i].Text;

                    cls_componentePaquete vo_componentePaquete = new cls_componentePaquete();

                    vo_componentePaquete.pComponente = vo_componente;
                    vo_componentePaquete.pPaquete = vo_paquete;

                    foreach (cls_entregableComponente entComp in cls_variablesSistema.vs_proyecto.pEntregableComponenteListaMemoria)
                    {
                        if (entComp.pPK_Componente == vo_componente.pPK_componente)
                        {
                            if (entComp.PaqueteEncontrado(vo_paquete))
                            {
                                entComp.RemoverPaqueteEncontrado(vo_paquete);
                                cls_variablesSistema.vs_proyecto.pPaqueteLista.RemoveAll(test => test.pPK_Paquete == vo_paquete.pPK_Paquete);
                                cls_variablesSistema.vs_proyecto.pComponentePaqueteListaMemoria.RemoveAll(test => test.pPK_Paquete == vo_paquete.pPK_Paquete);
                            }
                        }
                    }

                    lbx_paquetes.Items.Add(lbx_paqasociados.Items[i]);
                    ListItem li = lbx_paqasociados.Items[i];
                    lbx_paqasociados.Items.Remove(li);

                }
            }

            if (lbx_paqasociados.Items.Count == 0)
            {
                btnNxt.Enabled = false;
            }
        }


        #endregion Eventos Paquetes



        #region Métodos Actividades

        private void llenarDatosActividades()
        {
            try
            {
                cargarPaquetesAsociados();
            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al cargar el registro.", po_exception);
            }
        }

        /// <summary>
        /// Se obtienen las paquetes que se asociaron en el paso anterior del wizard, ya sean provenientes de Base de Datos, o recién asignados
        /// </summary>
        private void cargarPaquetesAsociados()
        {
            DataSet vo_dataSet = new DataSet();

            try
            {
                if (cls_variablesSistema.vs_proyecto.pComponentePaqueteListaMemoria.Count > 0)
                {
                    lbx_paquetesasociados.DataSource = cls_variablesSistema.vs_proyecto.pComponentePaqueteListaMemoria;
                    lbx_paquetesasociados.DataTextField = "pNombrePaquete";
                    lbx_paquetesasociados.DataValueField = "pPK_Paquete";
                    lbx_paquetesasociados.DataBind();
                }
                else
                {
                    vo_dataSet = cls_gestorComponentePaquete.selectComponentePaquete(cls_variablesSistema.vs_proyecto);
                    lbx_paquetesasociados.DataSource = vo_dataSet;
                    lbx_paquetesasociados.DataTextField = "nombre";
                    lbx_paquetesasociados.DataValueField = "PK_paquete";
                    lbx_paquetesasociados.DataBind();
                }
            }
            /*
                Nota: revisar el manejo de excepxiones personalizadas en este form
            */
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al cargar los datos de la lista de paquetes del proyecto.", po_exception);
            }

        }

        /// <summary>
        /// Se manda a cargar la totalidad de los actividades del proyecto
        /// </summary>
        private void cargarListaActividades()
        {
            try
            {
                /*
                 NOta: * Revisar los selects de los listar, para ver que tanto es necesario cambiar los "pNombre" por los nombres de la tabla => "pNombre" - "pNombreActividad"
                       * Ver si es relevante cambiar los nombres a los listbox
                 */
                lbx_actividades.DataSource = cls_gestorActividad.listarActividad();
                lbx_actividades.DataTextField = "pNombre";
                lbx_actividades.DataValueField = "pPK_actividad";
                lbx_actividades.DataBind();

                //Se valida dentro de la misma lista de actividades, que si en algunos de las actividades se encuentra asociada, que se encargue de eliminarlo
                //del listbox, para que no llegue a ser tomado en cuenta entre las actividades de algún otro paquete(son únicos por paquete)
                //Este listBox pivot se incorpora debido a que trabajar sobre el listbox original, por el manejo de punteros en C#, se presentan excepciones no controladas
                ListBox lbx_pivot = new ListBox();

                lbx_pivot.DataSource = cls_gestorActividad.listarActividad();
                lbx_pivot.DataTextField = "pNombre";
                lbx_pivot.DataValueField = "pPK_actividad";
                lbx_pivot.DataBind();

                //Si se devuelven actividades asociadas, se remueven los mismos del listBox que mantiene la totalidad de actividades, estp para mantener la 
                //pertenencia de una actividad a un sólo paquete
                if (lbx_actasociadas.Items.Count > 0)
                {
                    foreach (ListItem item in lbx_actasociadas.Items)
                    {
                        lbx_actividades.Items.Remove(item);
                    }
                }

                //También se procede a eliminar de la lista de actividades aquellas que se encuentren asignados en memoria
                foreach (ListItem item in lbx_pivot.Items)
                {
                    if (cls_variablesSistema.vs_proyecto.pPaqueteActividadListaMemoria.Where(test => test.pPK_Actividad.ToString() == item.Value).Count() > 0)
                    {
                        lbx_actividades.Items.Remove(item);
                    }
                }

            }
            /*
             Nota: revisar el manejo de excepxiones personalizadas en este form
             */
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al cargar los datos de la lista de actividades del proyecto.", po_exception);
            }

        }

        ///// <summary>
        ///// 
        ///// </summary>
        //private void cargarComponentePaqueteAsociados(cls_componentePaquete po_componentePaquete)
        //{
        //    DataSet vo_dataSet = new DataSet();

        //    try
        //    {
        //        vo_dataSet = cls_gestorComponentePaquete.selectComponentePaquete(po_componentePaquete);
        //        lbx_entasociados.DataSource = vo_dataSet;
        //        lbx_entasociados.DataTextField = "Nombre";
        //        lbx_entasociados.DataValueField = "PK_Paquete";
        //        lbx_entasociados.DataBind();

        //        if (lbx_entasociados.Items.Count > 0)
        //        {
        //            foreach (ListItem item in lbx_entasociados.Items)
        //            {
        //                lbx_entregables.Items.Remove(item);
        //            }
        //        }
        //    }
        //    catch (Exception po_exception)
        //    {
        //        throw new Exception("Ocurrió un error al cargar los entregables asociados al proyecto.", po_exception);
        //    }

        //}
        private void inicializarActividadesPorPaquete(cls_paquete po_paquete)
        {
            cls_paqueteActividad vo_paqueteActividad = new cls_paqueteActividad();

            vo_paqueteActividad.pProyecto = cls_variablesSistema.vs_proyecto;
            vo_paqueteActividad.pPaquete = po_paquete;

            cargarActividadesPorPaquete(vo_paqueteActividad);
            cargarListaActividades();
        }

        private void cargarActividadesPorPaquete(cls_paqueteActividad po_paqueteActividad)
        {
            DataSet vo_dataSet = new DataSet();

            try
            {
                if (cls_variablesSistema.vs_proyecto.pPaqueteActividadListaMemoria.Count == 0)
                {
                    vo_dataSet = cls_gestorPaqueteActividad.selectPaqueteActividad(cls_variablesSistema.vs_proyecto);

                    foreach (DataRow row in vo_dataSet.Tables[0].Rows)
                    {

                        cls_entregable vo_entregable = new cls_entregable();
                        cls_componente vo_componente = new cls_componente();
                        cls_paquete vo_paquete = new cls_paquete();
                        cls_actividad vo_actividad = new cls_actividad();
                        cls_paqueteActividad vo_paqueteActividad = new cls_paqueteActividad();

                        vo_entregable.pPK_entregable = Convert.ToInt32(row["PK_entregable"]);
                        vo_componente.pPK_componente = Convert.ToInt32(row["PK_componente"]);
                        vo_paquete.pPK_Paquete = Convert.ToInt32(row["PK_paquete"]);
                        vo_actividad.pPK_Actividad = Convert.ToInt32(row["PK_actividad"]);
                        vo_actividad.pNombre = Convert.ToString(row["nombre"]);

                        vo_paqueteActividad.pEntregable = vo_entregable;
                        vo_paqueteActividad.pComponente = vo_componente;
                        vo_paqueteActividad.pPaquete = vo_paquete;
                        vo_paqueteActividad.pActividad = vo_actividad;

                        cls_variablesSistema.vs_proyecto.pPaqueteActividadListaBaseDatos.Add(vo_paqueteActividad);

                        if (cls_variablesSistema.vs_proyecto.pComponentePaqueteListaMemoria.Where(test => test.pPK_Paquete == vo_paqueteActividad.pPK_Paquete).Count() > 0)
                        {
                            cls_variablesSistema.vs_proyecto.pActividadLista.Add(vo_actividad);
                            cls_variablesSistema.vs_proyecto.pPaqueteActividadListaMemoria.Add(vo_paqueteActividad);
                        }
                    }

                }

                if (cls_variablesSistema.vs_proyecto.pPaqueteActividadListaMemoria.Where(test => test.pPK_Paquete == po_paqueteActividad.pPK_Paquete).Count() > 0)
                {
                    lbx_actasociadas.DataSource = cls_variablesSistema.vs_proyecto.pPaqueteActividadListaMemoria.Where(test => test.pPK_Paquete == po_paqueteActividad.pPK_Paquete);
                    lbx_actasociadas.DataTextField = "pNombreActividad";
                    lbx_actasociadas.DataValueField = "pPK_Actividad";
                }
                else
                {
                    vo_dataSet = cls_gestorPaqueteActividad.selectPaqueteActividad(po_paqueteActividad);
                    lbx_actasociadas.DataSource = vo_dataSet;
                    lbx_actasociadas.DataTextField = "Nombre";
                    lbx_actasociadas.DataValueField = "PK_Actividad";
                }

                //Se realiza el Binding luego de saber de donde se tomarán los datos
                lbx_actasociadas.DataBind();

            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al cargar los actividades asociadas al proyecto.", po_exception);
            }
        }


        #endregion Métodos Actividades

        #region Eventos Actividades

        protected void lbx_paquetes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int paqueteSeleccionado;
            paqueteSeleccionado = Convert.ToInt32(lbx_paquetesasociados.SelectedValue.ToString());

            cls_paquete vo_paquete = new cls_paquete();
            vo_paquete.pPK_Paquete = paqueteSeleccionado;

            inicializarActividadesPorPaquete(vo_paquete);
        }

        protected void btn_asignarActividad_Click(object sender, EventArgs e)
        {
            int paqueteSeleccionado;
            paqueteSeleccionado = Convert.ToInt32(lbx_paquetesasociados.SelectedValue.ToString());

            cls_paquete vo_paquete = new cls_paquete();
            vo_paquete.pPK_Paquete = paqueteSeleccionado;

            for (int i = lbx_actividades.Items.Count - 1; i >= 0; i--)
            {
                if (lbx_actividades.Items[i].Selected == true)
                {
                    cls_actividad vo_actividad = new cls_actividad();
                    vo_actividad.pPK_Actividad = Convert.ToInt32(lbx_actividades.Items[i].Value.ToString());
                    vo_actividad.pNombre = lbx_actividades.Items[i].Text;

                    cls_paqueteActividad vo_paqueteActividad = new cls_paqueteActividad();

                    vo_paqueteActividad.pPaquete = vo_paquete;
                    vo_paqueteActividad.pActividad = vo_actividad;

                    foreach (cls_componentePaquete compPaq in cls_variablesSistema.vs_proyecto.pComponentePaqueteListaMemoria)
                    {
                        if (compPaq.pPK_Paquete == vo_paquete.pPK_Paquete)
                        {
                            if (!compPaq.ActividadEncontrada(vo_actividad))
                            {
                                //Se agregam el entregable y componente al que pertenece el paqueteActividad, puesto que se necesita al guardar el registro
                                vo_paqueteActividad.pEntregable = compPaq.pEntregable;
                                vo_paqueteActividad.pComponente = compPaq.pComponente;

                                compPaq.pPaqueteActividad.pActividadList.Add(vo_actividad);
                                compPaq.pPaqueteActividadList.Add(vo_paqueteActividad);
                                cls_variablesSistema.vs_proyecto.pActividadLista.Add(vo_actividad);
                                cls_variablesSistema.vs_proyecto.pPaqueteActividadListaMemoria.Add(vo_paqueteActividad);
                            }
                        }
                    }

                    lbx_actasociadas.Items.Add(lbx_actividades.Items[i]);
                    ListItem li = lbx_actividades.Items[i];
                    lbx_actividades.Items.Remove(li);

                }
            }

            if (lbx_actasociadas.Items.Count > 0)
            {
                btnNxt.Enabled = true;
            }
        }

        protected void btn_removerActividad_Click(object sender, EventArgs e)
        {
            int paqueteSeleccionado;
            paqueteSeleccionado = Convert.ToInt32(lbx_paquetesasociados.SelectedValue.ToString());

            cls_paquete vo_paquete = new cls_paquete();
            vo_paquete.pPK_Paquete = paqueteSeleccionado;

            for (int i = lbx_actasociadas.Items.Count - 1; i >= 0; i--)
            {
                if (lbx_actasociadas.Items[i].Selected == true)
                {
                    cls_actividad vo_actividad = new cls_actividad();
                    vo_actividad.pPK_Actividad = Convert.ToInt32(lbx_actasociadas.Items[i].Value.ToString());
                    vo_actividad.pNombre = lbx_actasociadas.Items[i].Text;

                    cls_paqueteActividad vo_paqueteActividad = new cls_paqueteActividad();

                    vo_paqueteActividad.pPaquete = vo_paquete;
                    vo_paqueteActividad.pActividad = vo_actividad;

                    foreach (cls_componentePaquete compPaq in cls_variablesSistema.vs_proyecto.pComponentePaqueteListaMemoria)
                    {
                        if (compPaq.pPK_Paquete == vo_paquete.pPK_Paquete)
                        {
                            if (compPaq.ActividadEncontrada(vo_actividad))
                            {
                                compPaq.RemoverActividadEncontrada(vo_actividad);
                                cls_variablesSistema.vs_proyecto.pActividadLista.RemoveAll(test => test.pPK_Actividad == vo_actividad.pPK_Actividad);
                                cls_variablesSistema.vs_proyecto.pPaqueteActividadListaMemoria.RemoveAll(test => test.pPK_Actividad == vo_actividad.pPK_Actividad);
                            }
                        }
                    }

                    lbx_actividades.Items.Add(lbx_actasociadas.Items[i]);
                    ListItem li = lbx_actasociadas.Items[i];
                    lbx_actasociadas.Items.Remove(li);

                }
            }

            if (lbx_actasociadas.Items.Count == 0)
            {
                btnNxt.Enabled = false;
            }
        }


        #endregion Eventos Actividades


    }
}