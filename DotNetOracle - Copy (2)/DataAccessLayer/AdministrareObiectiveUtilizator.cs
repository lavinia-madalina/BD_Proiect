using System.Collections.Generic;
using System.Data;

using LibrarieModele;

using Oracle.DataAccess.Client;

namespace NivelAccesDate
{
    public class AdministrareObiectiveUtilizator : IStocareObiectiveUtilizator
    {
        private const int PRIMUL_TABEL = 0;
        private const int PRIMA_LINIE = 0;

        public List<ObiectiveUtilizator> GetObiectiveUtilizator()
        {
            var result = new List<ObiectiveUtilizator>();
            var dsObiective = SqlDBHelper.ExecuteDataSet("select * from ObiectiveUtilizator", CommandType.Text);

            foreach (DataRow linieDB in dsObiective.Tables[PRIMUL_TABEL].Rows)
            {
                result.Add(new ObiectiveUtilizator(linieDB));
            }
            return result;
        }

        public ObiectiveUtilizator GetObiectivUtilizator(int idUtilizator, string tipObiectiv)
        {
            ObiectiveUtilizator result = null;
            var dsObiective = SqlDBHelper.ExecuteDataSet("select * from ObiectiveUtilizator where idUtilizator = :idUtilizator and tipObiectiv = :tipObiectiv", CommandType.Text,
                new OracleParameter(":idUtilizator", OracleDbType.Int32, idUtilizator, ParameterDirection.Input),
                new OracleParameter(":tipObiectiv", OracleDbType.Varchar2, tipObiectiv, ParameterDirection.Input));

            if (dsObiective.Tables[PRIMUL_TABEL].Rows.Count > 0)
            {
                DataRow linieDB = dsObiective.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new ObiectiveUtilizator(linieDB);
            }
            return result;
        }

        public bool AddObiectivUtilizator(ObiectiveUtilizator obiectiv)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "INSERT INTO ObiectiveUtilizator (idUtilizator, tipObiectiv, descriere, dataStart, dataEnd) VALUES (:idUtilizator, :tipObiectiv, :descriere, :dataStart, :dataEnd)", CommandType.Text,
                new OracleParameter(":idUtilizator", OracleDbType.Int32, obiectiv.IdUtilizator, ParameterDirection.Input),
                new OracleParameter(":tipObiectiv", OracleDbType.Varchar2, obiectiv.TipObiectiv, ParameterDirection.Input),
                new OracleParameter(":descriere", OracleDbType.Varchar2, obiectiv.Descriere, ParameterDirection.Input),
                new OracleParameter(":dataStart", OracleDbType.Date, obiectiv.DataStart, ParameterDirection.Input),
                new OracleParameter(":dataEnd", OracleDbType.Date, obiectiv.DataEnd, ParameterDirection.Input));
        }

        public bool UpdateObiectivUtilizator(ObiectiveUtilizator obiectiv)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "UPDATE ObiectiveUtilizator set descriere = :descriere, dataStart = :dataStart, dataEnd = :dataEnd where idUtilizator = :idUtilizator and tipObiectiv = :tipObiectiv", CommandType.Text,
                new OracleParameter(":descriere", OracleDbType.Varchar2, obiectiv.Descriere, ParameterDirection.Input),
                new OracleParameter(":dataStart", OracleDbType.Date, obiectiv.DataStart, ParameterDirection.Input),
                new OracleParameter(":dataEnd", OracleDbType.Date, obiectiv.DataEnd, ParameterDirection.Input),
                new OracleParameter(":idUtilizator", OracleDbType.Int32, obiectiv.IdUtilizator, ParameterDirection.Input),
                new OracleParameter(":tipObiectiv", OracleDbType.Varchar2, obiectiv.TipObiectiv, ParameterDirection.Input));
        }
        public bool DeleteObiectivByTip(string tipObiectiv)
        {
            // Executăm interogarea SQL pentru a șterge obiectivul cu tipul specificat
            return SqlDBHelper.ExecuteNonQuery(
                "DELETE FROM ObiectiveUtilizator WHERE tipObiectiv = :tipObiectiv",
                CommandType.Text,
                new OracleParameter(":tipObiectiv", OracleDbType.Varchar2, tipObiectiv, ParameterDirection.Input)
            );
        }

    }
}
