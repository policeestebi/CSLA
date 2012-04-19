using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using COSEVI.CSLA.lib.accesoDatos.App_InterfaceComunes;
using ExceptionManagement.Exceptions;
using COSEVI.CSLA.lib.entidades.mod.ControlSeguimiento;
using COSEVI.CSLA.lib.entidades.mod.Administracion;
using COSEVI.CSLA.lib.accesoDatos.mod.ControlSeguimiento;
using COSEVI.CSLA.lib.accesoDatos.mod.Administracion;

using CSLA.web.App_Variables;
using CSLA.web.App_Constantes;
using System.Data;


// =========================================================================
// COSEVI - Consejo de Seguridad Vial. - 2011
// Sistema CSLA (Sistema para el Control y Seguimiento de Labores)
//
// frw_actividades.aspx.cs
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
    public partial class frw_asignacionActividad : System.Web.UI.Page
    {

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
                    this.inicializarRegistros();
                }
                catch (Exception po_exception)
                {
                    String vs_error_usuario = "Error al inicializar el mantenimiento de asignación de actividades.";
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
                
                //Inicializacón de botón de asignación
                this.btn_asignarUsuario = (Button)acp_edicionDatos.FindControl("btn_asignarUsuario");
                this.btn_removerUsuario = (Button)acp_edicionDatos.FindControl("btn_removerUsuario");

                //Botones comunes
                //this.btn_eliminar = (Button)acp_edicionDatos.FindControl("btn_elminar");
                this.btn_regresar = (Button)acp_edicionDatos.FindControl("btn_regresar");
                this.btn_guardar = (Button)acp_edicionDatos.FindControl("btn_guardar");

            }
            catch (Exception po_exception)
            {
                String vs_error_usuario = "Ocurrió un error inicializando los controles del mantenimiento.";
                this.lanzarExcepcion(po_exception, vs_error_usuario);
            } 
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Método que se encarga de 
        /// llenar la información del
        /// grid view
        /// </summary>
        private void inicializarRegistros()
        {
            try
            {
                cargarNombreProyecto();
                //cargarActividadesProyecto();
                cargarDataSetPaquetes();
                cargarUsuarios();

                //Se carga el dataset con los estados que puede adquirir una actividad
                cargarDataSetEstados();
                //this.ddl_estado.DataBind();
            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error llenando la tabla.", po_exception);
            } 
        }

        /// <summary>
        /// 
        /// </summary>
        private void cargarNombreProyecto()
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

        private void cargarDataSetPaquetes()
        {
            try
            {
                this.ddl_paquete.DataSource = cls_gestorAsignacionActividad.listarPaquetesProyecto(cls_variablesSistema.vs_proyecto.pPK_proyecto);
                this.ddl_paquete.DataTextField = "pNombre";
                this.ddl_paquete.DataValueField = "pPK_Paquete";
                this.ddl_paquete.DataBind();
            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al cargar los paquetes del proyecto.", po_exception);
            }

        }

        private void cargarUsuarios()
        {
            try
            {
                /*
                 NOta: * Revisar los selects de los listar, para ver que tanto es necesario cambiar los "pNombre" por los nombres de la tabla => "pNombre" - "pNombreEntregable"
                       * Ver si es relevante cambiar los nombres a los listbox
                 */
                lbx_usuarios.DataSource = cls_gestorUsuario.listarUsuarios();
                lbx_usuarios.DataTextField = "pNombre";
                lbx_usuarios.DataValueField = "pPK_usuario";
                lbx_usuarios.DataBind();
            }
            /*
             Nota: revisar el manejo de excepxiones personalizadas en este form
             */
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al cargar los datos de la lista de usuarios del sistema.", po_exception);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        private void cargarActividadesProyecto(int pi_paquete)
        {
            try
            {
                /*
                 NOta: * Revisar los selects de los listar, para ver que tanto es necesario cambiar los "pNombre" por los nombres de la tabla => "pNombre" - "pNombreEntregable"
                       * Ver si es relevante cambiar los nombres a los listbox
                 */
                cls_variablesSistema.vs_proyecto.pAsignacionLista = cls_gestorAsignacionActividad.listarActividadesProyecto(cls_variablesSistema.vs_proyecto.pPK_proyecto, pi_paquete);

                lbx_actividades.DataSource = cls_variablesSistema.vs_proyecto.pAsignacionLista;
                lbx_actividades.DataTextField = "pNombreActividad";
                lbx_actividades.DataValueField = "pPK_Actividad";
                lbx_actividades.DataBind();
            }
            /*
             Nota: revisar el manejo de excepxiones personalizadas en este form
             */
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al cargar los datos de la lista de actividades del proyecto.", po_exception);
            }

        }

        //private void cargarPaquetesProyecto()
        //{
        //    try
        //    {
        //        /*
        //         NOta: * Revisar los selects de los listar, para ver que tanto es necesario cambiar los "pNombre" por los nombres de la tabla => "pNombre" - "pNombreEntregable"
        //               * Ver si es relevante cambiar los nombres a los listbox
        //         */
        //        cls_variablesSistema.vs_proyecto.pAsignacionLista = cls_gestorAsignacionActividad.listarActividadesProyecto(cls_variablesSistema.vs_proyecto.pPK_proyecto);

        //        lbx_actividades.DataSource = cls_variablesSistema.vs_proyecto.pPaquetesAsignadosLista;
        //        lbx_actividades.DataTextField = "pNombreActividad";
        //        lbx_actividades.DataValueField = "pPK_actividad";
        //        lbx_actividades.DataBind();
        //    }
        //    /*
        //     Nota: revisar el manejo de excepxiones personalizadas en este form
        //     */
        //    catch (Exception po_exception)
        //    {
        //        throw new Exception("Ocurrió un error al cargar los datos de la lista de actividades del proyecto.", po_exception);
        //    }

        //}

        /// <summary>
        /// Metodo que carga el dataSet de los estados a los que se puede asociar un proyecto
        /// </summary>
        private void cargarDataSetEstados()
        {
            DataSet vo_dataSet = new DataSet();

            try
            {
                vo_dataSet = cls_gestorProyecto.listarEstado();
                this.ddl_estado.DataSource = vo_dataSet;
                this.ddl_estado.DataTextField = vo_dataSet.Tables[0].Columns["descripcion"].ColumnName.ToString();
                this.ddl_estado.DataValueField = vo_dataSet.Tables[0].Columns["PK_estado"].ColumnName.ToString();
                this.ddl_estado.DataBind();
            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al cargar los estados del proyecto.", po_exception);
            }

        }

        /// <summary>
        /// Hace un buscar de la lista de permisos.
        /// </summary>
        /// <param name="psFilter">String filtro.</param>
        private void llenarGridViewFilter(String psFilter)
        {
            try
            {
                //this.grd_listaActividades.Columns[0].Visible = true;
                //this.grd_listaActividades.DataSource = cls_gestorActividadResp.listarActividadFiltro(psFilter);
                //this.grd_listaActividades.DataBind();
                //this.grd_listaActividades.Columns[0].Visible = false;
            }
            catch (Exception po_exception)
            {
                String vs_error_usuario = "Ocurrió un error llenando la tabla con filtro.";
                this.lanzarExcepcion(po_exception, vs_error_usuario);
            }
        }

        /// <summary>
        /// Crea un objeto de tipo
        /// cls_actividadResp con la informacón
        /// que se encuentra en el formulario
        /// web
        /// </summary>
        /// <returns>cls_actividadResp</returns>
        private cls_asignacionActividad crearObjeto()
        {
            cls_asignacionActividad vo_asignacionActividad = new cls_asignacionActividad();
            //if (cls_variablesSistema.tipoEstado != cls_constantes.AGREGAR)
            //{
            //    vo_actividad = (cls_asignacionActividad)cls_variablesSistema.obj;
            //}
            try
            {
                //vo_asignacionActividad = (cls_asignacionActividad)cls_variablesSistema.vs_proyecto.pAsignacionLista.Find(test => test.pPK_Actividad == Convert.ToInt32(hdn_codigoActividad.Value));

                vo_asignacionActividad.pDescripcion = txt_descripcion.Text;
                vo_asignacionActividad.pFechaInicio = Convert.ToDateTime(txt_fechaInicio.Text);
                vo_asignacionActividad.pFechaFin = Convert.ToDateTime(txt_fechaFin.Text);
                vo_asignacionActividad.pHorasAsignadas = Convert.ToInt32(txt_horasAsignadas.Text);
                vo_asignacionActividad.pHorasAsigDefectos = Convert.ToInt32(txt_horasAsigDefectos.Text);
                vo_asignacionActividad.pHorasReales = Convert.ToInt32(txt_horasReales.Text);
                vo_asignacionActividad.pHorasRealesDefectos = Convert.ToInt32(txt_horasRealesDef.Text);
                vo_asignacionActividad.pEstado.pPK_estado = Convert.ToInt32(ddl_estado.SelectedValue);

                return vo_asignacionActividad;
            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al crear el objeto para guardar el registro.", po_exception);
            }
        }

        /// <summary>
        /// Método que carga la información
        /// de un permiso.
        /// </summary>
        private void cargarObjeto()
        {
            cls_asignacionActividad vo_actividad = null;

            try
            {
                vo_actividad = (cls_asignacionActividad)cls_variablesSistema.obj;
                this.txt_descripcion.Text = vo_actividad.pDescripcion;
                this.txt_fechaInicio.Text = vo_actividad.pFechaInicio.ToShortDateString();
                this.txt_fechaFin.Text = vo_actividad.pFechaFin.ToShortDateString(); ;
                this.txt_horasAsignadas.Text = vo_actividad.pHorasAsignadas.ToString();
                this.txt_horasAsigDefectos.Text = vo_actividad.pHorasAsigDefectos.ToString();
                this.txt_horasReales.Text = vo_actividad.pHorasReales.ToString();
                this.txt_horasRealesDef.Text = vo_actividad.pHorasRealesDefectos.ToString();
                this.ddl_estado.SelectedValue = vo_actividad.pFK_Estado.ToString();

                if (cls_variablesSistema.tipoEstado == cls_constantes.VER)
                {
                    this.habilitarControles(false);
                }
                else
                {
                    this.habilitarControles(true);
                }
            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al cargar el registro.", po_exception);
            } 

        }

        /// <summary>
        /// Método que elimina un permiso
        /// </summary>
        /// <param name="po_actividad">Permiso a eliminar</param>
        private void eliminarDatos(cls_asignacionActividad po_actividad)
        {
            try
            {
                cls_gestorAsignacionActividad.deleteActividad(po_actividad);

                this.inicializarRegistros();

                this.upd_Principal.Update();
            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error eliminando la actividad.", po_exception);
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
            cls_asignacionActividad vo_asignacionActividad = this.crearObjeto();
            try
            {
                //switch (cls_variablesSistema.tipoEstado)
                switch (cls_constantes.AGREGAR)
                {
                    case cls_constantes.AGREGAR:
                        vi_resultado = cls_gestorAsignacionActividad.insertActividad(vo_asignacionActividad);
                        break;
                    case cls_constantes.EDITAR:
                        vi_resultado = cls_gestorAsignacionActividad.updateActividad(vo_asignacionActividad);
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
        /// Método que limpia la información
        /// existente en los diferentes
        /// controles del formulario web
        /// </summary>
        private void limpiarCampos()
        {
            this.txt_descripcion.Text = String.Empty;
            this.txt_fechaInicio.Text = String.Empty;
            this.txt_fechaFin.Text = String.Empty;
            this.txt_horasAsignadas.Text = String.Empty;
            this.txt_horasAsigDefectos.Text = String.Empty;
            this.txt_horasReales.Text = String.Empty;
            this.txt_horasRealesDef.Text = String.Empty;
            this.ddl_estado.SelectedIndex = -1;
        }

        /// <summary>
        /// Método que habilita o 
        /// deshabilita los controles del
        /// formulario web.
        /// </summary>
        /// <param name="pb_habilitados"></param>
        private void habilitarControles(bool pb_habilitados)
        {
            this.txt_descripcion.Enabled = pb_habilitados;
            this.txt_fechaInicio.Enabled = pb_habilitados;
            this.txt_fechaFin.Enabled = pb_habilitados;
            this.txt_horasAsignadas.Enabled = pb_habilitados;
            this.txt_horasAsigDefectos.Enabled = pb_habilitados;
            this.txt_horasReales.Enabled = pb_habilitados;
            this.txt_horasRealesDef.Enabled = pb_habilitados;
            this.ddl_estado.Enabled = pb_habilitados;
            this.btn_guardar.Visible = pb_habilitados;

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

        #endregion

        #region Eventos

        /// <summary>
        /// Evento q asigna el nuevo valor del dropdown list de estados cuando se modifica el proyecto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ddl_estado.Text = ((DropDownList)sender).SelectedValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlPaquete_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ddl_paquete.SelectedValue = ((DropDownList)sender).SelectedValue;

            cargarActividadesProyecto(Convert.ToInt32(ddl_paquete.SelectedValue));

        }

        /// <summary>
        /// Agrega un nuevo permiso.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_eliminar_Click(object sender, EventArgs e)
        {

            try
            {
                cls_variablesSistema.tipoEstado = cls_constantes.AGREGAR;

                this.limpiarCampos();

                this.habilitarControles(true);

                this.upd_Principal.Update();

                this.ard_principal.SelectedIndex = 1;
            }
            catch (Exception po_exception)
            {
                String vs_error_usuario = "Ocurrió un error al intentar mostrar la ventana de edición para los registros.";
                this.lanzarExcepcion(po_exception, vs_error_usuario);
            } 

        }

        /// <summary>
        /// Evento que se ejecuta cuando se 
        /// guarda un nuevo rol.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.guardarDatos();

                this.inicializarRegistros();

                this.limpiarCampos();

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
        protected void btn_regresar_Click(object sender, EventArgs e)
        {
            try
            {
                // Do something with the click ...
                Response.Redirect("frw_proyectos.aspx", false);
            }
            catch (Exception po_exception)
            {
                String vs_error_usuario = "Ocurrió un error al cancelar la operación.";
                this.lanzarExcepcion(po_exception, vs_error_usuario);
            } 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_asignarUsuario_Click(object sender, EventArgs e)
        {
            for (int i = lbx_actividades.Items.Count - 1; i >= 0; i--)
            {
                if (lbx_actividades.Items[i].Selected == true)
                {
                    cls_actividad vo_actividad = new cls_actividad();
                    vo_actividad.pPK_Actividad = Convert.ToInt32(lbx_actividades.Items[i].Value.ToString());
                    vo_actividad.pNombre = lbx_actividades.Items[i].Text.ToString();

                    for (int j = lbx_usuarios.Items.Count - 1; j >= 0; j--)
                    {
                        if (lbx_usuarios.Items[j].Selected == true)
                        {
                            cls_usuario vo_usuario = new cls_usuario();
                            vo_usuario.pPK_usuario = lbx_usuarios.Items[j].Value.ToString();
                            vo_usuario.pNombre = lbx_usuarios.Items[j].Text.ToString();

                            foreach (cls_asignacionActividad asigAct in cls_variablesSistema.vs_proyecto.pAsignacionLista)
                            {
                                if (asigAct.pPK_Actividad == vo_actividad.pPK_Actividad)
                                {
                                    asigAct.pPK_Usuario = vo_usuario.pPK_usuario;

                                    //hdn_codigoActividad.Value = vo_actividad.pPK_Actividad.ToString();
                                    //txt_actividad.Text = vo_actividad.pNombre;
                                    //hdn_codigoUsuario.Value = vo_usuario.pPK_usuario;
                                    //txt_usuario.Text = vo_usuario.pNombre;

                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_removerUsuario_Click(object sender, EventArgs e)
        {
            
        }

        #endregion


    }
}