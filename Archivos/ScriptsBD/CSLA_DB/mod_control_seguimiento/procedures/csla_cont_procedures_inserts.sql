USE CSLA
GO

IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_estadoInsert]'))
DROP PROCEDURE [dbo].[PA_cont_estadoInsert]
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
CREATE PROCEDURE  PA_cont_estadoInsert 
  @paramdescripcion varchar(30)  
AS
 BEGIN 
 SET NOCOUNT ON; 

         INSERT INTO t_cont_estado
        ( 
         descripcion
        ) 
        VALUES
        ( 
         @paramdescripcion
        ) 

END   
 GO 
 
IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_proyectoInsert]'))
DROP PROCEDURE [dbo].[PA_cont_proyectoInsert]
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
CREATE PROCEDURE  PA_cont_proyectoInsert
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
  @paramhorasRealesDefectos decimal 
 
AS 
 BEGIN 
 SET NOCOUNT ON; 

         INSERT INTO t_cont_proyecto
        (
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
        ) 
        VALUES
        ( 
         @paramFK_estado,
         @paramnombre,
         @paramdescripcion,
         @paramobjetivo,
         @parammeta,
         @paramfechaInicio,
         @paramfechaFin,
         @paramhorasAsignadas,
         @paramhorasAsigDefectos,
         @paramhorasReales,
         @paramhorasRealesDefectos
        ) 

END   
 GO 


IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_departamento_proyectoInsert]'))
DROP PROCEDURE [dbo].[PA_cont_departamento_proyectoInsert]
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
CREATE PROCEDURE  PA_cont_departamento_proyectoInsert 
  @paramPK_departamento int, 
  @paramPK_proyecto int 
AS 
 BEGIN 
 SET NOCOUNT ON; 

         INSERT INTO t_cont_departamento_proyecto
        ( 
         PK_departamento,
         PK_proyecto
        ) 
        VALUES
        ( 
         @paramPK_departamento,
         @paramPK_proyecto
        ) 

END   
 GO 

IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_entregableInsert]'))
DROP PROCEDURE [dbo].[PA_cont_entregableInsert]
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
CREATE PROCEDURE  PA_cont_entregableInsert 
  @paramcodigo varchar(20) , 
  @paramnombre varchar(100) , 
  @paramdescripcion varchar(100)  
AS 
 BEGIN 
 SET NOCOUNT ON; 

         INSERT INTO t_cont_entregable
        ( 
         codigo,
         nombre,
         descripcion
        ) 
        VALUES
        ( 
         @paramcodigo,
         @paramnombre,
         @paramdescripcion
        ) 

END   
 GO 
 
 IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_proyecto_entregableInsert]'))
DROP PROCEDURE [dbo].[PA_cont_proyecto_entregableInsert]
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
CREATE PROCEDURE  PA_cont_proyecto_entregableInsert
  @paramPK_entregable int,
  @paramPK_proyecto int 
AS 
 BEGIN 
 SET NOCOUNT ON;

         INSERT INTO t_cont_proyecto_entregable
        (
         PK_entregable,
         PK_proyecto
        ) 
        VALUES
        ( 
         @paramPK_entregable,
         @paramPK_proyecto
        ) 

END   
 GO 
 
 
 IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_componenteInsert]'))
DROP PROCEDURE [dbo].[PA_cont_componenteInsert]
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
CREATE PROCEDURE  PA_cont_componenteInsert 
  @paramcodigo varchar(20) , 
  @paramnombre varchar(100) , 
  @paramdescripcion varchar(100)  
AS
 BEGIN 
 SET NOCOUNT ON; 

         INSERT INTO t_cont_componente
        ( 
         codigo,
         nombre,
         descripcion
        ) 
        VALUES
        ( 
         @paramcodigo,
         @paramnombre,
         @paramdescripcion
        ) 

END   
 GO 
 
IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_entregable_componenteInsert]'))
DROP PROCEDURE [dbo].[PA_cont_entregable_componenteInsert]
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
CREATE PROCEDURE  PA_cont_entregable_componenteInsert 
  @paramPK_componente int, 
  @paramPK_entregable int, 
  @paramPK_proyecto int 
 
