USE Senai_Hroads_Tarde;

CREATE DATABASE Senai_Hroads_Tarde;

CREATE TABLE Classes
(
	idClasses INT PRIMARY KEY IDENTITY,
	NomeClasse VARCHAR(50) NOT NULL,
);
CREATE TABLE TiposHabilidades
(
	idTiposHabilidades INT PRIMARY KEY IDENTITY,
	Tipo VARCHAR(200) NOT NULL,
); 
CREATE TABLE Habilidades
(
	idHabilidade INT PRIMARY KEY IDENTITY,
	NomeHabilidade VARCHAR(30) NOT NULL,
	idTiposHabilidades INT FOREIGN KEY REFERENCES TiposHabilidades(idTiposHabilidades),
);
CREATE TABLE ClassesHabilidades
(
	idClasses INT FOREIGN KEY REFERENCES Classes(idClasses),
	idHabilidades INT FOREIGN KEY REFERENCES Habilidades(idHabilidade)
);
CREATE TABLE Personagens
(
	idPersonagem INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(255) NOT NULL,
	idClasse INT FOREIGN KEY REFERENCES Classes(idClasses),
	PvMaximo INT,
	ManaMaxima INT,
	DataAtt VARCHAR(20) NOT NULL,
	DataCr VARCHAR(20) NOT NULL,
);

CREATE TABLE TiposUsuarios
(
	idTiposusuarios INT PRIMARY KEY IDENTITY,
	titulo TEXT,
);

CREATE TABLE Usuarios
(
	idUsuario	INT PRIMARY KEY IDENTITY,
	email VARCHAR(150) UNIQUE NOT NULL,
	senha VARCHAR(50) NOT NULL,
	idTiposUsuarios INT FOREIGN KEY REFERENCES TiposUsuarios(idTiposUsuarios),
);