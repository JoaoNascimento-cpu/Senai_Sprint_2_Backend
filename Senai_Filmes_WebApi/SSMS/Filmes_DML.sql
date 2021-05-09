USE Filmes;

--			Tabela	 Coluna
INSERT INTO Generos (Nome)
VALUES				('Ação')
				   ,('Romance');
GO

INSERT INTO Generos (Nome)
VALUES				('Aventura');
GO

INSERT INTO Filmes (Titulo, idGenero)
VALUES			   ('Rambo', 1)
				  ,('Vingadores', 1)
				  ,('Ghost', 2)
				  ,('Diário de uma paixão', 2);
GO

INSERT INTO Filmes (Titulo)
VALUES			   ('Homem-Aranha')
				  ,('Eu sou a Lenda');

GO

INSERT INTO Usuarios(email, senha, permissao)
VALUES				('joao@gmail.com','123','comum'),
					('adm@adm.com','1234','administrador')	
GO

UPDATE Generos
SET Nome = 'Romance'
WHERE idGenero = 2;

DELETE FROM Generos
WHERE idGenero = 3;