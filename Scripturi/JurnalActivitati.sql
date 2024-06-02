CREATE TABLE JurnalActivitati
(
    idInregistrare NUMBER(3),
    data DATE,
    durataActivitate INTEGER NOT NULL,
    distanta NUMBER(4,2),
    caloriiArse CHAR(4),
    bonus VARCHAR2(10),
    email VARCHAR2(10)
);