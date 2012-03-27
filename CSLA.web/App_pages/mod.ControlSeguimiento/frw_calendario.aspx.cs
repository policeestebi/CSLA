using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSLA.web.App_pages.mod.ControlSeguimiento
{
    public partial class frm_calendario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            this.calendario.poDatos = ObtenerDatos();

        }


        public List<List<String>> ObtenerDatos()
        {
            List<List<String>> datos = null;

            int contador = 0;

            datos = new List<List<string>>();

            while (contador < 20)
            {
                datos.Add(new List<string>() { "Actividad" + contador, "0", "0", "0", "0", "0", "0", "0" });
                contador++;
            } 

            return datos;
        }

        protected void Unnamed1_voCambioFecha(object sender, DateTime pd_fechaLunes)
        {
            this.calendario.poDatos = ObtenerDatos();
        }

    }
}