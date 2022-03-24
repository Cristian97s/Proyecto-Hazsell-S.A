use master

--drop database RestauranteH
go
create database RestauranteH
go
use RestauranteH
go

create table Proveedor(
Rut_Proveedor int primary key identity,
Nombre_Proveedor varchar(30),
Direccion_Proveedor varchar(50),
Telefono_Proveedor varchar(20),
Email_Proveedor varchar(30),
Fax_Proveedor varchar(20)
)
go

create table Insumo(
cod_Insumo int primary key identity,
nombre_insumo varchar(30),
cantidad_insumo decimal,
unidad_medida_insumo varchar(50)
)
go

create table Proveedor_Insumo(
Id_ProveedorInsumo int primary key identity,
Precio_Insumo money,
Rut_Proveedor int  foreign key references Proveedor(Rut_Proveedor)on delete cascade on update cascade not null,
cod_Insumo int  foreign key references Insumo(cod_Insumo)on delete cascade on update cascade not null
)
go

create table Tipo_Personal(
cod_Tipo int primary key identity,
Descripcion varchar(50)
)
go

create table Turno(
cod_Turno int primary key identity,
Descripcion varchar(50),
--Hora_Entrada time
)
go

create table Personal_Cocinero(
Rut_Personal_Cocinero int primary key identity,
Nombre_Cocinero varchar(30),
Apellido_Cocinero varchar(30),
Telefono_Cocinero varchar(20),
Direccion_Cocinero varchar(50),
cod_Tipo int  foreign key references Tipo_Personal(cod_Tipo)on delete cascade on update cascade not null,
cod_turno int  foreign key references Turno(cod_turno)on delete cascade on update cascade not null
)
go

create table Plato(
cod_plato int primary key identity,
Nombre_Plato varchar(30),
Precio_Plato money,
--Tipo_plato varchar(30),
Descripcion_Plato varchar(50),
Rut_Personal_Cocinero int  foreign key references Personal_Cocinero(Rut_Personal_Cocinero)on delete cascade on update cascade not null,
)
go

create table Insumo_Plato(
Id_InsumoPlato int primary key identity,
cantidad_insumo_utilizado int,
cod_Insumo int  foreign key references Insumo(cod_Insumo)on delete cascade on update cascade not null,
cod_plato int  foreign key references Plato(cod_plato)on delete cascade on update cascade not null
)
go

create table Mesa(
Num_Mesa int primary key identity,
Cant_Max_Comensales int,
--Cada una de las personas que comen en la misma mesa "los comensales" entraron poco a poco y se fueron sentando ordenadamente.
Ubicacion varchar(30),
)
go

create table Personal_Mesero(
Rut_Personal_Mesero int primary key identity,
Nombre_Mesero varchar(30),
Apellido_Mesero varchar(30),
Telefono_Mesero varchar(20),
Direccion_Mesero varchar(50),
cod_Tipo int  foreign key references Tipo_Personal(cod_Tipo)on delete cascade on update cascade not null,
cod_turno int  foreign key references Turno(cod_turno)on delete cascade on update cascade not null,
)
go

create table Cliente(
Rut_Cliente int primary key identity,
Nombre_Cliente varchar(30),
Apellido_Cliente varchar(30),
Direccion_Cliente varchar(50),
Telefono_Cliente varchar(20),
Tipo_Cliente varchar(30),
Fecha_Nac_Cliente date,
Observaciones_Cliente varchar(50)
)
go

create table Pedido(
Id_Pedido int primary key identity,
Tipo_Pedido varchar(50),
Fecha_Pedido datetime,
Rut_Cliente int  foreign key references Cliente(Rut_Cliente)on delete cascade on update cascade not null,
Num_Mesa int foreign key references Mesa(Num_Mesa)on delete cascade on update cascade not null,
Rut_Personal_Mesero int foreign key references Personal_Mesero(Rut_Personal_Mesero)on delete cascade on update cascade not null
)
go

create table Detalle_Pedido(
Id_DetallePedido int primary key identity,
Menu varchar(50),
Id_Pedido int foreign key references Pedido(Id_Pedido),
cod_plato int foreign key references Plato(cod_plato)
)
go
create table Venta(
Cod_Venta int primary key identity,
Tipo_Venta varchar(30),
Sud_total money,
IVA money,
Propina money,
Total money,
PagoCon money,
Cambio money,
Fecha_Venta datetime,
Id_Pedido int foreign key references Pedido(Id_Pedido)on delete cascade on update cascade not null
)
go
create table Usuario(
IdUsuario int not null primary key identity(1,1),
cod_Tipo int foreign key references Tipo_Personal(cod_tipo),
Usuario varchar(50),
Contraseña varchar(50),
FechaCreacion datetime
)
go