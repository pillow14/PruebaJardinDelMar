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
    public class EstadisticasPorEquipoLogica : IEstadisticasPorEquipoLogica
    {
       #region Miembros

       /// <summary>
       /// Miembros
       /// </summary>
       private IEstadisticasPorEquipoDAL estadisticasPorEquipoDAL;

       #endregion

       #region Constructor

       /// <summary>
       /// Crea una nueva instancia del constructor
       /// </summary>
       /// <param name="_jugadoresDAL"></param>
       public EstadisticasPorEquipoLogica(IEstadisticasPorEquipoDAL _estadisticasPorEquipoDAL)
       {
           this.estadisticasPorEquipoDAL = _estadisticasPorEquipoDAL;
       }

       #endregion

       #region Acciones Base

       /// <summary>
       /// 
       /// </summary>
       /// <param name="id"></param>
       /// <param name="opcion"></param>
       /// <returns></returns>
       public IEnumerable<EstadisticasPorEquipo> ListaEstadisticasSegunItem()
       {
           return estadisticasPorEquipoDAL.ListaEstadisticasSegunItem();
       }

        #endregion
    }
}
