using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using COSEVI.CSLA.lib.accesoDatos.mod.Administracion;
using COSEVI.CSLA.lib.entidades.mod.Administracion;

using CSLA.web.App_Variables;
using CSLA.web.App_Constantes;


namespace CSLA.web.App_pages.mod.Administracion
{
    public partial class frw_permisosLista1 : System.Web.UI.Page
    {
        #region Atributos

        /// <summary>
        /// Almacena el modo o acción que se ejecuta en la página.
        /// </summary>
        private string modo;

        /// <summary>
        /// Código del permiso que se envía a la página.
        /// </summary>
        private string permiso;

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
            if (!IsPostBack)
            {
                this.inicializarDatos();

                this.registrarScriptsControles();
            }
        }

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

                if (!String.IsNullOrEmpty(this.modo))
                {

                    this.generarAcccion();
                }
                else
                {
                    this.llenarGridView();
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Función OnInit, se
        /// ejecuta de primero en toda la página
        /// en caso de que sea necesario realizar
        /// alguna inicialización adicional.
        /// </summary>
        /// <param name="e">EventArgs evento asociado.</param>
        protected override void OnInit(EventArgs e)
        {

            base.OnInit(e);
            //this.srp_man.RegisterAsyncPostBackControl(this.grd_listaPermisos);
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Obtiene los parámetros de la url.
        /// </summary>
        private void obtenerParametrosURL()
        {
            this.modo = Request.QueryString[cls_constantes.MODO];
            this.permiso = Request.QueryString[cls_constantes.PERMISO];
        }

        /// <summary>
        /// Método que se encarga de 
        /// llenar la información del
        /// grid view
        /// </summary>
        private void llenarGridView()
        {
            try
            {
                this.grd_listaPermisos.Columns[0].Visible = true;
                this.grd_listaPermisos.DataSource = cls_gestorPermiso.listarPermiso();
                this.grd_listaPermisos.DataBind();
            }
            catch (Exception)
            {
            }
        }




        /// <summary>
        /// Método que elimina un permiso
        /// </summary>
        /// <param name="po_permiso">Permiso a eliminar</param>
        private void eliminarDatos(cls_permiso po_permiso)
        {
            try
            {
                cls_gestorPermiso.deletePermiso(po_permiso);

                this.llenarGridView();

                this.upd_panel.Update();
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Registra los scrupts de lado del cliente para
        /// que se realicen una serie de eventos que son
        /// necesarios para que la página no se refreque del todo.
        /// </summary>
        public void registrarScriptsControles()
        {
            //Se registra el onclick para el boton de agregar.
            this.btn_agregar.Attributes["onclick"] = this.devolverFuncion("/App_pages/mod.Administracion/frw_permisosMant.aspx", "", cls_constantes.AGREGAR);
        }

        #endregion

        #region Eventos

        protected void btn_buscar_Click(object sender, EventArgs e)
        {

        }

        protected void grd_listaPermisos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                this.grd_listaPermisos.PageIndex = e.NewPageIndex;
                this.btn_agregar.Text = "funciona";
                this.upd_panel.Update();
            }
            catch (Exception)
            {

            }
        }

        protected void grd_listaPermisos_Sorting(object sender, GridViewSortEventArgs e)
        {
            this.btn_agregar.Text = "funciona";
            this.upd_panel.Update();

        }

        /// <summary>
        /// Dependiendo del parámetro "modo",
        /// se ejecuta la acción correspondiente.
        /// </summary>
        private void generarAcccion()
        {

            try
            {
                cls_permiso vo_permiso = new cls_permiso();

                vo_permiso.pPK_permiso = Convert.ToInt32(this.permiso);

                switch (this.modo)
                {
                    case cls_constantes.VER:
                        vo_permiso = cls_gestorPermiso.selecionarPermiso(vo_permiso);

                        cls_variablesSistema.obj = vo_permiso;

                        cls_variablesSistema.tipoEstado = this.modo;

                        break;

                    case cls_constantes.EDITAR:
                        vo_permiso = cls_gestorPermiso.selecionarPermiso(vo_permiso);

                        cls_variablesSistema.obj = vo_permiso;

                        cls_variablesSistema.tipoEstado = this.modo;

                        break;

                    case cls_constantes.ELIMINAR:
                        this.eliminarDatos(vo_permiso);
                        break;

                    default:
                        break;
                }

            }
            catch (Exception)
            {

            }

        }

        /// <summary>
        /// Se elimina esta función
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grd_listaPermisos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int vi_indice = Convert.ToInt32(e.CommandArgument);

                GridViewRow vu_fila = this.grd_listaPermisos.Rows[vi_indice];

                cls_permiso vo_permiso = new cls_permiso();

                vo_permiso.pPK_permiso = Convert.ToInt32(vu_fila.Cells[0].Text.ToString());

                switch (e.CommandName.ToString())
                {
                    case cls_constantes.VER:
                        vo_permiso = cls_gestorPermiso.selecionarPermiso(vo_permiso);

                        cls_variablesSistema.obj = vo_permiso;

                        cls_variablesSistema.tipoEstado = e.CommandName;

                        //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "", enviarEdit(), false);

                        ImageButton button = sender as ImageButton;

                        break;

                    case cls_constantes.EDITAR:
                        vo_permiso = cls_gestorPermiso.selecionarPermiso(vo_permiso);

                        cls_variablesSistema.obj = vo_permiso;

                        cls_variablesSistema.tipoEstado = e.CommandName;

                        break;

                    case cls_constantes.ELIMINAR:
                        this.eliminarDatos(vo_permiso);
                        break;

                    default:
                        break;
                }

            }
            catch (Exception)
            {

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

            if (ps_modo == cls_constantes.ELIMINAR)
            {
                vs_function = "return deleteRow('" + ps_url + "','" + vs_param + "');";
            }
            else
            {
                vs_function = "return loadPage('" + ps_url + "','" + vs_param + "');";
            }

            return vs_function;
        }

        #endregion

        protected void srp_man_AsyncPostBackError(object sender, AsyncPostBackErrorEventArgs e)
        {


            if (e.Exception.Data["ExtraInfo"] != null)
            {
                this.srp_man.AsyncPostBackErrorMessage =
                    e.Exception.Message +
                    e.Exception.Data["ExtraInfo"].ToString();
            }
            else
            {
                srp_man.AsyncPostBackErrorMessage =
                    "An unspecified error occurred.";
            }

        }
    }
}