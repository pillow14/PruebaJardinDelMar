using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Configuration;
using Dominio.Core;
using Datos.Interfaces;
using Datos.Implementacion.Utilitario.Recursos;

namespace Datos.Implementacion
{
    public class EstadisticasPorEquipoDAL: AccesoDatos, IEstadisticasPorEquipoDAL
    {
        public IEnumerable<EstadisticasPorEquipo> ListaEstadisticasSegunItem()
        {
            return null;
        }
    }
}
