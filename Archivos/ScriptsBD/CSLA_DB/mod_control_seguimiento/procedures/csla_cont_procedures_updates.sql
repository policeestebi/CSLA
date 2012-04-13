USE CSLA
GO

IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_estadoUpdate]'))
DROP PROCEDURE [dbo].[PA_cont_estadoUpdate]
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
CREATE PROCEDURE  PA_cont_estadoUpdate 
  @paramPK_estado int,
  @paramdescripcion varchar(30) 
AS 
 BEGIN 
SET NOCOUNT ON; 

         UPDATE t_cont_estado
         SET 
			descripcion = @paramdescripcion       
         WHERE 
			PK_estado = @paramPK_estado 
  
END   
 GO 

IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_proyectoUpdate]'))
DROP PROCEDURE [dbo].[PA_cont_proyectoUpdate]
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
CREATE PROCEDURE  PA_cont_proyectoUpdate 
  @paramFK_estado int, 
  @paramnombre varchar(100) , 
  @paramdescripcion varchar(100) , 
  @paramobjetivo varchar(500) , 
  @parammeta varchar(500) , 
  @paramfechaInicio datetime, 
  @paramfechaFin datetime, 
  @paramhorasAsignadas decimal, 
  @paramhorasAsigDefectos decimal, 
  @paramhorasReales decimal, 
  @paramhorasRealesDefectos decimal,
  @paramPK_proyecto int

AS 
 BEGIN 
SET NOCOUNT ON; 

         UPDATE t_cont_proyecto
         SET 
			FK_estado = @paramFK_estado ,
			nombre = @paramnombre ,
			descripcion = @paramdescripcion ,
			objetivo = @paramobjetivo ,
			meta = @parammeta ,
			fechaInicio = @paramfechaInicio ,
			fechaFin = @paramfechaFin ,
			horasAsignadas = @paramhorasAsignadas ,
			horasAsigDefectos = @paramhorasAsigDefectos ,
			horasReales = @paramhorasReales ,
			horasRealesDefectos = @paramhorasRealesDefectos       
         WHERE 
			PK_proyecto = @paramPK_proyecto 
  
END   
 GO 
 
 
 IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_entregableUpdate]'))
DROP PROCEDURE [dbo].[PA_cont_entregableUpdate]
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
CREATE PROCEDURE  PA_cont_entregableUpdate 
  @paramPK_entregable int,
  @paramcodigo varchar(20) , 
  @paramnombre varchar(100) , 
  @paramdescripcion varchar(100)  
AS 
 BEGIN 
SET NOCOUNT ON; 

         UPDATE t_cont_entregable
         SET 
			codigo = @paramcodigo ,
			nombre = @paramnombre ,
			descripcion = @paramdescripcion       
         WHERE 
			PK_entregable = @paramPK_entregable

END   
 GO
 

IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_proyecto_entregableUpdate]'))
DROP PROCEDURE [dbo].[PA_cont_proyecto_entregableUpdate]
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
CREATE PROCEDURE  PA_cont_proyecto_entregableUpdate 
  @paramPK_entregable int, 
  @paramPK_proyecto int,
  @paramAccion int  
AS 
 BEGIN 
SET NOCOUNT ON; 

DECLARE @activo int;

	IF ( SELECT COUNT(0) FROM t_cont_proyecto_entregable 
				WHERE 
					PK_entregable = @paramPK_entregable AND 
					PK_proyecto = @paramPK_proyecto) > 0
		BEGIN
			SET @activo = (SELECT activo FROM t_cont_proyecto_entregable
					WHERE PK_entregable = @paramPK_entregable AND PK_proyecto = @paramPK_proyecto);

			IF (@activo = 1 and @paramAccion = 0)
				UPDATE t_cont_proyecto_entregable       
         		SET activo = 0
				WHERE 
				   PK_entregable = @paramPK_entregable AND 
         			  PK_proyecto = @paramPK_proyecto;
			
			IF (@activo = 0 and @paramAccion = 1)
				UPDATE t_cont_proyecto_entregable       
         		SET activo = 1
				WHERE 
				   PK_entregable = @paramPK_entregable AND 
         			  PK_proyecto = @paramPK_proyecto;
		END
	ELSE
		BEGIN
			EXEC PA_cont_proyecto_entregableInsert @paramPK_entregable,@paramPK_proyecto;
		END
END   
 GO  
  
IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_componenteUpdate]'))
DROP PROCEDURE [dbo].[PA_cont_componenteUpdate]
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
CREATE PROCEDURE  PA_cont_componenteUpdate 
  @paramPK_componente int,
  @paramcodigo varchar(20) , 
  @paramnombre varchar(100) , 
  @paramdescripcion varchar(100) 
