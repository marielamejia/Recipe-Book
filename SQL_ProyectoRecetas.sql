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
	nombre varchar(50),
	instrucciones varchar(MAX))

create table RecetaEtiqueta(
	idReceta smallint not null,
	etiqueta varchar(50) not null, 
	primary key (idReceta, etiqueta))

create table RegistroReceta(
	idReceta smallint references Receta,
	idRegistro smallint not null,
	cedulaNutriologo varchar(20) references Nutriologo,
	primary key (idReceta, idRegistro))

create table Ingrediente(
	idIngrediente smallint not null primary key,
	nombre varchar(50),
	precioPromPorKg decimal(5,2))

create table RecetaIngrediente(
	idReceta smallint references Receta,
	idIngrediente smallint references Ingrediente,
	numPiezas decimal(4,2),
	primary key (idReceta, idIngrediente))

create table Usuario(
	idUsuario smallint not null primary key,
	nombre varchar(50),
	correo varchar(50) unique,
	contrasena varchar(20))

create table PlanDia(
	idPlan smallint not null primary key,
	nombre varchar(25),
	idUsuario smallint references Usuario)

create table RecetaPlan(
	idReceta smallint references Receta,
	idPlan smallint references PlanDia,
	primary key (idReceta, idPlan))

create table ListaSuper(
	idLista smallint not null primary key,
	numItems smallint,
	idUsuario smallint references Usuario)

create table IngredienteListaSuper(
	idIngrediente smallint references Ingrediente,
	idLista smallint references ListaSuper,
	numPiezas decimal(4,2),
	primary key (idIngrediente, idLista))

--Alta del administrador
insert into Administrador values('Admin', 'Admin')

--Registro de algunos ingredientes
insert into Ingrediente values (82,'Aceite', 23.00)
insert into Ingrediente values (83,'Arroz', 20.00)
insert into Ingrediente values (84,'Az�car' , 22.00)
insert into Ingrediente values (85,'Harina', 16.00)
insert into Ingrediente values (86,'Frijol bayo', 15.00)
insert into Ingrediente values (87,'Frijol negro', 30.00)
insert into Ingrediente values (88,'Huevo', 35.00)
insert into Ingrediente values (89,'Carne molida de res', 110.00)
insert into Ingrediente values (90,'Bistec de res', 150.00)
insert into Ingrediente values (91,'Aguacate', 60.00)
insert into Ingrediente values (92,'Lim�n', 20.00)
insert into Ingrediente values (93,'Guayaba', 30.00)
insert into Ingrediente values (94,'Manzana Golden', 30.00)
insert into Ingrediente values (95,'Manzana roja', 40.00)
insert into Ingrediente values (96,'Naranja', 10.00)
insert into Ingrediente values (97,'Papaya', 20.00)
insert into Ingrediente values (98,'Pi�a', 15.00)
insert into Ingrediente values (99,'Pl�tano macho', 15.00)

--Alta de un Nutri�logo de prueba
insert into Nutriologo values ('123', 'nutri', 'nutri')
--Alta de un Usuario de prueba
insert into Usuario values (1, 'usuario', 'usuario@gmail.com', 'usuario')


--Queries para el proyecto standalone

--Login
select contrasena from Administrador where usuAdmin = '{}'

--Ingrediente
insert into Ingrediente values ({}, {}, '{}') --para alta
delete from Ingrediente where idIngrediente = {} --para baja
select * from Ingrediente where nombre like '%{}%' --b�squeda
select * from Ingrediente --para ver todos
update Ingrediente set precioPromPorKg = {} where idIngrediente = {} --para actualizar el precio

--Nutr�logo
insert into Nutriologo values ('{}', '{}', '{}') --para alta
delete from Nutriologo where cedula = '{}' --para baja
select * from Nutriologo --para ver todos


--Queries para el proyecto web

--Login
select Nutriologo.contrasena from Nutriologo where cedula = '{}' --no olvidar guardar c�dula en el Session
select Usuario.contrasena, idUsuario from Usuario where correo = '{}' --no olvidar guardar el id en el Session
select idLista from ListaSuper where idUsuario = {Session["idUsuario"]} --tras el login de usuario

--Recetas
--para mostrar al inicio en el grid:
select idReceta,nombre from Receta
--para el buscador (no olvides resetear filtros tras buscar):
select Receta.idReceta,Receta.nombre from Receta where nombre like '{%nombreBuscado%}'
--para filtrar por etiquetas (se recorren los renglones del grid y si el query regresa tupla se a�ade al nuevo grid):
select * from RecetaEtiqueta where idReceta = {idReceta} and etiqueta like '{etiquetaBuscada}'
--para mostrar la receta (en el lado derecho):
select instrucciones from Receta where idReceta = {idReceta} --para instrucciones
select etiqueta from RecetaEtiqueta where idReceta = {idReceta} --para las etiquetas (vaciar en una lista)
select Ingrediente.nombre, RecetaIngrediente.numPiezas from RecetaIngrediente inner join Ingrediente 
	on RecetaIngrediente.idIngrediente = Ingrediente.idIngrediente where idReceta = {idReceta} 
	--para listar ingredientes en un grid (el id va invisible)
--para a�adir la receta a un plan semanal:
select idPlan, nombre from PlanDia where idUsuario = {Session["idUsuario"]} --para llenar una dropdownlist
insert into RecetaPlan values ({idReceta},{idPlan}) --para agregar, si hay error es porque ya estab a�adida

