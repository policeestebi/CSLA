using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
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

namespace CSLA.web.App_pages.mod.ControlSeguimiento
{
    public partial class frm_calendario : System.Web.UI.Page
    {
        #region Inicializacion

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!this.IsPostBack)
            //{
                //this.calendario.poDatos = ObtenerDatos();
                this.InicializarCalendario();
            //}
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Inicializa los datos del calendario.
        /// </summary>
        private void InicializarCalendario()
        {
            try
            {
                this.calendario.poDatosProyecto = this.ObtenerDatosProyectos();
                this.calendario.poDatosRegistro = this.ObtenerListaRegistro(this.ObtenerLunes(this.calendario.FechaLunes),
                                                    ((DataSet)this.calendario.poDatosProyecto).Tables[0].Rows[0][0].ToString()
                                                    );
                this.calendario.poDatosActividades = this.ObtenerListaActividades(((DataSet)this.calendario.poDatosProyecto).Tables[0].Rows[0][0].ToString());
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Obtiene la lista de proyectos.
        /// </summary>
        /// <returns></returns>
        private Object ObtenerDatosProyectos()
        {
            Object vo_datos = null;
            try
            {
                vo_datos = cls_gestorProyecto.listarProyectosUsuarioDataSet();
            }
            catch(Exception)
            {
                vo_datos = null;
            }

            return vo_datos;
        }

        /// <summary>
        /// Inicializa los datos
        /// para cargar las actividades
        /// </summary>
        /// <returns></returns>
        public List<List<String>> ObtenerDatos()
        {
            List<List<String>> datos = null;

            int contador = 0;

            datos = new List<List<string>>();

            while (contador < 20)
            {
                datos.Add(new List<string>() { "Actividad" + contador, "0", "0", "0", "0", "0", "0", "0" });
                contador++;
            }
            return datos;
        }

        /// <summary>
        /// Obtiene los datos del
        /// registro de tiempos de las actividades
        /// </summary>
        /// <param name="pd_fecha"></param>
        /// <param name="ps_proyecto"></param>
        /// <returns></returns>
        private Object ObtenerListaRegistro(DateTime pd_fecha, string ps_proyecto)
        {
            Object datos = null;
            string vs_tipo = string.Empty;
            try
            {
                vs_tipo = ps_proyecto == COSEVI.CSLA.lib.accesoDatos.App_Constantes.cls_constantes.CODIGO_IMPREVISTO.ToString() ? "I" : "O";

                datos = cls_gestorRegistroOperacion.listarOperacionesUsuario(cls_interface.vs_usuarioActual, vs_tipo,this.ConvertirFechaInicioDia(pd_fecha),this.ConvertirFechaInicioDia(pd_fecha.AddDays(6)));
            }
            catch (Exception)
            {
                datos = null;
            }

            return datos;
        }

        /// <summary>
        /// Convierte una fecha a una
        /// fecha a inicio de día.
        /// </summary>
        /// <param name="pd_fecha">DateTime fecha.</param>
        /// <returns>DateTime</returns>
        private DateTime ConvertirFechaInicioDia(DateTime pd_fecha)
        {
            return new DateTime(pd_fecha.Year, pd_fecha.Month, pd_fecha.Day);
        }

        /// <summary>
        /// Obtiene los datos del
        /// registro de tiempos de las actividades
        /// </summary>
        /// <param name="pd_fecha"></param>
        /// <param name="ps_proyecto"></param>
        /// <returns></returns>
        private Object ObtenerListaActividades(string ps_proyecto)
        {
            Object datos = null;
            string vs_tipo = string.Empty;
            try
            {
                vs_tipo = ps_proyecto == COSEVI.CSLA.lib.accesoDatos.App_Constantes.cls_constantes.CODIGO_IMPREVISTO.ToString() ? "I" : "O";

                datos = cls_gestorOperacion.listarOperacionesUsuario(cls_interface.vs_usuarioActual, vs_tipo);
            }
            catch (Exception)
            {
                datos = null;
            }
            return datos;
        }

        /// <summary>
        /// Obtiene el día lunes
        /// de la semana, según una fecha dada.
        /// </summary>
        /// <param name="pd_fecha">Datetime fecha.</param>
        /// <returns>Datetime fecha lunes de esa semana.</returns>
        public DateTime ObtenerLunes(DateTime pd_fecha)
        {
            DateTime vd_fecha = pd_fecha;

            if (pd_fecha.DayOfWeek == DayOfWeek.Monday)
                return pd_fecha;
            else
            {
                while (vd_fecha.DayOfWeek != DayOfWeek.Monday)
                {
                   vd_fecha = vd_fecha.AddDays(-1);
                }
            }

            return vd_fecha;
        }

        #endregion

        #region Eventos

        protected void Unnamed1_voCambioFecha(object sender, DateTime pd_fechaLunes, string proyecto)
        {
            this.calendario.poDatosRegistro = this.ObtenerListaRegistro(this.ObtenerLunes(this.calendario.FechaLunes),
                                                   proyecto
                                                   );
            this.calendario.poDatosActividades = this.ObtenerListaActividades(proyecto);
        }

        #endregion

        #region Propiedades

        #endregion

    }
}