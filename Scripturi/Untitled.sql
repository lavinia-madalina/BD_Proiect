CREATE TABLE `Utilizatori` (
  `idUtilizator` NUMBER(3),
  `nume` VARCHAR2(10),
  `prenume` VARCHAR2(10),
  `email` VARCHAR2(10),
  `varsta` NUMBER(2),
  `dataNasterii` DATE,
  `inaltime` CHAR(3),
  `numarKG` INTEGER,
  `indexMasaMusculara` Number(4,2)
);

CREATE TABLE `ObiectiveUtilizator` (
  `idUtilizator` NUMBER(3),
  `tipObiectiv` VARCHAR2(20),
  `descriere` VARCHAR(30),
  `dataStart` DATE,
  `dataEnd` DATE
);

CREATE TABLE `JurnalActivitati` (
  `idInregistrare` NUMBER(3),
  `data` DATE,
  `durataActivitate` INTEGER,
  `distanta` NUMBER(4,2),
  `caloriiArse` CHAR(4),
  `bonus` INTEGER
);

CREATE TABLE `Activitati` (
  `idActivitate` NUMBER(2),
  `nume` VARCHAR2(10),
  `prenume` VARCHAR2(10),
  `numeActivitate` VARCHAR(15),
  `descriereActivitate` VARCHAR(30),
  `durataActivitate` INTEGER
);

ALTER TABLE `Utilizatori` ADD FOREIGN KEY (`idUtilizator`) REFERENCES `ObiectiveUtilizator` (`idUtilizator`);

ALTER TABLE `Utilizatori` ADD FOREIGN KEY (`nume`) REFERENCES `Activitati` (`nume`);

ALTER TABLE `Utilizatori` ADD FOREIGN KEY (`prenume`) REFERENCES `Activitati` (`prenume`);

ALTER TABLE `Activitati` ADD FOREIGN KEY (`durataActivitate`) REFERENCES `JurnalActivitati` (`durataActivitate`);
