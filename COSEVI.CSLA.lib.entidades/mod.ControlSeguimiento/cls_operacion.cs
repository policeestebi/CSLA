using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//======================================================================
// Consejo de Seguridad Vial (COSEVI). - 2011
// Sistema CSLA
//
// cls_actividad.cs
//
// Clase que asocia la información de las operaciones por realizar por lo empleados
// del Consejo de Seguridad Vial.
// =====================================================================
// Historial
// PERSONA 			        MES - DIA - AÑO		DESCRIPCION
// Esteban Ramírez          04  - 08    2012    Se crea la clase.
//							
// 
//								
//								
//
//======================================================================

namespace COSEVI.CSLA.lib.entidades.mod.ControlSeguimiento
{
    public class cls_operacion
    {
        #region Constructor

        public cls_operacion()
        {
        }

        #endregion

        #region Propiedades

        public string PK_Tipo
        {
            get { return PK_tipo; }
            set { PK_tipo = value; }
        }

        public int FK_Proyecto
        {
            get { return FK_proyecto; }
            set { FK_proyecto = value; }
        }

        public int PK_Codigo
        {
            get { return PK_codigo; }
            set { PK_codigo = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        #endregion

        #region Atributos

        private string PK_tipo;

        private int FK_proyecto;

        private int PK_codigo;

        private string descripcion;

        #endregion
    }
}