--Planes Diarios
--para mostrar los planes activos (grid):
select idPlan, nombre from PlanDiario where idUsuario = {Session["idUsuario"]}
--para listar las recetas de un plan al picarle en el bot�n del respectivo rengl�n:
select Receta.idReceta,Receta.nombre from Receta inner join RecetaPlan on Receta.idReceta = RecetaPlan.idReceta
	where RecetaPlan.idPlan = {idPlan} --(vaciar en otro grid)
--para mostrar la receta (al picarle en el bot�n del respectivo rengl�n):
select instrucciones from Receta where idReceta = {idReceta} --para instrucciones
select etiqueta from RecetaEtiqueta where idReceta = {idReceta} --para las etiquetas
select Ingrediente.nombre, RecetaIngrediente.numPiezas from RecetaIngrediente inner join Ingrediente 
	on RecetaIngrediente.idIngrediente = Ingrediente.idIngrediente where idReceta = {idReceta} 
	--para listar ingredientes (en un tercer grid, el id va invisible)
--para a�adir los ingredientes a la lista al picarle en el bot�n de su respectivo rengl�n:
select numPiezas from IngredienteListaSuper where idLista = {"Session["idLista"]"} and idIngrediente = {idIngrediente}
	--para saber si ya estaba:
update IngredienteListaSuper set numPiezas = {piezasAnteriores + piezasReceta} 
	where idLista = {"Session["idLista"]"} and idIngrediente = {idIngrediente} --si ya se encontraba
insert into IngredienteListaSuper values ({Session["idLista"]},{idIngrediente},{piezasReceta}) --si no se encontraba

--ListaSuper
--para mostrar ingredientes (en un gridview):
select Ingrediente,idIngrediente, Ingrediente.nombre, Ingrediente.PrecioPromPorKilo, IngredienteLista.numPiezas
	from Ingrediente inner join IngredienteLista on Ingrediente.idIngrediente = IngredienteLista.idIngrediente
	where idLista = {idLista}
--para eliminar ingredientes (al picarle al bot�n de su respectivo rengl�n):
delete from IngredienteLista where idLista = {Session["idLista"]} and idIngrediente = {idIngrediente}
--para limpiar la lista (en alg�n bot�n):
delete from IngredienteLista where idLista = {Session["idLista"]}

--Nutri�logo
--mostrar recetas (en un gridview):
select Receta.idReceta,Receta.nombre from Receta inner join RegistroReceta on Receta.idReceta = RegistroReceta.idReceta
	where RegristroReceta.cedula = '{Session["cedula"]}'
--para mostrar la receta (al picarle en el bot�n del respectivo rengl�n):
select instrucciones from Receta where idReceta = {idReceta} --para instrucciones
select etiqueta from RecetaEtiqueta where idReceta = {idReceta} --para las etiquetas
select Ingrediente.nombre, RecetaIngrediente.numPiezas from RecetaIngrediente inner join Ingrediente 
	on RecetaIngrediente.idIngrediente = Ingrediente.idIngrediente where idReceta = {idReceta} 
	--para listar ingredientes (en un tercer grid, el id va invisible)
--Crear una nueva receta (va en otra p�gina distinta a la de mostrar)
--para mostrar los ingredientes con los que trabajar (en un grid con el id invisible y columna de bot�n para agregar):
select idIngrediente,nombre from Ingrediente
	--al dar click en el bot�n de agregar el rengl�n debe copiarse en un segundo grid casi igual pero que en vez de 
	--bot�n para agregar tenga un campo en blanco para que se escriba la cantidad (se ingresa en piezas, no en gramos)
--para llenar el checkboxlist con las etiquetas:
select distinct etiqueta from RecetaEtiqueta
--para el alta de la receta (habr� que pensar bien en c�mo se genera el ID):
insert into Receta values ({idReceta}, '{nombre}', '{instrucciones}')
insert into RegistroReceta values ({idReceta},{idRegistro},'{Session["cedula"]') 
	--maybe el id del registro puede ser el mismo que el de la etiqueta??
insert into RecetaEtiqueta values ({idReceta},'{etiqueta}') 
	--se va recorriendo el checkboxlist y si est� seleccionada se hace la inserci�n
insert into RecetaIngrediente ({idReceta},{idIngrediente},{cantidad})
	--se ir� recorriendo el grid de ingredientes seleccionados para esta parte

--Registro de un nutriologo
INSERT INTO Nutriologo VALUES(1, 'nutriAdmin', 'contra') 
--Registro de algunas recetas
INSERT INTO Receta VALUES(1, 'Receta base', 'Utilizada para dar de alta a las etiquetas')
INSERT INTO Receta VALUES(2, 'Huevos balanceados', 'Revolver huevos y cocer en un sarten. Acompañar con arroz y aguacate')
--Conectar receta con nutriologo
INSERT INTO RegistroReceta VALUES (2, 100, 1)
--Conectar receta con ingredientes
INSERT INTO RecetaIngrediente VALUES (2, 83, 1)
INSERT INTO RecetaIngrediente VALUES (2, 88, 2)
INSERT INTO RecetaIngrediente VALUES (2, 91, 1)
--Registro de algunas etiquetas
INSERT INTO RecetaEtiqueta VALUES(1,'Gluten-free')
INSERT INTO RecetaEtiqueta VALUES(1,'Obesidad')
INSERT INTO RecetaEtiqueta VALUES(1,'Diabetes')
INSERT INTO RecetaEtiqueta VALUES(1,'Hipertensión')

--Queries para el registro
SELECT distinct etiqueta FROM RecetaEtiqueta
SELECT idIngrediente, nombre FROM Ingrediente

SELECT COUNT(DISTINCT idReceta) FROM Receta