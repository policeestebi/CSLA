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

namespace CSLA.web.App_pages.mod.Estadistico
{
    public partial class frw_grf_inversionTiempos : System.Web.UI.Page
    {
        #region Inicialización

        protected void Page_Load(object sender, EventArgs e)
        {
            //this.validarSession();

            if (!Page.IsPostBack)
            {
                try
                {
                    //this.validarAcceso();
                    //Se al cargar proyectos
                    cargarProyectos();
                }
                catch (Exception po_exception)
                {
                    //String vs_error_usuario = "Error al inicializar el mantenimiento para la asignación de actividades.";
                    //this.lanzarExcepcion(po_exception, vs_error_usuario);
                }

            }
        }

        #endregion Inicialización

        #region Métodos Privados

        /// <summary>
        /// Método que realiza la consulta en BD para obtener la información por proyecto y cargar sus valores
        /// </summary>
        private void CargaGrafico(int ps_proyecto)
        {
            //Se procede a obtener la información por proyecto
            cls_estadistico vo_estadistico = new cls_estadistico();
            vo_estadistico.pPK_proyecto = ps_proyecto;
            List<cls_estadistico> vl_estadistico = cls_gestorEstadistico.SeleccionarInfoPorProyecto(vo_estadistico);

            //Se asignan los tooltips para el gráfico
            Chart1.Series["Default"].ToolTip = "#VALX: #VAL{d}";
            Chart1.Series["Default"].LegendToolTip = "#VALX: #VAL{d}";
            Chart1.Series["Default"].IsVisibleInLegend = true;
            Chart1.Series["Default"].Label = "#VALX\n#PERCENT";
            Chart1.Series["Default"].PostBackValue = "#INDEX";
            Chart1.Series["Default"].LegendPostBackValue = "#INDEX";

            //Se realiza el binding de la información que se obtuvo en la consulta
            Chart1.Series["Default"].Points.DataBindXY(vl_estadistico, "pTipoLabor", vl_estadistico, "pCantidad");

            //Se asignan los colores de la composición del gráfico
            Chart1.Series["Default"].Points[0].Color = Color.Tomato;
            Chart1.Series["Default"].Points[1].Color = Color.SteelBlue;
            Chart1.Series["Default"].Points[2].Color = Color.Orange;

            //Se indica que tipo de gráfico se va a presentar al usuario
            Chart1.Series["Default"].ChartType = SeriesChartType.Pie;

            //Se asignan los estilos del gráfico
            Chart1.Series["Default"]["PieLabelStyle"] = "Disabled";
            Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
            Chart1.Series["Default"].Points[0]["Exploded"] = "true";
            Chart1.Legends[0].Enabled = true;

            // Set chart title
            //Chart1.Titles[0].Text = "Inversión de Tiempos\npor Labor";

            // Set chart title font
            Chart1.Titles[0].Font = new Font("Times New Roman", 12, FontStyle.Regular);

            Chart1.Titles[0].TextStyle = new TextStyle();

            // Set chart title color
            Chart1.Titles[0].ForeColor = Color.Black;

            // Set Title Alignment
            Chart1.Titles[0].Alignment = System.Drawing.ContentAlignment.TopCenter;

            // Show a 30% perspective
            Chart1.ChartAreas["ChartArea1"].Area3DStyle.Perspective = 40;
            // Set the X Angle to 30
            Chart1.ChartAreas["ChartArea1"].Area3DStyle.Inclination = 65;
            // Set the Y Angle to 40
            Chart1.ChartAreas["ChartArea1"].Area3DStyle.Rotation = 30;

            //Se aplica el estilo pastel a los colores definidos para el gráfico
            Chart1.Palette = ChartColorPalette.BrightPastel;
            Chart1.ApplyPaletteColors();
            //Para que el estilo tome efecto se debe asignar a cada uno de los puntos de la serie en el gráfico
            foreach (var series in Chart1.Series)
            {
                foreach (var point in series.Points)
                {
                    point.Color = Color.FromArgb(220, point.Color);
                }
            }

            // Set Antialiasing mode
            Chart1.AntiAliasing = AntiAliasingStyles.Graphics;

            cargarChart(Chart1);

            //cls_variablesSistema.obj = Chart1;

            //cls_variablesSistema.vs_series = new Series();
            //cls_variablesSistema.vs_series = Chart1.Series["Default"];
            //cls_variablesSistema.vca_area = new ChartArea();
            //cls_variablesSistema.vca_area = Chart1.ChartAreas["ChartArea1"];

            //cls_variablesSistema.vc_grafico.Series["Default"] = new Series("Default");
            //cls_variablesSistema.vc_grafico.Series["Default"] = Chart1.Series["Default"];
            //cls_variablesSistema.vc_grafico.ChartAreas["ChartArea1"] = new ChartArea("ChartArea1");
            //cls_variablesSistema.vc_grafico.ChartAreas["ChartArea1"] = Chart1.ChartAreas["ChartArea1"];
        }

