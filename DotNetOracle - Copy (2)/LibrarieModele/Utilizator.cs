using System.Data;
using System;

namespace LibrarieModele
{
    public class Utilizator
    {
       // public int IdUtilizator { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Email { get; set; }
        public DateTime? DataNasterii { get; set; } // Nullable if not always set
        public string Inaltime { get; set; }
        public int? NumarKG { get; set; } // Nullable if not always set
        public int? IndexMasaMusculara { get; set; } // Nullable if not always set

        public Utilizator() { }

        public Utilizator(string nume, string prenume, string email, string inaltime, DateTime? dataNasterii, int? numarKG, int? indexMasaMusculara)
        {
            Nume = nume;
            Prenume = prenume;
            Email = email;
            Inaltime = inaltime;
            DataNasterii = dataNasterii;
            NumarKG = numarKG;
            IndexMasaMusculara = indexMasaMusculara;
        }


        public Utilizator(DataRow linieDB)
        {
           // IdUtilizator = Convert.ToInt32(linieDB["idUtilizator"]);
            Nume = linieDB["nume"].ToString();
            Prenume = linieDB["prenume"].ToString();
            Email = linieDB["email"].ToString();
            DataNasterii = linieDB["dataNasterii"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(linieDB["dataNasterii"]);
            Inaltime = linieDB["inaltime"].ToString();
            NumarKG = linieDB["numarKG"] == DBNull.Value ? (int?)null : Convert.ToInt32(linieDB["numarKG"]);
            IndexMasaMusculara = linieDB["indexMasaMusculara"] == DBNull.Value ? (int?)null : Convert.ToInt32(linieDB["indexMasaMusculara"]);
        }
    }
}
