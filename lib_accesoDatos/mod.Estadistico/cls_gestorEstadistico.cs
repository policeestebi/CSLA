using System;
using System.Collections;
using System.Collections.Generic;

using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using COSEVI.CSLA.lib.accesoDatos;
using COSEVI.CSLA.lib.entidades.mod.ControlSeguimiento;
using COSEVI.CSLA.lib.accesoDatos.App_Database;
using COSEVI.CSLA.lib.accesoDatos.App_Constantes;
using COSEVI.CSLA.lib.accesoDatos.App_InterfaceComunes;
using COSEVI.CSLA.lib.entidades.mod.Estadistico;

//=======================================================================
// Consejo de Seguridad Vial (COSEVI). - 2011
// Sistema CSLA
//
// cls_gestorEstado.cs
//
// Explicación de los contenidos del archivo.
// =========================================================================
// Historial
// PERSONA 			        MES - DIA - AÑO		DESCRIPCION
// GENERADOR			 	16    05    2011    Se crea la clase
// Cristian Arce            17    05    2011    Se modifica los gestores producidos por el generador
// Cristian Arce Jiménez  	11    01    2012	Se agrega la modifica la inserción en la bitácora.
//								
//
//======================================================================

namespace COSEVI.CSLA.lib.accesoDatos.mod.Estadistico
{
    public class cls_gestorEstadistico
    {
        /// <summary>
       /// Método que permite seleccionar  
       /// un único registro en la tabla estado
       /// </summary>
       /// <returns>poEstado valor del resultado de la ejecución de la sentencia</returns>
        public static List<cls_estadistico> SeleccionarInfoPorProyecto(cls_estadistico poEstadistico)
       {
           List<cls_estadistico> vo_lista = null;
           cls_estadistico vo_Estadistico = null;

           try
           {
               String vs_comando = "PA_estd_inversionTiempos";
               cls_parameter[] vu_parametros = { new cls_parameter("@paramProyecto", poEstadistico.pPK_proyecto) };

               DataSet vu_dataSet = cls_sqlDatabase.executeDataset(vs_comando, true, vu_parametros);

               vo_lista = new List<cls_estadistico>();
               for (int i = 0; i < vu_dataSet.Tables[0].Rows.Count; i++)
               {
                   vo_Estadistico = new cls_estadistico();

                   vo_Estadistico.pTipoLabor = vu_dataSet.Tables[0].Rows[i]["tipo"].ToString();

                   vo_Estadistico.pCantidad = Convert.ToInt32(vu_dataSet.Tables[0].Rows[i]["cantidad"].ToString());

                   vo_lista.Add(vo_Estadistico);
               }

               return vo_lista;
           }
           catch (Exception po_exception)
           {
               throw new Exception("Ocurrió un error al obtener el gráfico específico.", po_exception);
           }
       }

        /// <summary>
        /// Método que permite seleccionar  
        /// la lista simple de proyectos del sistema
        /// </summary>
        /// <returns>poEstado valor del resultado de la ejecución de la sentencia</returns>
        public static List<cls_proyecto> listarProyectos()
        {
            List<cls_proyecto> vo_lista = null;
            cls_proyecto vo_proyecto = null;

            try
            {
                DataSet vu_dataSet = cls_gestorUtil.selectFilter(cls_constantes.PROYECTO, " PK_proyecto, nombre", " 1 = 1 ");

                vo_lista = new List<cls_proyecto>();

                for (int i = 0; i < vu_dataSet.Tables[0].Rows.Count; i++)
                {
                    vo_proyecto = new cls_proyecto();

                    vo_proyecto.pPK_proyecto = Convert.ToInt32(vu_dataSet.Tables[0].Rows[i]["PK_proyecto"].ToString());

                    vo_proyecto.pNombre = vu_dataSet.Tables[0].Rows[i]["nombre"].ToString();

                    vo_lista.Add(vo_proyecto);
                }

                return vo_lista;
            }
            catch (Exception po_exception)
            {
                throw new Exception("Ocurrió un error al obtener la lista de proyectos.", po_exception);
            }
        }


   }
}
