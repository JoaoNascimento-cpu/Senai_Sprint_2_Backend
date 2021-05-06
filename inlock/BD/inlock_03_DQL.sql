USE inlock_games_tarde;

SELECT * FROM Estudios;

SELECT * FROM Jogos;

SELECT * FROM TipoUsuario;

SELECT * FROM Usuarios;

SELECT nomeJogo, nomeEstudio FROM Jogos
INNER JOIN Estudios
ON Jogos.idEstudio = Estudios.idEstudio;

SELECT  Estudios.nomeEstudio, Jogos.nomeJogo FROM Estudios
LEFT JOIN Jogos
ON Estudios.idEstudio = Jogos.idJogo

SELECT Jogos.idJogo, Jogos.nomeJogo FROM Jogos

SELECT Estudios.idEstudio, Estudios.nomeEstudio FROM Estudios

SELECT Usuarios.email, Usuarios.senha FROM Usuarios

