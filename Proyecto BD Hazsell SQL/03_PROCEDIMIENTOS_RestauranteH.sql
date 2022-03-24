use master
go
use RestauranteH
go
--PROCEDMIENTO PARA OBTENER PROVEEDORES
CREATE PROC usp_ObtenerProveedores
as
begin
 select Rut_Proveedor,Nombre_Proveedor,Direccion_Proveedor,Telefono_Proveedor,Email_Proveedor,Fax_Proveedor from Proveedor
end

go

--PROCEDIMIENTO PARA GUARDAR PROVEEDOR
CREATE PROC usp_RegistrarProveedor(
@Nombre_Proveedor varchar(30),
@Direccion_Proveedor varchar(50),
@Telefono_Proveedor varchar(20),
@Email_Proveedor varchar(30),
@Fax_Proveedor varchar(20)
--@Resultado bit output
)as
begin
	--SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM Proveedor WHERE Nombre_Proveedor = @Nombre_Proveedor)

		insert into Proveedor(Nombre_Proveedor,Direccion_Proveedor,Telefono_Proveedor,Email_Proveedor,Fax_Proveedor)
		values(@Nombre_Proveedor,@Direccion_Proveedor,@Telefono_Proveedor,@Email_Proveedor,@Fax_Proveedor)

	--ELSE
	--	SET @Resultado = 0	
end
go

--PROCEDIMIENTO PARA MODIFICAR PROVEEDOR
CREATE procedure usp_ModificarProveedor(
@Nombre_Proveedor varchar(30),
@Direccion_Proveedor varchar(50),
@Telefono_Proveedor varchar(20),
@Email_Proveedor varchar(30),
@Fax_Proveedor varchar(20),
@Rut_Proveedor int
--@Resultado bit output
)
as
begin
	--SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM Proveedor WHERE Nombre_Proveedor = @Nombre_Proveedor and  Rut_Proveedor != @Rut_Proveedor)
		
		update Proveedor set 
		Nombre_Proveedor = @Nombre_Proveedor,
		Direccion_Proveedor = @Direccion_Proveedor,
		Telefono_Proveedor = @Telefono_Proveedor,
		Email_Proveedor = @Email_Proveedor,
		Fax_Proveedor = @Fax_Proveedor
		where Rut_Proveedor = @Rut_Proveedor
	--ELSE
	--	SET @Resultado = 0

end
go

--PROCEDIMIENTO PARA ELIMINAR PROVEEDOR
CREATE procedure usp_EliminarProveedor(
@Rut_Proveedor int
--@Resultado bit output
)
as
begin
--	SET @Resultado = 1
	--validamos que ningun proveedor se encuentre asignado en la tabla Proveedor_Insumo
	IF not EXISTS 
	(select top 1 * from Proveedor_Insumo provin
inner join Proveedor p on p.Rut_Proveedor = provin.Rut_Proveedor
where p.Rut_Proveedor = @Rut_Proveedor)

		delete from Proveedor where Rut_Proveedor = @Rut_Proveedor
	--ELSE
	--	SET @Resultado = 0

end
go

--PROCEDMIENTO PARA OBTENER CLIENTES
CREATE PROC usp_ObtenerCliente
as
begin
 select Rut_Cliente,Nombre_Cliente,Apellido_Cliente,Direccion_Cliente,Telefono_Cliente,Tipo_Cliente,Fecha_Nac_Cliente,Observaciones_Cliente from Cliente
end

go



--PROCEDIMIENTO PARA GUARDAR CLIENTES
CREATE PROC usp_RegistrarCliente(
@Nombre_Cliente varchar(30),
@Apellido_Cliente varchar(30),
@Direccion_Cliente varchar(50),
@Telefono_Cliente varchar(20),
@Tipo_Cliente varchar(30),
@Fecha_Nac_Cliente datetime,
@Observaciones_Cliente varchar(50)
--@Resultado bit output
)as
begin
	--SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM Cliente WHERE Nombre_Cliente = @Nombre_Cliente)

		insert into Cliente(Nombre_Cliente,Apellido_Cliente,Direccion_Cliente,Telefono_Cliente,Tipo_Cliente,Fecha_Nac_Cliente,Observaciones_Cliente)
		values(@Nombre_Cliente,@Apellido_Cliente,@Direccion_Cliente,@Telefono_Cliente,@Tipo_Cliente,@Fecha_Nac_Cliente,@Observaciones_Cliente)

	--ELSE
	--	SET @Resultado = 0	
end
go



