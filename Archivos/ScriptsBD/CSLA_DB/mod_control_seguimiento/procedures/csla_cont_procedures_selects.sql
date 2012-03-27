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
         horasAsigDefectos,
         horasReales,
         horasRealesDefectos
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
			cont_dep_proy.PK_proyecto = @paramPK_proyecto
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
			cont_proy_ent.PK_proyecto = @paramPK_proyecto
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
			cont_ent_comp.PK_entregable = @paramPK_entregable
END  
 GO 