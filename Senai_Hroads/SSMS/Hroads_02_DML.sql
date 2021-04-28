USE Senai_Hroads_Tarde;

INSERT INTO Classes(NomeClasse)
VALUES				('Barbaro'),
					('Cruzado'),
					('Caçadora'),
					('Monge'),
					('Necromante'),
					('Feiticeiro'),
					('Arcanista');
INSERT INTO TiposHabilidades(Tipo)
VALUES		('Ataque'),
			('Defesa'),
			('Cura'),
			('Magia');

INSERT INTO Habilidades(idTiposHabilidades, NomeHabilidade)
VALUES		(1,'Lança Mortal'),
			(2,'Escudo Supremo'),
			(3,'Recuperar Vida');

INSERT INTO Personagens(idClasse, Nome, PvMaximo, ManaMaxima, DataAtt, DataCr)
VALUES		(1,'DeuBug', 100, 80, '2021-03-03', '2019-01-18'),
			(4,'BitBug', 70, 100, '2021-03-03', '2016-03-17'),
			(7,'Fer7',75, 60, '2021-03-03', '2018-03-18');

INSERT INTO TiposUsuarios(titulo)
VALUES		('ADM'),
			('Jogador');

INSERT INTO Usuarios(email, senha, idTiposUsuarios)
VALUES		('adm@adm.com', 'adm', 1),
			('cliente@cliente.com','cliente', 2);

UPDATE Personagens
SET		Nome = 'Fer8'
WHERE	idClasse = 7

UPDATE Classes
SET		NomeClasse = 'Necromancer'
WHERE		idClasses = 5
