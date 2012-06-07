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

namespace CSLA.web.App_pages.mod.Estadistico
{
    public partial class frw_grf_inversionTiempos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cls_estadistico vo_estadistico = new cls_estadistico();
            vo_estadistico.pPK_proyecto = 1;
            List <cls_estadistico> vl_estadistico = cls_gestorEstadistico.seleccionarGrafico(vo_estadistico);
            chtCategoriesProductCount.Series["Categories"].Points.DataBindXY(vl_estadistico, "pTipoLabor", vl_estadistico, "pCantidad");
        }
    }
}