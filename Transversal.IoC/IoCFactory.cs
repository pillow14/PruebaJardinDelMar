using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Transversal.IoC
{
    public sealed class IoCFactory
    {
        #region Singleton

        static readonly IoCFactory instance = new IoCFactory();

        /// <summary>
        /// Patron Singleton
        /// </summary>
        public static IoCFactory Instance
        {
            get
            {
                return instance;
            }
        }

        #endregion

        #region Members

        IContainer _CurrentContainer;

        ///
        /// <summary>
        /// Carga la configuración actual del IContainer
        /// </summary>
        public IContainer CurrentContainer
        {
            get
            {
                return _CurrentContainer;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Solo para el patrón singleton
        /// </summary>
        IoCFactory()
        {
            _CurrentContainer = new IoCUnityContainer();
        }

        #endregion
    }
}