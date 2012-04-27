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

using CSLA.web.App_Variables;
using CSLA.web.App_Constantes;
using System.Text;

namespace CSLA.web.App_pages.mod.ControlSeguimiento
{
    public partial class frm_registroTiempos : System.Web.UI.Page
    {
        #region Inicilizacion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.cargarObjetoSegunUrl();
                this.cargarValores();
            }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Carga los valores enviados
        /// por la url.
        /// </summary>
        private void cargarObjetoSegunUrl()
        {
            try
            {

                string vs_actividad = Request.QueryString["act"].ToString();
                string vs_proyecto = Request.QueryString["pro"].ToString();
                string vs_registro = Request.QueryString["reg"].ToString();
                string vs_fecha = Request.QueryString["fech"].ToString();

                string vs_paquete = Request.QueryString["paq"] == null ? "" : Request.QueryString["paq"].ToString();
                string vs_componente = Request.QueryString["comp"] == null ? "" : Request.QueryString["comp"].ToString();
                string vs_entregable = Request.QueryString["ent"] == null ? "" : Request.QueryString["ent"].ToString();

                //Se cargan los datos
                if (vs_proyecto == COSEVI.CSLA.lib.accesoDatos.App_Constantes.cls_constantes.CODIGO_IMPREVISTO.ToString() ||
                    vs_proyecto == COSEVI.CSLA.lib.accesoDatos.App_Constantes.cls_constantes.CODIGO_OPERACION.ToString() ||
                    vs_paquete == COSEVI.CSLA.lib.accesoDatos.App_Constantes.cls_constantes.CODIGO_INVALIDO.ToString())
                {
                    this.cargarOperacion(vs_actividad, vs_proyecto, vs_registro, vs_fecha);
                }
                else
                {
                    this.cargarActividad(vs_actividad, vs_paquete, vs_componente, vs_entregable, vs_proyecto, vs_registro, vs_fecha);
                }

            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Carga un registro de tipo operación.
        /// </summary>
        /// <param name="ps_actividad">String código</param>
        /// <param name="ps_proyecto">String proyecto.</param>
        /// <param name="ps_registro">String registro</param>
        /// <param name="ps_fecha">String fecha.</param>
        private void cargarOperacion(string ps_actividad, string ps_proyecto, string ps_registro, string ps_fecha)
        {
            cls_registroOperacion vo_registro;
            cls_operacion vo_operacion;
            cls_asignacionOperacion vo_asignacion;

            try
            {
                vo_registro = new cls_registroOperacion();


                vo_operacion = new cls_operacion();
                vo_operacion.pPK_Codigo = ps_actividad;
                vo_operacion = cls_gestorOperacion.seleccionarOperacion(vo_operacion);
                vo_operacion.pFK_Proyecto = Convert.ToInt32(ps_proyecto);

                vo_asignacion = new cls_asignacionOperacion();
                vo_asignacion.pFK_Operacion = vo_operacion;
                vo_asignacion.pFK_Usuario = cls_interface.vs_usuarioActual;

                vo_registro = new cls_registroOperacion();
                vo_registro.pFK_Asignacion = vo_asignacion;
                vo_registro.pFecha = Convert.ToDateTime(ps_fecha);

                if (String.IsNullOrEmpty(ps_registro))
                {
                    vo_registro.pHoras = 0;
                    vo_registro.pComentario = String.Empty;
                }
                else
                {
                    vo_registro.pPK_registro = Convert.ToDecimal(ps_registro);
                    cls_gestorRegistroOperacion.seleccionarRegistroOperacion(vo_registro);
                }

              

                cls_variablesSistema.obj = vo_registro;

            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Carga la instancia del
        /// registro de la asignación
        /// </summary>
        /// <param name="ps_actividad">String código actividad.</param>
        /// <param name="ps_paquete">String código paquete.</param>
        /// <param name="ps_componente">String código componente.</param>
        /// <param name="ps_entregable">String código entregable.</param>
        /// <param name="ps_proyecto">String código proyecto.</param>
        /// <param name="ps_registro">String código de registro.</param>
        /// <param name="ps_fecha">DateTime Fecha.</param>
        private void cargarActividad(string ps_actividad,
                                     string ps_paquete,
                                     string ps_componente,
                                     string ps_entregable,
                                     string ps_proyecto,
                                     string ps_registro,
                                     string ps_fecha)
        {
            cls_registroActividad vo_registro;
            cls_actividad vo_actividad;
            cls_asignacionActividad vo_asignacion;

            try
            {
                vo_registro = new cls_registroActividad();


                vo_actividad = new cls_actividad();
                vo_actividad.pPK_Actividad = Convert.ToInt32(ps_actividad);
                vo_actividad = cls_gestorActividad.seleccionarActividad(vo_actividad);


                vo_asignacion = new cls_asignacionActividad();
                vo_asignacion.pActividad = vo_actividad;
                vo_asignacion.pPK_Componente = Convert.ToInt32(ps_componente);
                vo_asignacion.pPK_Entregable = Convert.ToInt32(ps_entregable);
                vo_asignacion.pPK_Paquete = Convert.ToInt32(ps_paquete);
                vo_asignacion.pPK_Actividad = vo_actividad.pPK_Actividad;
                vo_asignacion.pPK_Proyecto = Convert.ToInt32(ps_proyecto);
                vo_asignacion.pPK_Usuario = cls_interface.vs_usuarioActual;

                vo_registro = new cls_registroActividad();
                vo_registro.pAsignacion = vo_asignacion;
                vo_registro.pFecha = Convert.ToDateTime(ps_fecha);

                if (String.IsNullOrEmpty(ps_registro))
                {
                    vo_registro.pHoras = 0;
                    vo_registro.pComentario = String.Empty;
                }
                else
                {
                    vo_registro.pRegistro = Convert.ToDecimal(ps_registro);
                    cls_gestorRegistroActividad.seleccionarRegistroActividad(vo_registro);
                }

                cls_variablesSistema.obj = vo_registro;

            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Se cargan los
        /// valores en los campos.
        /// </summary>
        private void cargarValores()
        {
            cls_registroOperacion vo_registro = null;

            try
            {
                if (cls_variablesSistema.obj != null)
                {

                    if (cls_variablesSistema.obj.GetType().Name == "cls_registroOperacion")
                    {
                        vo_registro = (cls_registroOperacion)cls_variablesSistema.obj;

                        cls_proyecto vo_proyecto = new cls_proyecto();
                        vo_proyecto.pPK_proyecto = vo_registro.pFK_Asignacion.pFK_Operacion.pFK_Proyecto;

                        if (vo_proyecto.pPK_proyecto == COSEVI.CSLA.lib.accesoDatos.App_Constantes.cls_constantes.CODIGO_IMPREVISTO)
                        {
                            this.lblProyectoValor.Text = COSEVI.CSLA.lib.accesoDatos.App_Constantes.cls_constantes.NOMBRE_IMPREVISTO;
                        }
                        else if (vo_proyecto.pPK_proyecto == COSEVI.CSLA.lib.accesoDatos.App_Constantes.cls_constantes.CODIGO_OPERACION)
                        {
                            this.lblProyectoValor.Text = COSEVI.CSLA.lib.accesoDatos.App_Constantes.cls_constantes.NOMBRE_OPERACION;
                        }
                        else
                        {
                            vo_proyecto = cls_gestorProyecto.seleccionarProyectos(vo_proyecto);
                            this.lblProyectoValor.Text = vo_proyecto.pNombre;
                        }

                        this.lblDiaValor.Text = vo_registro.pFecha.ToString("dddd, dd MMMM yyyy");
                        this.lblActividadValor.Text = vo_registro.pFK_Asignacion.pFK_Operacion.pDescripcion;
                        this.txtHoras.Text = vo_registro.pHoras.ToString();
                        this.txtComentarios.Text = vo_registro.pComentario;
                    }
                    else
                    {
                        this.cargaValoresActividad();
                    }

                }
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Carga los valores de la actividad
        /// en los controles de la ventana.
        /// </summary>
        private void cargaValoresActividad()
        {
            cls_registroActividad vo_registro = null;

            vo_registro = cls_variablesSistema.obj as cls_registroActividad;

            cls_proyecto vo_proyecto = new cls_proyecto();
            vo_proyecto.pPK_proyecto = vo_registro.pAsignacion.pPK_Proyecto;

            vo_proyecto = cls_gestorProyecto.seleccionarProyectos(vo_proyecto);
            this.lblProyectoValor.Text = vo_proyecto.pNombre;

            this.lblDiaValor.Text = vo_registro.pFecha.ToString("dddd, dd MMMM yyyy");
            this.lblActividadValor.Text = vo_registro.pAsignacion.pActividad.pDescripcion;
            this.txtHoras.Text = vo_registro.pHoras.ToString();
            this.txtComentarios.Text = vo_registro.pComentario;
        }

        /// <summary>
        /// Se cargan los valores de los controles
        /// en la instancia.
        /// </summary>
        private void cargarValoresInstancia()
        {
            try
            {
                if (cls_variablesSistema.obj != null && cls_variablesSistema.obj.GetType().Name == "cls_registroOperacion")
                {
                    cls_registroOperacion vo_registro = (cls_registroOperacion)cls_variablesSistema.obj;

                    vo_registro.pHoras = Convert.ToDecimal(this.txtHoras.Text);
                    vo_registro.pComentario = this.txtComentarios.Text;
                }
                else
                {
                    cls_registroActividad vo_registro = cls_variablesSistema.obj as cls_registroActividad;

                    vo_registro.pHoras = Convert.ToDecimal(this.txtHoras.Text);
                    vo_registro.pComentario = this.txtComentarios.Text;
                }

            }
            catch (Exception)
            {
            }
        }

        #endregion


        #region Eventos

        /// <summary>
        /// Evento que se ejecuta cuando se graba el registro
        /// de tiempo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.cargarValoresInstancia();

                if (cls_variablesSistema.obj != null && cls_variablesSistema.obj.GetType().Name == "cls_registroOperacion")
                {
                    cls_registroOperacion vo_registro = (cls_registroOperacion)cls_variablesSistema.obj;

                    //Si es nulo o vacío se debe insertar
                    if (vo_registro.pPK_registro == 0)
                    {
                        cls_gestorRegistroOperacion.insertRegistroOperacion(vo_registro);
                    }
                    else
                    {
                        cls_gestorRegistroOperacion.updateRegistroOperacion(vo_registro);
                    }

                }
                else
                {
                    cls_registroActividad vo_registro = (cls_registroActividad)cls_variablesSistema.obj;

                    //Si es nulo o vacío se debe insertar
                    if (vo_registro.pRegistro == 0)
                    {
                        cls_gestorRegistroActividad.insertRegistroActividad(vo_registro);
                    }
                    else
                    {
                        cls_gestorRegistroActividad.updateRegistroActividad(vo_registro);
                    }
                }

                StringBuilder script = new StringBuilder();

                script.Append("<script> alert(\"Se ha grabado con éxito el registro de tiempos\"); </script>");

                ClientScript.RegisterClientScriptBlock(GetType(), "Grabado", script.ToString(), false);

                //ClientScript.RegisterStartupScript(GetType(), "Grabado",
                //    "<script> alert('Se ha grabado con éxito el registro de tiempos'); </script>"
                //    , false);
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region Propiedades

        #endregion
    }
}