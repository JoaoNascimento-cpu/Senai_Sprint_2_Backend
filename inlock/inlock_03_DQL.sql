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
