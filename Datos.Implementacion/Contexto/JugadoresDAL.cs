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
    public class JugadoresDAL : AccesoDatos,IJugadoresDAL
    {
        #region Constructor

        /// <summary>
        /// Implementacion de constructor genérico
        /// </summary>
        public JugadoresDAL()
          : base()
         {}

        ///// <summary>
        ///// Implementacion de sobrecarga de constructor
        ///// </summary>
        ///// <param name="llaveConfiguracion">Llave de archivo de configuracion sobre la cual se 
        ///// obtendrá el string de conexión</param>
        //public JugadoresDAL(string llaveConfiguracion) : base(llaveConfiguracion)
        //{ }
        
        #endregion

        #region Metodos CRUD

        /// <summary>
        /// Crea un nuevo jugador
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellidoPaterno"></param>
        /// <param name="apellidoMaterno"></param>
        /// <param name="direccion"></param>
        /// <param name="telefono"></param>
        /// <param name="email"></param>
        /// <param name="rut"></param>
        /// <returns>0 si es exitoso, 1 si es fallido</returns>
        public int AgregarNuevoJugador(string nombre, string apellidoPaterno, string apellidoMaterno, string direccion, string telefono, string email, string rut)
        {
            using (DbCommand comandoDB = base.Catalogo.GetSqlStringCommand(ConsultasSQL.IngresarNuevoJugador))
            {
                base.Catalogo.AddInParameter(comandoDB, "@Nombre", DbType.String, nombre);
                base.Catalogo.AddInParameter(comandoDB, "@ApellidoPaterno", DbType.String,apellidoPaterno);
                base.Catalogo.AddInParameter(comandoDB, "@ApellidoMaterno", DbType.String,apellidoMaterno);
                base.Catalogo.AddInParameter(comandoDB, "@Rut", DbType.String, rut);
                base.Catalogo.AddInParameter(comandoDB, "@Domicilio", DbType.String,direccion);
                base.Catalogo.AddInParameter(comandoDB, "@Telefono", DbType.String,telefono);
                base.Catalogo.AddInParameter(comandoDB, "@Email", DbType.String,email);

                return Convert.ToInt32(this.Catalogo.ExecuteScalar(comandoDB));
                          
            }
        }

       /// <summary>
       /// Obtiene lista de jugadores segun parametros de busqueda
       /// </summary>
       /// <param name="nombre"></param>
       /// <param name="apellidoPaterno"></param>
       /// <param name="apellidoMaterno"></param>
       /// <returns></returns>
        public IEnumerable<Jugadores> ObtenerListaJugadores()
        {
            IList<Jugadores> jugador = new List<Jugadores>();

            using (DbCommand comandoDB = base.Catalogo.GetSqlStringCommand(ConsultasSQL.ObtenerListaJugadores))
            {
                using (IDataReader cursor = base.Catalogo.ExecuteReader(comandoDB))
                {
                    while (cursor.Read())
                    {
                        Jugadores jugadores = new Jugadores();

                        jugadores.Nombre = (cursor["Nombre"] != null && cursor["Nombre"] != DBNull.Value) ?
                                        cursor["Nombre"].ToString() : string.Empty;
                        jugadores.ApellidoPaterno = (cursor["ApellidoPaterno"] != null && cursor["ApellidoPaterno"] != DBNull.Value) ?
                                        cursor["ApellidoPaterno"].ToString() : string.Empty;
                        jugadores.ApellidoMaterno = (cursor["ApellidoMaterno"] != null && cursor["ApellidoMaterno"] != DBNull.Value) ?
                                        cursor["ApellidoMaterno"].ToString() : string.Empty;
                        jugadores.Rut = (cursor["Rut"] != null && cursor["Rut"] != DBNull.Value) ?
                                        cursor["Rut"].ToString() : string.Empty;
                        jugadores.Domicilio = (cursor["Domicilio"] != null && cursor["Domicilio"] != DBNull.Value) ?
                                        cursor["Domicilio"].ToString() : string.Empty;
                        jugadores.Telefono = (cursor["Telefono"] != null && cursor["Telefono"] != DBNull.Value) ?
                                        cursor["Telefono"].ToString() : string.Empty;
                        jugadores.Email = (cursor["Email"] != null && cursor["Email"] != DBNull.Value) ?
                                        cursor["Email"].ToString() : string.Empty;

                        jugador.Add(jugadores);

                    }
                }
            }

            return jugador;
        }

        /// <summary>
        /// Obtiene ranking TOP 5 de jugadores segun opcion escogida(Puntos, asistencias, rebotes,bloqueos)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="numero"></param>
        /// <returns></returns>
        public IEnumerable<EstadisticasPorJugador> RankingJugadoresPorDiversasCaracteristicas()
        {
            
            IList<EstadisticasPorJugador> listaEstadisticasJugador = new List<EstadisticasPorJugador>();
           
            using (DbCommand comandoDB = base.Catalogo.GetSqlStringCommand(ConsultasSQL.ObtenerEstadisticasPorJugador))
            {
                using (IDataReader cursor = base.Catalogo.ExecuteReader(comandoDB))
                {
                    while (cursor.Read())
                    {
                        EstadisticasPorJugador estadisticasJugadores = new EstadisticasPorJugador();

                        estadisticasJugadores.Nombre = (cursor["Nombre"] != null && cursor["Nombre"] != DBNull.Value) ?
                                        cursor["Nombre"].ToString() : string.Empty;
                        estadisticasJugadores.ApellidoPaterno = (cursor["ApellidoPaterno"] != null && cursor["ApellidoPaterno"] != DBNull.Value) ?
                                        cursor["ApellidoPaterno"].ToString() : string.Empty;
                        estadisticasJugadores.ApellidoMaterno = (cursor["ApellidoMaterno"] != null && cursor["ApellidoMaterno"] != DBNull.Value) ?
                                        cursor["ApellidoMaterno"].ToString() : string.Empty;

                        estadisticasJugadores.Puntos = (cursor["PorcentajeTotalPuntos"] != null && cursor["PorcentajetotalPuntos"] != DBNull.Value) ?
                                        Convert.ToDouble(cursor["PorcentajeTotalPuntos"]) : 0;
                        estadisticasJugadores.Asistencias = (cursor["PorcentajeTotalAsistencias"] != null && cursor["PorcentajeTotalAsistencias"] != DBNull.Value) ?
                                        Convert.ToDouble(cursor["PorcentajeTotalAsistencias"]) : 0;
                        estadisticasJugadores.Robos = (cursor["PorcentajeRobosTotales"] != null && cursor["PorcentajeRobosTotales"] != DBNull.Value) ?
                                        Convert.ToDouble(cursor["PorcentajeRobosTotales"]) : 0;

                        listaEstadisticasJugador.Add(estadisticasJugadores);

                    }
               }
            }

            return listaEstadisticasJugador;
        }
  
        #endregion
    }
}
