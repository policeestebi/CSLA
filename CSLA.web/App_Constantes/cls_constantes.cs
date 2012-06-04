﻿using System;
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

        /// <summary>
        /// Constante que se utiliza para
        /// obtener el Key en el web.config
        /// con la dirección URL.
        /// </summary>
        public const String URLKEY =  "URL";

        /// <summary>
        /// Script que se utiliza
        /// para salir al login cuando 
        /// se validan las páginas.
        /// </summary>
        public static String SCRIPTLOGOUT = String.Format("top.location = '{0}';",ConfigurationManager.AppSettings[URLKEY]);

        /// <summary>
        /// Constante que se utiliza para determinar el folder
        /// en donde se ubican todas las páginas del sistema.
        /// </summary>
        public const String FOLDER_PAGES = "App_pages";

    }
}
