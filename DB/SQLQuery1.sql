create database InLock_Games_Tarde
go

use InLock_Games_Tarde
go

create table Estudios (
	IdEstudio int primary key identity,
	NomeEstudio varchar(200) not null unique
	);
go

create table Jogos (
	IdJogo int primary key identity,
	NomeJogo varchar (255) not null unique,
	Descricao varchar (255) not null,
	DataLancamento Date not null,
	Valor decimal not null,
	IdEstudio int not null foreign key references Estudios (IdEstudio)
	);
go

create table TipoUsuario (
	IdTipoUsuario int primary key identity,
	Titulo varchar(100) not null unique
	);
go

create table Usuarios (
	IdUsuario int primary key identity,
	Email varchar (200) not null unique,
	Senha varchar (20) not null,
	IdTipoUsuario int not null foreign key references TipoUsuario (IdTipoUsuario)
	);
go



insert into TipoUsuario
values ('Administrador'),
		('Cliente')

insert into Usuarios
values ('admin@admin.com','admin','1'),
		('cliente@cliente.com','cliente','2')

insert into Estudios 
values ('Blizzard'),
		('Rockstar Studios'),
		('Square Enix')




