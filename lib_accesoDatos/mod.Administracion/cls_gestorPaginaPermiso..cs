using System;
using System.Collections;
using System.Collections.Generic;

using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using COSEVI.CSLA.lib.accesoDatos;
using COSEVI.CSLA.lib.accesoDatos.App_Database;
using COSEVI.CSLA.lib.accesoDatos.App_Constantes;
using COSEVI.CSLA.lib.accesoDatos.App_InterfaceComunes;
using COSEVI.CSLA.lib.entidades.mod.Administracion;

//=======================================================================
// Consejo de Seguridad Vial (COSEVI). - 2011
// Sistema CSLA
//
// cls_gestorPaginaPermiso.cs
//
// Explicación de los contenidos del archivo.
// =========================================================================
// Historial
// PERSONA 			        MES - DIA - AÑO		DESCRIPCION
// GENERADOR			 	16    05    2011    Se crea la clase
// Cristian Arce            22    05    2011    Se modifica los gestores producidos por el generador
// Cristian Arce Jiménez  	27    11    2011	Se agrega el manejo de excepciones personalizadas
// Esteban Ramírez          10    01    2012    Se agrega la inserción en la bitácora.
//								
//
//====================================================================== 

namespace COSEVI.CSLA.lib.accesoDatos.mod.Administracion
{
  
    public class cls_gestorPaginaPermiso
    {
       /// <summary>
        /// Método que permite insertar 
        /// un nuevo registro en la tabla paginaPermiso
        /// </summary>
        /// <param name="poPaginaPermiso">PaginaPermiso a insertar</param>
        /// <returns>Int valor del resultado de la ejecución de la sentencia</returns>
	   public static int insertPaginaPermiso(cls_paginaPermiso poPaginaPermiso)
        {
            int vi_resultado;

            try
            {
                String vs_comando = "PA_Pagina_permisoInsert";

                cls_parameter[] vu_parametros = 
                {
                    new cls_parameter("@paramPK_pagina", poPaginaPermiso.pPK_pagina),
                    new cls_parameter("@paramPK_permiso", poPaginaPermiso.pPK_permiso)
                };

                cls_sqlDatabase.beginTransaction();

                vi_resultado = cls_sqlDatabase.executeNonQuery(vs_comando, true, vu_parametros);

                cls_interface.insertarTransacccionBitacora(cls_constantes.INSERTAR, cls_constantes.PAGINA_PERMISO, poPaginaPermiso.pPK_pagina + "/" + poPaginaPermiso.pPK_permiso);

                cls_sqlDatabase.commitTransaction();

                return vi_resultado;

            }
            catch (Exception po_exception)
            {
                cls_sqlDatabase.rollbackTransaction();
                throw new Exception("Ocurrió un error al insertar el permiso de la página.", po_exception);
            }

    }

       /// <summary>
       /// Método que permite eliminar 
       /// un registro en la tabla paginaPermiso
       /// </summary>
       /// <param name="poPaginaPermiso">PaginaPermiso a eliminar</param>
       /// <returns>Int valor del resultado de la ejecución de la sentencia</returns>
       public static int deletePaginaPermiso(cls_paginaPermiso poPaginaPermiso)
        {
            int vi_resultado;

            try
            {
                String vs_comando = "PA_Pagina_permisoDelete";

                cls_parameter[] vu_parametros = 
                {
                    new cls_parameter("@paramPK_pagina", poPaginaPermiso.pPK_pagina),
                    new cls_parameter("@paramPK_permiso", poPaginaPermiso.pPK_permiso)
                };

                cls_sqlDatabase.beginTransaction();

                vi_resultado = cls_sqlDatabase.executeNonQuery(vs_comando, true, vu_parametros);

                cls_interface.insertarTransacccionBitacora(cls_constantes.ELIMINAR, cls_constantes.PAGINA_PERMISO, poPaginaPermiso.pPK_pagina + "/" + poPaginaPermiso.pPK_permiso);

                cls_sqlDatabase.commitTransaction();

                return vi_resultado;

            }
            catch (Exception po_exception)
            {
                cls_sqlDatabase.rollbackTransaction();
                throw new Exception("Ocurrió un error al eliminar el permiso de la página.", po_exception);
            }
        }	

    }
}
