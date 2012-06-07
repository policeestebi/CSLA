USE CSLA
GO

IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_estadoSelect]'))
DROP PROCEDURE [dbo].[PA_cont_estadoSelect]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Autor: Generador
-- Fecha Creación:	15-05-2011
-- Fecha Actulización:	15-05-2011
-- Descripción: 
-- =============================================
CREATE PROCEDURE  PA_cont_estadoSelect 
AS
 BEGIN 
		SELECT 
			PK_estado, 
			descripcion 
		FROM t_cont_estado
END  
 GO 
 
IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_proyectoSelect]'))
DROP PROCEDURE [dbo].[PA_cont_proyectoSelect]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Autor: Generador
-- Fecha Creación:	15-05-2011
-- Fecha Actulización:	15-05-2011
-- Descripción: 
-- =============================================
CREATE PROCEDURE  PA_cont_proyectoSelect
AS 
 BEGIN 
		SELECT 
         PK_proyecto,
         FK_estado,
         nombre,
         descripcion,
         objetivo,
         meta,
         fechaInicio,
         fechaFin,
         horasAsignadas,
         horasReales
        FROM t_cont_proyecto
END  
 GO 
  
IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_entregableSelect]'))
DROP PROCEDURE [dbo].[PA_cont_entregableSelect]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Autor: Generador
-- Fecha Creación:	15-05-2011
-- Fecha Actulización:	15-05-2011
-- Descripción: 
-- =============================================
CREATE PROCEDURE  PA_cont_entregableSelect 
AS 
 BEGIN 
 
		SELECT  
         PK_entregable,
         codigo,
         nombre,
         descripcion
        FROM t_cont_entregable
END  
 GO 

 IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_componenteSelect]'))
DROP PROCEDURE [dbo].[PA_cont_componenteSelect]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Autor: Generador
-- Fecha Creación:	15-05-2011
-- Fecha Actulización:	15-05-2011
-- Descripción: 
-- =============================================
CREATE PROCEDURE  PA_cont_componenteSelect 
AS
 BEGIN 
 
		SELECT 
         PK_componente,
         codigo,
         nombre,
         descripcion
        FROM t_cont_componente
END  
 GO 
 
IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_paqueteSelect]'))
DROP PROCEDURE [dbo].[PA_cont_paqueteSelect]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Autor: Generador
-- Fecha Creación:	15-05-2011
-- Fecha Actulización:	15-05-2011
-- Descripción: 
-- =============================================
CREATE PROCEDURE  PA_cont_paqueteSelect
AS 
 BEGIN 
 
		SELECT 
         PK_paquete,
         codigo,
         nombre,
         descripcion
        FROM t_cont_paquete
END  
 GO 
 
IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_actividadSelect]'))
DROP PROCEDURE [dbo].[PA_cont_actividadSelect]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Autor: Generador
-- Fecha Creación:	15-05-2011
-- Fecha Actulización:	15-05-2011
-- Descripción: 
-- =============================================
CREATE PROCEDURE  PA_cont_actividadSelect 
AS 
 BEGIN 
 
		SELECT
         PK_actividad,
         codigo,
         nombre,
         descripcion
        FROM t_cont_actividad
END  
 GO 

 IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_departamentoProyectoSelect]'))
DROP PROCEDURE [dbo].[PA_cont_departamentoProyectoSelect]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Autor: Generador
-- Fecha Creación:	15-05-2011
-- Fecha Actulización:	15-05-2011
-- Descripción: 
-- =============================================
CREATE PROCEDURE  PA_cont_departamentoProyectoSelect
  @paramPK_proyecto int
AS 
 BEGIN 
		SELECT 
			 cont_dep_proy.PK_proyecto,
			 cont_dep_proy.PK_departamento,
			 admi_dep.nombre         
        FROM 
			t_cont_departamento_proyecto cont_dep_proy inner join t_cont_proyecto cont_proy 
		ON 
			cont_dep_proy.PK_proyecto = cont_proy.PK_proyecto inner join t_admi_departamento admi_dep
		ON 
			cont_dep_proy.PK_departamento = admi_dep.PK_departamento
		WHERE 
			cont_dep_proy.PK_proyecto = @paramPK_proyecto AND
			cont_dep_proy.activo = 1
