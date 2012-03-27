using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using COSEVI.CSLA.lib.accesoDatos.mod.Administracion;
using COSEVI.CSLA.lib.entidades.mod.Administracion;

using CSLA.web.App_Variables;
using CSLA.web.App_Constantes;

// =========================================================================
// COSEVI - Consejo de Seguridad Vial. - 2011
// Sistema CSLA (Sistema para el Control y Seguimiento de Labores)
//
// frw_permisosMant.aspx.cs
//
// Explicación de los contenidos del archivo.
// =========================================================================
// Historial
// PERSONA 			        MES – DIA - AÑO		DESCRIPCIÓN
// Esteban Ramírez Gónzalez  	05 – 06  - 2011	 	Se crea la clase
//								…………………………………………………………
//								…………………………………………………………
// 
//								
//								
//
// =========================================================================

namespace CSLA.web.App_pages.mod.Administracion
{
    public partial class frw_permisosMant : System.Web.UI.Page
    {
        #region Atributos

        private string modo;

        #endregion

        #region Inicializacion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.inicializarDatos();

                this.guardarDatos();
            }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Incializa la información del grid
        /// dependiendo de si la página trae el 
        /// parámetro de "modo" en su url.
        /// </summary>
        private void inicializarDatos()
        {
            try
            {

                this.obtenerParametrosURL();

                if (!String.IsNullOrEmpty(this.modo) && String.IsNullOrEmpty(Request.QueryString[cls_constantes.PERMISONOMBRE]))
                {
                    //Se craga la información del permiso.
                    this.cargarObjeto();
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Obtiene los parámetros de la url.
        /// </summary>
        private void obtenerParametrosURL()
        {
            this.modo = Request.QueryString[cls_constantes.MODO];
            cls_variablesSistema.tipoEstado = Request.QueryString[cls_constantes.MODO];
            this.hdf_codigo.Value = Request.QueryString[cls_constantes.PERMISO];
            this.hdf_modo.Value = Request.QueryString[cls_constantes.MODO];
            
            

            this.txt_nombre.Text = Request.QueryString[cls_constantes.PERMISONOMBRE];
        }


        /// <summary>
        /// Método que limpia la información
        /// existente en los diferentes
        /// controles del formulario web
        /// </summary>
        private void limpiarCampos()
        {
            this.txt_nombre.Text = String.Empty;
        }

        /// <summary>
        /// Método que carga la información
        /// de un permiso.
        /// </summary>
        private void cargarObjeto()
        {
            cls_permiso vo_permiso = null;

            try
            {
                vo_permiso = new cls_permiso();
                vo_permiso.pPK_permiso = Convert.ToInt32(this.hdf_codigo.Value);

                vo_permiso = cls_gestorPermiso.selecionarPermiso(vo_permiso);

                this.txt_nombre.Text = vo_permiso.pNombre;

                switch (cls_variablesSistema.tipoEstado)
                {

                    case cls_constantes.AGREGAR:
                    case cls_constantes.EDITAR:
                        this.habilitarControles(true);
                        break;
                    case cls_constantes.VER:
                        this.habilitarControles(false);
                        break;
                }
            }
            catch (Exception)
            {
            }

        }

        /// <summary>
        /// Método que habilita o 
        /// deshabilita los controles del
        /// formulario web.
        /// </summary>
        /// <param name="pb_habilitados"></param>
        private void habilitarControles(bool pb_habilitados)
        {
            string mostrar = pb_habilitados ? "'always'" : "'none'";

            this.txt_nombre.Enabled = pb_habilitados;

            //Se deshabilita el control de botón guardar.

            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "deshabilitar",
                     "<script language=javascript>" +
                     "botonGuardar = document.getElementById('btn_guardar');" +
                     "botonGuardar.style.display=" + mostrar + ";" + 
                     "</script>");
        }

        /// <summary>
        /// Guarda la información se que se encuentra
        /// en el formalario Web, ya sea
        /// para ingresar o actualizarla
        /// </summary>
        /// <returns>Int valor devuelvo por el motor de bases de datos</returns>
        private int guardarDatos()
        {
            int vi_resultado = 1;
            cls_permiso vo_permiso = this.crearObjeto();
            try
            {
                if (!String.IsNullOrEmpty(Request.QueryString[cls_constantes.PERMISONOMBRE]))
                {
                    switch (this.hdf_modo.Value)
                    {
                        case cls_constantes.AGREGAR:
                            vi_resultado = cls_gestorPermiso.insertPermiso(vo_permiso);
                            break;
                        case cls_constantes.EDITAR:
                            vi_resultado = cls_gestorPermiso.updatePermiso(vo_permiso);
                            break;
                        default:
                            break;
                    }

                    this.ClientScript.RegisterClientScriptBlock(this.GetType(), "frw_permisosLista",
                       "<script language=javascript>" +
                       "alert('Se ha guadado con éxito.');" +
                       "</script>");

                }

                return vi_resultado;
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Crea un objeto de tipo
        /// cls_permiso con la informacón
        /// que se encuentra en el formalario
        /// web
        /// </summary>
        /// <returns>cls_permiso</returns>
        private cls_permiso crearObjeto()
        {
            cls_permiso vo_permiso = new cls_permiso();
            if (cls_variablesSistema.tipoEstado != cls_constantes.AGREGAR)
            {
                vo_permiso.pPK_permiso = Convert.ToInt32(this.hdf_codigo.Value);
            }
            try
            {
                vo_permiso.pNombre = txt_nombre.Text;
                return vo_permiso;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Función en cargada de crear el código en JS
        /// que permite pasar de una página a otra, enviándo
        /// los parámetros y utilizando AJAX.
        /// </summary>
        /// <param name="ps_url"></param>
        /// <param name="ps_permiso"></param>
        /// <param name="ps_modo"></param>
        /// <returns></returns>
        public string devolverFuncion(string ps_url, string ps_permiso, string ps_modo)
        {
            string vs_function = string.Empty;

            string vs_param = "permiso=" + ps_permiso + "&modo=" + ps_modo;

            vs_function = "return loadPage('" + ps_url + "','" + vs_param + "');";

            return vs_function;
        }

        #endregion

        #region Eventos

        #endregion

    }
}