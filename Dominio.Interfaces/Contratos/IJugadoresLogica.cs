using System;
using Dominio.Core;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces
{
    public interface IJugadoresLogica
    {
        int AgregarNuevoJugador(string nombre, string apellidoPaterno, string apellidoMaterno, string direccion, string telefono, string email, string rut);

        IEnumerable<Jugadores> ObtenerListaJugadores();

        IEnumerable<EstadisticasPorJugador> RankingJugadoresPorDiversasCaracteristicas();
    }
}
