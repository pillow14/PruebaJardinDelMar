using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Core
{
    public class EstadisticasPorEquipo
    {
        public int Id { get; set; }
        public double PuntosTotales { get; set; }
        public double PuntosPrimerCuarto { get; set; }
        public double PuntosSegundoCuarto { get; set; }
        public double PuntosTercerCuarto{get;set;}
        public double PuntosCuartoCuarto { get; set; }
        public double RebotesOfensivos { get; set; }
        public double RebotesDefensivos { get; set; }
        public double AsistenciasTotales { get; set; }
        public double BloqueosTotales { get; set; }
        public double RobosTotales { get; set; }
        public double FoulsTotales { get; set;
        }
    }
}