END  
 GO 

 IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_proyectoEntregableSelect]'))
DROP PROCEDURE [dbo].[PA_cont_proyectoEntregableSelect]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Autor: Generador
-- Fecha Creación:	15-05-2011
-- Fecha Actulización:	15-05-2011
-- Descripción: 
-- =============================================
CREATE PROCEDURE  PA_cont_proyectoEntregableSelect
  @paramPK_proyecto int
AS 
 BEGIN 
		SELECT 
			 cont_proy_ent.PK_proyecto,
			 cont_proy_ent.PK_entregable,
			 cont_ent.nombre 
        
        FROM 
			t_cont_proyecto_entregable cont_proy_ent inner join t_cont_proyecto cont_proy 
		ON 
			cont_proy_ent.PK_proyecto = cont_proy.PK_proyecto inner join t_cont_entregable cont_ent
		ON 
			cont_proy_ent.PK_entregable = cont_ent.PK_entregable
		WHERE 
			cont_proy_ent.PK_proyecto = @paramPK_proyecto AND
			cont_proy_ent.activo = 1
END  
 GO 

  IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_entregableComponenteSelect]'))
DROP PROCEDURE [dbo].[PA_cont_entregableComponenteSelect]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Autor: Generador
-- Fecha Creación:	15-05-2011
-- Fecha Actulización:	15-05-2011
-- Descripción: 
-- =============================================
CREATE PROCEDURE  PA_cont_entregableComponenteSelect
  @paramPK_proyecto int,
  @paramPK_entregable int
AS 
 BEGIN 
		SELECT 
			 cont_ent_comp.PK_proyecto,
			 cont_ent_comp.PK_entregable,
			 cont_ent_comp.PK_componente,
			 cont_comp.nombre        
        FROM 
			t_cont_entregable_componente cont_ent_comp inner join t_cont_proyecto cont_proy 
		ON 
			cont_ent_comp.PK_proyecto = cont_proy.PK_proyecto inner join t_cont_entregable cont_ent
		ON 
			cont_ent_comp.PK_entregable = cont_ent.PK_entregable inner join t_cont_componente cont_comp
		ON 
			cont_ent_comp.PK_componente = cont_comp.PK_componente
		WHERE 
			cont_ent_comp.PK_proyecto = @paramPK_proyecto AND
			cont_ent_comp.PK_entregable = @paramPK_entregable AND
			cont_ent_comp.activo = 1
END  
 GO 

  IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_entregableComponenteSelectAll]'))
DROP PROCEDURE [dbo].[PA_cont_entregableComponenteSelectAll]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Autor: Generador
-- Fecha Creación:	15-05-2011
-- Fecha Actulización:	15-05-2011
-- Descripción: 
-- =============================================
CREATE PROCEDURE  PA_cont_entregableComponenteSelectAll
  @paramPK_proyecto int
AS 
 BEGIN 
		SELECT 
			 cont_ent_comp.PK_proyecto,
			 cont_ent_comp.PK_entregable,
			 cont_ent_comp.PK_componente,
			 cont_comp.nombre        
        FROM 
			t_cont_entregable_componente cont_ent_comp inner join t_cont_proyecto cont_proy 
		ON 
			cont_ent_comp.PK_proyecto = cont_proy.PK_proyecto inner join t_cont_entregable cont_ent
		ON 
			cont_ent_comp.PK_entregable = cont_ent.PK_entregable inner join t_cont_componente cont_comp
		ON 
			cont_ent_comp.PK_componente = cont_comp.PK_componente
		WHERE 
			cont_ent_comp.PK_proyecto = @paramPK_proyecto AND
			cont_ent_comp.activo = 1
END  
 GO 

  IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_componentePaqueteSelect]'))
DROP PROCEDURE [dbo].[PA_cont_componentePaqueteSelect]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Autor: Generador
-- Fecha Creación:	15-05-2011
-- Fecha Actulización:	15-05-2011
-- Descripción: 
-- =============================================
CREATE PROCEDURE  PA_cont_componentePaqueteSelect
  @paramPK_proyecto int,
  @paramPK_componente int
