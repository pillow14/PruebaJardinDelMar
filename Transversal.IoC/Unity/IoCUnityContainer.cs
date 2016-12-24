using System;
using System.Collections.Generic;
using System.Configuration;
using Transversal.IoC.Recursos;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace Transversal.IoC
{
    /// <summary>
    /// Implementa contenedor en Microsoft Practices Unity
    /// </summary>
    public class IoCUnityContainer : IContainer
    {
        #region Members

        IDictionary<string, IUnityContainer> _ContainersDictionary;

        private const string CONTAINER_ROOT_NAME = "RootContainer";

        private const string UNITY_SECTION_NAME = "unity";

        #endregion

        #region Constructor

        /// <summary>
        /// Crea nueva instancia de IoCUnitContainer
        /// </summary>
        public IoCUnityContainer()
        {
            _ContainersDictionary = new Dictionary<string, IUnityContainer>();

            IUnityContainer rootContainer = new UnityContainer();
            _ContainersDictionary.Add("RootContext", rootContainer);

            IUnityContainer realAppContainer = rootContainer.CreateChildContainer();
            _ContainersDictionary.Add("RealAppContext", realAppContainer);

            ConfigureRootContainer(rootContainer);
        }

        #endregion

        #region Métodos Privados

        /// <summary>
        /// Configurar Root Container.
        /// </summary>
        /// <param name="container">Contenedor a configurar</param>
        public static void ConfigureRootContainer(IUnityContainer container)
        {
            LoadContainerConfiguration(container, UNITY_SECTION_NAME, CONTAINER_ROOT_NAME);
        }

        #endregion

        #region IServiceFactory Members

        /// <summary>
        /// <see cref="M:CoreApp.Infrastructure.CrossCutting.IoC.IContainer.Resolve{TService}"/>
        /// </summary>
        /// <typeparam name="TService"><see cref="M:CoreApp.Infrastructure.CrossCutting.IoC.IContainer.Resolve{TService}"/></typeparam>
        /// <returns><see cref="M:CoreApp.Infrastructure.CrossCutting.IoC.IContainer.Resolve{TService}"/></returns>
        public TService Resolve<TService>()
        {
            string containerName = ConfigurationManager.AppSettings["defaultIoCContainer"];

            if (string.IsNullOrEmpty(containerName)
                ||
                string.IsNullOrWhiteSpace(containerName))
            {
                throw new ArgumentNullException(Mensajes.exception_DefaultIOCSettings);
            }

            if (!_ContainersDictionary.ContainsKey(containerName))
                throw new InvalidOperationException(Mensajes.exception_ContainerNotFound);

            IUnityContainer container = _ContainersDictionary[containerName];

            return container.Resolve<TService>();
        }
        /// <summary>
        /// <see cref="M:CoreApp.Infrastructure.CrossCutting.IoC.IContainer.Resolve"/>
        /// </summary>
        /// <param name="type"><see cref="M:CoreApp.Infrastructure.CrossCutting.IoC.IContainer.Resolve"/></param>
        /// <returns><see cref="M:CoreApp.Infrastructure.CrossCutting.IoC.IContainer.Resolve"/></returns>
        public object Resolve(Type type)
        {
            string containerName = ConfigurationManager.AppSettings["defaultIoCContainer"];

            if (string.IsNullOrEmpty(containerName)
                ||
                string.IsNullOrWhiteSpace(containerName))
            {
                throw new ArgumentNullException(Mensajes.exception_DefaultIOCSettings);
            }

            if (!_ContainersDictionary.ContainsKey(containerName))
                throw new InvalidOperationException(Mensajes.exception_ContainerNotFound);

            IUnityContainer container = _ContainersDictionary[containerName];

            return container.Resolve(type, null);
        }

        /// <summary>
        /// <see cref="M:CoreApp.Infrastructure.CrossCutting.IoC.IContainer.RegisterType"/>
        /// </summary>
        /// <param name="type"><see cref="M:CoreApp.Infrastructure.CrossCutting.IoC.IContainer.RegisterType"/></param>
        public void RegisterType(Type type)
        {
            IUnityContainer container = this._ContainersDictionary["RootContext"];

            var hierarchicalLifetimeManager = new HierarchicalLifetimeManager();
            try
            {
                if (container != null)
                    container.RegisterType(type, hierarchicalLifetimeManager);
            }
            catch
            {
                hierarchicalLifetimeManager.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Carga la configuración del contenedor indicado desde el archivo de configuración
        /// </summary>
        /// <param name="container">Contenedor <see cref="IUnityContainer"/></param>
        /// <param name="sectionName">Nombre de la sección de configuración</param>
        /// <param name="containerName">Nombre del contenedor</param>
        private static void LoadContainerConfiguration(IUnityContainer container, string sectionName, string containerName)
        {
            container.LoadConfiguration(GetUnityConfigurationSection(sectionName), containerName);
        }

        /// <summary>
        /// Obtiene la sección de configuración de Unity
        /// </summary>
        /// <param name="sectionName">Nombre de la sección de configuración</param>
        /// <returns>Sección de configuración <see cref="UnityConfigurationSection"/></returns>
        private static UnityConfigurationSection GetUnityConfigurationSection(string sectionName)
        {
            return (UnityConfigurationSection)ConfigurationManager.GetSection(sectionName);
        }

        #endregion
    }
}