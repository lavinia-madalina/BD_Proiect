using LibrarieModele;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivelAccesDate
{
    public interface IStocareActivitati
    {
        List<Activitate> GetActivitati();
        Activitate GetActivitate(int idActivitate);
        bool AddActivitate(Activitate activitate);
        bool UpdateActivitate(Activitate activitate);
    }
}