--PROCEDIMIENTO PARA MODIFICAR CLIENTES
CREATE procedure usp_ModificarCliente(
@Rut_Cliente int,
@Nombre_Cliente varchar(30),
@Apellido_Cliente varchar(30),
@Direccion_Cliente varchar(50),
@Telefono_Cliente varchar(20),
@Tipo_Cliente varchar(30),
@Fecha_Nac_Cliente datetime,
@Observaciones_Cliente varchar(50)
--@Resultado bit output
)
as
begin
	--SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM Cliente WHERE Nombre_Cliente = @Nombre_Cliente and  Rut_Cliente != @Rut_Cliente)
		
		update Cliente set 
		Nombre_Cliente = @Nombre_Cliente,
		Direccion_Cliente = @Direccion_Cliente,
		Apellido_Cliente=@Apellido_Cliente,
		Telefono_Cliente = @Telefono_Cliente,
		Tipo_Cliente = @Tipo_Cliente,
		Fecha_Nac_Cliente = @Fecha_Nac_Cliente,
		Observaciones_Cliente = @Observaciones_Cliente
		where Rut_Cliente = @Rut_Cliente
	--ELSE
	--	SET @Resultado = 0

end
go



--PROCEDIMIENTO PARA ELIMINAR CLIENTE
CREATE procedure usp_EliminarCliente(
@Rut_Cliente int
--@Resultado bit output
)
as
begin
	--SET @Resultado = 1
	--validamos que ningun proveedor se encuentre asignado en la tabla Pedido
	IF not EXISTS (select top 1 * from Pedido ped
inner join Cliente cli on cli.Rut_Cliente = ped.Rut_Cliente
where cli.Rut_Cliente = @Rut_Cliente)

		delete from Cliente where Rut_Cliente = @Rut_Cliente
	--ELSE
	--	SET @Resultado = 0

end
go

--PROCEDMIENTO PARA OBTENER MESA
CREATE PROC usp_ObtenerMesa
as
begin
 select Num_Mesa,Cant_Max_Comensales,Ubicacion from Mesa
end

go



--PROCEDIMIENTO PARA GUARDAR MESA
CREATE PROC usp_RegistrarMesa(
@Cant_Max_Comensales int,
@Ubicacion varchar(30)
--@Resultado bit output
)as
begin
	--SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM Mesa WHERE Ubicacion = @Ubicacion)

		insert into Mesa(Cant_Max_Comensales,Ubicacion)
		values(@Cant_Max_Comensales,@Ubicacion)

	--ELSE
	--	SET @Resultado = 0	
end
go



--PROCEDIMIENTO PARA MODIFICAR MESA
CREATE PROC usp_ModificarMesa(
@Num_Mesa int,
@Cant_Max_Comensales int,
@Ubicacion varchar(30)
--@Resultado bit output
)
as
begin
	--SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM Mesa WHERE Ubicacion = @Ubicacion and  Num_Mesa != @Num_Mesa)
		
		update Mesa set 
		Cant_Max_Comensales = @Cant_Max_Comensales,
		Ubicacion = @Ubicacion
		where Num_Mesa = @Num_Mesa
	--ELSE
	--	SET @Resultado = 0

end
go

--PROCEDIMIENTO PARA ELIMINAR MESA
CREATE PROC usp_EliminarMesa(
@Num_Mesa int
--@Resultado bit output
)
as
begin
	--SET @Resultado = 1
	--validamos que ningun proveedor se encuentre asignado en la tabla Pedido
	IF not EXISTS (select top 1 * from Pedido ped
inner join Mesa on Mesa.Num_Mesa = ped.Num_Mesa
where Mesa.Num_Mesa = @Num_Mesa)

		delete from Mesa where Num_Mesa = @Num_Mesa
	--ELSE
	--	SET @Resultado = 0

end
go

--PROCEMIENTO PARA OBTENER INSUMO
CREATE PROC usp_ObtenerInsumo
as
begin
 select ins.cod_Insumo,ins.nombre_insumo,ins.cantidad_insumo,ins.unidad_medida_insumo from Insumo ins
end

go

--PROCEDIMIENTO PARA GUARDAR INSUMO
CREATE PROC usp_RegistrarInsumo(
@nombre_insumo varchar(30),
@cantidad_insumo decimal,
@unidad_medida_insumo varchar(30)
--@Resultado bit output
)as
begin
	--SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM Insumo WHERE nombre_insumo = @nombre_insumo and cantidad_insumo=@cantidad_insumo and unidad_medida_insumo=@unidad_medida_insumo)

		insert into Insumo(nombre_insumo,cantidad_insumo,unidad_medida_insumo) 
		values (@nombre_insumo,@cantidad_insumo,@unidad_medida_insumo)
	--ELSE
	--	SET @Resultado = 0
	
end

go

--PROCEDIMIENTO PARA MODIFICAR INSUMO
CREATE PROC usp_ModificarInsumo(
@cod_Insumo int,
@nombre_insumo varchar(30),
@cantidad_insumo decimal,
@unidad_medida_insumo varchar(30)
--@Resultado bit output
)
as
begin
	--SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM Insumo WHERE nombre_insumo = @nombre_insumo and cod_Insumo != @cod_Insumo)
		
		update Insumo set
		nombre_insumo=@nombre_insumo,
		cantidad_insumo=@cantidad_insumo,
		unidad_medida_insumo=@unidad_medida_insumo
		where cod_Insumo = @cod_Insumo
	--ELSE
	--	SET @Resultado = 0

