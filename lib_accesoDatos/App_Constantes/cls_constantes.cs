using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COSEVI.CSLA.lib.accesoDatos.App_Constantes
{
    public class cls_constantes
    {

        //Parámetros transacciones
        public const String INSERTAR = "Insertar";
        public const String MODIFICAR = "Modificar";
        public const String ELIMINAR = "Eliminar";
        public const String LOGIN = "Login";
        public const String LOGOFF = "Logoff";

        //Nombre Tablas
        public const String PERMISO = "t_admi_permiso";
        public const String ROL = "t_admi_rol";
        public const String MENU = "t_admi_menu";
        public const String COMPONENTE = "t_cont_componente";
        public const String ENTREGABLE = "t_cont_entregable";
        public const String ESTADO = "t_cont_estado";
        public const String PAQUETE = "t_cont_paquete";
        public const String CONSECUTIVO = "t_admi_consecutivo";
        public const String DEPARTAMENTO = "t_admi_departamento";
        public const String PAGINA = "t_admi_pagina";
        public const String PAGINA_PERMISO = "t_admi_pagina_permiso";
        public const String ROL_PAGINA_PERMISO = "t_admi_rol_pagina_permiso";
        public const String USUARIO = "t_admi_usuario";
        public const String ACTIVIDAD = "t_cont_actividad";
        public const String BITACORA = "t_admi_bitacora";
        public const String ENTREGABLE_COMPONENTE = "t_cont_entregable_componente";
        public const String PROYECTO_ENTREGABLE = "t_cont_proyecto_entregable";
        public const String COMPONENTE_PAQUETE = "t_cont_componente_paquete";
        public const String PROYECTO = "t_cont_proyecto";
        public const String DEPARTAMENTO_PROYECTO = "t_cont_departamento_proyecto";
        public const String OPERACION = "t_cont_operacion";
        public const String OPERACION_ASIGNACION = "t_cont_asignacion_operacion";
        public const String OPERACION_REGISTRO = "t_cont_registro_operacion";
        public const String ACTIVIDAD_REGISTRO = "t_cont_registro_actividad";

        public const String NOMBRE_IMPREVISTO = "Imprevisto";
        public const String NOMBRE_OPERACION = "Operación";
        public const int CODIGO_IMPREVISTO = 0;
        public const int CODIGO_OPERACION = -1;
        public const int CODIGO_INVALIDO = -1;

    }
}