AS 
 BEGIN 
		SELECT 
			 cont_comp_paq.PK_proyecto,
			 cont_comp_paq.PK_entregable,
			 cont_comp_paq.PK_componente,
			 cont_comp_paq.PK_paquete,
			 cont_paq.nombre        
        FROM 
			t_cont_componente_paquete cont_comp_paq inner join t_cont_proyecto cont_proy 
		ON 
			cont_comp_paq.PK_proyecto = cont_proy.PK_proyecto inner join t_cont_entregable cont_ent
		ON 
			cont_comp_paq.PK_entregable = cont_ent.PK_entregable inner join t_cont_componente cont_comp
		ON 
			cont_comp_paq.PK_componente = cont_comp.PK_componente inner join t_cont_paquete cont_paq
		ON 
			cont_comp_paq.PK_paquete = cont_paq.PK_paquete
		WHERE 
			cont_comp_paq.PK_proyecto = @paramPK_proyecto AND
			cont_comp_paq.PK_componente = @paramPK_componente AND
			cont_comp_paq.activo = 1
END  
 GO 

  IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_componentePaqueteSelectAll]'))
DROP PROCEDURE [dbo].[PA_cont_componentePaqueteSelectAll]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Autor: Generador
-- Fecha Creación:	15-05-2011
-- Fecha Actulización:	15-05-2011
-- Descripción: 
-- =============================================
CREATE PROCEDURE  PA_cont_componentePaqueteSelectAll
  @paramPK_proyecto int
AS 
 BEGIN 
		SELECT 
			 cont_comp_paq.PK_proyecto,
			 cont_comp_paq.PK_entregable,
			 cont_comp_paq.PK_componente,
			 cont_comp_paq.PK_paquete,
			 cont_paq.nombre        
        FROM 
			t_cont_componente_paquete cont_comp_paq inner join t_cont_proyecto cont_proy 
		ON 
			cont_comp_paq.PK_proyecto = cont_proy.PK_proyecto inner join t_cont_entregable cont_ent
		ON 
			cont_comp_paq.PK_entregable = cont_ent.PK_entregable inner join t_cont_componente cont_comp
		ON 
			cont_comp_paq.PK_componente = cont_comp.PK_componente inner join t_cont_paquete cont_paq
		ON 
			cont_comp_paq.PK_paquete = cont_paq.PK_paquete
		WHERE 
			cont_comp_paq.PK_proyecto = @paramPK_proyecto AND
			cont_comp_paq.activo = 1
END  
 GO 


  IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_paqueteActividadSelect]'))
DROP PROCEDURE [dbo].[PA_cont_paqueteActividadSelect]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Autor: Generador
-- Fecha Creación:	15-05-2011
-- Fecha Actulización:	15-05-2011
-- Descripción: 
-- =============================================
CREATE PROCEDURE  PA_cont_paqueteActividadSelect
  @paramPK_proyecto int,
  @paramPK_paquete int
AS 
 BEGIN 
		SELECT 
			 cont_paq_act.PK_proyecto,
			 cont_paq_act.PK_entregable,
			 cont_paq_act.PK_componente,
			 cont_paq_act.PK_paquete,
			 cont_paq_act.PK_actividad,
			 cont_act.nombre        
        FROM 
			t_cont_paquete_actividad cont_paq_act inner join t_cont_proyecto cont_proy 
		ON 
			cont_paq_act.PK_proyecto = cont_proy.PK_proyecto inner join t_cont_entregable cont_ent
		ON 
			cont_paq_act.PK_entregable = cont_ent.PK_entregable inner join t_cont_componente cont_comp
		ON 
			cont_paq_act.PK_componente = cont_comp.PK_componente inner join t_cont_paquete cont_paq
		ON 
			cont_paq_act.PK_paquete = cont_paq.PK_paquete inner join t_cont_actividad cont_act
		ON 
			cont_paq_act.PK_actividad = cont_act.PK_actividad
		WHERE 
			cont_paq_act.PK_proyecto = @paramPK_proyecto AND
			cont_paq_act.PK_paquete = @paramPK_paquete AND
			cont_paq_act.activo = 1
END  
 GO 


  IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_paqueteActividadSelectAll]'))
