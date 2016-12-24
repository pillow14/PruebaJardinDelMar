using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;
using Dominio.Core;
using Dominio.Interfaces;
using Datos.Interfaces;

namespace PruebaJardinDelMar.UI.Areas.Principal.Controllers
{
    public class PrincipalController : Controller
    {
        #region Miembros

        /// <summary>
        /// Miembros base
        /// </summary>
        private IJugadoresLogica jugadoresLogica;

        #endregion

        #region Constructor

        /// <summary>
        /// Crea una nueva instancia de controlador Principal
        /// </summary>
        /// <param name="_jugadoresLogica"></param>
        [Microsoft.Practices.Unity.InjectionConstructor]
        public PrincipalController(IJugadoresLogica _jugadoresLogica)
        {
            this.jugadoresLogica = _jugadoresLogica;
        }
        #endregion

        #region Acciones Base

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
           
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Jugadores()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult AgregarNuevoJugador(string nombre, string apellidoPaterno, string apellidoMaterno, string direccion, string telefono, string email,string rut)
        {
            int jugadorCreado = jugadoresLogica.AgregarNuevoJugador(nombre, apellidoPaterno, apellidoMaterno, direccion, telefono, email,rut);
            return Json(jugadorCreado, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jugadores"></param>
        /// <returns></returns>
        public ActionResult ListarJugadores(Jugadores jugadores)
        {
            IEnumerable<Jugadores> listaJugadores = null;

            listaJugadores = jugadoresLogica.ObtenerListaJugadores();

            return View("ListarJugadores", listaJugadores);
        }

        
        #endregion

        #region Acciones Json
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult GraficoEjemplo()
        {
            IEnumerable<EstadisticasPorJugador> listaDatos = jugadoresLogica.RankingJugadoresPorDiversasCaracteristicas();
            return View();
        }

        
        #endregion

        
    }
}
