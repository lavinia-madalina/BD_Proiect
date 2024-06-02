using System.Collections.Generic;
using System.Data;

using LibrarieModele;

using Oracle.DataAccess.Client;

namespace NivelAccesDate
{
    public class AdministrareJurnalActivitati: IStocareJurnalActivitati
    {
        private const int PRIMUL_TABEL = 0;
        private const int PRIMA_LINIE = 0;

        public List<JurnalActivitate> GetJurnaleActivitati()
        {
            var result = new List<JurnalActivitate>();
            var dsJurnale = SqlDBHelper.ExecuteDataSet("select * from JurnalActivitati", CommandType.Text);

            foreach (DataRow linieDB in dsJurnale.Tables[PRIMUL_TABEL].Rows)
            {
                result.Add(new JurnalActivitate(linieDB));
            }
            return result;
        }

        public JurnalActivitate GetJurnalActivitate(int idInregistrare)
        {
            JurnalActivitate result = null;
            var dsJurnale = SqlDBHelper.ExecuteDataSet("select * from JurnalActivitati where idInregistrare = :idInregistrare", CommandType.Text,
                new OracleParameter(":idInregistrare", OracleDbType.Int32, idInregistrare, ParameterDirection.Input));

            if (dsJurnale.Tables[PRIMUL_TABEL].Rows.Count > 0)
            {
                DataRow linieDB = dsJurnale.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new JurnalActivitate(linieDB);
            }
            return result;
        }

        public bool AddJurnalActivitate(JurnalActivitate jurnal)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "INSERT INTO JurnalActivitati (idInregistrare, data, durataActivitate, distanta, caloriiArse, bonus, email) VALUES (seq_JurnalActivitati.nextval, :data, :durataActivitate, :distanta, :caloriiArse, :bonus, :email)", CommandType.Text,
                new OracleParameter(":data", OracleDbType.Date, jurnal.Data, ParameterDirection.Input),
                new OracleParameter(":durataActivitate", OracleDbType.Int32, jurnal.DurataActivitate, ParameterDirection.Input),
                new OracleParameter(":distanta", OracleDbType.Decimal, jurnal.Distanta, ParameterDirection.Input),
                new OracleParameter(":caloriiArse", OracleDbType.Int32, jurnal.CaloriiArse, ParameterDirection.Input),
                new OracleParameter(":bonus", OracleDbType.Int32, jurnal.Bonus, ParameterDirection.Input),
                new OracleParameter(":email", OracleDbType.Varchar2, jurnal.Email, ParameterDirection.Input));
        }



        public bool UpdateJurnalActivitate(JurnalActivitate jurnal)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "UPDATE JurnalActivitati SET data = :data, durataActivitate = :durataActivitate, distanta = :distanta, caloriiArse = :caloriiArse, bonus = :bonus, email = :email WHERE idInregistrare = :idInregistrare", CommandType.Text,
                new OracleParameter(":data", OracleDbType.Date, jurnal.Data, ParameterDirection.Input),
                new OracleParameter(":durataActivitate", OracleDbType.Int32, jurnal.DurataActivitate, ParameterDirection.Input),
                new OracleParameter(":distanta", OracleDbType.Decimal, jurnal.Distanta, ParameterDirection.Input),
                new OracleParameter(":caloriiArse", OracleDbType.Int32, jurnal.CaloriiArse, ParameterDirection.Input),
                new OracleParameter(":bonus", OracleDbType.Int32, jurnal.Bonus, ParameterDirection.Input),
                new OracleParameter(":email", OracleDbType.Varchar2, jurnal.Email, ParameterDirection.Input),
                new OracleParameter(":idInregistrare", OracleDbType.Int32, jurnal.IdInregistrare, ParameterDirection.Input));
        }

    }
}
