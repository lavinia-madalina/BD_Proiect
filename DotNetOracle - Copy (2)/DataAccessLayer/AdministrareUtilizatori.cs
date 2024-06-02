using System;
using System.Collections.Generic;
using System.Data;

using LibrarieModele;

using Oracle.DataAccess.Client;

namespace NivelAccesDate
{
    public class AdministrareUtilizatori : IStocareUtilizatori
    {
        private const int PRIMUL_TABEL = 0;
        private const int PRIMA_LINIE = 0;

        public List<Utilizator> GetUtilizatori()
        {
            var result = new List<Utilizator>();
            var dsUtilizatori = SqlDBHelper.ExecuteDataSet("select * from Utilizatori", CommandType.Text);

            foreach (DataRow linieDB in dsUtilizatori.Tables[PRIMUL_TABEL].Rows)
            {
                result.Add(new Utilizator(linieDB));
            }
            return result;
        }

        public Utilizator GetUtilizator(int id)
        {
            Utilizator result = null;
            var dsUtilizatori = SqlDBHelper.ExecuteDataSet(
                "select * from Utilizatori where idUtilizator = :idUtilizator",
                CommandType.Text,
                new OracleParameter(":idUtilizator", OracleDbType.Int32, id, ParameterDirection.Input));

            if (dsUtilizatori.Tables[PRIMUL_TABEL].Rows.Count > 0)
            {
                DataRow linieDB = dsUtilizatori.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new Utilizator(linieDB);
            }
            return result;
        }

        public bool AddUtilizator(Utilizator utilizator)
        {
            
                Console.WriteLine("Adding user with the following parameters:");
                Console.WriteLine($"Nume: {utilizator.Nume}");
                Console.WriteLine($"Prenume: {utilizator.Prenume}");
                Console.WriteLine($"Email: {utilizator.Email}");
                Console.WriteLine($"DataNasterii: {utilizator.DataNasterii}");
                Console.WriteLine($"Inaltime: {utilizator.Inaltime}");
                Console.WriteLine($"NumarKG: {utilizator.NumarKG}");
                Console.WriteLine($"IndexMasaMusculara: {utilizator.IndexMasaMusculara}");

                // Execute the SQL query...
           

            return SqlDBHelper.ExecuteNonQuery(
                "INSERT INTO Utilizatori (idUtilizator, nume, prenume, email, dataNasterii, inaltime, numarKG, indexMasaMusculara) VALUES (seq_Utilizatori.nextval, :nume, :prenume, :email, :dataNasterii, :inaltime, :numarKG, :indexMasaMusculara)",
                CommandType.Text,
                new OracleParameter(":nume", OracleDbType.Varchar2, utilizator.Nume, ParameterDirection.Input),
                new OracleParameter(":prenume", OracleDbType.Varchar2, utilizator.Prenume, ParameterDirection.Input),
                new OracleParameter(":email", OracleDbType.Varchar2, utilizator.Email, ParameterDirection.Input),
                new OracleParameter(":dataNasterii", OracleDbType.Date, utilizator.DataNasterii, ParameterDirection.Input),
                new OracleParameter(":inaltime", OracleDbType.Char, utilizator.Inaltime, ParameterDirection.Input),
                new OracleParameter(":numarKG", OracleDbType.Int32, utilizator.NumarKG, ParameterDirection.Input),
                new OracleParameter(":indexMasaMusculara", OracleDbType.Int32, utilizator.IndexMasaMusculara, ParameterDirection.Input));
        }

        public bool UpdateUtilizator(Utilizator utilizator)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "UPDATE Utilizatori set nume = :nume, prenume = :prenume, email = :email, dataNasterii = :dataNasterii, inaltime = :inaltime, numarKG = :numarKG, indexMasaMusculara = :indexMasaMusculara where idUtilizator = :idUtilizator",
                CommandType.Text,
                new OracleParameter(":nume", OracleDbType.Varchar2, utilizator.Nume, ParameterDirection.Input),
                new OracleParameter(":prenume", OracleDbType.Varchar2, utilizator.Prenume, ParameterDirection.Input),
                new OracleParameter(":email", OracleDbType.Varchar2, utilizator.Email, ParameterDirection.Input),
                new OracleParameter(":dataNasterii", OracleDbType.Date, utilizator.DataNasterii, ParameterDirection.Input),
                new OracleParameter(":inaltime", OracleDbType.Char, utilizator.Inaltime, ParameterDirection.Input),
                new OracleParameter(":numarKG", OracleDbType.Int32, utilizator.NumarKG, ParameterDirection.Input),
                new OracleParameter(":indexMasaMusculara", OracleDbType.Int32, utilizator.IndexMasaMusculara, ParameterDirection.Input));
        }
        public bool DeleteUtilizatorByEmail(string email)
        {
            // Execute the SQL query to delete the user with the specified email
            return SqlDBHelper.ExecuteNonQuery(
                "DELETE FROM Utilizatori WHERE email = :email",
                CommandType.Text,
                new OracleParameter(":email", OracleDbType.Varchar2, email, ParameterDirection.Input)
            );
        }

    }
}
