using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Core
{
    public class EstadisticasPorJugador
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public double Puntos { get; set; }
        public double RebotesOfensivos { get; set; }
        public double RebotesDefensivos { get; set; }
        public double Asistencias { get; set; }
        public double Bloqueos { get; set; }
        public double Robos { get; set; }
        public double FoulsPorJuego { get; set; }
        public double MinutosPorJuego { get; set; }

    }
}
