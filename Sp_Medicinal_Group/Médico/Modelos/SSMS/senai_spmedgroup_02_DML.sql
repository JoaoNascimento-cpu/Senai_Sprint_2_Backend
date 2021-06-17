--Criação do DML do banco de dados 'Clinica'
USE Clinica;
GO

--inserindo valores 'idClinica, nome fantasia, razão social, cnpj e endereço na tabela Clinica 
INSERT INTO clinica(nomeFantasia, razaoSocial, cnpj, endereco)
VALUES ('Clinica Possarle', 'SP Medicinal Group ', '84.400.902/0001-30', 'Al Barão de Limeira, 532, SP');
GO

--incersão de valores na tabela tipoUsuario como id do Tipo do Usuario e titulo deste mesmo id
INSERT INTO tipoUsuario(tituloTipoUsuario)
VALUES	('ADM'),
		('Médico'),
		('Paciente');
GO

--Incersão de valores na tabela Usuario
INSERT INTO usuario(idTipoUsuario, email, senha)
VALUES	(1,'ADM@spmedicinalgroup.com','12345'),
		(2,'Ricardo.Lemos@spmedicalgroup.com','12345'),
		(2,'Helena.souza@spmedicalgroup.com','12345'),
		(3,'joão@gmail.com','12345'),
		(3,'Mateus@gmail.com','12345');
GO

--Inserção de valores da 'tabela paciente'
INSERT INTO paciente(idUsuario,rg, cpf, telefone)
VALUES	(4,'00.658.000-8', '000.000.000-00', '123456789'), 
		(5,'00.000.000-0 ', '000.000.000-10', '987654321');
GO

--Inserção de valores da tabela 'Situação' da consulta
INSERT INTO situacao(situacaoNome)
VALUES	('Agendado'),
		('Confirmado'),
		('Cancelado');
GO

--Inserção de valores na tebela 'especialidade'
INSERT INTO especialidade(nomeEspecialidade)
VALUES	('Acupuntura'),
		('Anestesiologia '),
		('Angiologia'),
		('Cardiologia'),
		('Cirurgia Cardiovascular'),
		('Cirurgia da Mão'),
		('Cirurgia do Aparelho Digestivo'),
		('Cirurgia Geral'),
		('Cirurgia Pediátrica'),
		('Cirurgia Plástica'),
		('Cirurgia Torácica'),
		('Cirurgia Vascular'),
		('Dermatologia'),
		('Radioterapia'),
		('Urologia'),
		('Pediatria'),
		('Psiquiatria');
GO

--Inserção de valores na tabela 'médico'
INSERT INTO medico(idUsuario, idEspecialidade, idClinica, crm, nomeMedico)
VALUES	(2, 17, 1,'54356-SP', 'Ricardo Lemos'),
		(3, 16, 1,'53452-SP', 'Helena Strada');
GO

--Inserção de valores na table 'consulta'
INSERT INTO consulta(idMedico, idPaciente, idSituacao, dataConsulta, descricao)
VALUES	(1, 2, 2, 2021-03-11 19:00:00, 'Tratamento de gonorréia'),
		(2, 1, 1, 2021-03-13 16:00:00, 'Tratamento de gripe'),
		(1, 2, 3, 2021-03-12 17:00:00, 'Tratamento na coluna ');
GO 