end

go


--PROCEDIMIENTO PARA ELIMINAR INSUMO
CREATE PROC usp_EliminarInsumo(
@cod_Insumo int
--@Resultado bit output
)
as
begin
	--SET @Resultado = 1

	--validamos que ningun producto se encuentre relacionado a una tabla
	IF not EXISTS (select top 1 * from Proveedor_Insumo provin
INNER JOIN Insumo ins ON ins.cod_Insumo = provin.cod_Insumo
WHERE ins.cod_Insumo = @cod_Insumo)
		delete from Insumo where cod_Insumo = @cod_Insumo

	--ELSE
	--	SET @Resultado = 0

end

GO

--PROCEMIENTO PARA OBTENER TIPO_PERSONA
CREATE PROC usp_ObtenerTipoPersona
as
begin
 select tp.cod_Tipo, tp.Descripcion from Tipo_Personal tp
end

go


--PROCEDIMIENTO PARA GUARDAR TIPO_PERSONA
CREATE PROC usp_RegistrarTipoPersona(
@Descripcion varchar(50)
--@Resultado bit output
)as
begin
	--SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM Tipo_Personal WHERE Descripcion = @Descripcion)

		insert into Tipo_Personal(Descripcion) 
		values (@Descripcion)
	--ELSE
	--	SET @Resultado = 0
	
end

go


--PROCEDIMIENTO PARA MODIFICAR TIPO_PERSONA
CREATE PROC usp_ModificarTipoPersona(
@cod_Tipo int,
@Descripcion varchar(50)
--@Resultado bit output
)
as
begin
	--SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM Tipo_Personal WHERE cod_Tipo = @cod_Tipo and Descripcion = @Descripcion)
		
		update Tipo_Personal set
		Descripcion = @Descripcion
		where cod_Tipo = @cod_Tipo
	--ELSE
	--	SET @Resultado = 0

end

go


--PROCEDIMIENTO PARA ELIMINAR TIPO_PERSONA
CREATE PROC usp_EliminarTipoPersona(
@cod_Tipo int
--@Resultado bit output
)
as
begin
	--SET @Resultado = 1

	--validamos que ningun producto se encuentre relacionado a una tabla
	IF not EXISTS (select top 1 * from Personal_Cocinero pc
INNER JOIN Tipo_Personal tp ON tp.cod_Tipo = pc.cod_Tipo
WHERE tp.cod_Tipo = @cod_Tipo)
		delete from Tipo_Personal where cod_Tipo = @cod_Tipo

	--ELSE
	--	SET @Resultado = 0

end

GO

--PROCEMIENTO PARA OBTENER TURNO
CREATE PROC usp_ObtenerTurno
as
begin
 select tur.cod_Turno, tur.Descripcion from Turno tur
end

go

--PROCEDIMIENTO PARA GUARDAR TURNO
CREATE PROC usp_RegistrarTurno(
@Descripcion varchar(50)
--@Resultado bit output
)as
begin
	--SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM Turno WHERE Descripcion = @Descripcion)

		insert into Turno(Descripcion) 
		values (@Descripcion)
	--ELSE
	--	SET @Resultado = 0
	
end

go

--PROCEDIMIENTO PARA MODIFICAR TURNO
CREATE PROC usp_ModificarTurno(
@cod_Turno int,
@Descripcion varchar(50)
--@Resultado bit output
)
as
begin
	--SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM Turno WHERE cod_Turno = @cod_Turno and Descripcion = @Descripcion)
		
		update Turno set
		Descripcion = @Descripcion
		where cod_Turno = @cod_Turno
	--ELSE
	--	SET @Resultado = 0

end

go

--PROCEDIMIENTO PARA ELIMINAR TURNO
CREATE PROC usp_EliminarTurno(
@cod_Turno int
--@Resultado bit output
)
as
begin
	--SET @Resultado = 1

	--validamos que ningun producto se encuentre relacionado a una tabla
	IF not EXISTS (select top 1 * from Personal_Cocinero pc
INNER JOIN Turno tur ON tur.cod_Turno = pc.cod_Turno
WHERE tur.cod_Turno = @cod_Turno)
		delete from Turno where cod_Turno = @cod_Turno

	--ELSE
	--	SET @Resultado = 0

end

GO

--PROCEDMIENTO PARA OBTENER PERSONAL_COCINERO

CREATE PROC usp_ObtenerPersonalCocinero
as
begin
 select pc.Rut_Personal_Cocinero, pc.Nombre_Cocinero,pc.Apellido_Cocinero,pc.Telefono_Cocinero,pc.Direccion_Cocinero,tp.cod_Tipo,tp.Descripcion as [Descripcion Tipo],tur.cod_turno,tur.Descripcion as [Descripcion Turno]
 from Personal_Cocinero pc
 inner join Tipo_Personal tp on tp.cod_Tipo = pc.cod_Tipo
 inner join Turno tur on tur.cod_Turno= pc.cod_turno
