create database BDnutricion
use BDnutricion

--Creaci�n de tablas

create table Administrador(
	usuAdmin varchar(20) not null primary key,
	contrasena varchar(20))

create table Nutriologo(
	cedula varchar(20) not null primary key,
	nombre varchar(50),
	contrasena varchar(20))

create table Receta(
	idReceta smallint not null primary key,
	foto varBinary(MAX),
	instrucciones varchar(MAX))

create table RecetaEtiqueta(
	idReceta smallint not null,
	etiqueta varchar(50) not null, 
	primary key (idReceta, etiqueta))

create table RegistroReceta(
	idReceta smallint references Receta,
	idRegistro smallint not null,
	tipo varchar(50),
	cedulaNutriologo varchar(20) references Nutriologo,
	primary key (idReceta, idRegistro))

create table Ingrediente(
	idIngrediente smallint not null primary key,
	precioProm decimal(5,2),
	nombre varchar(50))

create table RecetaIngrediente(
	idReceta smallint references Receta,
	idIngrediente smallint references Ingrediente,
	primary key (idReceta, idIngrediente))

create table Usuario(
	idUsuario smallint not null primary key,
	correo varchar(50),
	nombre varchar(50),
	contrasena varchar(20))

create table PlanSemanal(
	idPlan smallint not null primary key,
	fechaIn date,
	idUsiario smallint references Usuario)

create table RecetaPlanSemanal(
	idReceta smallint references Receta,
	idPlan smallint references PlanSemanal,
	dia varchar(10),
	primary key (idReceta, idPlan))

create table ListaSuper(
	idLista smallint not null primary key,
	numItems smallint,
	idUsuario smallint references Usuario)

create table IngredienteListaSuper(
	idIngrediente smallint references Ingrediente,
	idLista smallint references ListaSuper,
	primary key (idIngrediente, idLista))

--Alta del administrador
insert into Administrador values('Admin', 'Admin')


--Queries para el proyecto standalone

--Login
select idUsuario from Usuario where idUsuario = '{}' and contrasena = '{}'

--Ingrediente
insert into Ingrediente values ('{}', {}, '{}') --para alta
delete from Ingrediente where idIngrediente = {} --para baja
select * from Ingrediente where nombre like '{}' --b�squeda
select * from Ingrediente --para ver todos
update Ingrediente set precioProm = {} where idIngrediente = {} --para actualizar el precio

--Nutr�logo
insert into Nutriologo values ('{}', '{}', '{}') --para alta
delete from Nutriologo where cedula = '{}' --para baja
select * from Nutriologo --para ver todos