DROP PROCEDURE [dbo].[PA_cont_paqueteActividadSelectAll]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Autor: Generador
-- Fecha Creación:	15-05-2011
-- Fecha Actulización:	15-05-2011
-- Descripción: 
-- =============================================
CREATE PROCEDURE  PA_cont_paqueteActividadSelectAll
  @paramPK_proyecto int
AS 
 BEGIN 
		SELECT 
			 cont_paq_act.PK_proyecto,
			 cont_paq_act.PK_entregable,
			 cont_paq_act.PK_componente,
			 cont_paq_act.PK_paquete,
			 cont_paq_act.PK_actividad,
			 cont_act.nombre        
        FROM 
			t_cont_paquete_actividad cont_paq_act inner join t_cont_proyecto cont_proy 
		ON 
			cont_paq_act.PK_proyecto = cont_proy.PK_proyecto inner join t_cont_entregable cont_ent
		ON 
			cont_paq_act.PK_entregable = cont_ent.PK_entregable inner join t_cont_componente cont_comp
		ON 
			cont_paq_act.PK_componente = cont_comp.PK_componente inner join t_cont_paquete cont_paq
		ON 
			cont_paq_act.PK_paquete = cont_paq.PK_paquete inner join t_cont_actividad cont_act
		ON 
			cont_paq_act.PK_actividad = cont_act.PK_actividad
		WHERE 
			cont_paq_act.PK_proyecto = @paramPK_proyecto AND
			cont_paq_act.activo = 1
END  
 GO 

 IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_operacionSelectAll]'))
DROP PROCEDURE [dbo].[PA_cont_operacionSelectAll]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Autor: Esteban Ramírez González
-- Fecha Creación:	11-04-2012
-- Fecha Actulización:	11-04-2012
-- Descripción: 
-- =============================================
CREATE PROCEDURE  PA_cont_operacionSelectAll
  @paramUsuario	  NVARCHAR(30)
AS 
 BEGIN 
		SELECT 
			o.PK_codigo,
			o.tipo,
			o.descripcion
		FROM
			t_cont_operacion o
		INNER JOIN
			t_cont_asignacion_operacion ao
		ON
			o.PK_codigo = ao.PK_codigo AND
			ao.PK_usuario = @paramUsuario
END  
 GO 


 IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_proyectoSelectUsuario]'))
DROP PROCEDURE [dbo].[PA_cont_proyectoSelectUsuario]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Autor: Esteban Ramírez González
-- Fecha Creación:	12-04-2012
-- Fecha Actulización:	12-04-2012
-- Descripción: Se utiliza para seleccionar en cuales
--				se encuentra el usuario asociado
--				en donde estos esten en estado
--				iniciado.
-- =============================================
CREATE PROCEDURE  PA_cont_proyectoSelectUsuario
	 @paramUsuario	  NVARCHAR(30)
AS 
 BEGIN 
		SELECT DISTINCT
			 pro.PK_proyecto,
			 pro.FK_estado,
			 pro.nombre,
			 pro.descripcion,
			 pro.objetivo,
			 pro.meta,
			 pro.fechaInicio,
			 pro.fechaFin,
			 pro.horasAsignadas,
			 pro.horasReales
		 FROM 
			t_cont_proyecto pro
		 INNER JOIN
			t_cont_asignacion_actividad acs
		  ON
		  pro.PK_proyecto = acs.PK_proyecto AND
		  acs.PK_usuario = @paramUsuario
		WHERE
			pro.FK_estado = 1
END  
GO 


 IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_paquetesProyectoSelectAll]'))
DROP PROCEDURE [dbo].[PA_cont_paquetesProyectoSelectAll]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Autor: Generador
-- Fecha Creación:	15-05-2011
-- Fecha Actulización:	15-05-2011
-- Descripción: 
-- =============================================
CREATE PROCEDURE  PA_cont_paquetesProyectoSelectAll
  @paramPK_proyecto int