AS 
 BEGIN 
SET NOCOUNT ON; 

         UPDATE t_cont_componente
         SET 
			codigo = @paramcodigo ,
			nombre = @paramnombre ,
			descripcion = @paramdescripcion       
         WHERE 
			PK_componente = @paramPK_componente

END   
 GO 



IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_entregable_componenteUpdate]'))
DROP PROCEDURE [dbo].[PA_cont_entregable_componenteUpdate]
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
CREATE PROCEDURE  PA_cont_entregable_componenteUpdate 
  @paramPK_componente int, 
  @paramPK_entregable int, 
  @paramPK_proyecto int, 
  @paramAccion int  
AS 
 BEGIN 
SET NOCOUNT ON; 

DECLARE @activo int;

	IF ( SELECT COUNT(0) FROM t_cont_entregable_componente 
				WHERE 
					PK_componente = @paramPK_componente AND 
					PK_entregable = @paramPK_entregable AND 
					PK_proyecto = @paramPK_proyecto) > 0
		BEGIN
			SET @activo = (SELECT activo FROM t_cont_entregable_componente
					WHERE PK_componente = @paramPK_componente AND  PK_entregable = @paramPK_entregable AND PK_proyecto = @paramPK_proyecto);

			IF (@activo = 1 and @paramAccion = 0)
				UPDATE t_cont_entregable_componente       
         		SET activo = 0
				WHERE 
					PK_componente = @paramPK_componente AND
				    PK_entregable = @paramPK_entregable AND 
         			PK_proyecto = @paramPK_proyecto;
			
			IF (@activo = 0 and @paramAccion = 1)
				UPDATE t_cont_entregable_componente       
         		SET activo = 1
				WHERE 
				   PK_componente = @paramPK_componente AND
				   PK_entregable = @paramPK_entregable AND 
         		   PK_proyecto = @paramPK_proyecto;
		END
	ELSE
		BEGIN
			EXEC PA_cont_entregable_componenteInsert @paramPK_componente,@paramPK_entregable,@paramPK_proyecto;
		END
END   
 GO 


IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_paqueteUpdate]'))
DROP PROCEDURE [dbo].[PA_cont_paqueteUpdate]
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
CREATE PROCEDURE  PA_cont_paqueteUpdate 
  @paramPK_paquete int,
  @paramcodigo varchar(20) , 
  @paramnombre varchar(100) , 
  @paramdescripcion varchar(100) 
AS 
 BEGIN 
SET NOCOUNT ON; 

         UPDATE t_cont_paquete
         SET 
			codigo = @paramcodigo ,
			nombre = @paramnombre ,
			descripcion = @paramdescripcion       
         WHERE 
			PK_paquete = @paramPK_paquete

END   
 GO 



IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_componente_paqueteUpdate]'))
DROP PROCEDURE [dbo].[PA_cont_componente_paqueteUpdate]
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
CREATE PROCEDURE  PA_cont_componente_paqueteUpdate 
  @paramPK_paquete int, 
  @paramPK_componente int, 
  @paramPK_entregable int, 
  @paramPK_proyecto int, 
  @paramAccion int  
AS 
 BEGIN 
SET NOCOUNT ON; 

DECLARE @activo int;

	IF ( SELECT COUNT(0) FROM t_cont_componente_paquete 
				WHERE 
					PK_paquete = @paramPK_paquete AND 
					PK_componente = @paramPK_componente AND 
					PK_entregable = @paramPK_entregable AND 
					PK_proyecto = @paramPK_proyecto) > 0
		BEGIN
			SET @activo = (SELECT activo FROM t_cont_componente_paquete
					WHERE PK_paquete = @paramPK_paquete AND PK_componente = @paramPK_componente AND  PK_entregable = @paramPK_entregable AND PK_proyecto = @paramPK_proyecto);

			IF (@activo = 1 and @paramAccion = 0)
				UPDATE t_cont_componente_paquete       
         		SET activo = 0
				WHERE 
					PK_paquete = @paramPK_paquete AND 
					PK_componente = @paramPK_componente AND
				    PK_entregable = @paramPK_entregable AND 
         			PK_proyecto = @paramPK_proyecto;
			
			IF (@activo = 0 and @paramAccion = 1)
				UPDATE t_cont_componente_paquete       
         		SET activo = 1
				WHERE 
				   PK_paquete = @paramPK_paquete AND 
				   PK_componente = @paramPK_componente AND
				   PK_entregable = @paramPK_entregable AND 
         		   PK_proyecto = @paramPK_proyecto;
		END
	ELSE
		BEGIN
			EXEC PA_cont_componente_paqueteInsert @paramPK_paquete,@paramPK_componente,@paramPK_entregable,@paramPK_proyecto;
		END
