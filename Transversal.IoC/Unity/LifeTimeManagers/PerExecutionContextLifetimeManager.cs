using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Microsoft.Practices.Unity;
using System.Runtime.Remoting.Messaging;
using Transversal.IoC.Recursos;

namespace Transversal.IoC
{
    /// <summary>
    /// Este es un lifetime personalizado que preserva la instancia del mismo ambiente de ejecución. 
    /// </summary>
    sealed class PerExecutionContextLifetimeManager
        : LifetimeManager
    {
        #region Nested

        /// <summary>
        /// Extensión personalizada para OperationContext scope
        /// </summary>
        class ContainerExtension : IExtension<OperationContext>
        {
            #region Members

            public object Value { get; set; }

            #endregion

            #region IExtension<OperationContext> Members

            public void Attach(OperationContext owner)
            {

            }

            public void Detach(OperationContext owner)
            {

            }

            #endregion
        }
        #endregion

        #region Members

        Guid _key;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public PerExecutionContextLifetimeManager() : this(Guid.NewGuid()) { }

        /// <summary>
        ///  Constructor
        /// </summary>
        /// <param name="key">Llave para lifetimemanager resolver</param>
        PerExecutionContextLifetimeManager(Guid key)
        {
            if (key == Guid.Empty)
                throw new ArgumentException(Mensajes.exception_PerExecutionContextLifetimeManagerKeyCannotBeNull);

            _key = key;
        }
        #endregion

        #region ILifetimeManager Members

        /// <summary>
        /// <see cref="M:Microsoft.Practices.Unity.LifetimeManager.GetValue"/>
        /// </summary>
        /// <returns><see cref="M:Microsoft.Practices.Unity.LifetimeManager.GetValue"/></returns>
        public override object GetValue()
        {
            object result = null;

            if (OperationContext.Current != null)
            {
                ContainerExtension containerExtension = OperationContext.Current.Extensions.Find<ContainerExtension>();
                if (containerExtension != null)
                {
                    result = containerExtension.Value;
                }
            }
            else if (HttpContext.Current != null)
            {
                if (HttpContext.Current.Items[_key.ToString()] != null)
                    result = HttpContext.Current.Items[_key.ToString()];
            }
            else
            {
                result = CallContext.GetData(_key.ToString());
            }


            return result;
        }
        /// <summary>
        /// <see cref="M:Microsoft.Practices.Unity.LifetimeManager.RemoveValue"/>
        /// </summary>
        public override void RemoveValue()
        {
            if (OperationContext.Current != null)
            {
                ContainerExtension containerExtension = OperationContext.Current.Extensions.Find<ContainerExtension>();
                if (containerExtension != null)
                    OperationContext.Current.Extensions.Remove(containerExtension);

            }
            else if (HttpContext.Current != null)
            {
                if (HttpContext.Current.Items[_key.ToString()] != null)
                    HttpContext.Current.Items[_key.ToString()] = null;
            }
            else
            {
                CallContext.FreeNamedDataSlot(_key.ToString());
            }
        }
        /// <summary>
        /// <see cref="M:Microsoft.Practices.Unity.LifetimeManager.SetValue"/>
        /// </summary>
        /// <param name="newValue"><see cref="M:Microsoft.Practices.Unity.LifetimeManager.SetValue"/></param>
        public override void SetValue(object newValue)
        {

            if (OperationContext.Current != null)
            {
                ContainerExtension containerExtension = OperationContext.Current.Extensions.Find<ContainerExtension>();
                if (containerExtension == null)
                {
                    containerExtension = new ContainerExtension()
                    {
                        Value = newValue
                    };

                    OperationContext.Current.Extensions.Add(containerExtension);
                }
            }
            else if (HttpContext.Current != null)
            {
                if (HttpContext.Current.Items[_key.ToString()] == null)
                    HttpContext.Current.Items[_key.ToString()] = newValue;
            }
            else
            {
                CallContext.SetData(_key.ToString(), newValue);
            }
        }

        #endregion
    }
}