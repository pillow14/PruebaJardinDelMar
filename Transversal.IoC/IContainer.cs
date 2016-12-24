using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Transversal.IoC
{
    /// <summary>
    /// Contrato base para localizar y registrar dependencias
    /// </summary>
    public interface IContainer
    {
        /// <summary>
        /// Resuelve TService dependency
        /// </summary>
        /// <typeparam name="TService">Type of dependency</typeparam>
        /// <returns>instance of TService</returns>
        TService Resolve<TService>();

        /// <summary>
        /// Resuelve el tipo de construcción
        /// </summary>
        /// <returns>Instancia del tipo</returns>
        object Resolve(Type type);

        /// <summary>
        /// Registra el tipo en service locator
        /// </summary>
        /// <param name="type">Tipo a registrar</param>
        void RegisterType(Type type);
    }
}
