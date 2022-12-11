CREATE DATABASE Formula1;
USE Formula1;
CREATE TABLE Pilotos(
ID INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
Nome VARCHAR(255),
Nacionalidade VARCHAR(255),
Equipe VARCHAR(255),
UltimaVitoria DateTime
);

select * from Pilotos;