end

go

--PROCEDIMIENTO PARA GUARDAR PERSONAL_COCINERO
CREATE PROC usp_RegistrarPersonalCocinero(
@Nombre_Cocinero varchar(30),
@Apellido_Cocinero varchar(30),
@Telefono_Cocinero varchar(20),
@Direccion_Cocinero varchar(50),
@cod_Tipo int,
@cod_turno int
--@Resultado bit output
)as
begin
	--SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM Personal_Cocinero WHERE Nombre_Cocinero = @Nombre_Cocinero)

		insert into Personal_Cocinero(Nombre_Cocinero,Apellido_Cocinero,Telefono_Cocinero,Direccion_Cocinero,cod_Tipo,cod_turno)
		values(@Nombre_Cocinero,@Apellido_Cocinero,@Telefono_Cocinero,@Direccion_Cocinero,@cod_Tipo,@cod_turno)

	--ELSE
	--	SET @Resultado = 0	
end
go

--PROCEDIMIENTO PARA MODIFICAR PERSONAL_COCINERO
create procedure usp_ModificarPersonalCocinero(
@Rut_Personal_Cocinero int,
@Nombre_Cocinero varchar(30),
@Apellido_Cocinero varchar(30),
@Telefono_Cocinero varchar(20),
@Direccion_Cocinero varchar(50),
@cod_Tipo int,
@cod_turno int
--@Resultado bit output
)
as
begin
	--SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM Personal_Cocinero WHERE Nombre_Cocinero = @Nombre_Cocinero and  Rut_Personal_Cocinero != @Rut_Personal_Cocinero)
		
		update Personal_Cocinero set 
		Nombre_Cocinero=@Nombre_Cocinero,
		Apellido_Cocinero=@Apellido_Cocinero,
		Telefono_Cocinero=@Telefono_Cocinero,
		Direccion_Cocinero=@Direccion_Cocinero,
		cod_Tipo=@cod_Tipo,
		cod_turno=@cod_turno
		where Rut_Personal_Cocinero = @Rut_Personal_Cocinero
	--ELSE
	--	SET @Resultado = 0

end
go

--PROCEDIMIENTO PARA ELIMINAR PERSONAL_COCINERO
create procedure usp_EliminarPersonalCocinero(
@Rut_Personal_Cocinero int
--@Resultado bit output
)
as
begin
	--SET @Resultado = 1
	--validamos que ningun cocinero se encuentre asignado en la tabla plato
	IF not EXISTS (select top 1 * from Plato pla
inner join Personal_Cocinero pc on pc.Rut_Personal_Cocinero = pla.Rut_Personal_Cocinero
where pc.Rut_Personal_Cocinero = @Rut_Personal_Cocinero)

		delete from Personal_Cocinero where Rut_Personal_Cocinero = @Rut_Personal_Cocinero
	--ELSE
	--	SET @Resultado = 0

end
go

--PROCEDMIENTO PARA OBTENER PERSONAL_MESERO

CREATE PROC usp_ObtenerPersonalMesero
as
begin
 select pm.Rut_Personal_Mesero, pm.Nombre_Mesero,pm.Apellido_Mesero, pm.Telefono_Mesero,pm.Direccion_Mesero,tp.cod_Tipo,tp.Descripcion as [Descripcion Tipo],tur.cod_turno,tur.Descripcion as [Descripcion Turno]
 from Personal_Mesero pm
 inner join Tipo_Personal tp on tp.cod_Tipo = pm.cod_Tipo
 inner join Turno tur on tur.cod_Turno= pm.cod_turno
end

go

--PROCEDIMIENTO PARA GUARDAR PERSONAL_MESERO
CREATE PROC usp_RegistrarPersonalMesero(
@Nombre_Mesero varchar(30),
@Apellido_Mesero varchar(30),
@Telefono_Mesero varchar(20),
@Direccion_Mesero varchar(50),
@cod_Tipo int,
@cod_turno int
--@Resultado bit output
)as
begin
	--SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM Personal_Mesero WHERE Nombre_Mesero = @Nombre_Mesero)

		insert into Personal_Mesero(Nombre_Mesero,Apellido_Mesero,Telefono_Mesero,Direccion_Mesero,cod_Tipo,cod_turno)
		values(@Nombre_Mesero,@Apellido_Mesero,@Telefono_Mesero,@Direccion_Mesero,@cod_Tipo,@cod_turno)

	--ELSE
	--	SET @Resultado = 0	
end
go

