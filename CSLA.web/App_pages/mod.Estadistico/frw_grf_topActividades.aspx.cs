using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Data;
using COSEVI.CSLA.lib.accesoDatos.mod.Estadistico;
using COSEVI.CSLA.lib.entidades.mod.Estadistico;
using System.Drawing;
using CSLA.web.App_Variables;
using ExceptionManagement.Exceptions;
using CSLA.web.App_Constantes;
using COSEVI.CSLA.lib.entidades.mod.Administracion;

// =========================================================================
// COSEVI - Consejo de Seguridad Vial. - 2011
// Sistema CSLA (Sistema para el Control y Seguimiento de Labores)
//
// frw_grf_topActividades.aspx.cs
//
// Explicación de los contenidos del archivo.
// =========================================================================
// Historial
// PERSONA 			           MES – DIA - AÑO		DESCRIPCIÓN
// Esteban Ramírez Gónzalez  	03 – 06  - 2012	 	Se crea la clase
// 
//								
//								
//
// =========================================================================


namespace CSLA.web.App_pages.mod.Estadistico
{
    public partial class frw_grf_topActividades : System.Web.UI.Page
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
            this.validarSession();

            if (!Page.IsPostBack)
            {
                try
                {
                    this.validarAcceso();
                    cargarProyectos();
                }
                catch (Exception po_exception)
                {
                    String vs_error_usuario = "Error en la consulta de datos para el gráfco de actividades top por proyecto.";
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
            try
            {
                base.OnInit(e);
            }
            catch (Exception po_exception)
            {
                String vs_error_usuario = "Error al inicializar los controles de la ventana para el gráfico de actividades top por proyecto.";
                this.lanzarExcepcion(po_exception, vs_error_usuario);
            }
        }

        /// <summary>
        /// Función que se ejecute cada vez que se realice un postback
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Grafico_Init(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    //Cuando se está ingresando a la página, se limpian las variables de sesión para evitar valores incorrectos
                    LimpiarVariablesSession();
                    txt_fechaInicio.Text = DateTime.Today.AddMonths(-1).ToString().Substring(0,10);
                    txt_fechaFin.Text = DateTime.Today.ToString().Substring(0, 10);
                }
                else
                {
                    if (!(Session[cls_constantes.CODIGOPROYECTO] == null))
                    {
                        CargaGrafico(Convert.ToInt32(Session[cls_constantes.CODIGOPROYECTO]), Convert.ToDateTime(Session[cls_constantes.FECHADESDE]), Convert.ToDateTime(Session[cls_constantes.FECHAHASTA]));
                    }
                }
            }
            catch (Exception po_exception)
            {
                String vs_error_usuario = "Ocurrió un error al inicializar los controles del gráfico.";
                this.lanzarExcepcion(po_exception, vs_error_usuario);
            }
        }


        #endregion Inicialización

        #region Métodos Privados

        /// <summary>
        /// Método que realiza la consulta en BD para obtener la información por proyecto y cargar sus valores
        /// </summary>
        private void CargaGrafico(int ps_proyecto, DateTime pd_fechaDesde, DateTime pd_fechaHasta)
        {
            try
            {
                //Si se está obteniendo información para un proyecto que NO es el proyecto por defecto
                if (ps_proyecto > 0)
                {
                    obtenerGraficoActividadesPorProyecto(ps_proyecto, pd_fechaDesde, pd_fechaHasta);
                }
                else
                {
                    obtenerGraficoPorDefecto();
                }
            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al definir el tipo de gráfico.", po_exception);
            }
        }

        /// <summary>
        /// Metodo que carga el ddl de proyectos para escoger por cual se quiere filtrar
        /// </summary>
        private void cargarProyectos()
        {
            try
            {
                this.ddl_proyecto.DataSource = cls_gestorEstadistico.listarProyectos();
                this.ddl_proyecto.DataTextField = "pNombre";
                this.ddl_proyecto.DataValueField = "pPK_proyecto";
                this.ddl_proyecto.DataBind();

                this.ddl_proyecto.Items.Insert(0, new ListItem("Seleccione un proyecto", "0"));
                this.ddl_proyecto.SelectedIndex = 0;

            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al cargar la lista de proyectos.", po_exception);
            }
        }

        /// <summary>
        /// Método que obtiene la información con la que se va a cargar en gráfico
        /// </summary>
        private void obtenerGraficoActividadesPorProyecto(int ps_proyecto, DateTime pd_fechaDesde, DateTime pd_fechaHasta)
        {
            try
            {
                //Se procede a obtener la información por proyecto
                cls_topActividades vo_topActividades = new cls_topActividades();
                vo_topActividades.pPK_proyecto = ps_proyecto;
                vo_topActividades.pFechaDesde = pd_fechaDesde;
                vo_topActividades.pFechaHasta = pd_fechaHasta;

                List<cls_topActividades> vl_topActividades = cls_gestorEstadistico.TopActividadesPorProyecto(vo_topActividades);

                //Se asignan los tooltips para el gráfico
                Grafico.Series["Leyendas"].ToolTip = "#VALX: #VAL{d}";
                Grafico.Series["Leyendas"].LegendToolTip = "#VALX: #VAL{d}";
                Grafico.Series["Leyendas"].IsVisibleInLegend = true;
                Grafico.Series["Leyendas"].Label = "#VALX\n#PERCENT";
                Grafico.Series["Leyendas"].PostBackValue = "#INDEX";
                Grafico.Series["Leyendas"].LegendPostBackValue = "#INDEX";

                //Se realiza el binding de la información que se obtuvo en la consulta
                Grafico.Series["Leyendas"].Points.DataBindXY(vl_topActividades, "pNombreActividad", vl_topActividades, "pCantidadHoras");

                //Se indica que tipo de gráfico se va a presentar al usuario
                Grafico.Series["Leyendas"].ChartType = SeriesChartType.Column;

                //Se asignan los estilos del gráfico
                Grafico.ChartAreas["AreaGrafico"].Area3DStyle.Enable3D = true;
                // Draw as 3D Cylinder
                Grafico.Series["Leyendas"]["DrawingStyle"] = "Cylinder";
                Grafico.Legends[0].Enabled = false;

                // Set the X Angle to 30
                Grafico.ChartAreas["AreaGrafico"].Area3DStyle.Inclination = 10;
                // Set the Y Angle to 40
                Grafico.ChartAreas["AreaGrafico"].Area3DStyle.Rotation = 40;

                // Show columns as clustered
                Grafico.ChartAreas["AreaGrafico"].Area3DStyle.IsClustered = true;

                // Set series point width
                Grafico.Series["Leyendas"]["PointWidth"] = "0.6";

                // Show X axis end labels
                Grafico.ChartAreas["AreaGrafico"].AxisX.LabelStyle.IsEndLabelVisible = false;

                // Set axis title
                Grafico.ChartAreas["AreaGrafico"].AxisX.Title = "Nombre de Actividades";

                // Set Title font
                Grafico.ChartAreas["AreaGrafico"].AxisX.TitleFont = new Font("Arial", 10, FontStyle.Bold);

                // Set axis title
                Grafico.ChartAreas["AreaGrafico"].AxisY.Title = "Cantidad de Horas Invertidas";

                // Set Title font
                Grafico.ChartAreas["AreaGrafico"].AxisY.TitleFont = new Font("Arial", 10, FontStyle.Bold);
                
                //Set orientacion
                Grafico.ChartAreas["AreaGrafico"].AxisY.TextOrientation = TextOrientation.Auto;

                //Se aplica el estilo pastel a los colores definidos para el gráfico
                Grafico.Palette = ChartColorPalette.Bright;
                Grafico.ApplyPaletteColors();
                //Para que el estilo tome efecto se debe asignar a cada uno de los puntos de la serie en el gráfico
                foreach (var series in Grafico.Series)
                {
                    foreach (var point in series.Points)
                    {
                        point.Color = Color.FromArgb(220, point.Color);
                    }
                }

                // Set Antialiasing mode
                Grafico.AntiAliasing = AntiAliasingStyles.Graphics;
                Grafico.AlignDataPointsByAxisLabel();
            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al cargar el gráfico con la información de la base de datos.", po_exception);
            }
        }

        /// <summary>
        /// Método que obtiene la información para el gráfico por defecto
        /// </summary>
        private void obtenerGraficoPorDefecto()
        {
            try
            {
                string[] valoresX = new string[] { "Sin Actividades" };
                decimal[] valoresY = new decimal[] { 0 };

                //Se realiza el binding de la información que se obtuvo en la consulta
                Grafico.Series["Leyendas"].Points.DataBindXY(valoresX, valoresY);
                Grafico.Legends[0].Enabled = false;

                //Se asignan los colores de la composición del gráfico
                Grafico.Series["Leyendas"].Points[0].Color = Color.White;

                //Se indica que tipo de gráfico se va a presentar al usuario
                Grafico.Series["Leyendas"].ChartType = SeriesChartType.Pie;
            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al cargar el gráfico con la información por defecto.", po_exception);
            }
        }

        /// <summary>
        /// Método utilizado para limpiar las 3 variables de sesión que utiliza este gráfico
        /// </summary>
        private void LimpiarVariablesSession()
        {
            Session[cls_constantes.CODIGOPROYECTO] = null;
            Session[cls_constantes.FECHADESDE] = null;
            Session[cls_constantes.FECHAHASTA] = null;
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
                ScriptManager.RegisterClientScriptBlock(this.Grafico, this.Grafico.GetType(), "jsKeyScript", vs_script, true);

                throw new GeneralException("GeneralException", po_exception);
            }
            catch (GeneralException po_general_exception)
            {
                ExceptionManagement.ExceptionManager.Publish(po_general_exception);
            }
        }

        #endregion Métodos Privados

        #region Eventos

        /// <summary>
        /// Evento para levantar el explode del gráfico(Explode = destacar, hacer sobresalir una de las secciones)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Generar_Click(object sender, EventArgs e)
        {
            try
            {
                Session[cls_constantes.CODIGOPROYECTO] = ddl_proyecto.SelectedValue;
                Session[cls_constantes.FECHADESDE] = txt_fechaInicio.Text;
                Session[cls_constantes.FECHAHASTA] = txt_fechaFin.Text;

                //Si el proyecto es un proyecto válido, se carga, de lo contrario, se limpia la variable en memoria
                //Si el proyecto es el "0", no se traerá nada, por lo que no se mostrará nada en ventana, que es el 
                //caso defecto, y está bien
                if (Convert.ToInt32(ddl_proyecto.SelectedValue) > -1)
                {
                    CargaGrafico(Convert.ToInt32(ddl_proyecto.SelectedValue), Convert.ToDateTime(txt_fechaInicio.Text), Convert.ToDateTime(txt_fechaFin.Text));
                }
            }
            catch (Exception po_exception)
            {
                String vs_error_usuario = "Ocurrió un error al enfocar la sección del gráfico.";
                this.lanzarExcepcion(po_exception, vs_error_usuario);
            }
        }

        #endregion Eventos

        #region Seguridad

        /// <summary>
        /// Valida si el usuario
        /// tiene acceso a la página de lo contrario
        /// destruye la sessión
        /// 
        /// </summary>
        private void validarAcceso()
        {
            if (!this.pbAcceso)
            {
                this.Session.Abandon();
                this.Session.Clear();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Salida", cls_constantes.SCRIPTLOGOUT, true);
            }
        }

        /// <summary>
        /// Determina si la sesión se encuentra
        /// activa, si no es así se envía a la página de inicio.
        /// </summary>
        private void validarSession()
        {
            if (this.Session["cls_usuario"] == null)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Salida", cls_constantes.SCRIPTLOGOUT, true);
            }
        }

        /// <summary>
        /// Valida el acceso del usuario en la página
        /// </summary>
        private bool pbAcceso
        {
            get
            {
                if (Session[cls_constantes.PAGINA] != null)
                {
                    return (Session[cls_constantes.PAGINA] as cls_pagina)[cls_constantes.ACCESO] != null;
                }
                else
                {
                    return false;
                }
            }
        }

        #endregion Seguridad

    }
}