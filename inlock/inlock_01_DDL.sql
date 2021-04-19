CREATE DATABASE inlock_games_tarde;

USE inlock_games_tarde;

CREATE TABLE Estudios
(
	idEstudio INT PRIMARY KEY IDENTITY,
	nomeEstudio VARCHAR(255),
);
GO

CREATE TABLE Jogos
(
	idJogo INT PRIMARY KEY IDENTITY,
	nomeJogo VARCHAR(255),
	descricao VARCHAR(255) NOT NULL,
	dataDeLancamento DATE,
	valor MONEY NOT NULL,
	idEstudio INT FOREIGN KEY REFERENCES Estudios(idEstudio),
);
GO

CREATE TABLE TipoUsuario
(
	idTipoUsuario INT PRIMARY KEY IDENTITY,
	titulo VARCHAR(255) NOT NULL,
);
GO

CREATE TABLE Usuarios
(
	 idUsuario INT PRIMARY KEY IDENTITY,
	 email VARCHAR(255) NOT NULL,
	 senha VARCHAR(255) NOT NULL,
	 idTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario(idTipoUsuario),
);