--PROCEDIMIENTO PARA MODIFICAR PERSONAL_MESERO
Create procedure usp_ModificarPersonalMesero(
@Rut_Personal_Mesero int,
@Nombre_Mesero varchar(30),
@Apellido_Mesero varchar(30),
@Telefono_Mesero varchar(20),
@Direccion_Mesero varchar(50),
@cod_Tipo int,
@cod_turno int
--@Resultado bit output
)
as
begin
	--SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM Personal_Mesero WHERE Nombre_Mesero = @Nombre_Mesero and  Rut_Personal_Mesero != @Rut_Personal_Mesero)
		
		update Personal_Mesero set 
		Nombre_Mesero=@Nombre_Mesero,
		Apellido_Mesero=@Apellido_Mesero,
		Telefono_Mesero=@Telefono_Mesero,
		Direccion_Mesero=@Direccion_Mesero,
		cod_Tipo=@cod_Tipo,
		cod_turno=@cod_turno
		where Rut_Personal_Mesero = @Rut_Personal_Mesero
	--ELSE
	--	SET @Resultado = 0

end
go

--PROCEDIMIENTO PARA ELIMINAR PERSONAL_MESERO
create procedure usp_EliminarPersonalMesero(
@Rut_Personal_Mesero int
--@Resultado bit output
)
as
begin
	--SET @Resultado = 1
	--validamos que ningun mesero se encuentre asignado en la tabla Pedido
	IF not EXISTS (select top 1 * from Pedido ped
inner join Personal_Mesero pm on pm.Rut_Personal_Mesero = ped.Rut_Personal_Mesero
where pm.Rut_Personal_Mesero = @Rut_Personal_Mesero)

		delete from Personal_Mesero where Rut_Personal_Mesero = @Rut_Personal_Mesero
	--ELSE
	--	SET @Resultado = 0

end
go

--PROCEMIENTO PARA OBTENER PLATO
CREATE PROC usp_ObtenerPlato
as
begin
 select pla.cod_plato,pla.Nombre_Plato,pla.Precio_Plato,pla.Descripcion_Plato,pc.Rut_Personal_Cocinero,pc.Nombre_Cocinero,pc.Apellido_Cocinero from Plato pla
 inner join Personal_Cocinero pc on pc.Rut_Personal_Cocinero =pla.Rut_Personal_Cocinero
end

go

--PROCEDIMIENTO PARA GUARDAR PLATO
CREATE PROC usp_RegistrarPlato(
@Nombre_Plato varchar(30),
@Precio_Plato money,
@Descripcion_Plato varchar(50),
@Rut_Personal_Cocinero int
--@Resultado bit output
)as
begin
	--SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM Plato WHERE Nombre_Plato = @Nombre_Plato)

		insert into Plato(Nombre_Plato,Precio_Plato,Descripcion_Plato,Rut_Personal_Cocinero) 
		values (@Nombre_Plato,@Precio_Plato,@Descripcion_Plato,@Rut_Personal_Cocinero)
	--ELSE
	--	SET @Resultado = 0
	
end

go

--PROCEDIMIENTO PARA MODIFICAR PLATO
create procedure usp_ModificarPlato(
@cod_plato int,
@Nombre_Plato varchar(30),
@Precio_Plato money,
@Descripcion_Plato varchar(30),
@Rut_Personal_Cocinero int
--@Resultado bit output
)
as
begin
	--SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM Plato WHERE Nombre_Plato = @Nombre_Plato and cod_plato != @cod_plato)
		
		update Plato set
		Nombre_Plato=@Nombre_Plato,
		Precio_Plato=@Precio_Plato,
		Descripcion_Plato=@Descripcion_Plato,
		Rut_Personal_Cocinero=@Rut_Personal_Cocinero
		where cod_plato = @cod_plato
	--ELSE
	--	SET @Resultado = 0

end

go

--PROCEDIMIENTO PARA ELIMINAR PLATO
create procedure usp_EliminarPlato(
@cod_plato int
--@Resultado bit output
)
as
begin
	--SET @Resultado = 1

	--validamos que ningun producto se encuentre relacionado a una tabla
	IF not EXISTS (select top 1 * from Insumo_Plato inspla
INNER JOIN Plato pla ON pla.cod_plato = inspla.cod_plato
WHERE pla.cod_plato = @cod_plato)
		delete from Plato where cod_plato = @cod_plato

	--ELSE
	--	SET @Resultado = 0

end

GO

/********************* PROVEEDOR_INSUSMO **************************/

--PROCEDMIENTO PARA OBTENER PROVEEDOR_INSUSMO

Create PROC usp_ObtenerProveedorInsumo
as
begin
 select provin.Id_ProveedorInsumo, p.Rut_Proveedor, p.Nombre_Proveedor[Nombre Proveedor],p.Telefono_Proveedor [Telefono Proveedor],
 ins.cod_Insumo,ins.nombre_insumo[Nombre Insumo],provin.Precio_Insumo
 from Proveedor_Insumo provin
 inner join Proveedor p on p.Rut_Proveedor = provin.Rut_Proveedor
 inner join Insumo ins on ins.cod_Insumo = provin.cod_Insumo
end

go

