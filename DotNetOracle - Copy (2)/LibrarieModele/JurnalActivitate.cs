using System.Data;
using System;
namespace LibrarieModele
{
    public class JurnalActivitate
    {
        public int IdInregistrare { get; set; }
        public DateTime Data { get; set; }
        public int DurataActivitate { get; set; }
        public decimal Distanta { get; set; }
        public int CaloriiArse { get; set; }
        public int Bonus { get; set; }
        public string Email { get; set; }

        public JurnalActivitate() { }

        public JurnalActivitate(DataRow linieDB)
        {
            IdInregistrare = Convert.ToInt32(linieDB["idInregistrare"]);
            Data = Convert.ToDateTime(linieDB["data"]);
            DurataActivitate = Convert.ToInt32(linieDB["durataActivitate"]);
            Distanta = Convert.ToDecimal(linieDB["distanta"]);
            CaloriiArse = Convert.ToInt32(linieDB["caloriiArse"]);
            Bonus = CalculateBonus(CaloriiArse);
            Email = linieDB["email"].ToString();
        }

        public JurnalActivitate(DateTime data, int durataActivitate, decimal distanta, int caloriiArse, string email)
        {
            Data = data;
            DurataActivitate = durataActivitate;
            Distanta = distanta;
            CaloriiArse = caloriiArse;
            Bonus = CalculateBonus(caloriiArse);
            Email = email;
        }

        public static int CalculateBonus(int caloriiArse)
        {
            // Exemplu simplu de calcul al bonusului în funcție de calorii arse
            return caloriiArse / 100;
        }
    }
}
