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
    public partial class frw_proyectos : System.Web.UI.Page
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
                    String vs_error_usuario = "Error al inicializar el mantenimiento de proyectos.";
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

                //Inicialización de botones de la asignación de Departamentos para el Proyecto
                this.btn_asignarDepto = (Button)acp_edicionDatos.FindControl("btn_asignarDepto");
                this.btn_removerDepto = (Button)acp_edicionDatos.FindControl("btn_removerDepto");

                this.ucSearchProyecto.SearchClick += new COSEVI.web.controls.ucSearch.searchClick(this.ucSearchProyecto_searchClick);

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
            this.ucSearchProyecto.LstCollecction.Add(new ListItem("Proyecto", "Pk_proyecto"));
            this.ucSearchProyecto.LstCollecction.Add(new ListItem("Estado", "FK_estado"));
            this.ucSearchProyecto.LstCollecction.Add(new ListItem("Nombre", "nombre"));
            this.ucSearchProyecto.LstCollecction.Add(new ListItem("Descripcion", "descripcion"));
            this.ucSearchProyecto.LstCollecction.Add(new ListItem("Objetivo", "objetivo"));
            this.ucSearchProyecto.LstCollecction.Add(new ListItem("Meta", "meta"));
            this.ucSearchProyecto.LstCollecction.Add(new ListItem("FechaInicio", "fechaInicio"));
            this.ucSearchProyecto.LstCollecction.Add(new ListItem("FechaFin", "fechaFin"));
            this.ucSearchProyecto.LstCollecction.Add(new ListItem("HorasAsignadas", "horasAsignadas"));
            this.ucSearchProyecto.LstCollecction.Add(new ListItem("HorasAsigDefectos", "horasAsigDefectos"));
            this.ucSearchProyecto.LstCollecction.Add(new ListItem("HorasReales", "horasReales"));
            this.ucSearchProyecto.LstCollecction.Add(new ListItem("HorasRealesDefectos", "horasRealesDefectos"));
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
                //Se ponen visibles las columas de llave del proyecto y estado, esto para el binding, luego se ocultan de nuevo
                this.grd_listaProyecto.Columns[0].Visible = true;
                this.grd_listaProyecto.Columns[12].Visible = true;

                //El datasource del gridview es el listado de proyectos
                this.grd_listaProyecto.DataSource = cls_gestorProyecto.listarProyectos();
                
                //Se carga el dataset con los estados que puede adquirir un proyecto
                cargarDataSetEstados();

                this.grd_listaProyecto.DataBind();
                this.ddl_estado.DataBind();
                this.grd_listaProyecto.Columns[0].Visible = false;
                this.grd_listaProyecto.Columns[12].Visible = false;
            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error llenando la tabla.", po_exception);
            } 
        }

        /// <summary>
        /// Hace un buscar de la lista de proyectos.
        /// </summary>
        /// <param name="psFilter">String filtro.</param>
        private void llenarGridViewFilter(String psFilter)
        {
            try
            {
                //Se ponen visibles las columas de llave del proyecto y estado, esto para el binding, luego se ocultan de nuevo
                this.grd_listaProyecto.Columns[0].Visible = true;
                this.grd_listaProyecto.Columns[12].Visible = true;

                //El datasource del gridview es el listado de proyectos pero ya con el filtro asignado
                this.grd_listaProyecto.DataSource = cls_gestorProyecto.listarProyectoFiltro(psFilter);
                
                this.grd_listaProyecto.DataBind();
                this.grd_listaProyecto.Columns[0].Visible = false;
                this.grd_listaProyecto.Columns[12].Visible = false;
            }
            catch (Exception po_exception)
            {
                String vs_error_usuario = "Ocurrió un error llenando la tabla con filtro.";
                this.lanzarExcepcion(po_exception, vs_error_usuario);
            }
        }

        /// <summary>
        /// Crea un objeto de tipo
        /// cls_proyecto con la informacón
        /// que se encuentra en el formulario
        /// web
        /// </summary>
        /// <returns>cls_proyecto</returns>
        private cls_proyecto crearObjetoProyecto()
        {
            cls_proyecto vo_proyecto = new cls_proyecto();
            if (cls_variablesSistema.tipoEstado != cls_constantes.AGREGAR)
            {
                vo_proyecto = (cls_proyecto)cls_variablesSistema.obj;
            }
            try
            {
                vo_proyecto.pFK_estado = Convert.ToInt32(ddl_estado.SelectedValue);
                vo_proyecto.pNombre = txt_nombre.Text;
                vo_proyecto.pDescripcion = txt_descripcion.Text;
                vo_proyecto.pObjetivo = txt_objetivo.Text;
                vo_proyecto.pMeta = txt_meta.Text;
                vo_proyecto.pFechaInicio = Convert.ToDateTime(txt_fechaInicio.Text);
                vo_proyecto.pFechaFin = Convert.ToDateTime(txt_fechaFin.Text);
                vo_proyecto.pHorasAsignadas = Convert.ToDecimal(txt_horasAsignadas.Text);
                vo_proyecto.pHorasAsigDefectos = Convert.ToDecimal(txt_horasAsigDefectos.Text);
                vo_proyecto.pHorasReales = Convert.ToDecimal(txt_horasReales.Text);
                vo_proyecto.pHorasRealesDefectos = Convert.ToDecimal(txt_horasRealesDef.Text);
                return vo_proyecto;
            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al crear el objeto para guardar el registro.", po_exception);
            }
        }

        /// <summary>
        /// Método que devuelve los departamentos que han sido recién asociados al proyecto
        /// </summary>
        /// <returns></returns>
        private List<cls_departamento> departamentosAsociados()
        {
            List<cls_departamento> vo_lista = null;
            cls_departamento vo_departamento = null;

            vo_lista = new List<cls_departamento>();

            try
            {
                foreach (ListItem item in lbx_depasociados.Items)
                {
                    vo_departamento = new cls_departamento();

                    vo_departamento.pPK_departamento = Convert.ToInt32(item.Value);
                    vo_departamento.pNombre = item.Text;

                    vo_lista.Add(vo_departamento);
                }

                return vo_lista;

            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al verificar los departamentos asociados al proyecto.", po_exception);
            }           
        }

        /// <summary>
        /// Método que carga la información
        /// de un proyecto.
        /// </summary>
        private void cargarObjetoProyecto()
        {
            cls_proyecto vo_proyecto = null;

            try
            {
                vo_proyecto = (cls_proyecto)cls_variablesSistema.obj;
                this.ddl_estado.SelectedValue = vo_proyecto.pFK_estado.ToString();
                this.txt_nombre.Text = vo_proyecto.pNombre;
                this.txt_descripcion.Text = vo_proyecto.pDescripcion;
                this.txt_objetivo.Text = vo_proyecto.pObjetivo;
                this.txt_meta.Text = vo_proyecto.pMeta;
                this.txt_fechaInicio.Text = vo_proyecto.pFechaInicio.ToShortDateString();
                this.txt_fechaFin.Text = vo_proyecto.pFechaFin.ToShortDateString();
                this.txt_horasAsignadas.Text = vo_proyecto.pHorasAsignadas.ToString();
                this.txt_horasAsigDefectos.Text = vo_proyecto.pHorasAsigDefectos.ToString();
                this.txt_horasReales.Text = vo_proyecto.pHorasReales.ToString();
                this.txt_horasRealesDef.Text = vo_proyecto.pHorasRealesDefectos.ToString();
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
        /// Método que elimina un proyecto
        /// </summary>
        /// <param name="po_proyecto">Permiso a eliminar</param>
        private void eliminarDatos(cls_proyecto po_proyecto)
        {
            //Primero se intenta eliminar los departamentos asociados a un proyecto, se presenta una excepción si estos tienen también entregables asociados
            try
            {
                int vi_resultado = 1;

                cls_departamentoProyecto vo_departamentoProyecto = new cls_departamentoProyecto();
                vo_departamentoProyecto.pProyecto = po_proyecto;
                vi_resultado = cls_gestorDepartamentoProyecto.deleteDepartamentoProyectoMasivo(vo_departamentoProyecto);            
            
            }
            catch (Exception po_exception)
            {
                throw new Exception("Por favor, verifique que el proyecto no tenga entregables asociados.", po_exception);
            }

            //Si se eliminaron de manera correcta los departamentos asociados a proyecto, se procede a eliminar el proyecto en si
            try
            {
                cls_gestorProyecto.deleteProyecto(po_proyecto);
            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error eliminando el proyecto.", po_exception);
            }

            this.llenarGridView();

            this.upd_Principal.Update();
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

            try
            {
                cls_proyecto vo_proyecto = this.crearObjetoProyecto();
                cls_departamento vo_dpto = new cls_departamento();
                cls_departamentoProyecto vo_dptoProyecto = new cls_departamentoProyecto();

                List<cls_departamento> vl_departamentoAsociado = departamentosAsociados();
                List<cls_departamentoProyecto> vl_departamentoProyecto = new List<cls_departamentoProyecto>();

                //El proyecto es el mismo para todos los departamentos que se vayan a insertar
                vo_dptoProyecto.pProyecto = vo_proyecto;

                switch (cls_variablesSistema.tipoEstado)
                {
                    case cls_constantes.AGREGAR:

                        //Se intenta realizar la inserción del proyecto en la tabla correspondiente
                        vi_resultado = cls_gestorProyecto.insertProyecto(vo_proyecto);

                        //Para cada departamento, se realiza la correspondiente inserción con el proyecto específico
                        foreach (cls_departamento vo_departamento in vl_departamentoAsociado)
                        {
                            vo_dptoProyecto.pDepartamento = vo_departamento;

                            vi_resultado = cls_gestorDepartamentoProyecto.insertDepartamentoProyecto(vo_dptoProyecto);
                        }

                        break;

                    case cls_constantes.EDITAR:
                        vi_resultado = cls_gestorProyecto.updateProyecto(vo_proyecto);

                        //Se revisa cada departamento en la lista que presenta la variable de sistema de "proyecto", si la lista de deparmentos asociados
                        //no cuenta con el departamento de contenido en la lista de la variable de sistema, esta última se intenta eliminar
                        foreach (cls_departamento vo_departamento in cls_variablesSistema.vs_proyecto.pDepartamentoLista)
                        {
                            if (!(vl_departamentoAsociado.Where(dep => dep.pPK_departamento == vo_departamento.pPK_departamento).Count() > 0))
                            {
                                vo_dptoProyecto.pDepartamento = vo_departamento;
                                vi_resultado = cls_gestorDepartamentoProyecto.deleteDepartamentoProyecto(vo_dptoProyecto);
                            }
                        }

                        //Si alguno de los departamentos recién asociados no se encuentra en la variable del sistema, se procede a realizar la inserción de la misma
                        foreach (cls_departamento vo_departamento in vl_departamentoAsociado)
                        {
                            if (!(cls_variablesSistema.vs_proyecto.pDepartamentoLista.Where(dep => dep.pPK_departamento == vo_departamento.pPK_departamento).Count() > 0))
                            {
                                vo_dptoProyecto.pDepartamento = vo_departamento;
                                vi_resultado = cls_gestorDepartamentoProyecto.insertDepartamentoProyecto(vo_dptoProyecto);
                            }
                        }

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

        //private int guardarDatos()
        //{
        //    int vi_resultado = 1;
            
        //    try
        //    {
        //        cls_proyecto vo_proyecto = this.crearObjetoProyecto();
        //        List<cls_departamento> vl_departamento = departamentosAsociados();
        //        cls_departamentoProyecto vo_departamentoProyecto = new cls_departamentoProyecto();

        //        switch (cls_variablesSistema.tipoEstado)
        //        {
        //            case cls_constantes.AGREGAR:
        //                vi_resultado = cls_gestorProyecto.insertProyecto(vo_proyecto);

        //                vo_departamentoProyecto.pProyecto = vo_proyecto;

        //                //Para cada departamento, se realiza la correspondiente inserción con el proyecto específico
        //                foreach (cls_departamento vo_departamento in vl_departamento)
        //                {
        //                    vo_departamentoProyecto.pDepartamento = vo_departamento;

        //                    vi_resultado = cls_gestorDepartamentoProyecto.insertDepartamentoProyecto(vo_departamentoProyecto);
        //                }

        //                break;
        //            case cls_constantes.EDITAR:
        //                vi_resultado = cls_gestorProyecto.updateProyecto(vo_proyecto);

        //                vo_departamentoProyecto.pProyecto = vo_proyecto;

        //                //Se revisa cada departamento en la lista que presenta la variable de sistema de "departamentoProyecto", si la lista de deparmentos asociados
        //                //no cuenta con el departamento de contenido en la lista de la variable de sistema, esta última se intenta eliminar
        //                foreach (cls_departamento vo_departamento in cls_variablesSistema.vs_departamentoProyecto.pDepartamentoList)
        //                {
        //                    if (!vl_departamento.Contains(vo_departamento))
        //                    {
        //                        vo_departamentoProyecto.pDepartamento = vo_departamento;
        //                        vi_resultado = cls_gestorDepartamentoProyecto.deleteDepartamentoProyecto(vo_departamentoProyecto);  
        //                    }                            
        //                }

        //                //Si alguno de los departamentos recién asociados no se encuentra en la variable del sistema, se procede a realizar la inserción de la misma
        //                foreach (cls_departamento vo_departamento in vl_departamento)
        //                {
        //                    if (!cls_variablesSistema.vs_departamentoProyecto.pDepartamentoList.Contains(vo_departamento))
        //                    {
        //                        vo_departamentoProyecto.pDepartamento = vo_departamento;

        //                        vi_resultado = cls_gestorDepartamentoProyecto.insertDepartamentoProyecto(vo_departamentoProyecto);
        //                    }
        //                }

        //                break;
        //            default:
        //                break;
        //        }

        //        limpiarVariablesSistema();

        //        return vi_resultado;
        //    }
        //    catch (Exception po_exception)
        //    {
        //        throw new Exception("Ocurrió un error al guardar el registro.", po_exception);
        //    } 
        //}

        /// <summary>
        /// Método que limpia la información
        /// existente en los diferentes
        /// controles del formulario web
        /// </summary>
        private void limpiarCampos()
        {
            this.ddl_estado.SelectedIndex = -1;
            this.txt_nombre.Text = String.Empty;
            this.txt_descripcion.Text = String.Empty;
            this.txt_objetivo.Text = String.Empty;
            this.txt_meta.Text = String.Empty;
            this.txt_fechaInicio.Text = String.Empty;
            this.txt_fechaFin.Text = String.Empty;
            this.txt_horasAsignadas.Text = String.Empty;
            this.txt_horasAsigDefectos.Text = String.Empty;
            this.txt_horasReales.Text = String.Empty;
            this.txt_horasRealesDef.Text = String.Empty;
        }

        /// <summary>
        /// Método que habilita o 
        /// deshabilita los controles del
        /// formulario web.
        /// </summary>
        /// <param name="pb_habilitados"></param>
        private void habilitarControles(bool pb_habilitados)
        {
            this.ddl_estado.Enabled = pb_habilitados;
            this.txt_nombre.Enabled = pb_habilitados;
            this.txt_descripcion.Enabled = pb_habilitados;
            this.txt_objetivo.Enabled = pb_habilitados;
            this.txt_meta.Enabled = pb_habilitados;
            this.txt_fechaInicio.Enabled = pb_habilitados;
            this.txt_fechaFin.Enabled = pb_habilitados;
            this.txt_horasAsignadas.Enabled = pb_habilitados;
            this.txt_horasAsigDefectos.Enabled = pb_habilitados;
            this.txt_horasReales.Enabled = pb_habilitados;
            this.txt_horasRealesDef.Enabled = pb_habilitados;

            btn_asignarDepto.Enabled = pb_habilitados;
            btn_removerDepto.Enabled = pb_habilitados;

            this.btn_guardar.Visible = pb_habilitados;

        }

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
            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al cargar los estados del proyecto.", po_exception);
            } 

        }

        /// <summary>
        /// Metodo que carga el dataSet de los departamentos a los que se puede asociar un proyecto
        /// </summary>
        private void cargarDataSetDepartamentos()
        {
            DataSet vo_dataSet = new DataSet();

            try
            {
                    vo_dataSet = cls_gestorDepartamentoProyecto.listarDepartamento();
                    lbx_departamentos.DataSource = vo_dataSet;
                    lbx_departamentos.DataTextField = "nombre";
                    lbx_departamentos.DataValueField = "PK_departamento";
                    lbx_departamentos.DataBind();
                    
            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al cargar los estados del proyecto.", po_exception);
            } 

        }

        /// <summary>
        /// Método que obtiene los departamentos asociados a un proyecto específicos
        /// </summary>
        private void cargarDepartamentoProyecto(cls_proyecto po_proyecto)
        {
            DataSet vo_dataSet = new DataSet();

            try
            {
                vo_dataSet = cls_gestorDepartamentoProyecto.selectDepartamentoProyecto(po_proyecto);
                lbx_depasociados.DataSource = vo_dataSet;
                lbx_depasociados.DataTextField = "nombre";
                lbx_depasociados.DataValueField = "PK_departamento";
                lbx_depasociados.DataBind();

                if (lbx_depasociados.Items.Count > 0)
                {
                    cls_variablesSistema.vs_proyecto = po_proyecto;

                    foreach (ListItem item in lbx_depasociados.Items)
                    {
                        cls_departamento vo_departamento = new cls_departamento();
                        cls_departamentoProyecto vo_deptoProyecto = new cls_departamentoProyecto();

                        lbx_departamentos.Items.Remove(item);

                        vo_departamento.pPK_departamento = Convert.ToInt32(item.Value);
                        vo_departamento.pNombre = item.Text;

                        vo_deptoProyecto.pProyecto = po_proyecto;
                        vo_deptoProyecto.pDepartamentoList.Add(vo_departamento);

                        cls_variablesSistema.vs_proyecto.pDepartamentoLista.Add(vo_departamento);
                        cls_variablesSistema.vs_proyecto.pDptoProyLista.Add(vo_deptoProyecto);
                    }
                }
                else
                {
                    limpiarVariablesSistema();
                }
            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al cargar los departamentos asociados al proyecto.", po_exception);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="po_proyecto"></param>
        private void cargarProyectoAsignacion(cls_proyecto po_proyecto)
        {
            try
            {
                cls_variablesSistema.vs_proyecto = po_proyecto;
            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al cargar los departamentos asociados al proyecto.", po_exception);
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

        /// <summary>
        /// Método que limpia la variable del sistema vs_departamentoProyecto
        /// </summary>
        private void limpiarVariablesSistema()
        {
            cls_variablesSistema.vs_proyecto = new cls_proyecto();
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
        protected void ucSearchProyecto_searchClick(object sender, EventArgs e, string value, ListItem seletecItem)
        {
            this.llenarGridViewFilter(this.ucSearchProyecto.Filter); 
        }

        /// <summary>
        /// Agrega un nuevo proyecto.
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

                cargarDataSetDepartamentos();

                limpiarVariablesSistema();

            }
            catch (Exception po_exception)
            {
                String vs_error_usuario = "Ocurrió un error al intentar mostrar la ventana de edición para los registros.";
                this.lanzarExcepcion(po_exception, vs_error_usuario);
            } 

        }

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

                this.llenarGridView();

                this.limpiarCampos();

                this.limpiarVariablesSistema();

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
        protected void grd_listaProyecto_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {              
                this.grd_listaProyecto.PageIndex = e.NewPageIndex;
                this.llenarGridView();
                this.upd_Principal.Update();
            }
            catch (Exception po_exception)
            {
                String vs_error_usuario = "Ocurrió un error al realizar el listado de proyectos.";
                this.lanzarExcepcion(po_exception, vs_error_usuario);
            } 
        }

        /// <summary>
        /// Cuando se seleccionada un botón del grid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grd_listaProyecto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int vi_indice = Convert.ToInt32(e.CommandArgument);

                GridViewRow vu_fila = this.grd_listaProyecto.Rows[vi_indice];

                cls_proyecto vo_proyecto = new cls_proyecto();

                List<cls_departamentoProyecto> vo_departamentoProyecto = new List<cls_departamentoProyecto>();

                vo_proyecto.pPK_proyecto= Convert.ToInt32(vu_fila.Cells[0].Text.ToString());
                vo_proyecto.pNombre = vu_fila.Cells[1].Text.ToString();
                vo_proyecto.pDescripcion = vu_fila.Cells[2].Text.ToString();
                vo_proyecto.pObjetivo = vu_fila.Cells[3].Text.ToString();
                vo_proyecto.pMeta = vu_fila.Cells[4].Text.ToString();
                vo_proyecto.pFechaInicio = Convert.ToDateTime(vu_fila.Cells[5].Text.ToString());
                vo_proyecto.pFechaFin = Convert.ToDateTime(vu_fila.Cells[6].Text.ToString());
                vo_proyecto.pHorasAsignadas = Convert.ToDecimal(vu_fila.Cells[7].Text.ToString());
                vo_proyecto.pHorasAsigDefectos = Convert.ToDecimal(vu_fila.Cells[8].Text.ToString());
                vo_proyecto.pHorasReales = Convert.ToDecimal(vu_fila.Cells[9].Text.ToString());
                vo_proyecto.pHorasRealesDefectos = Convert.ToDecimal(vu_fila.Cells[10].Text.ToString());
                vo_proyecto.pDescripcionEstado = vu_fila.Cells[11].Text.ToString();
                vo_proyecto.pFK_estado = Convert.ToInt32(vu_fila.Cells[12].Text.ToString());

                switch (e.CommandName.ToString())
                {
                    case cls_constantes.VER:
                        vo_proyecto = cls_gestorProyecto.seleccionarProyectos(vo_proyecto);

                        cls_variablesSistema.obj = vo_proyecto;

                        cls_variablesSistema.tipoEstado = e.CommandName;

                        this.cargarObjetoProyecto();

                        cargarDataSetDepartamentos();

                        cargarDepartamentoProyecto(vo_proyecto);

                        this.ard_principal.SelectedIndex = 1;
                        break;

                    case cls_constantes.EDITAR:
                        vo_proyecto = cls_gestorProyecto.seleccionarProyectos(vo_proyecto);

                        cls_variablesSistema.obj = vo_proyecto;

                        cls_variablesSistema.tipoEstado = e.CommandName;

                        this.cargarObjetoProyecto();

                        cargarDataSetDepartamentos();

                        cargarDepartamentoProyecto(vo_proyecto);

                        this.ard_principal.SelectedIndex = 1;
                        break;

                    case cls_constantes.ELIMINAR:
                        this.eliminarDatos(vo_proyecto);
                        break;

                    case cls_constantes.CREAR:

                        //Se limpia la variable de sistema que mantiene los departamentos proyectos para inmediatamente después comprobar si hubieron cambios o no
                        limpiarVariablesSistema();

                        //Se envía a cargar el atributo estático de cls_variablesSistema que mantiene la lista de departamentos proyecto
                        cargarDepartamentoProyecto(vo_proyecto);

                        //Se envía a la página de creación de proyectos
                        Response.Redirect("frw_proyectosCreacion.aspx",false);

                        break;

                    case cls_constantes.ASIGNAR:

                        //Se limpia la variable de sistema que mantiene los departamentos proyectos para inmediatamente después comprobar si hubieron cambios o no
                        limpiarVariablesSistema();

                        //Se envía a cargar el atributo estático de cls_variablesSistema que mantiene el proyecto
                        cargarProyectoAsignacion(vo_proyecto);

                        //Se envía a la página de creación de proyectos
                        Response.Redirect("frw_asignacionActividad.aspx", false);

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

        /// <summary>
        /// Evento q asigna el nuevo valor del dropdown list de estados cuando se modifica el proyecto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ddl_estado.Text = ((DropDownList)sender).SelectedValue;
        }

        #endregion

        #region Creación

        /// <summary>
        /// Método que se encarga de presentar los datos para el ListBox de departamentos
        /// </summary>
        private void llenarListBoxDepartamentos() 
        {
            try
            {
                this.lbx_departamentos.DataSource = cls_gestorDepartamentoProyecto.listarDepartamento();
                this.lbx_departamentos.DataValueField = "Pk_departamento";
                this.lbx_departamentos.DataTextField = "nombre";
                this.lbx_departamentos.DataBind();

            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al cargar la lista de departamentos.", po_exception);
            }
        }

        /// <summary>
        /// Evento para asignar departamentos a un proyecto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_asignarDepto_Click(object sender, EventArgs e)
        {
            for (int i = lbx_departamentos.Items.Count - 1; i >= 0; i--)
            {
                if (lbx_departamentos.Items[i].Selected == true)
                {
                    lbx_depasociados.Items.Add(lbx_departamentos.Items[i]);
                    ListItem li = lbx_departamentos.Items[i];
                    lbx_departamentos.Items.Remove(li);
                }
            }
        }

        /// <summary>
        /// Evento para remover departamentos a un proyecto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_removerDepto_Click(object sender, EventArgs e)
        {
            for (int i = lbx_depasociados.Items.Count - 1; i >= 0; i--)
            {
                if (lbx_depasociados.Items[i].Selected == true)
                {
                    lbx_departamentos.Items.Add(lbx_depasociados.Items[i]);
                    ListItem li = lbx_depasociados.Items[i];
                    lbx_depasociados.Items.Remove(li);
                }
            }
        }

        #endregion Creación




    }
}