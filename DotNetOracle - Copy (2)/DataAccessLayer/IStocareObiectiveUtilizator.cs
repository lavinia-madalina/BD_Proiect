using LibrarieModele;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivelAccesDate
{
    public interface IStocareObiectiveUtilizator : IStocareFactory
    {
        List<ObiectiveUtilizator> GetObiectiveUtilizator();
        ObiectiveUtilizator GetObiectivUtilizator(int idUtilizator, string tipObiectiv);
        bool AddObiectivUtilizator(ObiectiveUtilizator obiectiv);
        bool UpdateObiectivUtilizator(ObiectiveUtilizator obiectiv);
    }
}
