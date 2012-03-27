USE CSLA
GO

IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_estadoSelectOne]'))
DROP PROCEDURE [dbo].[PA_cont_estadoSelectOne]
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
CREATE PROCEDURE  PA_cont_estadoSelectOne 
@paramPK_estado int
AS 
 BEGIN 
         SELECT 
			PK_estado, 
			descripcion 
		FROM t_cont_estado 
        WHERE 
			PK_estado = @paramPK_estado
END  
 GO 

IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_proyectoSelectOne]'))
DROP PROCEDURE [dbo].[PA_cont_proyectoSelectOne]
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
CREATE PROCEDURE  PA_cont_proyectoSelectOne 
  @paramPK_proyecto int
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
        WHERE 
			PK_proyecto = @paramPK_proyecto
END  
 GO 
 
 
 IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_entregableSelectOne]'))
DROP PROCEDURE [dbo].[PA_cont_entregableSelectOne]
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
CREATE PROCEDURE  PA_cont_entregableSelectOne 
@paramPK_entregable int
AS 
 BEGIN 
         SELECT  
			PK_entregable, 
			codigo,
			nombre,
			descripcion  
		 FROM t_cont_entregable   
         WHERE 
			PK_entregable = @paramPK_entregable
END  
 GO
 
 
IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_componenteSelectOne]'))
DROP PROCEDURE [dbo].[PA_cont_componenteSelectOne]
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
CREATE PROCEDURE  PA_cont_componenteSelectOne 
@paramPK_componente int
AS 
 BEGIN 
         SELECT 
			PK_componente, 
			codigo,
			nombre,
			descripcion   
		 FROM   t_cont_componente
         WHERE 
			PK_componente = @paramPK_componente
END  
 GO 


IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_paqueteSelectOne]'))
DROP PROCEDURE [dbo].[PA_cont_paqueteSelectOne]
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
CREATE PROCEDURE  PA_cont_paqueteSelectOne 
@paramPK_paquete int
AS 
 BEGIN 
         SELECT 
			codigo,
			nombre,
			descripcion     
		 FROM t_cont_paquete  
         WHERE 
			PK_paquete = @paramPK_paquete
END  
 GO 

IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_actividadSelectOne]'))
DROP PROCEDURE [dbo].[PA_cont_actividadSelectOne]
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
CREATE PROCEDURE  PA_cont_actividadSelectOne 
  @paramPK_actividad int
AS 
 BEGIN 

         SELECT 
			codigo,
			nombre,
			descripcion      
		 FROM t_cont_actividad    
         WHERE 
			   PK_actividad = @paramPK_actividad 
END  
 GO 
