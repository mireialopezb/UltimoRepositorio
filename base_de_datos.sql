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

CREATE TABLE partida (
    ID_partida INT NOT NULL,
    fecha VARCHAR(30),
    hora VARCHAR(30),
    duracion INT NOT NULL,
    ID_ganador INT NOT NULL,
    num_jugadores INT NOT NULL,
    PRIMARY KEY (ID_partida)

)ENGINE=InnoDB;

INSERT INTO partida VALUES (1, '29/09/2020', '17:43', 1, 3,2);
INSERT INTO partida VALUES (2, '02/10/2020','12:11', 9,1,2);
INSERT INTO partida VALUES (3, '07/10/2020','20:58', 15, 2,2);
INSERT INTO partida VALUES (4, '12/10/2020','14:24', 9, 4,2);
INSERT INTO partida VALUES (5, '13/10/2020','16:24', 9, 3,3);
INSERT INTO partida VALUES (6, '14/10/2020','18:24', 9, 1,4);

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

INSERT INTO registro VALUES (4,3,8);
INSERT INTO registro VALUES (4,4,9);

INSERT INTO registro VALUES (5,3,10);
INSERT INTO registro VALUES (5,4,3);
INSERT INTO registro VALUES (5,2,7);

INSERT INTO registro VALUES (6,3,6);
INSERT INTO registro VALUES (6,4,3);
INSERT INTO registro VALUES (6,2,13);
INSERT INTO registro VALUES (6,1,1);

