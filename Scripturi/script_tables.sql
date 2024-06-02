CREATE TABLE Utilizatori (
    idUtilizator NUMBER(3) NOT NULL PRIMARY KEY, 
    nume VARCHAR2(10),
    prenume VARCHAR2(10),
    email VARCHAR2(50) CONSTRAINT ck_email_utilizatori CHECK (email LIKE '%@%'),
    varsta NUMBER(2),
    dataNasterii DATE,
    inaltime CHAR(3),
    numarKG INTEGER,
    indexMasaMusculara INTEGER
);

CREATE TABLE ObiectiveUtilizator (
    idUtilizator NUMBER(3) CONSTRAINT fk_idUtilizator_utilizatori REFERENCES Utilizatori(idUtilizator),
    tipObiectiv VARCHAR2(20),
    descriere VARCHAR2(30),
    dataStart DATE,
    dataEnd DATE,
    PRIMARY KEY (idUtilizator, tipObiectiv)
);

CREATE TABLE JurnalActivitati (
    idInregistrare NUMBER(3) PRIMARY KEY, 
    data DATE,
    durataActivitate INTEGER NOT NULL,
    distanta NUMBER(4,2),
    caloriiArse INTEGER,
    bonus INTEGER
);

CREATE TABLE Activitati (
    idActivitate NUMBER(3) CONSTRAINT fk_idActivitate_jurnal REFERENCES JurnalActivitati(idInregistrare),
    nume VARCHAR2(10),
    prenume VARCHAR2(10),
    numeActivitate VARCHAR2(15),
    descriereActivitate VARCHAR2(30),
    durataActivitate INTEGER NOT NULL,
    PRIMARY KEY (idActivitate)
);