AS 
 BEGIN 
		
		SELECT DISTINCT
			 cont_paq_act.PK_paquete,
			 cont_paq.nombre nombrePaquete       
        FROM 
			t_cont_paquete_actividad cont_paq_act inner join t_cont_proyecto cont_proy 
		ON 
			cont_paq_act.PK_proyecto = cont_proy.PK_proyecto inner join t_cont_entregable cont_ent
		ON 
			cont_paq_act.PK_entregable = cont_ent.PK_entregable inner join t_cont_componente cont_comp
		ON 
			cont_paq_act.PK_componente = cont_comp.PK_componente inner join t_cont_paquete cont_paq
		ON 
			cont_paq_act.PK_paquete = cont_paq.PK_paquete
		WHERE 
			cont_paq_act.PK_proyecto = @paramPK_proyecto AND
			cont_paq_act.activo = 1
END  
 GO

 
 IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_operacionSelectUsuario]'))
DROP PROCEDURE [dbo].[PA_cont_operacionSelectUsuario]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Autor: Esteban Ramírez González
-- Fecha Creación:	12-04-2012
-- Fecha Actulización:	12-04-2012
-- Descripción: Se utiliza para seleccionar en cuales
--				las operaciones asociadas 
--				a un usuario.
-- =============================================
CREATE PROCEDURE  PA_cont_operacionSelectUsuario
	 @paramUsuario	  NVARCHAR(30),
	 @paramTipo		  NVARCHAR(1)
AS 
 BEGIN 
	SELECT 
		op.PK_codigo,
		op.descripcion
	FROM 
		t_cont_asignacion_operacion aop
	INNER JOIN
		t_cont_operacion op
	ON
		aop.PK_codigo = op.PK_codigo AND
		aop.PK_usuario = @paramUsuario
	WHERE 
		op.FK_proyecto IS NULL AND
		op.tipo = @paramTipo
	ORDER BY op.descripcion asc
END  
GO 

IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_registroOperacionSelectUsuario]'))
DROP PROCEDURE [dbo].[PA_cont_registroOperacionSelectUsuario]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Autor: Esteban Ramírez González
-- Fecha Creación:	12-04-2012
-- Fecha Actulización:	12-04-2012
-- Descripción: Se utiliza para seleccionar en cuales
--				las operaciones asociadas 
--				a un usuario.
-- =============================================
CREATE PROCEDURE  PA_cont_registroOperacionSelectUsuario
	 @paramUsuario	  NVARCHAR(30),
	 @paramTipo		  NVARCHAR(1),
	 @paramFechaInicio	DATETIME,
	 @paramFechaFin		DATETIME
AS 
 BEGIN 
	SELECT
	op.PK_codigo,
	op.tipo,
	op.descripcion,
	ro.PK_registro,
	ro.PK_usuario,
	ro.fecha,
	ro.horas,
	ro.comentario
FROM 
	t_cont_registro_operacion ro
RIGHT OUTER JOIN
	t_cont_operacion op
ON
	ro.PK_codigo = op.PK_codigo AND
	ro.PK_usuario = @paramUsuario 
WHERE
	op.FK_proyecto IS NULL AND
	op.tipo = @paramTipo	 AND
	ro.fecha between @paramFechaInicio AND @paramFechaFin	
ORDER BY op.descripcion asc

END  
GO 



IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_registroActividadSelectUsuario]'))
DROP PROCEDURE [dbo].[PA_cont_registroActividadSelectUsuario]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Autor: Esteban Ramírez González
-- Fecha Creación:	17-04-2012
-- Fecha Actulización:	17-04-2012
-- Descripción: Se utiliza para seleccionar en cuales
--				las actividades registradas por el 
--				usuario.
-- =============================================
CREATE PROCEDURE  PA_cont_registroActividadSelectUsuario
	 @paramProyecto   INT,
	 @paramUsuario	  NVARCHAR(30),
	 @paramFechaInicio	DATETIME,
	 @paramFechaFin		DATETIME
