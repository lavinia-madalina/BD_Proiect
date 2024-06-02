CREATE TABLE Utilizatori
(
    idUtilizator NUMBER PRIMARY KEY,
    nume VARCHAR2(10),
    prenume VARCHAR2(10),
    email VARCHAR2(10) CONSTRAINT ck_email_utilizatori CHECK (email LIKE '%@%'),
    dataNasterii DATE,
    inaltime CHAR(3),
    numarKG INTEGER,
    indexMasaMusculara CHAR(2)
);

CREATE SEQUENCE seq_Utilizatori
    START WITH 1
    INCREMENT BY 1
    NOMAXVALUE;

CREATE OR REPLACE TRIGGER trg_utilizatori_id
BEFORE INSERT ON Utilizatori
FOR EACH ROW
BEGIN
    :NEW.idUtilizator := seq_Utilizatori.NEXTVAL;
END;
/
