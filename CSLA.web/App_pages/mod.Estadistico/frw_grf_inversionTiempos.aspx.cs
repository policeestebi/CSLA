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

namespace CSLA.web.App_pages.mod.Estadistico
{
    public partial class frw_grf_inversionTiempos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Se llama al método que obtiene la información a desplegar
                CargaGrafico();
            }
            catch
            { 
            
            }
            //Incluir Try y catch

        }

        #region Métodos Privados

        /// <summary>
        /// Método que realiza la consulta en BD para obtener la información por proyecto y cargar sus valores
        /// </summary>
        private void CargaGrafico()
        {
            //Se procede a obtener la información por proyecto
            cls_estadistico vo_estadistico = new cls_estadistico();
            vo_estadistico.pPK_proyecto = 1;
            List<cls_estadistico> vl_estadistico = cls_gestorEstadistico.seleccionarGrafico(vo_estadistico);

            // Set series and legend tooltips
            Chart1.Series["Default"].ToolTip = "#VALX: #VAL{d}";
            Chart1.Series["Default"].LegendToolTip = "#VALX: #VAL{d}";

            Chart1.Series["Default"].IsVisibleInLegend = true;
            Chart1.Series["Default"].Label = "#VALX\n#PERCENT";

            Chart1.Series["Default"].PostBackValue = "#INDEX";
            Chart1.Series["Default"].LegendPostBackValue = "#INDEX";

            //Chart1.Series["Default"].Points.DataBindXY(xValues, yValues);
            Chart1.Series["Default"].Points.DataBindXY(vl_estadistico, "pTipoLabor", vl_estadistico, "pCantidad");

            //Chart1.Series["Default"].Points[0].Color = Color.CornflowerBlue;
            //Chart1.Series["Default"].Points[1].Color = Color.IndianRed;
            //Chart1.Series["Default"].Points[2].Color = Color.Peru;

            Chart1.Series["Default"].Points[0].Color = Color.Tomato;
            Chart1.Series["Default"].Points[1].Color = Color.SteelBlue;
            Chart1.Series["Default"].Points[2].Color = Color.Orange;

            Chart1.Series["Default"].ChartType = SeriesChartType.Pie;

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

            Chart1.Palette = ChartColorPalette.BrightPastel;

            Chart1.ApplyPaletteColors();

            foreach (var series in Chart1.Series)
            {
                foreach (var point in series.Points)
                {
                    point.Color = Color.FromArgb(220, point.Color);
                }
            }

            // Set Antialiasing mode
            Chart1.AntiAliasing = AntiAliasingStyles.Graphics;
        }

        #endregion Métodos Privados

        #region Eventos
        protected void Chart1_Click(object sender, ImageMapEventArgs e)
        {
            int pointIndex = int.Parse(e.PostBackValue);
            Series series = Chart1.Series["Default"];
            if (pointIndex >= 0 && pointIndex < series.Points.Count)
            {
                series.Points[pointIndex].CustomProperties = string.Empty;
                series.Points[pointIndex].CustomProperties += "Exploded=true";
            }
        }

        #endregion Eventos
    }
}