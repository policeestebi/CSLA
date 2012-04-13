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
// cls_gestorActividad.cs
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
    public class cls_gestorAsignacionActividad
    {
        /// <summary>
        /// Método que permite insertar 
        /// un nuevo registro en la tabla estado
        /// </summary>
        /// <param name="po_Actividad">Actividad a insertar</param>
        /// <returns>Int valor del resultado de la ejecución de la sentencia</returns>
	   public static int insertActividad(cls_asignacionActividad po_Actividad)
   {
            int vi_resultado;

            try
            {
                String vs_comando = "PA_cont_asignacionActividadInsert";
                cls_parameter[] vu_parametros = 
                {
                 		new cls_parameter("@paramPK_actividad", po_Actividad.pPK_Actividad),
                        new cls_parameter("@paramPK_paquete", po_Actividad.pPK_Paquete),
                        new cls_parameter("@paramPK_componente", po_Actividad.pPK_Componente),
                        new cls_parameter("@paramPK_entregable", po_Actividad.pPK_Entregable),
                        new cls_parameter("@paramPK_proyecto", po_Actividad.pPK_Proyecto),
                        new cls_parameter("@paramPK_usuario", po_Actividad.pPK_Usuario),
                        new cls_parameter("@paramFK_estado", po_Actividad.pFK_Estado),
                        new cls_parameter("@paramdescripcion", po_Actividad.pDescripcion),
                        new cls_parameter("@paramfechaInicio", po_Actividad.pFechaInicio),
                        new cls_parameter("@paramfechaFin", po_Actividad.pFechaFin),
                        new cls_parameter("@paramhorasAsignadas", po_Actividad.pHorasAsignadas),
                        new cls_parameter("@paramhorasAsigDefectos", po_Actividad.pHorasAsigDefectos),
                        new cls_parameter("@paramhorasReales", po_Actividad.pHorasReales),
                        new cls_parameter("@paramhorasRealesDefectos", po_Actividad.pHorasRealesDefectos)
                };

                cls_sqlDatabase.beginTransaction();

                vi_resultado = cls_sqlDatabase.executeNonQuery(vs_comando, true, vu_parametros);

                // Se obtiene el número del registro insertado.
                po_Actividad.pPK_Actividad = Convert.ToInt32(cls_gestorUtil.selectMax(cls_constantes.ACTIVIDAD, "PK_actividad"));

                //cls_interface.insertarTransacccionBitacora(cls_constantes.INSERTAR, cls_constantes.ACTIVIDAD, po_Actividad.pPK_Actividad.ToString());

                cls_sqlDatabase.commitTransaction();

                return vi_resultado;

            }
            catch (Exception po_exception)
            {
                cls_sqlDatabase.rollbackTransaction();
                throw new Exception("Ocurrió un error al insertar la actividad.", po_exception);
            }

    }

       /// <summary>
       /// Método que permite actualizar 
       /// un registro en la tabla Actividad
       /// </summary>
       /// <param name="po_Actividad">Actividad a actualizar</param>
       /// <returns>Int valor del resultado de la ejecución de la sentencia</returns>
       public static int updateActividad(cls_asignacionActividad po_Actividad)
       {
            int vi_resultado;

            try
            {
                String vs_comando = "PA_cont_asignacionActividadUpdate";
                cls_parameter[] vu_parametros = 
                {
                    new cls_parameter("@paramPK_actividad", po_Actividad.pPK_Actividad),
                    new cls_parameter("@paramPK_paquete", po_Actividad.pPK_Paquete),
                    new cls_parameter("@paramPK_componente", po_Actividad.pPK_Componente),
                    new cls_parameter("@paramPK_entregable", po_Actividad.pPK_Entregable),
                    new cls_parameter("@paramPK_proyecto", po_Actividad.pPK_Proyecto),
                    new cls_parameter("@paramPK_usuario", po_Actividad.pPK_Usuario),
                    new cls_parameter("@paramFK_estado", po_Actividad.pFK_Estado),
                    new cls_parameter("@paramdescripcion", po_Actividad.pDescripcion),
                    new cls_parameter("@paramfechaInicio", po_Actividad.pFechaInicio),
                    new cls_parameter("@paramfechaFin", po_Actividad.pFechaFin),
                    new cls_parameter("@paramhorasAsignadas", po_Actividad.pHorasAsignadas),
                    new cls_parameter("@paramhorasAsigDefectos", po_Actividad.pHorasAsigDefectos),
                    new cls_parameter("@paramhorasReales", po_Actividad.pHorasReales),
                    new cls_parameter("@paramhorasRealesDefectos", po_Actividad.pHorasRealesDefectos)
                };

                cls_sqlDatabase.beginTransaction();

                vi_resultado = cls_sqlDatabase.executeNonQuery(vs_comando, true, vu_parametros);

                cls_interface.insertarTransacccionBitacora(cls_constantes.MODIFICAR, cls_constantes.ACTIVIDAD, po_Actividad.pPK_Actividad.ToString());

                cls_sqlDatabase.commitTransaction();

                return vi_resultado;

            }
            catch (Exception po_exception)
            {
                cls_sqlDatabase.rollbackTransaction();
                throw new Exception("Ocurrió un error al modificar la actividad.", po_exception);
            }

    }

       /// <summary>
       /// Método que permite eliminar 
       /// un registro en la tabla Actividad
       /// </summary>
       /// <param name="po_Actividad">Actividad a eliminar</param>
       /// <returns>Int valor del resultado de la ejecución de la sentencia</returns>
       public static int deleteActividad(cls_asignacionActividad po_Actividad)
       {
            int vi_resultado;

            try
            {
                String vs_comando = "PA_cont_asignacionActividadDelete";
                cls_parameter[] vu_parametros = 
                {
                    new cls_parameter("@paramPK_actividad", po_Actividad.pPK_Actividad),
                    new cls_parameter("@paramPK_paquete", po_Actividad.pPK_Paquete),
                    new cls_parameter("@paramPK_componente", po_Actividad.pPK_Componente),
                    new cls_parameter("@paramPK_entregable", po_Actividad.pPK_Entregable),
                    new cls_parameter("@paramPK_proyecto", po_Actividad.pPK_Proyecto),
                    new cls_parameter("@paramPK_usuario", po_Actividad.pPK_Usuario)
                };

                cls_sqlDatabase.beginTransaction();

                vi_resultado = cls_sqlDatabase.executeNonQuery(vs_comando, true, vu_parametros);

                cls_interface.insertarTransacccionBitacora(cls_constantes.ELIMINAR, cls_constantes.ACTIVIDAD, po_Actividad.pPK_Actividad.ToString());

                cls_sqlDatabase.commitTransaction();

                return vi_resultado;

            }
            catch (Exception po_exception)
            {
                cls_sqlDatabase.rollbackTransaction();
                throw new Exception("Ocurrió un error al eliminar la actividad.", po_exception);
            }

       }

       /// <summary>
       /// Método que permite listar 
       /// todos los registros en la tabla actividad
       /// </summary>
       /// <returns> List<cls_actividad>  valor del resultado de la ejecución de la sentencia</returns>
       public static List<cls_asignacionActividad> listarActividades()
       {
           List<cls_asignacionActividad> vo_lista = null;
           cls_asignacionActividad vo_Actividad = null;
           try
           {
               String vs_comando = "PA_cont_actividadSelect";
               cls_parameter[] vu_parametros = {
                                                  
                                               };

               DataSet vu_dataSet = cls_sqlDatabase.executeDataset(vs_comando, true, vu_parametros);

               vo_lista = new List<cls_asignacionActividad>();
               for (int i = 0; i < vu_dataSet.Tables[0].Rows.Count; i++)
               {
                   vo_Actividad = new cls_asignacionActividad();

                   vo_Actividad.pPK_Actividad = Convert.ToInt32(vu_dataSet.Tables[0].Rows[i]["PK_actividad"]);

                   vo_Actividad.pPK_Paquete = Convert.ToInt32(vu_dataSet.Tables[0].Rows[i]["PK_paquete"]);

                   vo_Actividad.pPK_Componente = Convert.ToInt32(vu_dataSet.Tables[0].Rows[i]["PK_componente"]);

                   vo_Actividad.pPK_Entregable = Convert.ToInt32(vu_dataSet.Tables[0].Rows[i]["PK_entregable"]);

                   vo_Actividad.pPK_Proyecto = Convert.ToInt32(vu_dataSet.Tables[0].Rows[i]["PK_proyecto"]);

                   vo_Actividad.pPK_Usuario = vu_dataSet.Tables[0].Rows[i]["PK_usuario"].ToString();

                   vo_Actividad.pFK_Estado = Convert.ToInt32(vu_dataSet.Tables[0].Rows[i]["FK_estado"]);

                   vo_Actividad.pDescripcion = vu_dataSet.Tables[0].Rows[i]["descripcion"].ToString();

                   vo_Actividad.pFechaInicio = Convert.ToDateTime(vu_dataSet.Tables[0].Rows[i]["fechaInicio"]);

                   vo_Actividad.pFechaFin = Convert.ToDateTime(vu_dataSet.Tables[0].Rows[i]["fechaFin"]);

                   vo_Actividad.pHorasAsignadas = Convert.ToDecimal(vu_dataSet.Tables[0].Rows[i]["horasAsignadas"]);

                   vo_Actividad.pHorasAsigDefectos = Convert.ToDecimal(vu_dataSet.Tables[0].Rows[i]["horasAsigDefectos"]);

                   vo_Actividad.pHorasReales = Convert.ToDecimal(vu_dataSet.Tables[0].Rows[i]["horasReales"]);

                   vo_Actividad.pHorasRealesDefectos = Convert.ToDecimal(vu_dataSet.Tables[0].Rows[i]["horasRealesDefectos"]);

                   vo_lista.Add(vo_Actividad);
               }

               return vo_lista;
           }
           catch (Exception po_exception)
           {
               throw new Exception("Ocurrió un error al obtener el listado de las actividades.", po_exception);
           }

       }

       /// <summary>
       /// Método que permite seleccionar  
       /// un único registro en la tabla estado
       /// </summary>
       /// <returns>poActividad valor del resultado de la ejecución de la sentencia</returns>
       public static cls_asignacionActividad seleccionarActividad(cls_asignacionActividad po_Actividad)
       {
           try
           {
               String vs_comando = "PA_cont_actividadSelectOne";
               cls_parameter[] vu_parametros = { 
                                                   new cls_parameter("@paramPK_actividad", po_Actividad.pPK_Actividad),
                                                   new cls_parameter("@paramPK_paquete", po_Actividad.pPK_Paquete),
                                                   new cls_parameter("@paramPK_componente", po_Actividad.pPK_Componente),
                                                   new cls_parameter("@paramPK_entregable", po_Actividad.pPK_Entregable),
                                                   new cls_parameter("@paramPK_proyecto", po_Actividad.pPK_Proyecto),
                                                   new cls_parameter("@paramPK_usuario", po_Actividad.pPK_Usuario)
                                               };

               DataSet vu_dataSet = cls_sqlDatabase.executeDataset(vs_comando, true, vu_parametros);

               po_Actividad = new cls_asignacionActividad();

                   po_Actividad.pPK_Actividad = Convert.ToInt32(vu_dataSet.Tables[0].Rows[0]["PK_actividad"]);

                   po_Actividad.pPK_Paquete = Convert.ToInt32(vu_dataSet.Tables[0].Rows[0]["PK_paquete"]);

                   po_Actividad.pPK_Componente = Convert.ToInt32(vu_dataSet.Tables[0].Rows[0]["PK_componente"]);

                   po_Actividad.pPK_Entregable = Convert.ToInt32(vu_dataSet.Tables[0].Rows[0]["PK_entregable"]);

                   po_Actividad.pPK_Proyecto = Convert.ToInt32(vu_dataSet.Tables[0].Rows[0]["PK_proyecto"]);

                   po_Actividad.pPK_Usuario = vu_dataSet.Tables[0].Rows[0]["PK_usuario"].ToString();

                   po_Actividad.pFK_Estado = Convert.ToInt32(vu_dataSet.Tables[0].Rows[0]["FK_estado"]);

                   po_Actividad.pDescripcion = vu_dataSet.Tables[0].Rows[0]["descripcion"].ToString();

                   po_Actividad.pFechaInicio = Convert.ToDateTime(vu_dataSet.Tables[0].Rows[0]["fechaInicio"]);

                   po_Actividad.pFechaFin = Convert.ToDateTime(vu_dataSet.Tables[0].Rows[0]["fechaFin"]);

                   po_Actividad.pHorasAsignadas = Convert.ToDecimal(vu_dataSet.Tables[0].Rows[0]["horasAsignadas"]);

                   po_Actividad.pHorasAsigDefectos = Convert.ToDecimal(vu_dataSet.Tables[0].Rows[0]["horasAsigDefectos"]);

                   po_Actividad.pHorasReales = Convert.ToDecimal(vu_dataSet.Tables[0].Rows[0]["horasReales"]);

                   po_Actividad.pHorasRealesDefectos = Convert.ToDecimal(vu_dataSet.Tables[0].Rows[0]["horasRealesDefectos"]);

               return po_Actividad;

           }
           catch (Exception po_exception)
           {
               throw new Exception("Ocurrió un error al seleccionar la actividad específica.", po_exception);
           }

       }

       /// <summary>
       /// Hace un lista de permisos con un filtrado específico.
       /// </summary>
       /// <param name="psFiltro">String filtro.</param>
       /// <returns></returns>
       public static List<cls_asignacionActividad> listarActividadesProyecto(int ps_proyecto)
       {
           List<cls_asignacionActividad> vo_lista = null;
           cls_asignacionActividad vo_asignacionActividad = null;
           try
           {
               String vs_comando = "PA_cont_actividadesProyectoSelectAll";
               cls_parameter[] vu_parametros = {
                                                 new cls_parameter("@paramPK_proyecto", ps_proyecto.ToString())
                                               };

               DataSet vu_dataSet = cls_sqlDatabase.executeDataset(vs_comando, true, vu_parametros);

               vo_lista = new List<cls_asignacionActividad>();
               for (int i = 0; i < vu_dataSet.Tables[0].Rows.Count; i++)
               {
                   vo_asignacionActividad = new cls_asignacionActividad();

                   vo_asignacionActividad.pPK_Actividad = Convert.ToInt32(vu_dataSet.Tables[0].Rows[i]["PK_actividad"]);

                   vo_asignacionActividad.pPK_Paquete = Convert.ToInt32(vu_dataSet.Tables[0].Rows[i]["PK_paquete"]);

                   vo_asignacionActividad.pPK_Componente = Convert.ToInt32(vu_dataSet.Tables[0].Rows[i]["PK_componente"]);

                   vo_asignacionActividad.pPK_Entregable = Convert.ToInt32(vu_dataSet.Tables[0].Rows[i]["PK_entregable"]);

                   vo_asignacionActividad.pPK_Proyecto = Convert.ToInt32(vu_dataSet.Tables[0].Rows[i]["PK_proyecto"]);

                   vo_asignacionActividad.pNombreActividad = vu_dataSet.Tables[0].Rows[i]["nombre"].ToString();

                   vo_lista.Add(vo_asignacionActividad);
               }

               return vo_lista;
           }
           catch (Exception po_exception)
           {
               throw new Exception("Ocurrió un error al obtener el listado de las actividades.", po_exception);
           }
       }

	
    }
}
