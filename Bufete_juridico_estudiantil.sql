create database BUFETE_JURIDICO_ESTUDIANTIL
GO

use BUFETE_JURIDICO_ESTUDIANTIL
GO

create table Tramites
(
CLAVE int identity(1,1) not null primary key,
NOMBRE varchar(50) not null
)
GO

create table Juzgados
(
CLAVE int identity(1,1) not null primary key,
DOMICILIO varchar(80),
TELEFONO varchar(15)
)
GO

create table Clientes
(
CLAVE int identity(1,1) not null primary key,
NOMBRE varchar(50) not null,
EDAD int,
DOMICILIO varchar(80),
TELEFONO_CASA varchar(15),
TELEFONO_FAMILIAR_1 varchar(15),
TELEFONO_FAMILIAR_2 varchar(15),
CLAVE_JUZGADO int references Juzgados(CLAVE)
)
GO

create table Registros
(
NUMERO_EXPEDIENTE int not null primary key,
CLAVE_TRAMITE int not null references Tramites(CLAVE),
CLAVE_CLIENTE int not null references Clientes(CLAVE),
FECHA datetime,
BITACORA varchar(max)
)
GO

create table Usuarios
(
CLAVE int identity(1,1) not null primary key,
USUARIO varchar(50) not null,
CONTRASEÑA varchar(20) not null
)