AS 
 BEGIN 
 SET NOCOUNT ON; 

         INSERT INTO t_cont_entregable_componente
        (
         PK_componente,
         PK_entregable,
         PK_proyecto
        ) 
        VALUES
        ( 
         @paramPK_componente,
         @paramPK_entregable,
         @paramPK_proyecto
        ) 

END   
 GO 

 
IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_paqueteInsert]'))
DROP PROCEDURE [dbo].[PA_cont_paqueteInsert]
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
CREATE PROCEDURE  PA_cont_paqueteInsert
  @paramcodigo varchar(20) , 
  @paramnombre varchar(100) , 
  @paramdescripcion varchar(100)  
 
AS 
 BEGIN 
 SET NOCOUNT ON; 

         INSERT INTO t_cont_paquete
        ( 
         codigo,
         nombre,
         descripcion
        ) 
        VALUES
        ( 
         @paramcodigo,
         @paramnombre,
         @paramdescripcion
        ) 

END   
 GO 
 
IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_componente_paqueteInsert]'))
DROP PROCEDURE [dbo].[PA_cont_componente_paqueteInsert]
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
CREATE PROCEDURE  PA_cont_componente_paqueteInsert
  @paramPK_paquete int, 
  @paramPK_componente int, 
  @paramPK_entregable int, 
  @paramPK_proyecto int 
 
AS 
 BEGIN 
 SET NOCOUNT ON; 

         INSERT INTO t_cont_componente_paquete
        (
         PK_paquete,
         PK_componente,
         PK_entregable,
         PK_proyecto
        ) 
        VALUES
        ( 
         @paramPK_paquete,
         @paramPK_componente,
         @paramPK_entregable,
         @paramPK_proyecto
        ) 

END   
 GO 
 
 IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_actividadInsert]'))
DROP PROCEDURE [dbo].[PA_cont_actividadInsert]
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
CREATE PROCEDURE  PA_cont_actividadInsert
  @paramcodigo varchar(20) , 
  @paramnombre varchar(100) , 
  @paramdescripcion varchar(100)  
 
AS 
 BEGIN 
 SET NOCOUNT ON; 

         INSERT INTO t_cont_actividad
        ( 
         codigo,
         nombre,
         descripcion
        ) 
        VALUES
        ( 
         @paramcodigo,
         @paramnombre,
         @paramdescripcion
        ) 

END   
 GO 

 
IF  EXISTS (SELECT * FROM sys.procedures WHERE object_id = OBJECT_ID(N'[dbo].[PA_cont_actividadAsignadaInsert]'))
DROP PROCEDURE [dbo].[PA_cont_actividadAsignadaInsert]
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
CREATE PROCEDURE  PA_cont_actividadAsignadaInsert 
  @paramPK_actividad int, 
  @paramPK_paquete int,
  @paramPK_componente int, 
  @paramPK_entregable int, 
  @paramPK_proyecto int, 
  @paramPK_usuario varchar(30) , 
  @paramFK_estado int, 
  @paramdescripcion varchar(100) , 
  @paramfechaInicio datetime, 
  @paramfechaFin datetime, 
  @paramhorasAsignadas decimal, 
  @paramhorasAsigDefectos decimal, 
  @paramhorasReales decimal, 
  @paramhorasRealesDefectos decimal 
AS 
 BEGIN 
 SET NOCOUNT ON; 

         INSERT INTO t_cont_actividadAsignada
        ( 
		 PK_actividad,
         PK_paquete,
         PK_componente,
         PK_entregable,
         PK_proyecto,
         PK_usuario,
         FK_estado,
         descripcion,
         fechaInicio,
         fechaFin,
         horasAsignadas,
         horasAsigDefectos,
         horasReales,
         horasRealesDefectos
        ) 
        VALUES
        ( 
		 @paramPK_actividad, 
         @paramPK_paquete,
         @paramPK_componente,
         @paramPK_entregable,
         @paramPK_proyecto,
         @paramPK_usuario,
         @paramFK_estado,
         @paramdescripcion,
         @paramfechaInicio,
         @paramfechaFin,
         @paramhorasAsignadas,
         @paramhorasAsigDefectos,
         @paramhorasReales,
         @paramhorasRealesDefectos
        ) 

END   
 GO 

