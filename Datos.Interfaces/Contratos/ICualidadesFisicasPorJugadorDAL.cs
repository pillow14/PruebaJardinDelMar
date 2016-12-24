using Dominio.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface ICualidadesFisicasPorJugadorDAL
    {
        IEnumerable<CualidadesFisicasPorJugador> ObtenerRankingCualidadesFisicasPorJugador(int id, string opcion);
    }
}
