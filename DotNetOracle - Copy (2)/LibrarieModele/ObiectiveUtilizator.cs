using System;
using System.Data;

namespace LibrarieModele
{
    public class ObiectiveUtilizator
    {
        public int IdUtilizator { get; set; }
        public string TipObiectiv { get; set; }
        public string Descriere { get; set; }
        public DateTime? DataStart { get; set; }
        public DateTime? DataEnd { get; set; }

        public ObiectiveUtilizator() { }

        public ObiectiveUtilizator(int idUtilizator, string tipObiectiv, string descriere, DateTime? dataStart, DateTime? dataEnd)
        {
            IdUtilizator = idUtilizator;
            TipObiectiv = tipObiectiv;
            Descriere = descriere;
            DataStart = dataStart;
            DataEnd = dataEnd;
        }

        public ObiectiveUtilizator(DataRow linieDB)
        {
            IdUtilizator = Convert.ToInt32(linieDB["idUtilizator"]);
            TipObiectiv = linieDB["tipObiectiv"].ToString();
            Descriere = linieDB["descriere"].ToString();
            DataStart = linieDB["dataStart"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(linieDB["dataStart"]);
            DataEnd = linieDB["dataEnd"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(linieDB["dataEnd"]);
        }
    }
}
