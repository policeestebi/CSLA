using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



//======================================================================
// Consejo de Seguridad Vial (COSEVI). - 2011
// Sistema CSLA
//
// cls_componente_paquete.cs
//
// Clase que contiene la información relacionada con los paquetes pertenecientes a los componentes 
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

namespace COSEVI.CSLA.lib.entidades.mod.ControlSeguimiento
{
	public class cls_componentePaquete
    {
        /// <summary>
        /// Clase que contiene la información relacionada con los paquetes pertenecientes a los componentes
        /// del Consejo de Seguridad Vial.
        /// </summary>
        /// 

        #region Constructor

        /// <summary>
        /// Constructor de la clase cls_componente_paquete.
        /// </summary>
        public cls_componentePaquete()
        {
            this.paquete = new cls_paquete();
            //this.entregableComponente = new cls_entregableComponente();

        }

        #endregion

        #region Propiedades

        public int pPK_componente
        {
            get { return entregableComponente.pPK_Componente; }
            set { this.entregableComponente.pPK_Componente = value; }
        }

        public int pPK_entregable
        {
            get { return entregableComponente.pPK_Entregable; }
            set { this.entregableComponente.pPK_Entregable = value; }
        }

        public int pPK_proyecto
        {
            get { return entregableComponente.pPK_Proyecto; }
            set { this.entregableComponente.pPK_Proyecto = value; }
        }

        public int pPK_paquete
        {
            get { return paquete.pPK_Paquete; }
            set { this.paquete.pPK_Paquete = value; }
        }

        public cls_entregableComponente pEntregableComponente
        {
            get { return entregableComponente; }
            set { this.entregableComponente = value; }
        }

        public cls_paquete pPaquete
        {
            get { return paquete; }
            set { this.paquete = value; }
        }

        #endregion

		#region Atributos

	    private cls_entregableComponente entregableComponente;

	    private cls_paquete paquete;
 
        #endregion
     
	}

}

