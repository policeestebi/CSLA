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
			PK_actividad,
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
			PK_actividad,
			codigo,
			nombre,
			descripcion      
		 FROM t_cont_actividad    
         WHERE 
			   PK_actividad = @paramPK_actividad 
END  
 GO 

 IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_operacionSelectOne]'))
DROP PROCEDURE [dbo].[PA_cont_operacionSelectOne]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Autor: Esteban Ramírez G.
-- Fecha Creación:	11-04-2011
-- Fecha Actulización:	11-04-2011
-- Descripción: 
-- =============================================
CREATE PROCEDURE  PA_cont_operacionSelectOne 
  @paramPK_codigo NVARCHAR(50)
AS 
 BEGIN 

         SELECT 
			PK_codigo,
			tipo,
			descripcion,
			ISNULL(FK_proyecto,-1) as FK_proyecto
		 FROM
			t_cont_operacion
         WHERE 
			   PK_codigo = @paramPK_codigo
END  
 GO 


  IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_operacionRegistroSelectOne]'))
DROP PROCEDURE [dbo].[PA_cont_operacionRegistroSelectOne]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Autor: Esteban Ramírez G.
-- Fecha Creación:	11-04-2011
-- Fecha Actulización:	11-04-2011
-- Descripción: 
-- =============================================
CREATE PROCEDURE  PA_cont_operacionRegistroSelectOne 
  @paramPK_registro   numeric(10,2),
  @paramPK_codigo	nvarchar(50),
  @paramUsuario		nvarchar(30)
AS 
 BEGIN 

         SELECT 
			PK_registro,
			PK_codigo,
			PK_usuario,
			fecha,
			horas,
			comentario
		 FROM
			t_cont_registro_operacion
         WHERE 
			   PK_codigo = @paramPK_codigo AND
			   PK_registro = @paramPK_registro AND
			   PK_usuario = @paramUsuario
END  
GO 

  IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_actividadRegistroSelectOne]'))
DROP PROCEDURE [dbo].[PA_cont_actividadRegistroSelectOne]
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
CREATE PROCEDURE  PA_cont_actividadRegistroSelectOne 
@paramRegistro	INT,
  @paramActividad   INT,
  @paramPaquete		INT,
  @paramComponente  INT,
  @paramEntregable	INT,
  @paramProyecto	INT,
  @paramUsuario		nvarchar(50)
AS 
 BEGIN 

         SELECT 
			PK_registro,
			PK_actividad,
			PK_paquete ,
			PK_componente,
			PK_entregable,
			PK_proyecto,
			PK_usuario ,
			fecha,
			horas,
			comentario
		 FROM
			t_cont_registro_actividad
         WHERE 
			PK_registro = @paramRegistro AND
			PK_actividad = @paramActividad AND
			PK_paquete = @paramPaquete AND
			PK_componente = @paramComponente AND
			PK_entregable = @paramEntregable AND
			PK_proyecto =  @paramProyecto AND
			PK_usuario = @paramUsuario
END  
GO 
