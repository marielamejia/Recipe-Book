create database BDnutricion
use BDnutricion

--Creacion de tablas

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


--PRUEBAS ES IMPORTANTE DAR DE ALTA EN ORDEN (POR TABLA)
--Alta de un Usuario de prueba
INSERT INTO Usuario VALUES (1, 'usuario', 'usuario@gmail.com', 'usuario')
--Registro de un nutriologo
INSERT INTO Nutriologo VALUES(1, 'nutriAdmin', 'contrasena') 
--Registro de algunas recetas
INSERT INTO Receta VALUES(1, 'Receta base', 'Utilizada para dar de alta a las etiquetas')
INSERT INTO Receta VALUES(2, 'Huevos balanceados', 'Revolver 2 huevos y cocer en un sarten. Acompañar con 200 gramos de arroz y medio aguacate. Calorías: 476-516 kcal. Proteínas totales: 18-20g. Grasas totales: 22-26g. Carbohidratos: 51-60 gramos')
INSERT INTO Receta VALUES(3, 'Jugo amanecer', 'Exprimir 2 naranjas en la licuadora y agregar un pedazo de papaya. Para una consistencia más pesada agregar más papaya, para una consistencia más ligera, agregar agua. Calorías: 210-270 kcal. Proteínas: 5-6 gramos. Grasas: menos de 1 gramo. Carbohidratos: 50-65 gramos. Fibra: 10-13 gramos')
INSERT INTO Receta VALUES(4,'Ensalada de fruta','Cortar una guayaba y dos manzanas en trozos pequeños. Revuelve en un plato hondo, como aderezo podria usar yogurt o miel. Calorías: 227-250 kcal. Proteínas: 3-4 gramos. Grasas: menos de 1 gramo. Carbohidratos: 59-67 gramos. Fibra: 11-15 gramos')
--Conectar receta con nutriologo
INSERT INTO RegistroReceta VALUES (2, 100, 1)
INSERT INTO RegistroReceta VALUES (3, 101, 1)
INSERT INTO RegistroReceta VALUES (4, 102, 1)
--Conectar receta con ingredientes
INSERT INTO RecetaIngrediente VALUES (2, 83, 1)
INSERT INTO RecetaIngrediente VALUES (2, 88, 2)
INSERT INTO RecetaIngrediente VALUES (2, 91, 1)
INSERT INTO RecetaIngrediente VALUES (3, 97, 1)
INSERT INTO RecetaIngrediente VALUES (3, 96, 2)
INSERT INTO RecetaIngrediente VALUES (4, 93, 1)
INSERT INTO RecetaIngrediente VALUES (4, 94, 2)
--Registro de algunas etiquetas en recetas
INSERT INTO RecetaEtiqueta VALUES(1,'Obesidad')
INSERT INTO RecetaEtiqueta VALUES(1,'Diabetes')
INSERT INTO RecetaEtiqueta VALUES(1,'Hipertensión')
INSERT INTO RecetaEtiqueta VALUES(2,'Diabetes')
INSERT INTO RecetaEtiqueta VALUES(2,'Obesidad')
INSERT INTO RecetaEtiqueta VALUES(3,'Hipertensión')
INSERT INTO RecetaEtiqueta VALUES(4,'Obesidad')
INSERT INTO RecetaEtiqueta VALUES(4,'Diabetes')
--Registro de algunos Planes con usuarios
INSERT INTO PlanDia VALUES(1, 'Lunes', 1)
INSERT INTO PlanDia VALUES(2, 'Martes', 1)
INSERT INTO PlanDia VALUES(3, 'Miercoles', 1)
--Registro de planes con recetas
INSERT INTO RecetaPlan VALUES(2, 1)
INSERT INTO RecetaPlan VALUES(3, 1)
INSERT INTO RecetaPlan VALUES(3, 2)
INSERT INTO RecetaPlan VALUES(4, 2)
INSERT INTO RecetaPlan VALUES(2, 3)
--Registro de lista de super con usuario
INSERT INTO ListaSuper VALUES(1, 5, 1)
--Registro de ingredientes en lista
INSERT INTO IngredienteListaSuper VALUES(94, 1, 2)
INSERT INTO IngredienteListaSuper VALUES(97, 1, 1)
INSERT INTO IngredienteListaSuper VALUES(83, 1, 1)
