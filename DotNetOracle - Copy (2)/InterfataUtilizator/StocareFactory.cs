using NivelAccesDate;
using System;
using System.Configuration;
using LibrarieModele;

namespace InterfataUtilizator
{
    /// <summary>
    /// Factory Design Pattern
    /// </summary>
    public class StocareFactory
    {
        public object GetTipStocare(Type tipEntitate)
        {

            var formatSalvare = ConfigurationManager.AppSettings["FormatSalvare"];
            if (formatSalvare != null)
            {
                switch (formatSalvare)
                {
                    default:
                    case "BazaDateOracle":
                        if (tipEntitate == typeof(Utilizator))
                        {
                            return new AdministrareUtilizatori();
                        }
                        if (tipEntitate == typeof(Activitate))
                        {
                            return new AdministrareActivitati();
                        }
                        if (tipEntitate == typeof(ObiectiveUtilizator))
                        {
                            return new AdministrareObiectiveUtilizator();
                        }
                        if (tipEntitate == typeof(JurnalActivitate))
                        {
                            return new AdministrareJurnalActivitati();
                        }
                        break;

                    case "BIN":
                        // instantiere clase care realizeaza salvarea in fisier binar
                        break;
                }
            }
            return null;

        }
    }
}