        /// <summary>
        /// Metodo que carga el ddl de proyectos para escoger por cual se quiere filtrar
        /// </summary>
        private void cargarProyectos()
        {
            try
            {
                this.ddl_proyecto.DataSource = cls_gestorEstadistico.listarProyectos(); ;
                this.ddl_proyecto.DataTextField = "pNombre";
                this.ddl_proyecto.DataValueField = "pPK_proyecto";
                this.ddl_proyecto.DataBind();
            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al cargar los estados del proyecto.", po_exception);
            }
        }


        private void cargarChart(Chart c)
        {
            try
            {
                cls_variablesSistema.vc_grafico = c;

                cls_variablesSistema.vc_grafico = new Chart();
                cls_variablesSistema.vc_grafico = c;

                cls_variablesSistema.obj = c;
            }
            catch
            { 
            
            }
        }

        #endregion Métodos Privados

        #region Eventos

        /// <summary>
        /// Evento para asignar el primer valor del dropdownlist, que en este caso es la leyenda "Seleccione un proyecto", en la posición "0"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlProyecto_DataBound(object sender, EventArgs e)
        {
            try
            {
                this.ddl_proyecto.Items.Insert(0, new ListItem("Seleccione un proyecto", "0"));
                this.ddl_proyecto.SelectedIndex = 0;
            }
            catch (Exception po_exception)
            {
                //String vs_error_usuario = "Ocurrió un error mientras se asociaba la lista de paquetes.";
                //this.lanzarExcepcion(po_exception, vs_error_usuario);
            }
        }

        /// <summary>
        /// Evento q asigna el nuevo valor del dropdown list de proyectos para el filtro
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlProyecto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.ddl_proyecto.SelectedValue = ((DropDownList)sender).SelectedValue;

                if (Convert.ToInt32(ddl_proyecto.SelectedValue) != 0)
                {
                    cls_variablesSistema.vc_grafico = new Chart();
                    CargaGrafico(Convert.ToInt32(ddl_proyecto.SelectedValue));
                }
            }
            catch (Exception po_exception)
            {
                //String vs_error_usuario = "Ocurrió un error al intentar cambiar el estado del proyecto.";
                //this.lanzarExcepcion(po_exception, vs_error_usuario);
            }
        }

        //Si queda tiempo, hacer que se pueda ver levantada la porción que se escoja
        protected void Chart1_Click(object sender, ImageMapEventArgs e)
        {
            int pointIndex = int.Parse(e.PostBackValue);
            //Series series = Chart1.Series["Default"];
            Series series = cls_variablesSistema.vc_grafico.Series["Default"];
            if (pointIndex >= 0 && pointIndex < series.Points.Count)
            {
                series.Points[pointIndex].CustomProperties = string.Empty;
                series.Points[pointIndex].CustomProperties += "Exploded=true";
            }
        }

        /// <summary>
        /// Evento que se ejecuta cuando se le da
        /// en el botón de regresar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_regresar_Click(object sender, EventArgs e)
        {
            try
            {
                //Se redirecciona a la ventana principal de proyectos
                Response.Redirect("frw_principal.aspx", false);
            }
            catch (Exception po_exception)
            {
                //String vs_error_usuario = "Ocurrió un error al intentar regresar al mantenimiento de proyeto.";
                //this.lanzarExcepcion(po_exception, vs_error_usuario);
            }
        }

        #endregion Eventos

        #region Seguridad

        ///// <summary>
        ///// Valida si el usuario
        ///// tiene acceso a la página de lo contrario
        ///// destruye la sessión
        ///// 
        ///// </summary>
        //private void validarAcceso()
        //{
        //    if (!this.pbAcceso)
        //    {
        //        this.Session.Abandon();
        //        this.Session.Clear();
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Salida", cls_constantes.SCRIPTLOGOUT, true);
        //    }
        //}

        ///// <summary>
        ///// Determina si la sesión se encuentra
        ///// activa, si no es así se envía a la página de inicio.
        ///// </summary>
        //private void validarSession()
        //{
        //    if (this.Session["cls_usuario"] == null)
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Salida", cls_constantes.SCRIPTLOGOUT, true);
        //    }
        //}

        ///// <summary>
        ///// Valida el acceso del usuario en la página
        ///// </summary>
        //private bool pbAcceso
        //{
        //    get
        //    {
        //        if (Session[cls_constantes.PAGINA] != null)
        //        {
        //            return (Session[cls_constantes.PAGINA] as cls_pagina)[cls_constantes.ACCESO] != null;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //}

        #endregion Seguridad

    }
}