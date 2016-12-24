using Dominio.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Interfaces
{
    public interface IEquipoDAL
    {
        Equipo IngresarNuevoEquipo(int id, string nombre, string direccion, string rut, string telefono, string email);

        Equipo ActualizarDatosEquipo(string nombre, string direccion, string rut, string telefono, string email);

        IEnumerable<Equipo> EstadisticasDeEquipo(int id, string opcion);
    }
}
