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
    public class cls_gestorActividadResp
    {
        /// <summary>
        /// Método que permite insertar 
        /// un nuevo registro en la tabla estado
        /// </summary>
        /// <param name="poActividad">Actividad a insertar</param>
        /// <returns>Int valor del resultado de la ejecución de la sentencia</returns>
	   public static int insertActividad(cls_actividadResp poActividad)
   {
            int vi_resultado;

            try
            {
                String vs_comando = "PA_cont_actividadInsert";
                cls_parameter[] vu_parametros = 
                {
                 		new cls_parameter("@paramPK_actividad", poActividad.pPK_Actividad),
                        new cls_parameter("@paramPK_paquete", poActividad.pPK_Paquete),
                        new cls_parameter("@paramPK_componente", poActividad.pPK_Componente),
                        new cls_parameter("@paramPK_entregable", poActividad.pPK_Entregable),
                        new cls_parameter("@paramPK_departamento", poActividad.pPK_Departmento),
                        new cls_parameter("@paramPK_proyecto", poActividad.pPK_Proyecto),
                        new cls_parameter("@paramPK_usuario", poActividad.pPK_Usuario),
                        new cls_parameter("@paramFK_estado", poActividad.pFK_Estado),
                        new cls_parameter("@paramnombre", poActividad.pNombre),
                        new cls_parameter("@paramdescripcion", poActividad.pDescripcion),
                        new cls_parameter("@paramfechaInicio", poActividad.pFechaInicio),
                        new cls_parameter("@paramfechaFin", poActividad.pFechaFin),
                        new cls_parameter("@paramhorasAsignadas", poActividad.pHorasAsignadas),
                        new cls_parameter("@paramhorasAsigDefectos", poActividad.pHorasAsigDefectos),
                        new cls_parameter("@paramhorasReales", poActividad.pHorasReales),
                        new cls_parameter("@paramhorasRealesDefectos", poActividad.pHorasRealesDefectos)
                };

                cls_sqlDatabase.beginTransaction();

                vi_resultado = cls_sqlDatabase.executeNonQuery(vs_comando, true, vu_parametros);

                // Se obtiene el número del registro insertado.
                poActividad.pPK_Actividad = Convert.ToInt32(cls_gestorUtil.selectMax(cls_constantes.ACTIVIDAD, "PK_actividad"));

                cls_interface.insertarTransacccionBitacora(cls_constantes.INSERTAR, cls_constantes.ACTIVIDAD, poActividad.pPK_Actividad.ToString());

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
       /// <param name="poActividad">Actividad a actualizar</param>
       /// <returns>Int valor del resultado de la ejecución de la sentencia</returns>
       public static int updateActividad(cls_actividadResp poActividad)
       {
            int vi_resultado;

            try
            {
                String vs_comando = "PA_cont_actividadUpdate";
                cls_parameter[] vu_parametros = 
                {
                    new cls_parameter("@paramPK_actividad", poActividad.pPK_Actividad),
                    new cls_parameter("@paramPK_paquete", poActividad.pPK_Paquete),
                    new cls_parameter("@paramPK_componente", poActividad.pPK_Componente),
                    new cls_parameter("@paramPK_entregable", poActividad.pPK_Entregable),
                    new cls_parameter("@paramPK_departamento", poActividad.pPK_Departmento),
                    new cls_parameter("@paramPK_proyecto", poActividad.pPK_Proyecto),
                    new cls_parameter("@paramPK_usuario", poActividad.pPK_Usuario),
                    new cls_parameter("@paramFK_estado", poActividad.pFK_Estado),
                    new cls_parameter("@paramnombre", poActividad.pNombre),
                    new cls_parameter("@paramdescripcion", poActividad.pDescripcion),
                    new cls_parameter("@paramfechaInicio", poActividad.pFechaInicio),
                    new cls_parameter("@paramfechaFin", poActividad.pFechaFin),
                    new cls_parameter("@paramhorasAsignadas", poActividad.pHorasAsignadas),
                    new cls_parameter("@paramhorasAsigDefectos", poActividad.pHorasAsigDefectos),
                    new cls_parameter("@paramhorasReales", poActividad.pHorasReales),
                    new cls_parameter("@paramhorasRealesDefectos", poActividad.pHorasRealesDefectos)
                };

                cls_sqlDatabase.beginTransaction();

                vi_resultado = cls_sqlDatabase.executeNonQuery(vs_comando, true, vu_parametros);

                cls_interface.insertarTransacccionBitacora(cls_constantes.MODIFICAR, cls_constantes.ACTIVIDAD, poActividad.pPK_Actividad.ToString());

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
       /// <param name="poActividad">Actividad a eliminar</param>
       /// <returns>Int valor del resultado de la ejecución de la sentencia</returns>
       public static int deleteActividad(cls_actividadResp poActividad)
       {
            int vi_resultado;

            try
            {
                String vs_comando = "PA_cont_actividadDelete";
                cls_parameter[] vu_parametros = 
                {
                    new cls_parameter("@paramPK_actividad", poActividad.pPK_Actividad),
                    new cls_parameter("@paramPK_paquete", poActividad.pPK_Paquete),
                    new cls_parameter("@paramPK_componente", poActividad.pPK_Componente),
                    new cls_parameter("@paramPK_entregable", poActividad.pPK_Entregable),
                    new cls_parameter("@paramPK_departamento", poActividad.pPK_Departmento),
                    new cls_parameter("@paramPK_proyecto", poActividad.pPK_Proyecto),
                    new cls_parameter("@paramPK_usuario", poActividad.pPK_Usuario)
                };

                cls_sqlDatabase.beginTransaction();

                vi_resultado = cls_sqlDatabase.executeNonQuery(vs_comando, true, vu_parametros);

                cls_interface.insertarTransacccionBitacora(cls_constantes.ELIMINAR, cls_constantes.ACTIVIDAD, poActividad.pPK_Actividad.ToString());

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
       public static List<cls_actividadResp> listarActividad()
       {
           List<cls_actividadResp> vo_lista = null;
           cls_actividadResp poActividad = null;
           try
           {
               String vs_comando = "PA_cont_actividadSelect";
               cls_parameter[] vu_parametros = { };

               DataSet vu_dataSet = cls_sqlDatabase.executeDataset(vs_comando, true, vu_parametros);

               vo_lista = new List<cls_actividadResp>();
               for (int i = 0; i < vu_dataSet.Tables[0].Rows.Count; i++)
               {
                   poActividad = new cls_actividadResp();

                   poActividad.pPK_Actividad = Convert.ToInt32(vu_dataSet.Tables[0].Rows[i]["PK_actividad"]);

                   poActividad.pPK_Paquete = Convert.ToInt32(vu_dataSet.Tables[0].Rows[i]["PK_paquete"]);

                   poActividad.pPK_Componente = Convert.ToInt32(vu_dataSet.Tables[0].Rows[i]["PK_componente"]);

                   poActividad.pPK_Entregable = Convert.ToInt32(vu_dataSet.Tables[0].Rows[i]["PK_entregable"]);

                   poActividad.pPK_Departmento = Convert.ToInt32(vu_dataSet.Tables[0].Rows[i]["PK_departmento"]);

                   poActividad.pPK_Proyecto = Convert.ToInt32(vu_dataSet.Tables[0].Rows[i]["PK_proyecto"]);

                   poActividad.pPK_Usuario = vu_dataSet.Tables[0].Rows[i]["PK_usuario"].ToString();

                   poActividad.pFK_Estado = Convert.ToInt32(vu_dataSet.Tables[0].Rows[i]["FK_estado"]);

                   poActividad.pNombre = vu_dataSet.Tables[0].Rows[i]["nombre"].ToString();

                   poActividad.pDescripcion = vu_dataSet.Tables[0].Rows[i]["descripcion"].ToString();

                   poActividad.pFechaInicio = Convert.ToDateTime(vu_dataSet.Tables[0].Rows[i]["fechaInicio"]);

                   poActividad.pFechaFin = Convert.ToDateTime(vu_dataSet.Tables[0].Rows[i]["fechaFin"]);

                   poActividad.pHorasAsignadas = Convert.ToDecimal(vu_dataSet.Tables[0].Rows[i]["horasAsignadas"]);

                   poActividad.pHorasAsigDefectos = Convert.ToDecimal(vu_dataSet.Tables[0].Rows[i]["horasAsigDefectos"]);

                   poActividad.pHorasReales = Convert.ToDecimal(vu_dataSet.Tables[0].Rows[i]["horasReales"]);

                   poActividad.pHorasRealesDefectos = Convert.ToDecimal(vu_dataSet.Tables[0].Rows[i]["horasRealesDefectos"]);

                   vo_lista.Add(poActividad);
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
       public static cls_actividadResp seleccionarActividad(cls_actividadResp poActividad)
       {
           try
           {
               String vs_comando = "PA_cont_actividadSelectOne";
               cls_parameter[] vu_parametros = { 
                                                   new cls_parameter("@paramPK_actividad", poActividad.pPK_Actividad),
                                                   new cls_parameter("@paramPK_paquete", poActividad.pPK_Paquete),
                                                   new cls_parameter("@paramPK_componente", poActividad.pPK_Componente),
                                                   new cls_parameter("@paramPK_entregable", poActividad.pPK_Entregable),
                                                   new cls_parameter("@paramPK_departamento", poActividad.pPK_Departmento),
                                                   new cls_parameter("@paramPK_proyecto", poActividad.pPK_Proyecto),
                                                   new cls_parameter("@paramPK_usuario", poActividad.pPK_Usuario)
                                               };

               DataSet vu_dataSet = cls_sqlDatabase.executeDataset(vs_comando, true, vu_parametros);

               poActividad = new cls_actividadResp();

                   poActividad.pPK_Actividad = Convert.ToInt32(vu_dataSet.Tables[0].Rows[0]["PK_actividad"]);

                   poActividad.pPK_Paquete = Convert.ToInt32(vu_dataSet.Tables[0].Rows[0]["PK_paquete"]);

                   poActividad.pPK_Componente = Convert.ToInt32(vu_dataSet.Tables[0].Rows[0]["PK_componente"]);

                   poActividad.pPK_Entregable = Convert.ToInt32(vu_dataSet.Tables[0].Rows[0]["PK_entregable"]);

                   poActividad.pPK_Departmento = Convert.ToInt32(vu_dataSet.Tables[0].Rows[0]["PK_departmento"]);

                   poActividad.pPK_Proyecto = Convert.ToInt32(vu_dataSet.Tables[0].Rows[0]["PK_proyecto"]);

                   poActividad.pPK_Usuario = vu_dataSet.Tables[0].Rows[0]["PK_usuario"].ToString();

                   poActividad.pFK_Estado = Convert.ToInt32(vu_dataSet.Tables[0].Rows[0]["FK_estado"]);

                   poActividad.pNombre = vu_dataSet.Tables[0].Rows[0]["nombre"].ToString();

                   poActividad.pDescripcion = vu_dataSet.Tables[0].Rows[0]["descripcion"].ToString();

                   poActividad.pFechaInicio = Convert.ToDateTime(vu_dataSet.Tables[0].Rows[0]["fechaInicio"]);

                   poActividad.pFechaFin = Convert.ToDateTime(vu_dataSet.Tables[0].Rows[0]["fechaFin"]);

                   poActividad.pHorasAsignadas = Convert.ToDecimal(vu_dataSet.Tables[0].Rows[0]["horasAsignadas"]);

                   poActividad.pHorasAsigDefectos = Convert.ToDecimal(vu_dataSet.Tables[0].Rows[0]["horasAsigDefectos"]);

                   poActividad.pHorasReales = Convert.ToDecimal(vu_dataSet.Tables[0].Rows[0]["horasReales"]);

                   poActividad.pHorasRealesDefectos = Convert.ToDecimal(vu_dataSet.Tables[0].Rows[0]["horasRealesDefectos"]);

               return poActividad;

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
       public static List<cls_actividadResp> listarActividadFiltro(string psFiltro)
       {
           List<cls_actividadResp> vo_lista = null;
           cls_actividadResp voActividad = null;
           try
           {
               DataSet vu_dataSet = cls_gestorUtil.selectFilter(cls_constantes.ACTIVIDAD, string.Empty, psFiltro);

               vo_lista = new List<cls_actividadResp>();

               for (int i = 0; i < vu_dataSet.Tables[0].Rows.Count; i++)
               {
                   voActividad = new cls_actividadResp();

                   voActividad.pPK_Actividad = Convert.ToInt32(vu_dataSet.Tables[0].Rows[0]["PK_actividad"]);

                   voActividad.pPK_Paquete = Convert.ToInt32(vu_dataSet.Tables[0].Rows[0]["PK_paquete"]);

                   voActividad.pPK_Componente = Convert.ToInt32(vu_dataSet.Tables[0].Rows[0]["PK_componente"]);

                   voActividad.pPK_Entregable = Convert.ToInt32(vu_dataSet.Tables[0].Rows[0]["PK_entregable"]);

                   voActividad.pPK_Departmento = Convert.ToInt32(vu_dataSet.Tables[0].Rows[0]["PK_departmento"]);

                   voActividad.pPK_Proyecto = Convert.ToInt32(vu_dataSet.Tables[0].Rows[0]["PK_proyecto"]);

                   voActividad.pPK_Usuario = vu_dataSet.Tables[0].Rows[0]["PK_usuario"].ToString();

                   voActividad.pFK_Estado = Convert.ToInt32(vu_dataSet.Tables[0].Rows[0]["FK_estado"]);

                   voActividad.pNombre = vu_dataSet.Tables[0].Rows[0]["nombre"].ToString();

                   voActividad.pDescripcion = vu_dataSet.Tables[0].Rows[0]["descripcion"].ToString();

                   voActividad.pFechaInicio = Convert.ToDateTime(vu_dataSet.Tables[0].Rows[0]["fechaInicio"]);

                   voActividad.pFechaFin = Convert.ToDateTime(vu_dataSet.Tables[0].Rows[0]["fechaFin"]);

                   voActividad.pHorasAsignadas = Convert.ToDecimal(vu_dataSet.Tables[0].Rows[0]["horasAsignadas"]);

                   voActividad.pHorasAsigDefectos = Convert.ToDecimal(vu_dataSet.Tables[0].Rows[0]["horasAsigDefectos"]);

                   voActividad.pHorasReales = Convert.ToDecimal(vu_dataSet.Tables[0].Rows[0]["horasReales"]);

                   voActividad.pHorasRealesDefectos = Convert.ToDecimal(vu_dataSet.Tables[0].Rows[0]["horasRealesDefectos"]);


                   vo_lista.Add(voActividad);
               }

               return vo_lista;
           }
           catch (Exception po_exception)
           {
               throw new Exception("Ocurrió un error al obtener el listado de las actividades de manera filtrada.", po_exception);
           }
       }

	
    }
}
