using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Core;
using Dominio.Implementacion;
using Dominio.Interfaces;
using Datos.Implementacion;
using Datos.Interfaces;

namespace Dominio.Implementacion
{
    public class EstadisticasPorJugadorLogica : IEstadisticasPorJugadorLogica
    {
         #region Miembros

       /// <summary>
       /// Miembros
       /// </summary>
       private IEstadisticasPorJugadorDAL estadisticasPorJugadorDAL;

       #endregion

        #region Constructor

      /// <summary>
      /// 
      /// </summary>
      /// <param name="_estadisticasPorJugadorDAL"></param>
       public EstadisticasPorJugadorLogica(IEstadisticasPorJugadorDAL _estadisticasPorJugadorDAL)
       {
           this.estadisticasPorJugadorDAL = _estadisticasPorJugadorDAL;
       }

       #endregion

        #region Acciones Base

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="opcion"></param>
        /// <returns></returns>
       public IEnumerable<EstadisticasPorJugador> ObtenerEstadisticasPorJugadorSegunItem(int id, string opcion)
       {
           return estadisticasPorJugadorDAL.ObtenerEstadisticasPorJugadorSegunItem(id, opcion);
       }
        #endregion
    }
}
