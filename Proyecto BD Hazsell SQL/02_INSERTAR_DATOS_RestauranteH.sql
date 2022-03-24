use master
use RestauranteH

---*******PROVEEDOR*********
Insert into Proveedor(Nombre_Proveedor, Direccion_Proveedor, Telefono_Proveedor, Email_Proveedor, Fax_Proveedor)
VALUES ('Molinos de Nicaragua, S.A.','Parque Sandino 300 vrs al Este','(+505) 2552 2291','www.monisa.com','(+505) 2552 2291')
select * from Proveedor

---*****INSUMO******
Insert into Insumo(nombre_insumo,cantidad_insumo,unidad_medida_insumo)
Values('Arroz faisan','3','25 Libras')
select * from Insumo

-----***TIPO_PERSONAL****
insert into Tipo_Personal(Descripcion)
values('Cocinero')
select * from Tipo_Personal

-----*****Turno****
insert into Turno(Descripcion)
values('Diurno')
select * from Turno

-----Cliente
insert into Cliente(Nombre_Cliente,Apellido_Cliente,Direccion_Cliente,Telefono_Cliente,Tipo_Cliente,Fecha_Nac_Cliente,Observaciones_Cliente)
values ('Luis','Perez','Semáforos de Enitel Villa Fontana, 30 mts al Norte','+505 8457 6489','Premium','1995-02-18','Paciente con los meceros')
select * from Cliente

--Mesa *crear un procedimiento para agragar 
insert into Mesa(Cant_Max_Comensales,Ubicacion)
values ('0','Ninguna')
select * from Mesa

/*LAS DEMAS TABLAS SE VAN LLENADO CON LOS PROCEDIMIENTOS*/