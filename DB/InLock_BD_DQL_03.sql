USE InLock_Games_Tarde; 

SELECT * FROM Usuarios

SELECT * FROM Estudios

SELECT * FROM Jogos



select Jogos.NomeJogo, Estudios.NomeEstudio
from Jogos
right outer join Estudios on Estudios.IdEstudio = Jogos.IdEstudio
