using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using COSEVI.CSLA.lib.accesoDatos.App_InterfaceComunes;
using ExceptionManagement.Exceptions;
using COSEVI.CSLA.lib.entidades.mod.Administracion;
using COSEVI.CSLA.lib.accesoDatos.mod.Administracion;

using CSLA.web.App_Variables;
using CSLA.web.App_Constantes;


// =========================================================================
// COSEVI - Consejo de Seguridad Vial. - 2011
// Sistema CSLA (Sistema para el Control y Seguimiento de Labores)
//
// frw_permiso.aspx.cs
//
// Explicación de los contenidos del archivo.
// =========================================================================
// Historial
// PERSONA 			        MES – DIA - AÑO		DESCRIPCIÓN
// Esteban Ramírez Gónzalez  	03 – 06  - 2011	 	Se crea la clase
// Esteban Ramírez Gónzalez  	26 – 08  - 2011	 	Se crea la clase
//								…………………………………………………………
//								…………………………………………………………
// 
//								
//								
//
// =========================================================================

namespace CSLA.web.App_pages.mod.Administracion
{
    public partial class frw_bitacora : System.Web.UI.Page
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
                    this.llenarGridView();
                }
                catch (Exception po_exception)
                {
                    String vs_error_usuario = "Error al inicializar la consulta de bitácora.";
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
                this.btn_agregar = (Button)acp_listadoDatos.FindControl("btn_agregar");
                this.ucSearchBitacora.SearchClick += new COSEVI.web.controls.ucSearch.searchClick(this.ucSearchBitacora_searchClick);

                //Se agregan los filtros.
                this.agregarItemListFiltro();

            }
            catch (Exception po_exception)
            {
                String vs_error_usuario = "Ocurrió un error inicializando los controles del mantenimiento.";
                this.lanzarExcepcion(po_exception, vs_error_usuario);
            } 
        }

        /// <summary>
        /// Agrega los filtros para el control de búsqueda.
        /// </summary>
        private void agregarItemListFiltro()
        {

            this.ucSearchBitacora.LstCollecction.Add(new ListItem("Bitacora", "PK_bitacora"));
            this.ucSearchBitacora.LstCollecction.Add(new ListItem("Departamento", "FK_departamento"));
            this.ucSearchBitacora.LstCollecction.Add(new ListItem("Usuario", "FK_usuario"));
            this.ucSearchBitacora.LstCollecction.Add(new ListItem("Accion", "accion"));
            this.ucSearchBitacora.LstCollecction.Add(new ListItem("Fecha", "fecha_accion"));
            this.ucSearchBitacora.LstCollecction.Add(new ListItem("Numero", "numero_registro"));
            this.ucSearchBitacora.LstCollecction.Add(new ListItem("Tabla", "tabla"));
            this.ucSearchBitacora.LstCollecction.Add(new ListItem("Maquina", "maquina"));
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Método que se encarga de 
        /// llenar la información del
        /// grid view
        /// </summary>
        private void llenarGridView()
        {
            try
            {
                this.grd_listaBitacora.Columns[0].Visible = true;
                this.grd_listaBitacora.DataSource = cls_gestorBitacora.listarBitacora();
                this.grd_listaBitacora.DataBind();
                this.grd_listaBitacora.Columns[0].Visible = false;
            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error llenando la tabla.", po_exception);
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
                this.grd_listaBitacora.Columns[0].Visible = true;
                this.grd_listaBitacora.DataSource = cls_gestorBitacora.listarBitacoraFiltro(psFilter);
                this.grd_listaBitacora.DataBind();
                this.grd_listaBitacora.Columns[0].Visible = false;
            }
            catch (Exception po_exception)
            {
                String vs_error_usuario = "Ocurrió un error llenando la tabla con filtro.";
                this.lanzarExcepcion(po_exception, vs_error_usuario);
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

        #endregion

        #region Eventos

        /// <summary>
        /// Busca un rol según el filtro.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="value"></param>
        /// <param name="seletecItem"></param>
        protected void ucSearchBitacora_searchClick(object sender, EventArgs e, string value, ListItem seletecItem)
        {
            this.llenarGridViewFilter(this.ucSearchBitacora.Filter); 

        }

        /// <summary>
        /// Evento que se ejecuta cuando se le da
        /// en el botón de cancelar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    this.habilitarControles(true);

            //    this.limpiarCampos();

            //    this.upd_Principal.Update();

            //    this.ard_principal.SelectedIndex = 0;
            //}
            //catch (Exception po_exception)
            //{
            //    String vs_error_usuario = "Ocurrió un error al cancelar la operación.";
            //    this.lanzarExcepcion(po_exception, vs_error_usuario);
            //} 
        }

        /// <summary>
        /// Cambiar de índice de página.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grd_listaBitacora_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {          
                this.grd_listaBitacora.PageIndex = e.NewPageIndex;
                this.llenarGridView();
                this.upd_Principal.Update();
            }
            catch (Exception po_exception)
            {
                String vs_error_usuario = "Ocurrió un error al realizar el listado de la bitácora.";
                this.lanzarExcepcion(po_exception, vs_error_usuario);
            } 
        }

        #endregion

    }
}