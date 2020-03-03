use InLock_Games_Tarde;
go

insert into TipoUsuario
values	('Administrador'),
		('Cliente');

insert into Usuarios
values	('admin@admin.com','admin','1'),
		('cliente@cliente.com','cliente','2');

insert into Estudios 
values	('Blizzard'),
		('Rockstar Studios'),
		('Square Enix');


insert into Jogos (NomeJogo, Descricao, DataLancamento, Valor, IdEstudio)
values	('Red Dead Redemption II', 'Jogo eletrônico de ação-aventura western', '2018-10-26', '120.00', '2')
