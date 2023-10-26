create database BDnutricion
use BDnutricion

--Creación de tablas

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
	correo varchar(50),
	nombre varchar(50),
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
insert into Ingrediente values (84,'Azúcar' , 22.00)
insert into Ingrediente values (85,'Harina', 16.00)
insert into Ingrediente values (86,'Frijol bayo', 15.00)
insert into Ingrediente values (87,'Frijol negro', 30.00)
insert into Ingrediente values (88,'Huevo', 35.00)
insert into Ingrediente values (89,'Carne molida de res', 110.00)
insert into Ingrediente values (90,'Bistec de res', 150.00)
insert into Ingrediente values (91,'Aguacate', 60.00)
insert into Ingrediente values (92,'Limón', 20.00)
insert into Ingrediente values (93,'Guayaba', 30.00)
insert into Ingrediente values (94,'Manzana Golden', 30.00)
insert into Ingrediente values (95,'Manzana roja', 40.00)
insert into Ingrediente values (96,'Naranja', 10.00)
insert into Ingrediente values (97,'Papaya', 20.00)
insert into Ingrediente values (98,'Piña', 15.00)
insert into Ingrediente values (99,'Plátano macho', 15.00)

--Alta de un Nutriólogo de prueba
insert into Nutriologo values ('123', 'nutri', 'nutri')
--Alta de un Usuario de prueba
insert into Usuario values (123, 'usuario@gmail.com', 'usuario', 'usuario')


--Queries para el proyecto standalone

--Login
select contrasena from Administrador where usuAdmin = '{}'

--Ingrediente
insert into Ingrediente values ({}, {}, '{}') --para alta
delete from Ingrediente where idIngrediente = {} --para baja
select * from Ingrediente where nombre like '%{}%' --búsqueda
select * from Ingrediente --para ver todos
update Ingrediente set precioPromPorKg = {} where idIngrediente = {} --para actualizar el precio

--Nutrólogo
insert into Nutriologo values ('{}', '{}', '{}') --para alta
delete from Nutriologo where cedula = '{}' --para baja
select * from Nutriologo --para ver todos


--Queries para el proyecto web

--Login
select Nutriologo.contrasena from Nutriologo where cedula = '{}' --no olvidar guardar cédula en el Session
select Usuario.contrasena, idUsuario from Usuario where correo = '{}' --no olvidar guardar el id en el Session
select idLista from ListaSuper where idUsuario = {Session["idUsuario"]} --tras el login de usuario

--Recetas
--para mostrar al inicio en el grid:
select idReceta,nombre from Receta
--para el buscador (no olvides resetear filtros tras buscar):
select Receta.idReceta,Receta.nombre from Receta where nombre like '{%nombreBuscado%}'
--para filtrar por etiquetas (se recorren los renglones del grid y si el query regresa tupla se añade al nuevo grid):
select * from RecetaEtiqueta where idReceta = {idReceta} and etiqueta like '{etiquetaBuscada}'
--para mostrar la receta (en el lado derecho):
select instrucciones from Receta where idReceta = {idReceta} --para instrucciones
select etiqueta from RecetaEtiqueta where idReceta = {idReceta} --para las etiquetas (vaciar en una lista)
select Ingrediente.nombre, RecetaIngrediente.numPiezas from RecetaIngrediente inner join Ingrediente 
	on RecetaIngrediente.idIngrediente = Ingrediente.idIngrediente where idReceta = {idReceta} 
	--para listar ingredientes en un grid (el id va invisible)
--para añadir la receta a un plan semanal:
select idPlan, nombre from PlanDia where idUsuario = {Session["idUsuario"]} --para llenar una dropdownlist
insert into RecetaPlan values ({idReceta},{idPlan}) --para agregar, si hay error es porque ya estab añadida

--Planes Diarios
--para mostrar los planes activos (grid):
select idPlan, nombre from PlanDiario where idUsuario = {Session["idUsuario"]}
--para listar las recetas de un plan al picarle en el botón del respectivo renglón:
select Receta.idReceta,Receta.nombre from Receta inner join RecetaPlan on Receta.idReceta = RecetaPlan.idReceta
	where RecetaPlan.idPlan = {idPlan} --(vaciar en otro grid)
--para mostrar la receta (al picarle en el botón del respectivo renglón):
select instrucciones from Receta where idReceta = {idReceta} --para instrucciones
select etiqueta from RecetaEtiqueta where idReceta = {idReceta} --para las etiquetas
select Ingrediente.nombre, RecetaIngrediente.numPiezas from RecetaIngrediente inner join Ingrediente 
	on RecetaIngrediente.idIngrediente = Ingrediente.idIngrediente where idReceta = {idReceta} 
	--para listar ingredientes (en un tercer grid, el id va invisible)
--para añadir los ingredientes a la lista al picarle en el botón de su respectivo renglón:
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
--para eliminar ingredientes (al picarle al botón de su respectivo renglón):
delete from IngredienteLista where idLista = {Session["idLista"]} and idIngrediente = {idIngrediente}
--para limpiar la lista (en algún botón):
delete from IngredienteLista where idLista = {Session["idLista"]}

--Nutriólogo
--mostrar recetas (en un gridview):
select Receta.idReceta,Receta.nombre from Receta inner join RegistroReceta on Receta.idReceta = RegistroReceta.idReceta
	where RegristroReceta.cedula = '{Session["cedula"]}'
--para mostrar la receta (al picarle en el botón del respectivo renglón):
select instrucciones from Receta where idReceta = {idReceta} --para instrucciones
select etiqueta from RecetaEtiqueta where idReceta = {idReceta} --para las etiquetas
select Ingrediente.nombre, RecetaIngrediente.numPiezas from RecetaIngrediente inner join Ingrediente 
	on RecetaIngrediente.idIngrediente = Ingrediente.idIngrediente where idReceta = {idReceta} 
	--para listar ingredientes (en un tercer grid, el id va invisible)
--Crear una nueva receta (va en otra página distinta a la de mostrar)
--para mostrar los ingredientes con los que trabajar (en un grid con el id invisible y columna de botón para agregar):
select idIngrediente,nombre from Ingrediente
	--al dar click en el botón de agregar el renglón debe copiarse en un segundo grid casi igual pero que en vez de 
	--botón para agregar tenga un campo en blanco para que se escriba la cantidad (se ingresa en piezas, no en gramos)
--para llenar el checkboxlist con las etiquetas:
select distinct etiqueta from RecetaEtiqueta
--para el alta de la receta (habrá que pensar bien en cómo se genera el ID):
insert into Receta values ({idReceta}, '{nombre}', '{instrucciones}')
insert into RegistroReceta values ({idReceta},{idRegistro},'{Session["cedula"]') 
	--maybe el id del registro puede ser el mismo que el de la etiqueta??
insert into RecetaEtiqueta values ({idReceta},'{etiqueta}') 
	--se va recorriendo el checkboxlist y si está seleccionada se hace la inserción
insert into RecetaIngrediente ({idReceta},{idIngrediente},{cantidad})
	--se irá recorriendo el grid de ingredientes seleccionados para esta parte