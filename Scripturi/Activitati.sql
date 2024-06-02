CREATE TABLE Activitati
(
    idActivitate NUMBER PRIMARY KEY,
    numeActivitate VARCHAR2(15),
    descriereActivitate VARCHAR2(30),
    durataActivitate INTEGER NOT NULL
);

CREATE SEQUENCE seq_Activitati
    START WITH 1
    INCREMENT BY 1
    NOMAXVALUE;

CREATE OR REPLACE TRIGGER trg_activitati_id
BEFORE INSERT ON Activitati
FOR EACH ROW
BEGIN
    :NEW.idActivitate := seq_Activitati.NEXTVAL;
END;
/