--PROCEDIMIENTO PARA GUARDAR PROVEEDOR_INSUSMO
create PROC usp_RegistrarProveedorInsumo(
@Rut_Proveedor int,
@cod_insumo int,
@Precio_Insumo money
--@Resultado bit output
)as
begin
	--SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM Proveedor_Insumo WHERE Rut_Proveedor = @Rut_Proveedor and cod_Insumo = @cod_insumo)

		insert into Proveedor_Insumo (Rut_Proveedor,cod_Insumo,Precio_Insumo) 
		values (@Rut_Proveedor,@cod_insumo,@Precio_Insumo)

	--ELSE
	--	SET @Resultado = 0
	
end

go
--PROCEDIMIENTO PARA MODIFICAR PROVEEDOR_INSUSMO
create procedure usp_ModificarProveedorInsumo(
@Id_ProveedorInsumo int,
@Rut_Proveedor int,
@cod_Insumo int,
@Precio_Insumo Money
--@Resultado bit output
)
as
begin
	--SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM Proveedor_Insumo WHERE @Id_ProveedorInsumo != @Id_ProveedorInsumo and Precio_Insumo = @Precio_Insumo )
		
		update Proveedor_Insumo set 
		Rut_Proveedor = @Rut_Proveedor,
		cod_Insumo = @cod_Insumo,
		Precio_Insumo = @Precio_Insumo
		where Id_ProveedorInsumo = @Id_ProveedorInsumo 
	--ELSE
	--	SET @Resultado = 0

end

go
--select * from Proveedor_Insumo
--exec usp_ModificarProveedorInsumo 1,1,1,20
--exec usp_ObtenerProveedorInsumo
--PROCEDIMIENTO PARA ELIMINAR PROVEEDOR_INSUSMO
create procedure usp_EliminarProveedorInsumo(
@Id_ProveedorInsumo int
--@Resultado bit output
)
as
begin
	--SET @Resultado = 1

	IF NOT EXISTS (SELECT * FROM Proveedor_Insumo WHERE @Id_ProveedorInsumo = @Id_ProveedorInsumo and Precio_Insumo<0)

		delete from Proveedor_Insumo where Id_ProveedorInsumo = @Id_ProveedorInsumo

	--ELSE
	--	SET @Resultado = 0

end

go

/********************* INSUMO_PLATO **************************/

--PROCEDMIENTO PARA OBTENER INSUMO_PLATO

create PROC usp_ObtenerInsumoPlato
as
begin
 select inspla.Id_InsumoPlato , pla.cod_plato,pla.Nombre_Plato[Nombre Plato],pla.Precio_Plato[Precio Plato],
 ins.cod_Insumo,ins.nombre_insumo[Nombre Insumo],inspla.cantidad_insumo_utilizado
 from Insumo_Plato inspla
 inner join Plato pla on pla.cod_plato = inspla.cod_plato
 inner join Insumo ins on ins.cod_Insumo = inspla.cod_Insumo
end

go

--PROCEDIMIENTO PARA GUARDAR INSUSMO_PLATO
Create PROC usp_RegistrarInsumoPlato(
@cod_plato int,
@cod_insumo int,
@cantidad_insumo_utilidado int
--@Resultado bit output
)as
begin
	--SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM Insumo_Plato WHERE cod_plato = @cod_plato and cod_Insumo = @cod_insumo)

		insert into Insumo_Plato(cod_plato,cod_Insumo,cantidad_insumo_utilizado) 
		values (@cod_plato,@cod_insumo,@cantidad_insumo_utilidado)

	--ELSE
	--	SET @Resultado = 0
	
end

go

--PROCEDIMIENTO PARA MODIFICAR INSUMO_PLATO
create procedure usp_ModificarInsumoPlato(
@Id_InsumoPlato int,
@cod_plato int,
@cod_insumo int,
@cantidad_insumo_utilidado int
--@Resultado bit output
)
as
begin
	--SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM Insumo_Plato WHERE @Id_InsumoPlato = @Id_InsumoPlato and cantidad_insumo_utilizado = @cantidad_insumo_utilidado )
		
		update Insumo_Plato set 
		cod_plato = @cod_plato,
		cod_Insumo = @cod_Insumo,
		cantidad_insumo_utilizado = @cantidad_insumo_utilidado
		where Id_InsumoPlato = @Id_InsumoPlato
	--ELSE
	--	SET @Resultado = 0

end

go

--PROCEDIMIENTO PARA ELIMINAR INSUMO_PLATO
create procedure usp_EliminarInsumoPlato(
@Id_InsumoPlato int
--@Resultado bit output
)
as
begin
	--SET @Resultado = 1

	IF NOT EXISTS (SELECT * FROM Insumo_Plato WHERE @Id_InsumoPlato = @Id_InsumoPlato and cantidad_insumo_utilizado<0)

		delete from Insumo_Plato where Id_InsumoPlato = @Id_InsumoPlato

	--ELSE
	--	SET @Resultado = 0

