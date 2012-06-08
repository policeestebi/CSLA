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
            //cls_estadistico vo_estadistico = new cls_estadistico();
            //vo_estadistico.pPK_proyecto = 1;
            //List <cls_estadistico> vl_estadistico = cls_gestorEstadistico.seleccionarGrafico(vo_estadistico);
            //chtCategoriesProductCount.Series["Categories"].Points.DataBindXY(vl_estadistico, "pTipoLabor", vl_estadistico, "pCantidad");


            ///////////////////////////////////////////////////////////////////


            //double[] yValues = { 71.15, 23.19, 5.66 };
            //string[] xValues = { "AAA", "BBB", "CCC" };

            //cls_estadistico vo_estadistico = new cls_estadistico();
            //vo_estadistico.pPK_proyecto = 1;
            //List<cls_estadistico> vl_estadistico = cls_gestorEstadistico.seleccionarGrafico(vo_estadistico);

            ////Chart1.Series["Default"].Points.DataBindXY(xValues, yValues);
            //Chart1.Series["Default"].Points.DataBindXY(vl_estadistico, "pTipoLabor", vl_estadistico, "pCantidad");

            //Chart1.Series["Default"].Points[0].Color = Color.Red;
            //Chart1.Series["Default"].Points[1].Color = Color.Blue;
            //Chart1.Series["Default"].Points[2].Color = Color.Orange;

            //Chart1.Series["Default"].ChartType = SeriesChartType.Pie;

            //Chart1.Series["Default"]["PieLabelStyle"] = "Disabled";

            //Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;

            //Chart1.Series["Default"].Points[0]["Exploded"] = "true";

            //Chart1.Legends[0].Enabled = true;

            /////////////////////////////////////////////////////////////////////////


            // Add series to the chart
            //Series series = Chart1.Series.Add("My series");

            // Set series and legend tooltips
            Chart1.Series["Default"].ToolTip = "#VALX: #VAL{d}";
            Chart1.Series["Default"].LegendToolTip = "#VALX: #VAL{d}";

            Chart1.Series["Default"].IsVisibleInLegend = true;
            Chart1.Series["Default"].Label = "#VALX\n#PERCENT"; 

            Chart1.Series["Default"].PostBackValue = "#INDEX";
            Chart1.Series["Default"].LegendPostBackValue = "#INDEX";

            cls_estadistico vo_estadistico = new cls_estadistico();
            vo_estadistico.pPK_proyecto = 1;
            List<cls_estadistico> vl_estadistico = cls_gestorEstadistico.seleccionarGrafico(vo_estadistico);

            //Chart1.Series["Default"].Points.DataBindXY(xValues, yValues);
            Chart1.Series["Default"].Points.DataBindXY(vl_estadistico, "pTipoLabor", vl_estadistico, "pCantidad");

            Chart1.Series["Default"].Points[0].Color = Color.CornflowerBlue;
            Chart1.Series["Default"].Points[1].Color = Color.IndianRed;
            Chart1.Series["Default"].Points[2].Color = Color.Peru;

            Chart1.Series["Default"].ChartType = SeriesChartType.Pie;

            Chart1.Series["Default"]["PieLabelStyle"] = "Disabled";

            Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;

            Chart1.Series["Default"].Points[0]["Exploded"] = "true";

            Chart1.Legends[0].Enabled = true;

            // Set chart title
            Chart1.Titles[0].Text = "Inversión de Tiempos\npor Labor";

            // Set chart title font
            Chart1.Titles[0].Font = new Font("Times New Roman", 12, FontStyle.Regular);

            Chart1.Titles[0].TextStyle = new TextStyle();

            // Set chart title color
            Chart1.Titles[0].ForeColor = Color.Black;

            // Set Title Alignment
            Chart1.Titles[0].Alignment = System.Drawing.ContentAlignment.TopCenter;

        }

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
    }
}