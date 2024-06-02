CREATE TABLE Utilizatori
(
idUtilizator NUMBER(3) NOT NULL PRIMARY KEY, 
nume VARCHAR2(10),
prenume VARCHAR2(10),
email VARCHAR2(10) CONSTRAINT ck_email_utilizatori CHECK (email LIKE '%@%'),
dataNasterii DATE,
inaltime CHAR(3),
numarKG INTEGER,
indexMasaMusculara CHAR(2)
);

CREATE TABLE ObiectiveUtilizator
(
idUtilizator NUMBER(3) CONSTRAINT fk_idUtilizator_utilizatori REFERENCES  Utilizatori(idUtilizator), 
tipObiectiv VARCHAR2(20),
descriere VARCHAR(30),
dataStart DATE,
dataEnd DATE
);

CREATE TABLE JurnalActivitati
(
idInregistrare NUMBER(3), 
data DATE,
durataActivitate INTEGER NOT NULL,
distanta NUMBER(4,2),
caloriiArse CHAR(4),
bonus VARCHAR2(10)
);

CREATE TABLE Activitati
(
idActivitate NUMBER(2),
numeActivitate VARCHAR(15),
descriereActivitate VARCHAR(30),
durataActivitate INTEGER NOT NULL
);