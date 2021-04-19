USE inlock_games_tarde;

INSERT INTO Estudios(nomeEstudio)
VALUES	('Blizzard'),
		('Rockstar Studios'),
		('Square Enix');
GO

INSERT INTO Jogos(idEstudio, nomeJogo, descricao, dataDeLancamento, valor)
VALUES	(1,'Diablo 3', 'É um jogo que contém bastante ação e é viciante, seja você um novato ou um fã.', '2012-05-15',  99.00),	
		(2,'Red Dead Redemption II', 'Jogo eletrônico de ação-aventura western.', '2018-10-26', 120.00);
GO

INSERT INTO	TipoUsuario(titulo)
VALUES	('Administrador'),
		('Cliente');
GO

INSERT INTO Usuarios(idTipoUsuario, email, senha)
VALUES	(1, 'admin@admin.com', 'admin'),
		(2, 'cliente@cliente.com', 'cliente');
