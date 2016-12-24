using System;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace Utilitarios.Excepciones
{
    public static class ProveedorExcepciones
    {
        #region Métodos Públicos

        /// <summary>
        /// Maneja excepción, dependiendo la política enviada
        /// </summary>
        /// <param name="excepcion">Excepción que será manejada por el Handler</param>
        /// <param name="politica">Identificador de política, según la cual se controlará la excepción</param>
        /// <returns>Excepción manejada, puede retornar una nueva o la de origen</returns>
        public static Exception ManejaExcepcion(Exception excepcion, string politica)
        {
            return ExceptionPolicy.HandleException(excepcion, politica) ? excepcion : excepcion;
        }

        #endregion
    }
}