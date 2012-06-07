using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



//======================================================================
// Consejo de Seguridad Vial (COSEVI). - 2011
// Sistema CSLA
//
// cls_estado.cs
//
/// Clase que asocia la información de las actividades de los proyectos
// del Consejo de Seguridad Vial.
// =====================================================================
// Historial
// PERSONA 			        MES - DIA - AÑO		DESCRIPCION
// Cristian Arce            05  - 15    2011    Se crea la clase.
//							
// 
//								
//								
//
//======================================================================

namespace COSEVI.CSLA.lib.entidades.mod.Estadistico
{
    /// <summary>
    /// Clase que asocia los estados a los proyectos y actividades
    /// del Consejo de Seguridad Vial.
    /// </summary>
	public class cls_estadistico
    {

        #region Constructor

        /// <summary>
        /// Constructor de la clase cls_estado.
        /// </summary>
        public cls_estadistico()
        {
        }

        #endregion

        #region Propiedades

        public int pPK_proyecto
        {
            get { return PK_proyecto; }
            set { this.PK_proyecto = value; }
        }

        public string pTipoLabor
        {
            get { return tipoLabor; }
            set { this.tipoLabor = value; }
        }

        public int pCantidad
        {
            get { return cantidad; }
            set { this.cantidad = value; }
        }

        #endregion

		#region Atributos

        /// <summary>
        /// Código del proyecto
        /// </summary>
 	    private int PK_proyecto;

        /// <summary>
        /// Tipo de labor para el desgloce
        /// </summary>
	    private string tipoLabor;

        /// <summary>
        /// Cantidad de registros
        /// </summary>
        private int cantidad;

        #endregion

    }

}

