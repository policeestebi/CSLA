using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
namespace CSLA.web.App_Constantes
{
    public class cls_constantes
    {
        //Parámetros operaciones
        public const String AGREGAR = "Agregar";
        public const String ELIMINAR = "Eliminar";
        public const String MODIFICAR = "Modificar";
        public const String EDITAR = "Editar";
        public const String VER = "Ver";
        public const String ACCESO = "Acceso";
        public const String CAMBIAR = "Cambiar";
        public const String CREAR= "Crear";
        public const String ASIGNAR = "Asignar";
        public const String COPIAR = "Copiar";


        //Parámetros para las urls
        public const string MODO = "modo";
        public const string PERMISO = "permiso";
        public const string PERMISONOMBRE = "pN";

        //Constantes de la sesion
        public const string PAGINA = "vo_pagina";

        public const String URLKEY =  "URL";

        public static String SCRIPTLOGOUT = String.Format("top.location = '{0}'",ConfigurationManager.AppSettings[URLKEY]);

    }
}
