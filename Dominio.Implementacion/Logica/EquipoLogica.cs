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
    public class EquipoLogica: IEquipoLogica
    {
       #region Miembros
       /// <summary>
       /// Miembros
       /// </summary>
       private IEquipoDAL equipoDAL;

       #endregion

       #region Constructor

       /// <summary>
       /// Crea una nueva instancia del constructor
       /// </summary>
       /// <param name="_jugadoresDAL"></param>
       public EquipoLogica(IEquipoDAL _equipoDAL)
       {
           this.equipoDAL = _equipoDAL;
       }

       #endregion

       #region Acciones Base

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="direccion"></param>
        /// <param name="rut"></param>
        /// <param name="telefono"></param>
        /// <param name="email"></param>
        /// <returns></returns>
       public Equipo IngresarNuevoEquipo(int id, string nombre, string direccion, string rut, string telefono, string email)
       {
           return equipoDAL.IngresarNuevoEquipo(id, nombre, direccion, rut, telefono, email);
       }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="nombre"></param>
       /// <param name="direccion"></param>
       /// <param name="rut"></param>
       /// <param name="telefono"></param>
       /// <param name="email"></param>
       /// <returns></returns>
        public Equipo ActualizarDatosEquipo(string nombre, string direccion, string rut, string telefono, string email)
       {
           return equipoDAL.ActualizarDatosEquipo(nombre, direccion, rut, telefono, email);
       }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="opcion"></param>
        /// <returns></returns>
        public IEnumerable<Equipo> EstadisticasDeEquipo(int id, string opcion)
        {
            return equipoDAL.EstadisticasDeEquipo(id, opcion);
        }

        #endregion
    }
}
