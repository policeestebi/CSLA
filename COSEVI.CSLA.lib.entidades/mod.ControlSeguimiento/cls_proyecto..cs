using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using COSEVI.CSLA.lib.entidades.mod.Administracion;



//======================================================================
// Consejo de Seguridad Vial (COSEVI). - 2011
// Sistema CSLA
//
// cls_proyecto.cs
//
// Clase que contiene la información relacionada con los proyectos
// del Consejo de Seguridad Vial.
// =====================================================================
// Historial
// PERSONA 			        MES - DIA - AÑO		DESCRIPCION
// Cristian Arce            05  - 15  - 2011    Se crea la clase.
// Cristian Arce            31  - 10  - 2011    Se crea la clase.//							
// 
//								
//								
//
//======================================================================

namespace COSEVI.CSLA.lib.entidades.mod.ControlSeguimiento
{
	public class cls_proyecto
    {

        #region Constructor

        /// <summary>
        /// Constructor de la clase cls_proyecto.
        /// </summary>
        public cls_proyecto()
        {
            this.estadoProyecto = new cls_estado();
            this.entregableLista = new List<cls_entregable>();
            this.componenteLista = new List<cls_componente>();

            this.proyectoEntregableLista = new List<cls_proyectoEntregable>();
            this.entregableComponenteLista = new List<cls_entregableComponente>();

        }

        #endregion

        #region Propiedades

        public int pPK_proyecto
        {
            get { return PK_proyecto; }
            set { this.PK_proyecto = value; }
        }

		public int pFK_estado
        {
            get { return pEstado.pPK_estado; }
            set { this.pEstado.pPK_estado = value; }
        }

        public string pDescripcionEstado
        {
            get { return pEstado.pDescripcion; }
            set { this.pEstado.pDescripcion = value; }
        }

		public string pNombre
        {
            get { return nombre; }
            set { this.nombre = value; }
        }

		public string pDescripcion
        {
            get { return descripcion; }
            set { this.descripcion = value; }
        }

		public string pObjetivo
        {
            get { return objetivo; }
            set { this.objetivo = value; }
        }

		public string pMeta
        {
            get { return meta; }
            set { this.meta = value; }
        }

		public DateTime pFechaInicio
        {
            get { return fechaInicio; }
            set { this.fechaInicio = value; }
        }

		public DateTime pFechaFin
        {
            get { return fechaFin; }
            set { this.fechaFin = value; }
        }

		public decimal pHorasAsignadas
        {
            get { return horasAsignadas; }
            set { this.horasAsignadas = value; }
        }

		public decimal pHorasAsigDefectos
        {
            get { return horasAsigDefectos; }
            set { this.horasAsigDefectos = value; }
        }

		public decimal pHorasReales
        {
            get { return horasReales; }
            set { this.horasReales = value; }
        }

		public decimal pHorasRealesDefectos
        {
            get { return horasRealesDefectos; }
            set { this.horasRealesDefectos = value; }
        }

        public cls_estado pEstado
        {
            get { return estadoProyecto; }
            set { this.estadoProyecto = value; }
        }

        public List<cls_departamentoProyecto> pDptoProyLista
        {
            get { return dptoProyLista; }
            set { this.dptoProyLista = value; }
        }

        public List<cls_departamento> pDepartamentoLista
        {
            get { return departamentoLista; }
            set { this.departamentoLista = value; }
        }

        #endregion

		#region Atributos

        /// <summary>
        /// Código del proyecto
        /// </summary>
 	    private int PK_proyecto;

        /// <summary>
        /// Código del estado
        /// </summary>
	    private int FK_estado;

        /// <summary>
        /// Nombre del proyecto
        /// </summary>
	    private string nombre;

        /// <summary>
        /// Descripción del proyecto
        /// </summary>
	    private string descripcion;

        /// <summary>
        /// Objetivo del proyecto
        /// </summary>
	    private string objetivo;

        /// <summary>
        /// Meta del proyecto
        /// </summary>
	    private string meta;

        /// <summary>
        /// Fecha de Inicio del proyecto
        /// </summary>
	    private DateTime fechaInicio;

        /// <summary>
        /// Fecha de Finalización del proyecto
        /// </summary>
	    private DateTime fechaFin;

        /// <summary>
        /// Horas asignadas para el proyecto
        /// </summary>
	    private decimal horasAsignadas;

        /// <summary>
        /// Horas asignadas para defectos del proyecto
        /// </summary>
	    private decimal horasAsigDefectos;

        /// <summary>
        /// Horas reales de duración del proyecto
        /// </summary>
	    private decimal horasReales;

        /// <summary>
        /// Horas reales en la corrección de defectos para el proyecto
        /// </summary>
	    private decimal horasRealesDefectos;

	    private cls_estado estadoProyecto;

        private List<cls_departamento> departamentoLista = new List<cls_departamento>();

        private List<cls_departamentoProyecto> dptoProyLista = new List<cls_departamentoProyecto>();

        #endregion

        #region Creación de Proyecto

        #region Atributos

        private List<cls_entregable> entregableLista = new List<cls_entregable>();

        private List<cls_componente> componenteLista = new List<cls_componente>();

        private List<cls_proyectoEntregable> proyectoEntregableLista = new List<cls_proyectoEntregable>();

        private List<cls_entregableComponente> entregableComponenteLista = new List<cls_entregableComponente>();

        #endregion Atributos


        #region Propiedades

        public List<cls_entregable> pEntregableLista
        {
            get { return entregableLista; }
            set { this.entregableLista = value; }
        }

        public List<cls_componente> pComponenteLista
        {
            get { return componenteLista; }
            set { this.componenteLista = value; }
        }

        public List<cls_proyectoEntregable> pProyectoEntregableLista
        {
            get { return proyectoEntregableLista; }
            set { this.proyectoEntregableLista = value; }
        }

        public List<cls_entregableComponente> pEntregableComponenteLista
        {
            get { return entregableComponenteLista; }
            set { this.entregableComponenteLista = value; }
        }

        #endregion Propiedades

        #endregion Creación de Proyecto

    }

}

