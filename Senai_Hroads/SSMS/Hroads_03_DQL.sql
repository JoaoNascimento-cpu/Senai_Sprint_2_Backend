USE Senai_Hroads_Tarde

SELECT * FROM Personagens;

SELECT * FROM Classes;

SELECT NomeClasse
FROM Classes;

SELECT * FROM Habilidades;

SELECT COUNT(*) Habilidades
FROM Habilidades;

SELECT Habilidades.idHabilidade, Habilidades.NomeHabilidade
FROM   Habilidades;

SELECT TiposHabilidades.Tipo
FROM   TiposHabilidades;

SELECT Habilidades.NomeHabilidade, TiposHabilidades.Tipo 
FROM   Habilidades
LEFT JOIN  TiposHabilidades
ON Habilidades.idHabilidade = TiposHabilidades.idTiposHabilidades;

SELECT Personagens.Nome, Classes.NomeClasse
FROM	Personagens
RIGHT JOIN Classes
ON Personagens.idPersonagem = Classes.idClasses

SELECT Classes.NomeClasse, Habilidades.NomeHabilidade
FROM	Classes
LEFT JOIN Habilidades
ON Classes.idClasses = Habilidades.idHabilidade

SELECT Classes.NomeClasse, Habilidades.NomeHabilidade
FROM	Habilidades
RIGHT JOIN Classes
ON Classes.idClasses = Habilidades.idHabilidade

SELECT * FROM  TiposUsuarios;

SELECT * FROM Usuarios;