using System;
using System.Data;

namespace LibrarieModele
{
    public class Activitate
    {
     //   public int IdActivitate { get; set; }
        public string NumeActivitate { get; set; }
        public string DescriereActivitate { get; set; }
        public int DurataActivitate { get; set; }

        public Activitate() { }

        public Activitate(string numeActivitate, string descriereActivitate, int durataActivitate)
        {
            NumeActivitate = numeActivitate;
            DescriereActivitate = descriereActivitate;
            DurataActivitate = durataActivitate;
        }

        public Activitate(DataRow linieDB)
        {
          //  IdActivitate = Convert.ToInt32(linieDB["idActivitate"]);
            NumeActivitate = linieDB["numeActivitate"].ToString();
            DescriereActivitate = linieDB["descriereActivitate"].ToString();
            DurataActivitate = Convert.ToInt32(linieDB["durataActivitate"]);
        }
    }
}
