DROP DATABASE IF EXISTS juego;
CREATE DATABASE juego;

USE juego;

CREATE TABLE jugador (
    ID_jugador INT NOT NULL,
    nombre VARCHAR(20),
    contraseña VARCHAR(20),
    PRIMARY KEY (ID_jugador)

)ENGINE=InnoDB;

INSERT INTO jugador VALUES (1,'Izan', 'hola');
INSERT INTO jugador VALUES (2,'Mireia', 'quetal');
INSERT INTO jugador VALUES (3,'Gabriel', 'adios');
INSERT INTO jugador VALUES (4,'Antonia', 'profesora');
INSERT INTO jugador VALUES (5,'Izan2', 'hola');

CREATE TABLE partida (
    ID_partida INT NOT NULL,
    fecha VARCHAR(30),
    hora VARCHAR(30),
    duracion INT NOT NULL,
    ID_ganador INT NOT NULL,
    PRIMARY KEY (ID_partida)

)ENGINE=InnoDB;

INSERT INTO partida VALUES (1, '29/09/2020', '17:43', 6, 3);
INSERT INTO partida VALUES (2, '2/10/2020','12:11', 1,1);
INSERT INTO partida VALUES (3, '7/10/2020','20:58', 15, 2);
INSERT INTO partida VALUES (4, '12/10/2020','16:24', 9, 4);

CREATE TABLE personaje(
    ID_personaje INT NOT NULL,
    nombre_personaje VARCHAR (30),
    PRIMARY KEY (ID_personaje)

)ENGINE=InnoDB;

INSERT INTO personaje VALUES (0,'0');
INSERT INTO personaje VALUES (1,'Emma');
INSERT INTO personaje VALUES (2,'Antonia');
INSERT INTO personaje VALUES (3,'Javi');
INSERT INTO personaje VALUES (4,'Cristina R.');
INSERT INTO personaje VALUES (5,'Julen');
INSERT INTO personaje VALUES (6,'Arnau');
INSERT INTO personaje VALUES (7,'Víctor');
INSERT INTO personaje VALUES (8,'Mireia');
INSERT INTO personaje VALUES (9,'David');
INSERT INTO personaje VALUES (10,'Gabri');
INSERT INTO personaje VALUES (11,'Andrea');
INSERT INTO personaje VALUES (12,'Enric');
INSERT INTO personaje VALUES (13,'Izan');
INSERT INTO personaje VALUES (14,'Angela');
INSERT INTO personaje VALUES (15,'Crisrina B.');

CREATE TABLE registro(
    ID_partida INT NOT NULL,
    ID_jugador INT NOT NULL,
    ID_personaje INT NOT NULL, 
    FOREIGN KEY (ID_partida) REFERENCES partida(ID_partida),
    FOREIGN KEY (ID_jugador) REFERENCES jugador(ID_jugador),
    FOREIGN KEY (ID_personaje) REFERENCES personaje(ID_personaje)
    
)ENGINE=InnoDB;

INSERT INTO registro VALUES (1,3,4);
INSERT INTO registro VALUES (1,1,3);

INSERT INTO registro VALUES (2,1,1);
INSERT INTO registro VALUES (2,4,2);

INSERT INTO registro VALUES (3,2,4);
INSERT INTO registro VALUES (3,1,3);


INSERT INTO registro VALUES (4,3,4);
INSERT INTO registro VALUES (4,4,3);
/*
SELECT personaje.nombre_personaje FROM (partida, personaje, registro) 
WHERE partida.ID_partida = 2
AND partida.ID_partida = registro.ID_partida
AND registro.ID_personaje1 = personaje.ID_personaje;

SELECT personaje.nombre_personaje FROM (partida, personaje, registro) 
WHERE partida.ID_partida = 2
AND partida.ID_partida = registro.ID_partida
AND registro.ID_personaje2 = personaje.ID_personaje;


SELECT registro.ID_jugador, partida.ID_ganador FROM (registro, partida) WHERE partida.ID_partida IN (SELECT registro.ID_partida FROM registro WHERE registro.ID_jugador = 1) AND partida.ID_partida = registro.ID_partida; 

SELECT jugador.nombre FROM jugador WHERE jugador.ID_jugador = 1;

SELECT partida.ID_partida, partida.hora FROM partida WHERE partida.fecha = '29/09/2020';

SELECT * from partida;

SELECT nombre FROM jugador WHERE ID_jugador = 1;

SELECT * FROM jugador;

DELETE FROM jugador WHERE (jugador.nombre= 'Izan2' AND jugador.contraseña = 'hola');

SELECT * FROM jugador;

INSERT INTO partida VALUES (5,'12/10/2020','16:24',9,1)*/

SELECT registro.ID_partida, partida.ID_ganador FROM (registro, partida) WHERE partida.ID_partida IN (SELECT registro.ID_partida FROM registro WHERE registro.ID_jugador = 1) AND partida.ID_partida = registro.ID_partida AND registro.ID_jugador =4; 


SELECT registro.ID_partida, jugador.nombre, registro.ID_jugador, partida.ID_ganador FROM (registro,jugador,partida) WHERE partida.ID_partida BETWEEN (SELECT partida.ID_partida FROM partida WHERE partida.fecha = '%s') AND (SELECT partida.ID_partida FROM partida WHERE partida.fecha = '%s') AND partida.ID_partida = registro.ID_partida AND registro.ID_jugador=jugador.ID_jugador;

SELECT jugador.nombre FROM jugador,partida WHERE jugador.ID_jugador = (SELECT partida.ID_ganador FROM partida WHERE partida.duracion=(SELECT MIN(partida.duracion) FROM partida)) AND partida.ID_ganador=jugador.ID_jugador ;

SELECT jugador.nombre FROM (jugador,registro,partida) WHERE partida.ID_ganador = (SELECT partida.ID_ganador FROM partida WHERE partida.duracion = (SELECT MIN(partida.duracion) FROM partida ) ) AND partida.ID_partida=registro.ID_partida AND registro.ID_jugador=jugador.ID_jugador AND partida.ID_ganador=jugador.ID_jugador;


