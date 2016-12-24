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
    public class CualidadesFisicasPorJugadorLogica : ICualidadesFisicasPorJugadorLogica
    {
         #region Miembros
       /// <summary>
       /// Miembros
       /// </summary>
       private ICualidadesFisicasPorJugadorDAL cualidadesFisicasPorJugadorDAL;

       #endregion

         #region Constructor

       /// <summary>
       /// 
       /// </summary>
       /// <param name="_cualidadesFisicasPorJugadorDAL"></param>
       public CualidadesFisicasPorJugadorLogica(ICualidadesFisicasPorJugadorDAL _cualidadesFisicasPorJugadorDAL)
       {
           this.cualidadesFisicasPorJugadorDAL = _cualidadesFisicasPorJugadorDAL;
       }

       #endregion

         #region Acciones Base
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="opcion"></param>
        /// <returns></returns>
       public IEnumerable<CualidadesFisicasPorJugador> ObtenerRankingCualidadesFisicasPorJugador(int id, string opcion)
       {
           return cualidadesFisicasPorJugadorDAL.ObtenerRankingCualidadesFisicasPorJugador(id, opcion);
       }

        #endregion
    }
}
