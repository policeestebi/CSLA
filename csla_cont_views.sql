CREATE VIEW v_cont_registroTiempo
AS
SELECT 
	op.PK_codigo codigo,
	op.descripcion,
	op.tipo,
	op.FK_proyecto proyecto,
	SUM(ro.horas) total_horas
FROM
	t_cont_operacion op
INNER JOIN
	t_cont_registro_operacion ro
ON
	op.PK_codigo = ro.PK_codigo
GROUP BY
	op.PK_codigo,op.descripcion,op.tipo,op.FK_proyecto
GO