END   
 GO  


IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_actividadUpdate]'))
DROP PROCEDURE [dbo].[PA_cont_actividadUpdate]
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
CREATE PROCEDURE  PA_cont_actividadUpdate 
  @paramPK_actividad int, 
  @paramcodigo varchar(20) , 
  @paramnombre varchar(100) , 
  @paramdescripcion varchar(100) 
AS 
 BEGIN 
SET NOCOUNT ON; 

         UPDATE t_cont_actividad
         SET 
			codigo = @paramcodigo ,
			nombre = @paramnombre ,
			descripcion = @paramdescripcion       
         WHERE 
			PK_actividad = @paramPK_actividad
  
END   
 GO
 


IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_paquete_actividadUpdate]'))
DROP PROCEDURE [dbo].[PA_cont_paquete_actividadUpdate]
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
CREATE PROCEDURE  PA_cont_paquete_actividadUpdate 
  @paramPK_actividad int,   
  @paramPK_paquete int, 
  @paramPK_componente int, 
  @paramPK_entregable int, 
  @paramPK_proyecto int, 
  @paramAccion int  
AS 
 BEGIN 
SET NOCOUNT ON; 

DECLARE @activo int;

	IF ( SELECT COUNT(0) FROM t_cont_paquete_actividad 
				WHERE 
					PK_actividad = @paramPK_actividad AND 
					PK_paquete = @paramPK_paquete AND 
					PK_componente = @paramPK_componente AND 
					PK_entregable = @paramPK_entregable AND 
					PK_proyecto = @paramPK_proyecto) > 0
		BEGIN
			SET @activo = (SELECT activo FROM t_cont_paquete_actividad
					WHERE PK_actividad = @paramPK_actividad AND PK_paquete = @paramPK_paquete AND PK_componente = @paramPK_componente AND  PK_entregable = @paramPK_entregable AND PK_proyecto = @paramPK_proyecto);

			IF (@activo = 1 and @paramAccion = 0)
				UPDATE t_cont_paquete_actividad       
         		SET activo = 0
				WHERE 
					PK_actividad = @paramPK_actividad AND
					PK_paquete = @paramPK_paquete AND 
					PK_componente = @paramPK_componente AND
				    PK_entregable = @paramPK_entregable AND 
         			PK_proyecto = @paramPK_proyecto;
			
			IF (@activo = 0 and @paramAccion = 1)
				UPDATE t_cont_paquete_actividad       
         		SET activo = 1
				WHERE 
				   PK_actividad = @paramPK_actividad AND
				   PK_paquete = @paramPK_paquete AND 
				   PK_componente = @paramPK_componente AND
				   PK_entregable = @paramPK_entregable AND 
         		   PK_proyecto = @paramPK_proyecto;
		END
	ELSE
		BEGIN
			EXEC PA_cont_paquete_actividadInsert @paramPK_actividad,@paramPK_paquete,@paramPK_componente,@paramPK_entregable,@paramPK_proyecto;
		END
END   
 GO 
 
<<<<<<< HEAD
 IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_paquete_operacionUpdate]'))
DROP PROCEDURE [dbo].[PA_cont_paquete_operacionUpdate]
=======
 IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_operacionUpdate]'))
DROP PROCEDURE [dbo].[PA_cont_operacionUpdate]
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
CREATE PROCEDURE  PA_cont_operacionUpdate 
  @paramPK_operacion NVARCHAR(50),
  @paramDescripcion NVARCHAR(100)   
AS 
 BEGIN 
SET NOCOUNT ON; 

	UPDATE t_cont_operacion
	SET descripcion = @paramDescripcion
	WHERE 
	PK_codigo = @paramPK_operacion;

END   
 GO   

IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_operacionRegistroUpdate]'))
DROP PROCEDURE [dbo].[PA_cont_operacionRegistroUpdate]
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
CREATE PROCEDURE  PA_cont_operacionRegistroUpdate 
  @paramPK_registro   numeric(10,2),
  @paramPK_codigo	nvarchar(50),
  @paramUsuario		nvarchar(30),
  @paramHoras		numeric(10,2),
  @comentario		nvarchar(100) 
AS 
 BEGIN 
SET NOCOUNT ON; 

	UPDATE t_cont_registro_operacion
	SET 
		comentario = @comentario,
		horas = @paramHoras
	WHERE 
	  PK_codigo = @paramPK_codigo AND
			   PK_registro = @paramPK_registro AND
			   PK_usuario = @paramUsuario;

END   
 GO 
