﻿using Dominio.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface IEstadisticasPorEquipoDAL
    {
        IEnumerable<EstadisticasPorEquipo> ListaEstadisticasSegunItem();
    }
}