AS 
 BEGIN 
 
 SELECT * FROM (
	SELECT
		ra.PK_registro,
		ra.PK_actividad PK_codigo,
		ra.PK_paquete,
		ra.PK_componente,
		ra.PK_entregable,
		ra.PK_proyecto,
		ra.PK_usuario,
		ra.fecha,
		ra.horas,
		act.descripcion descripcion,
		pa.descripcion descripcion_paquete
	FROM 
		t_cont_registro_actividad ra
	INNER JOIN
		t_cont_actividad act
	ON
		ra.PK_actividad = act.PK_actividad AND
		ra.PK_usuario = @paramUsuario AND
		ra.PK_proyecto = @paramProyecto
	INNER JOIN
		t_cont_paquete pa
	ON
		ra.PK_paquete = pa.PK_paquete 
	WHERE
		ra.fecha between @paramFechaInicio AND @paramFechaFin	
	UNION
	SELECT
		ro.PK_registro,
		op.PK_codigo PK_codigo,
		-1 PK_paquete,
		-1 PK_componente,
		-1 PK_entregable,
		op.FK_proyecto PK_proyecto ,
		@paramUsuario PK_usuario,
		ro.fecha,
		ro.horas,
		op.descripcion,
		'' descripcion_paquete
	FROM 
		t_cont_registro_operacion ro
	RIGHT OUTER JOIN
		t_cont_operacion op
	ON
		ro.PK_codigo = op.PK_codigo AND
		ro.PK_usuario = @paramUsuario 
	WHERE
		op.FK_proyecto = @paramProyecto AND
		ro.fecha between @paramFechaInicio AND @paramFechaFin	
	) t
	ORDER BY descripcion asc
	
END 
GO 

IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_actividadSelectUsuario]'))
DROP PROCEDURE [dbo].[PA_cont_actividadSelectUsuario]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Autor: Esteban Ramírez González
-- Fecha Creación:	12-04-2012
-- Fecha Actulización:	12-04-2012
-- Descripción: Se utiliza para seleccionar en cuales
--				las operaciones asociadas 
--				a un usuario.
-- =============================================
CREATE PROCEDURE  PA_cont_actividadSelectUsuario
	 @paramUsuario	  NVARCHAR(30),
	 @paramProyecto	  INT	  
AS 
 BEGIN 
 SELECT * FROM
 (
	SELECT 
		aact.PK_actividad PK_codigo,
		aact.PK_paquete,
		aact.PK_componente,
		aact.PK_entregable,
		aact.PK_proyecto,
		aact.PK_usuario,
		act.descripcion descripcion,
		pa.descripcion descripcion_paquete
	FROM 
		t_cont_asignacion_actividad aact
	INNER JOIN
		t_cont_actividad act
	ON
		aact.PK_actividad = act.PK_actividad AND
		aact.PK_proyecto = @paramProyecto AND
		aact.PK_usuario = 	@paramUsuario
	INNER JOIN
		t_cont_paquete pa
	ON
		aact.PK_paquete = pa.PK_paquete
	UNION
	SELECT 
		op.PK_codigo PK_codigo,
		-1	PK_paquete,
		-1  PK_componente,
		-1  PK_entregable,
		op.FK_proyecto PK_proyecto,
		@paramUsuario PK_usuario,
		op.descripcion,
		'' descripcion_paquete
	FROM
		t_cont_operacion op
	INNER JOIN
		t_cont_asignacion_operacion ap
	ON
		op.PK_codigo = ap.PK_codigo AND
		ap.PK_usuario = @paramUsuario AND
		op.FK_proyecto = @paramProyecto
	) t
	ORDER BY descripcion ASC
	
END  
GO 

IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_estd_inversionTiempos]'))
DROP PROCEDURE [dbo].[PA_estd_inversionTiempos]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Autor: Esteban Ramírez G.
-- Fecha Creación:	19-04-2011
-- Fecha Actualización:	19-04-2011
-- Descripción: 
-- =============================================
CREATE PROCEDURE  PA_estd_inversionTiempos
  @paramProyecto	INT
AS 
 BEGIN 

	Select 'Actividad' as tipo, COUNT(PK_registro)AS cantidad 
			From t_cont_registro_actividad tcra 
			Where tcra.PK_proyecto = @paramProyecto

	Union all

	Select tipo = CASE tco.tipo 
					WHEN 'I' THEN 'Imprevisto'
					WHEN 'O' THEN 'Operacion' END, 
			   COUNT(tco.tipo) AS cantidad 
			From t_cont_registro_operacion tcro INNER JOIN t_cont_operacion tco
			ON tcro.PK_codigo = tco.PK_codigo, t_cont_proyecto tcp
			WHERE tcro.fecha between tcp.fechaInicio AND tcp.fechaFin
			AND tcp.PK_proyecto = @paramProyecto
		Group by tco.tipo

END  
GO 