end

go

--**************PEDIDO********************

----PROCEDIMIENTO PARA OBTENER PEDIDO
Create PROC usp_ObtenerPedido
as
begin
 select ped.Id_Pedido,cli.Rut_Cliente,cli.Nombre_Cliente,cli.Apellido_Cliente,ped.Tipo_Pedido,mesa.Num_Mesa,mesa.Cant_Max_Comensales,mesa.Ubicacion,pm.Rut_Personal_Mesero,pm.Nombre_Mesero,pm.Apellido_Mesero,ped.Fecha_Pedido
 from Pedido ped
 inner join Cliente cli on cli.Rut_Cliente = ped.Rut_Cliente
 inner join Mesa mesa on mesa.Num_Mesa = ped.Num_Mesa
 inner join Personal_Mesero pm on pm.Rut_Personal_Mesero = ped.Rut_Personal_Mesero
end

go

--PROCEDIMIENTO PARA GUARDAR PEDIDO
Create PROC usp_RegistrarPedido(
@Rut_Cliente int,
@Tipo_Pedido varchar(50),
@Num_Mesa int,
@Rut_Personal_Mesero int,
@Fecha_Pedido datetime
--@Resultado bit output
)as
begin
	--SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM Pedido WHERE Rut_Cliente = @Rut_Cliente and Num_Mesa = @Num_Mesa and Rut_Personal_Mesero = @Rut_Personal_Mesero)

		insert into Pedido(Rut_Cliente,Tipo_Pedido,Num_Mesa,Rut_Personal_Mesero,Fecha_Pedido) 
		values (@Rut_Cliente,@Tipo_Pedido,@Num_Mesa,@Rut_Personal_Mesero,@Fecha_Pedido)

	--ELSE
	--	SET @Resultado = 0
	
end

go

--PROCEDIMIENTO PARA MODIFICAR PEDIDO
CREATE PROC usp_ModificarPedido(
@Id_Pedido int,
@Rut_Cliente int,
@Tipo_Pedido varchar(50),
@Num_Mesa int,
@Rut_Personal_Mesero int,
@Fecha_Pedido datetime
--@Resultado bit output
)
as
begin
	--SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM Pedido WHERE @Id_Pedido != @Id_Pedido)
		
		update Pedido set 
		Rut_Cliente = @Rut_Cliente,
		Tipo_Pedido = @Tipo_Pedido,
		Num_Mesa = @Num_Mesa,
		Rut_Personal_Mesero = @Rut_Personal_Mesero,
		Fecha_Pedido = @Fecha_Pedido
		where Id_Pedido = @Id_Pedido
	--ELSE
	--	SET @Resultado = 0

end

go

--PROCEDIMIENTO PARA ELIMINAR PEDIDO
create procedure usp_EliminarPedido(
@Id_Pedido int
--@Resultado bit output
)
as
begin
	--SET @Resultado = 1

	--validamos que ningun pedido se encuentre relacionado a una tabla
	IF not EXISTS (select top 1 * from Venta v
INNER JOIN Pedido ped ON ped.Id_Pedido = v.Id_Pedido
WHERE ped.Id_Pedido = @Id_Pedido)
		delete from Pedido where Id_Pedido = @Id_Pedido

	--ELSE
	--	SET @Resultado = 0

end

go

----PROCEDIMIENTO PARA OBTENER DETALLE_PEDIDO
create PROC usp_ObtenerDetallePedido
as
begin
 select dp.Id_DetallePedido,dp.Menu,pla.cod_plato,Nombre_Plato,pla.Precio_Plato,ped.Id_Pedido,ped.Tipo_Pedido,ped.Fecha_Pedido,ped.Rut_Cliente
 from Detalle_Pedido dp
 inner join Pedido ped on ped.Id_Pedido = dp.Id_Pedido
 inner join Plato pla on pla.cod_plato = dp.cod_plato
end

go

--PROCEDIMIENTO PARA GUARDAR DETALLE_PEDIDO
Create PROC usp_RegistrarDetallePedido(
@Id_Pedido int,
@cod_plato int,
@Menu varchar(50)
--@Resultado bit output
)as
begin
	--SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM Detalle_Pedido WHERE cod_plato = @cod_plato and Id_Pedido = @Id_Pedido)

		insert into Detalle_Pedido(Id_Pedido,cod_plato,Menu) 
		values (@Id_Pedido,@cod_plato,@Menu)

	--ELSE
	--	SET @Resultado = 0
	
end

go

--PROCEDIMIENTO PARA MODIFICAR DETALLE_PEDIDO
create procedure usp_ModificarDetallePedido(
@Id_DetallePedido int,
@Id_Pedido int,
@cod_plato int,
@Menu varchar(50)
--@Resultado bit output
)
as
begin
	--SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM Detalle_Pedido WHERE @Id_DetallePedido != @Id_DetallePedido and Menu = @Menu)
		
		update Detalle_Pedido set 
		Id_Pedido = @Id_Pedido,
		cod_plato = @cod_plato,
		Menu = @Menu
		where Id_DetallePedido = @Id_DetallePedido
	--ELSE
	--	SET @Resultado = 0

