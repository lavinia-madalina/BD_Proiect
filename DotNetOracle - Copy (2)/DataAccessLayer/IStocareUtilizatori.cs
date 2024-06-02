using LibrarieModele;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NivelAccesDate
{
    public interface IStocareUtilizatori : IStocareFactory
    {
        List<Utilizator> GetUtilizatori();
        Utilizator GetUtilizator(int id);
        bool AddUtilizator(Utilizator u);
        bool UpdateUtilizator(Utilizator u);
    }
}
