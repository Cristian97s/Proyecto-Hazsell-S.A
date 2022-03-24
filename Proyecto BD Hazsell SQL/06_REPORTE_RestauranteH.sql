/*Consulta para la Creacion del reporte PAPA XD*/
	use master
	go
	use RestauranteH
	go
create proc getSalesOrder
@fromDate Date,
@toDate Date
as
	select v.Cod_Venta as Cod_Venta,
	 v.Fecha_Venta as Fecha_Venta,
	 ped.Fecha_Pedido as Fecha_Pedido,
	 ped.Tipo_Pedido as Tipo_pedido,
	 (Pm.Nombre_Mesero+' '+Pm.Apellido_Mesero) as Nombre_Mesero,
	 v.Tipo_Venta as Forma_Pago,
	 pla.Nombre_Plato as Nombre_Plato,
	 pla.Precio_Plato as Precio,
	 (pla.Precio_Plato+Sud_total)as Sud_Total,
	 ((pla.Precio_Plato+Sud_total)*0.15+v.IVA) as IVA,
	 v.Propina as Propina,
	 ((pla.Precio_Plato+Sud_total)+((pla.Precio_Plato+Sud_total)*0.15+IVA))+Total as Total,
	 v.PagoCon as Pago,
	 (PagoCon-((pla.Precio_Plato+Sud_total)+((pla.Precio_Plato+Sud_total)*0.15+IVA))+Total)+Cambio as Cambio
	from Venta v
	 inner join Pedido ped on ped.Id_Pedido = v.Id_Pedido
	 inner join Detalle_Pedido dp on dp.Id_Pedido = ped.Id_Pedido
	 inner join Plato pla on pla.cod_plato = dp.cod_plato
	 inner join Personal_Mesero Pm on pm.Rut_Personal_Mesero = ped.Rut_Personal_Mesero
	where v.Fecha_Venta between @fromDate  and @toDate
	order by v.Cod_Venta asc
go
--select * from Venta select * from Pedido select * from Personal_Mesero select * from Cliente Select* From Plato