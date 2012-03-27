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

//=======================================================================
// Consejo de Seguridad Vial (COSEVI). - 2011
// Sistema CSLA
//
// cls_gestorComponentePaquete.cs
//
// Explicación de los contenidos del archivo.
// =========================================================================
// Historial
// PERSONA 			        MES - DIA - AÑO		DESCRIPCION
// GENERADOR			 	16    05    2011    Se crea la clase
// Cristian Arce            22    05    2011    Se modifica los gestores producidos por el generador
// Cristian Arce Jiménez  	27    11    2011	Se agrega el manejo de excepciones personalizadas
// Cristian Arce Jiménez  	11    01    2012	Se agrega la modifica la inserción en la bitácora.
//
//======================================================================

namespace COSEVI.CSLA.lib.accesoDatos.mod.ControlSeguimiento
{
    public class cls_gestorComponentePaquete
    {
        /// <summary>
        /// Método que permite insertar 
        /// un nuevo registro en la tabla componentePaquete
        /// </summary>
        /// <param name="poComponentePaquete">ComponentePaquete a insertar</param>
        /// <returns>Int valor del resultado de la ejecución de la sentencia</returns>
	   public static int insertComponentePaquete(cls_componentePaquete poComponentePaquete)
   {
            int vi_resultado;

            try
            {
                String vs_comando = "PA_cont_componente_paqueteInsert";
                cls_parameter[] vu_parametros = 
                {
                    new cls_parameter("@paramPK_paquete", poComponentePaquete.pPK_paquete),
                    new cls_parameter("@paramPK_componente", poComponentePaquete.pPK_componente),
                    new cls_parameter("@paramPK_entregable", poComponentePaquete.pPK_entregable),
                    new cls_parameter("@paramPK_proyecto", poComponentePaquete.pPK_proyecto)
                };

                cls_sqlDatabase.beginTransaction();

                vi_resultado = cls_sqlDatabase.executeNonQuery(vs_comando, true, vu_parametros);

                cls_interface.insertarTransacccionBitacora(cls_constantes.INSERTAR, cls_constantes.COMPONENTE_PAQUETE, poComponentePaquete.pPK_proyecto + "/" + poComponentePaquete.pPK_entregable + "/" + poComponentePaquete.pPK_componente + "/" + poComponentePaquete.pPK_paquete);

                cls_sqlDatabase.commitTransaction();

                return vi_resultado;

            }
            catch (Exception po_exception)
            {
                cls_sqlDatabase.rollbackTransaction();
                throw new Exception("Ocurrió un error al insertar el componente del paquete.", po_exception);
            }

    }

       /// <summary>
       /// Método que permite eliminar 
       /// un registro en la tabla componentePaquete
       /// </summary>
       /// <param name="poComponentePaquete">ComponentePaquete a eliminar</param>
       /// <returns>Int valor del resultado de la ejecución de la sentencia</returns>
       public static int deleteComponentePaquete(cls_componentePaquete poComponentePaquete)
       {
            int vi_resultado;

            try
            {
                String vs_comando = "PA_cont_componente_paqueteDelete";
                cls_parameter[] vu_parametros = 
                {
                    
                    new cls_parameter("@paramPK_paquete", poComponentePaquete.pPK_paquete),
                    new cls_parameter("@paramPK_componente", poComponentePaquete.pPK_componente),
                    new cls_parameter("@paramPK_entregable", poComponentePaquete.pPK_entregable),
                    new cls_parameter("@paramPK_proyecto", poComponentePaquete.pPK_proyecto)  
                };

                cls_sqlDatabase.beginTransaction();

                vi_resultado = cls_sqlDatabase.executeNonQuery(vs_comando, true, vu_parametros);

                cls_interface.insertarTransacccionBitacora(cls_constantes.ELIMINAR, cls_constantes.COMPONENTE_PAQUETE, poComponentePaquete.pPK_proyecto + "/" + poComponentePaquete.pPK_entregable + "/" + poComponentePaquete.pPK_componente + "/" + poComponentePaquete.pPK_paquete);

                cls_sqlDatabase.commitTransaction();

                return vi_resultado;

            }
            catch (Exception po_exception)
            {
                cls_sqlDatabase.rollbackTransaction();
                throw new Exception("Ocurrió un error al eliminar el componente del paquete.", po_exception);
            }

    }	
    }
}
