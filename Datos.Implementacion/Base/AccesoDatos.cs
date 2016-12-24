using System;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Datos.Implementacion
{
    /// <summary>
    /// Clase genérica de conexion a datos Interfaz Comprobante de pago
    /// </summary>
    public class AccesoDatos : IDisposable
    {
        #region Propiedades Internas

        /// <summary>
        /// Base de datos de la aplicacion
        /// </summary>
        internal Database Catalogo { get; set; }
        
        #endregion

        #region Constructor

        /// <summary>
        /// Crea una nueva instancia de la clase creando una conexion con los valores por defecto
        /// obtenidos del archivo de configuración
        /// </summary>
        public AccesoDatos()
        {
            this.Catalogo = DatabaseFactory.CreateDatabase("PruebaJardinDelMar");
            
        }

        /// <summary>
        /// Crea una nueva instancia de la clase creando una conexion con los valores de la llave de configuración indicada por parámetro
        /// </summary>
        public AccesoDatos(string llave)
        {
            this.Catalogo = DatabaseFactory.CreateDatabase(llave);
            
        }

        #endregion

        #region Destructor

        /// <summary>
        /// Libera los recursos utilizados por la clase
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Sobreescritura de metodo dispose, el cual libera los recursos manejados por la clase
        /// </summary>
        /// <param name="disposing">indica si debe liberar los recursos manejados</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Catalogo = null;
                
            }
        }

        #endregion
    }
}