end

go

--PROCEDIMIENTO PARA ELIMINAR DETALLE_PEDIDO
Create procedure usp_EliminarDetallePedido(
@Id_DetallePedido int
--@Resultado bit output
)
as
begin
	--SET @Resultado = 1

	IF NOT EXISTS (SELECT * FROM Detalle_Pedido WHERE Id_DetallePedido = @Id_DetallePedido and @Id_DetallePedido<0 )

		delete from Detalle_Pedido where Id_DetallePedido = @Id_DetallePedido

	--ELSE
	--	SET @Resultado = 0

end

go

/**********VENTA**********/
--PROCEDMIENTO PARA OBTENER VENTA
create PROC usp_ObtenerVenta
as
begin
 select Cod_Venta,Tipo_Venta,(pla.Precio_Plato+Sud_total)as Sud_total,((pla.Precio_Plato+Sud_total)*0.15+v.IVA) as IVA, Propina,
 ((pla.Precio_Plato+Sud_total)+((pla.Precio_Plato+Sud_total)*0.15+IVA))+Total as Total,PagoCon,
 (PagoCon-((pla.Precio_Plato+Sud_total)+((pla.Precio_Plato+Sud_total)*0.15+IVA))+Total)+Cambio as Cambio,
 Fecha_Venta,ped.Id_Pedido,ped.Fecha_Pedido,dp.Menu,dp.cod_plato,pla.Nombre_Plato
 from Venta v
 inner join Pedido ped on ped.Id_Pedido = v.Id_Pedido
 inner join Detalle_Pedido dp on dp.Id_Pedido = ped.Id_Pedido
 inner join Plato pla on pla.cod_plato = dp.cod_plato
 end

go
--select * from Venta select * from Detalle_Pedido select * from Pedido select * from Plato
--PROCEDIMIENTO PARA GUARDAR VENTA
create PROC usp_RegistrarVenta(
@Tipo_Venta varchar(30),
--@Sud_total money,
--@IVA money,
@Propina money,
--@Total money,
@PagoCon money,
--@Cambio money,
@Fecha_Venta datetime,
@Id_Pedido int
--@Resultado bit output
)as
begin
	--SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM Venta WHERE Id_Pedido = @Id_Pedido)

		insert into Venta(Tipo_Venta,Sud_total,IVA,Propina,Total,PagoCon,Cambio,Fecha_Venta,Id_Pedido) 
		values (@Tipo_Venta,0,0,@Propina,0,@PagoCon,0,@Fecha_Venta,@Id_Pedido)
	--ELSE
	--	SET @Resultado = 0
	
end

go

--PROCEDIMIENTO PARA MODIFICAR VENTA
Create procedure usp_ModificarVenta(
@Cod_Venta int,
@Tipo_Venta varchar(30),
--@Sud_total money,
--@IVA money,
@Propina money,
--@Total money,
@PagoCon money,
--@Cambio money,
@Fecha_Venta datetime,
@Id_Pedido int
--@Resultado bit output
)
as
begin
	--SET @Resultado = 1
	IF NOT EXISTS (SELECT * FROM Venta WHERE @Cod_Venta != @Cod_Venta)
		
		update Venta set 
			Tipo_Venta = @Tipo_Venta,
			--Sud_total = @Sud_total,
			--IVA = @IVA,
			Propina = @Propina,
			--Total = @Total,
			PagoCon = @PagoCon,
			--Cambio = @Cambio,
			Fecha_Venta = @Fecha_Venta,
			Id_Pedido = @Id_Pedido
		where Cod_Venta = @Cod_Venta
	--ELSE
	--	SET @Resultado = 0

end

go

--PROCEDIMIENTO PARA ELIMINAR VENTA
Create procedure usp_EliminarVenta(
@Cod_Venta int
--@Resultado bit output
)
as
begin
	--SET @Resultado = 1

	IF NOT EXISTS (SELECT * FROM Venta WHERE @Cod_Venta != @Cod_Venta)

		delete from Venta where Cod_Venta = @Cod_Venta

	--ELSE
	--	SET @Resultado = 0

end

go

/**********Usuario**********/
--PROCEDMIENTO PARA OBTENER USUARIO
go
create procedure SP_ListaUsuarios
as
select cod_Tipo as Puesto, Usuario, Contraseña, FechaCreacion as Creación from Usuario
go
--PROCEDIMIENTO PARA VERIFICAR USUARIO
GO
Create procedure SP_VerificarUsuario
@Usuario varchar(50), @Pass varchar(50)
as
select Usuario,Contraseña, cod_Tipo 
from Usuario 
where Usuario=@Usuario and Contraseña=@Pass
