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


// =========================================================================
// COSEVI - Consejo de Seguridad Vial. - 2011
// Sistema CSLA (Sistema para el Control y Seguimiento de Labores)
//
// frw_permiso.aspx.cs
//
// Explicación de los contenidos del archivo.
// =========================================================================
// Historial
// PERSONA 			            MES – DIA - AÑO		DESCRIPCIÓN
// Esteban Ramírez Gónzalez  	03 – 06  - 2011	 	Se crea la clase
// Cristian Arce Jiménez      	29 – 08  - 2011	 	Se crea la clase
// Cristian Arce Jiménez  	    27 – 11  - 2011	 	Se agrega el manejo de excepciones personalizadas
// Cristian Arce Jiménez  	    23 – 01  - 2012	 	Se agrega el manejo de filtros
// 
//								
//								
//
// =========================================================================

namespace CSLA.web.App_pages.mod.ControlSeguimiento
{
    public partial class frw_componentes : System.Web.UI.Page
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
                    String vs_error_usuario = "Error al inicializar el mantenimiento de componentes.";
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
                this.btn_cancelar = (Button)acp_edicionDatos.FindControl("btn_cancelar");
                this.btn_guardar = (Button)acp_edicionDatos.FindControl("btn_guardar");

                this.ucSearchComponente.SearchClick +=new COSEVI.web.controls.ucSearch.searchClick(this.ucSearchComponente_searchClick);

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

