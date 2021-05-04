--Criação do Banco de dados Clínica
CREATE DATABASE Clinica
--Usando o banco de dados
USE Clinica;
GO
--A função GO tem a mesma função que o F5(de iniciar ou começar a criação de tudo que está acima dele)

--Criação da tabela "tipoUsuario" 
CREATE TABLE tipoUsuario
(
	idTipoUsuario INT PRIMARY KEY IDENTITY,
	tituloTipoUsuario VARCHAR(20) NOT NULL,
);
GO
--Criação da tabela "especialidade"
CREATE TABLE especialidade
(
	idEspecialidade INT PRIMARY KEY IDENTITY,
	nomeEspecialidade VARCHAR(255) NOT NULL,
);
GO
--Criação da tabela "usuario"
CREATE TABLE usuario
(
	idUsuario INT PRIMARY KEY IDENTITY,
	idTipoUsuario INT FOREIGN KEY REFERENCES tipoUsuario(idTipoUsuario),
	email VARCHAR(100) UNIQUE NOT NULL,
	senha VARCHAR(18) NOT NULL,
);
GO

--Criação da tabela "usuario"
CREATE TABLE situacao
(
	idSituacao INT PRIMARY KEY IDENTITY,
	situacaoNome VARCHAR(100) UNIQUE NOT NULL,
);
GO
--Criação da tabela "clinica"
CREATE TABLE clinica
(
	idClinica INT PRIMARY KEY IDENTITY,
	cnpj VARCHAR(18) UNIQUE NOT NULL,--a função 'UNIQUE' é usada para que n haja nenhum valor semelhante a ela
	endereco VARCHAR(300) NOT NULL,
	nomeFantasia VARCHAR(255) NOT NULL,
	razaoSocial VARCHAR(255) NOT NULL,
);
GO
--Criação da tabela "medico"
CREATE TABLE medico
(
	idMedico INT PRIMARY KEY IDENTITY,
	idUsuario INT FOREIGN KEY REFERENCES usuario(idUsuario),
	idEspecialidade INT FOREIGN KEY REFERENCES especialidade(idEspecialidade),
	idClinica INT FOREIGN KEY REFERENCES clinica(idClinica),
	crm VARCHAR(9) UNIQUE NOT NULL,
	nomeMedico VARCHAR(255) NOT NULL,
);
GO
--Criação da tabela "paciente"
CREATE TABLE paciente
(
	idPaciente INT PRIMARY KEY IDENTITY,
	idUsuario INT FOREIGN KEY REFERENCES usuario(idUsuario),
	rg VARCHAR(12) UNIQUE NOT NULL,
	cpf VARCHAR(15) UNIQUE NOT NULL,
	telefone VARCHAR(9) UNIQUE NOT NULL,
);
GO
--Criação da tabela "consulta"
CREATE TABLE consulta
(
	idConsulta INT PRIMARY KEY IDENTITY,
	idMedico INT FOREIGN KEY REFERENCES medico(idMedico),
	idPaciente INT FOREIGN KEY REFERENCES paciente(idPaciente),
	idSituacao INT FOREIGN KEY REFERENCES situacao(idSituacao),
	dataConsulta DATETIME NOT NULL,
	descricao VARCHAR(255) NOT NULL,
);
GO