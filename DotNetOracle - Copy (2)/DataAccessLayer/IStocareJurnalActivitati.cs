using LibrarieModele;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivelAccesDate
{
    public interface IStocareJurnalActivitati
    {
        List<JurnalActivitate> GetJurnaleActivitati();
        JurnalActivitate GetJurnalActivitate(int idInregistrare);
        bool AddJurnalActivitate(JurnalActivitate jurnal);
        bool UpdateJurnalActivitate(JurnalActivitate jurnal);
    }
}