            this.ucSearchComponente.LstCollecction.Add(new ListItem("Componente", "PK_componente"));
            this.ucSearchComponente.LstCollecction.Add(new ListItem("Codigo", "codigo"));
            this.ucSearchComponente.LstCollecction.Add(new ListItem("Nombre", "nombre"));
            this.ucSearchComponente.LstCollecction.Add(new ListItem("Descripcion", "descripcion"));
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
                this.grd_listaComponente.Columns[0].Visible = true;
                this.grd_listaComponente.DataSource = cls_gestorComponente.listarComponente();
                this.grd_listaComponente.DataBind();
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
                this.grd_listaComponente.Columns[0].Visible = true;
                this.grd_listaComponente.DataSource = cls_gestorComponente.listarComponenteFiltro(psFilter);
                this.grd_listaComponente.DataBind();
                this.grd_listaComponente.Columns[0].Visible = false;
            }
            catch (Exception po_exception)
            {
                String vs_error_usuario = "Ocurrió un error llenando la tabla con filtro.";
                this.lanzarExcepcion(po_exception, vs_error_usuario);
            }
        }

        /// <summary>
        /// Crea un objeto de tipo
        /// cls_componente con la informacón
        /// que se encuentra en el formulario
        /// web
        /// </summary>
        /// <returns>cls_componente</returns>
        private cls_componente crearObjeto()
        {
            cls_componente vo_componente = new cls_componente();
            if (cls_variablesSistema.tipoEstado != cls_constantes.AGREGAR)
            {
                vo_componente = (cls_componente)cls_variablesSistema.obj;
            }
            try
            {
                vo_componente.pCodigo = txt_codigo.Text;
                vo_componente.pNombre = txt_nombre.Text;
                vo_componente.pDescripcion = txt_descripcion.Text;
                return vo_componente;
            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al crear el objeto para guardar el registro.", po_exception);
            }
        }

        /// <summary>
        /// Método que carga la información
        /// de un componente.
        /// </summary>
        private void cargarObjeto()
        {
            cls_componente vo_componente = null;

            try
            {
                vo_componente = (cls_componente)cls_variablesSistema.obj;
                this.txt_codigo.Text = vo_componente.pCodigo;
                this.txt_nombre.Text = vo_componente.pNombre;
                this.txt_descripcion.Text = vo_componente.pDescripcion;
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
        /// Método que elimina un componente
        /// </summary>
        /// <param name="po_componente">Permiso a eliminar</param>
        private void eliminarDatos(cls_componente po_componente)
        {
            try
            {
                cls_gestorComponente.deleteComponente(po_componente);

                this.llenarGridView();

                this.upd_Principal.Update();
            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error eliminando el componente.", po_exception);
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
            cls_componente vo_componente = this.crearObjeto();
            try
            {
                switch (cls_variablesSistema.tipoEstado)
                {
                    case cls_constantes.AGREGAR:
                        vi_resultado = cls_gestorComponente.insertComponente(vo_componente);
                        break;
                    case cls_constantes.EDITAR:
                        vi_resultado = cls_gestorComponente.updateComponente(vo_componente);
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
            this.txt_codigo.Text = String.Empty;
            this.txt_nombre.Text = String.Empty;
            this.txt_descripcion.Text = String.Empty;
        }

        /// <summary>
        /// Método que habilita o 
        /// deshabilita los controles del
        /// formulario web.
        /// </summary>
        /// <param name="pb_habilitados"></param>
        private void habilitarControles(bool pb_habilitados)
        {
            this.txt_codigo.Enabled = pb_habilitados;
            this.txt_nombre.Enabled = pb_habilitados;
            this.txt_descripcion.Enabled = pb_habilitados;
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
        /// Busca un rol según el filtro.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="value"></param>
        /// <param name="seletecItem"></param>
        protected void ucSearchComponente_searchClick(object sender, EventArgs e, string value, ListItem seletecItem)
        {

            this.llenarGridViewFilter(this.ucSearchComponente.Filter); 

        }

        /// <summary>
        /// Agrega un nuevo componente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_agregar_Click(object sender, EventArgs e)
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

                this.llenarGridView();

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
        protected void btn_cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.habilitarControles(true);

                this.limpiarCampos();

                this.upd_Principal.Update();

                this.ard_principal.SelectedIndex = 0;
            }
            catch (Exception po_exception)
            {
                String vs_error_usuario = "Ocurrió un error al cancelar la operación.";
                this.lanzarExcepcion(po_exception, vs_error_usuario);
            } 
        }

        /// <summary>
        /// Cambiar de índice de página.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grd_listaComponente_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {         
                this.grd_listaComponente.PageIndex = e.NewPageIndex;
                this.llenarGridView();
                this.upd_Principal.Update();
            }
            catch (Exception po_exception)
            {
                String vs_error_usuario = "Ocurrió un error al realizar el listado de componentes.";
                this.lanzarExcepcion(po_exception, vs_error_usuario);
            }
        }

        /// <summary>
        /// Cuando se seleccionada un botón del grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grd_listaComponente_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int vi_indice = Convert.ToInt32(e.CommandArgument);

                GridViewRow vu_fila = this.grd_listaComponente.Rows[vi_indice];

                cls_componente vo_componente = new cls_componente();

                vo_componente.pPK_componente = Convert.ToInt32(vu_fila.Cells[0].Text.ToString());
                vo_componente.pCodigo = vu_fila.Cells[1].Text.ToString();
                vo_componente.pNombre = vu_fila.Cells[2].Text.ToString();
                vo_componente.pDescripcion = vu_fila.Cells[3].Text.ToString();

                switch (e.CommandName.ToString())
                {
                    case cls_constantes.VER:
                        vo_componente = cls_gestorComponente.seleccionarComponente(vo_componente);

                        cls_variablesSistema.obj = vo_componente;

                        cls_variablesSistema.tipoEstado = e.CommandName;

                        this.cargarObjeto();

                        this.ard_principal.SelectedIndex = 1;
                        break;

                    case cls_constantes.EDITAR:
                        vo_componente = cls_gestorComponente.seleccionarComponente(vo_componente);

                        cls_variablesSistema.obj = vo_componente;

                        cls_variablesSistema.tipoEstado = e.CommandName;

                        this.cargarObjeto();

                        this.ard_principal.SelectedIndex = 1;
                        break;

                    case cls_constantes.ELIMINAR:
                        this.eliminarDatos(vo_componente);
                        break;

                    default:
                        break;
                }

            }
            catch (Exception po_exception)
            {
                String vs_error_usuario = "Ocurrió un error al intentar mostrar la ventana de edición para los registros.";
                this.lanzarExcepcion(po_exception, vs_error_usuario);
            } 
        }

        #endregion


    }
}