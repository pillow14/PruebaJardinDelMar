using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Core;

namespace Datos.Interfaces
{
    public interface IJugadoresDAL
    {
        IEnumerable<Jugadores> ObtenerListaJugadores();

        int AgregarNuevoJugador(string nombre, string apellidoPaterno, string apellidoMaterno, string direccion, string telefono, string email, string rut);

        IEnumerable<EstadisticasPorJugador> RankingJugadoresPorDiversasCaracteristicas();
    }
}
