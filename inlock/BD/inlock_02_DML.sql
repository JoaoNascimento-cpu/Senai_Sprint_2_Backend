USE inlock_games_tarde;

INSERT INTO Estudios(nomeEstudio)
VALUES	('Blizzard'),
		('Rockstar Studios'),
		('Square Enix');
GO

INSERT INTO Jogos(idEstudio, nomeJogo, descricao, dataDeLancamento, valor)
VALUES	(1,'Diablo 3', '� um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�.', '2012-05-15',  99.00),	
		(2,'Red Dead Redemption II', 'Jogo eletr�nico de a��o-aventura western.', '2018-10-26', 120.00);
GO

INSERT INTO	TipoUsuario(titulo)
VALUES	('Administrador'),
		('Cliente');
GO

INSERT INTO Usuarios(idTipoUsuario, email, senha)
VALUES	(1, 'admin@admin.com', 'admin'),
		(2, 'cliente@cliente.com', 'cliente');
