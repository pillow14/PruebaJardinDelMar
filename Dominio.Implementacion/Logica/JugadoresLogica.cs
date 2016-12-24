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
   public class JugadoresLogica: IJugadoresLogica
   {
       #region Miembros
       /// <summary>
       /// Miembros
       /// </summary>
       private IJugadoresDAL jugadoresDAL;

       #endregion

       #region Constructor

       /// <summary>
       /// Crea una nueva instancia del constructor
       /// </summary>
       /// <param name="_jugadoresDAL"></param>
       public JugadoresLogica(IJugadoresDAL _jugadoresDAL)
       {
           this.jugadoresDAL = _jugadoresDAL;
       }

       #endregion

       #region Acciones Base

       /// <summary>
       /// 
       /// </summary>
       /// <param name="nombre"></param>
       /// <param name="apellidoPaterno"></param>
       /// <param name="apellidoMaterno"></param>
       /// <returns></returns>
       public IEnumerable<Jugadores> ObtenerListaJugadores()
       {
           return jugadoresDAL.ObtenerListaJugadores();
       }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="nombre"></param>
       /// <param name="apellidoPaterno"></param>
       /// <param name="apellidoMaterno"></param>
       /// <param name="direccion"></param>
       /// <param name="telefono"></param>
       /// <param name="email"></param>
       /// <param name="rut"></param>
       /// <returns></returns>
       public int AgregarNuevoJugador(string nombre, string apellidoPaterno, string apellidoMaterno, string direccion, string telefono, string email,string rut)
       {
           return jugadoresDAL.AgregarNuevoJugador(nombre, apellidoPaterno, apellidoMaterno, direccion, telefono, email, rut);
       }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       public IEnumerable<EstadisticasPorJugador> RankingJugadoresPorDiversasCaracteristicas()
       {
           return jugadoresDAL.RankingJugadoresPorDiversasCaracteristicas();
       }

       #endregion

      

   }
}
