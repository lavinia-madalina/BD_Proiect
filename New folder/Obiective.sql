CREATE TABLE ObiectiveUtilizator
(
    idObiectiv NUMBER PRIMARY KEY,
    idUtilizator NUMBER(3) CONSTRAINT fk_idUtilizator_utilizatori REFERENCES Utilizatori(idUtilizator),
    tipObiectiv VARCHAR2(50),
    descriere VARCHAR2(255),
    dataStart DATE,
    dataEnd DATE
);

CREATE SEQUENCE seq_ObiectiveUtilizator
    START WITH 1
    INCREMENT BY 1
    NOMAXVALUE;

CREATE OR REPLACE TRIGGER trg_ObiectiveUtilizator_id
BEFORE INSERT ON ObiectiveUtilizator
FOR EACH ROW
BEGIN
    :NEW.idObiectiv := seq_ObiectiveUtilizator.NEXTVAL;
END;
/
