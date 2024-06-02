using System.Collections.Generic;
using System.Data;

using LibrarieModele;

using Oracle.DataAccess.Client;

namespace NivelAccesDate
{
    public class AdministrareActivitati : IStocareActivitati
    {
        private const int PRIMUL_TABEL = 0;
        private const int PRIMA_LINIE = 0;

        public List<Activitate> GetActivitati()
        {
            var result = new List<Activitate>();
            var dsActivitati = SqlDBHelper.ExecuteDataSet("select * from Activitati", CommandType.Text);

            foreach (DataRow linieDB in dsActivitati.Tables[PRIMUL_TABEL].Rows)
            {
                result.Add(new Activitate(linieDB));
            }
            return result;
        }

        public Activitate GetActivitate(int idActivitate)
        {
            Activitate result = null;
            var dsActivitati = SqlDBHelper.ExecuteDataSet(
                "select * from Activitati where idActivitate = :idActivitate",
                CommandType.Text,
                new OracleParameter(":idActivitate", OracleDbType.Int32, idActivitate, ParameterDirection.Input));

            if (dsActivitati.Tables[PRIMUL_TABEL].Rows.Count > 0)
            {
                DataRow linieDB = dsActivitati.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new Activitate(linieDB);
            }
            return result;
        }

        public bool AddActivitate(Activitate activitate)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "INSERT INTO Activitati (idActivitate, numeActivitate, descriereActivitate, durataActivitate) VALUES (seq_Activitati.NEXTVAL,:numeActivitate, :descriereActivitate, :durataActivitate)",
                CommandType.Text,
                new OracleParameter(":numeActivitate", OracleDbType.Varchar2, activitate.NumeActivitate, ParameterDirection.Input),
                new OracleParameter(":descriereActivitate", OracleDbType.Varchar2, activitate.DescriereActivitate, ParameterDirection.Input),
                new OracleParameter(":durataActivitate", OracleDbType.Int32, activitate.DurataActivitate, ParameterDirection.Input));
        }


        public bool UpdateActivitate(Activitate activitate)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "UPDATE Activitati SET numeActivitate = :numeActivitate, descriereActivitate = :descriereActivitate, durataActivitate = :durataActivitate WHERE idActivitate = :idActivitate",
                CommandType.Text,
                new OracleParameter(":numeActivitate", OracleDbType.Varchar2, activitate.NumeActivitate, ParameterDirection.Input),
                new OracleParameter(":descriereActivitate", OracleDbType.Varchar2, activitate.DescriereActivitate, ParameterDirection.Input),
                new OracleParameter(":durataActivitate", OracleDbType.Int32, activitate.DurataActivitate, ParameterDirection.Input));
             //new OracleParameter(":idActivitate", OracleDbType.Int32, activitate.IdActivitate, ParameterDirection.Input));
        }

        public bool DeleteActivitateByNume(string numeActivitate)
        {
            // Executăm interogarea SQL pentru a șterge activitatea cu numele specificat
            return SqlDBHelper.ExecuteNonQuery(
                "DELETE FROM Activitati WHERE numeActivitate = :numeActivitate",
                CommandType.Text,
                new OracleParameter(":numeActivitate", OracleDbType.Varchar2, numeActivitate, ParameterDirection.Input)
            );
        }

    }
}
