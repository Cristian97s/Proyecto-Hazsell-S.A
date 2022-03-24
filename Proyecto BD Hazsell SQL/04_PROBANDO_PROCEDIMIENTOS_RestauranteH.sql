/*****EJECUCION Y REVISADO DE LOS PROCEDIMIENTOS*****/
use master
use RestauranteH

---PROCEDIMIENTOS PARA REGISTRAR---
exec usp_RegistrarProveedor 'Pollo Rico','Final de calle La Inmaculada, Granada','2589 2291','www.monisa.com','2589 2291'
exec usp_RegistrarCliente 'Paoblo','Rocha','Semaforos de Armando Gido 1/2 Abajo','(+505) 2568 9874','Casual','1995-06-09','Paga por adelantado'
exec usp_RegistrarMesa '4','A1'
exec usp_RegistrarInsumo 'Carne de Pollo','10','10 Libras'
exec usp_RegistrarTipoPersona 'Mesero'
exec usp_RegistrarTipoPersona 'Admin'
exec usp_RegistrarTipoPersona 'RRHH'
exec usp_RegistrarTurno 'Vespertino'
--------------------------------------------------------------------------------------------------------------------------------------------------
exec usp_RegistrarPersonalCocinero 'Alvaro','Martinez','+505 8356 8957','De la Calzada 2cd al lago, media hacia abajo','1','1'
exec usp_RegistrarPersonalCocinero 'Mateo','lopez','+505 8056 4789','Anexo villa libartad','1','2'
exec usp_RegistrarPersonalMesero 'Paul','Chavarria','+505 8469 2351','Del madroño 3 andenes al sur','2','1'
exec usp_RegistrarPersonalMesero 'Joel','Martinez','+505 7356 2104','Altamira','2','2'
exec usp_RegistrarPlato 'Caballo Bayo','18','Comida típica Nicaragüense,​ que consiste en una gran combinación de ingredientes','1'
exec usp_RegistrarPlato 'Arroz a la Valenciana','15','El Vigorón es un platillo típico nica que contiene yuca cocida, chicharrón y ensalada de repollo','1'

exec usp_RegistrarProveedorInsumo '1','1','15.60' /*@Rut_Proveedor int,@cod_Insumo int,@Precio_Insumo money*/
exec usp_RegistrarProveedorInsumo '1','2','85.23'
exec usp_RegistrarInsumoPlato '1','1','2'/*@cod_plato int,@cod_insumo int, @cantidad_insumo_utilidado int*/
exec usp_RegistrarInsumoPlato '2','2','2'
exec usp_RegistrarPedido '1','Delivery','1','1','2021-09-23' /*@Rut_Cliente,@Tipo_Pedido,@Num_Mesa,@Rut_Personal_Mesero,@Fecha_Pedido*/
exec usp_RegistrarPedido '2','Local','2','2','2021-09-23'
exec usp_RegistrarDetallePedido '1','1','Plato Fuerte' /*@Id_Pedido int,@cod_plato int,@Menu varchar(50)*/
exec usp_RegistrarDetallePedido '2','2','Almuerzo'
exec usp_RegistrarVenta 'Efectivo','10.00','100.00','2021-10-24','1'/*tipo_venta, propina, pagocon, id_pedido*/
exec usp_RegistrarVenta 'Efectivo','20.00','50.00','2021-10-24','2'

---PROCEDIMIENTOS PARA OBTENER---------------------------------------------
exec usp_ObtenerProveedores
exec usp_ObtenerCliente
exec usp_ObtenerMesa
exec usp_ObtenerInsumo
exec usp_ObtenerTipoPersona
exec usp_ObtenerTurno
----------No ahi registro es necesario registrar---------------------------
exec usp_ObtenerPersonalCocinero
exec usp_ObtenerPersonalMesero
exec usp_ObtenerPlato
exec usp_ObtenerProveedorInsumo 
exec usp_ObtenerInsumoPlato
exec usp_ObtenerPedido
exec usp_ObtenerDetallePedido
exec usp_ObtenerVenta

/*---PROCEDIMIENTOS PARA MODIFICAR---
exec usp_ModificarProveedor 'Pollo Rico','Calle La Inmaculada, Granada','(+505) 2589 2291','www.monisa.com','(+505) 2589 2291','1'
exec usp_ModificarCliente '2','Paoblo','Rocha','Semaforos de Armando Gido 1/2 Abajo','(+505) 2568 9874','VIP','1995-06-09','Paga por adelantado'
exec usp_ModificarMesa '2','2','B4'
exec usp_ModificarInsumo '2','Vino tinto cristal','2','Bot 0,75 Litro'
exec usp_ModificarTipoPersona '2','Cocinero'
exec usp_ModificarTurno '2','Nocturno'
exec usp_ModificarPersonalCocinero '1','Alvaro','Martinez Norori','+505 8356 8957','De la Calzada 2cd al lago, media hacia abajo'
exec usp_ModificarPersonalMesero '1','Paul','Chavarria Guevarra','+505 8469 2351','Del madroño 3 andenes al sur'
exec usp_ModificarPlato '1','Crème Brûlée','25.15','Crema quemada con una capa de azúcar caramelizada'
exec usp_ModificarProveedorInsumo '3','2','1','22.50' /*@Rut_Proveedor int,@cod_Insumo int,@Precio_Insumo money*/
exec usp_obtenerProveedorInsumo
exec usp_obtenerProveedores
exec usp_obtenerInsumo
exec usp_ModificarInsumoPlato '1','1','1','30'/*id insumoplato,idplato,idinsumo*/
exec usp_obtenerInsumoPlato
exec usp_ModificarPedido '1','1','local','1','1','2021-10-23'
exec usp_ModificarDetallePedido '1','1','1','Postre Agridulce'
exec usp_ModificarDetallePedido '2','1','2','Almuerzo'
exec usp_obtenerDetallePedido
exec usp_obtenerPedido
exec usp_obtenerPlato
exec usp_ModificarVenta '1','Tarjeta','150.00','700.00','2021-10-23','1'*/

/*---PROCEDIMIENTOS PARA ELIMINAR---
exec usp_EliminarProveedor '2'
exec usp_EliminarCliente '2'
exec usp_EliminarMesa '2'
exec usp_EliminarInsumo '2'
exec usp_EliminarTipoPersona '2'
exec usp_EliminarTurno '2'
exec usp_EliminarPersonalCocinero '2'
exec usp_EliminarPersonalMesero '2'
exec usp_EliminarPlato '2'
exec usp_EliminarProveedorInsumo '1'
exec usp_EliminarInsumoPlato '2'
exec usp_EliminarPedido '2'
exec usp_EliminarDetallePedido '1'
exec usp_EliminarVenta '1'
*/