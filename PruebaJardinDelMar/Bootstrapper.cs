using System;
using System.Web.Mvc;
using Transversal.IoC;
using Microsoft.Practices.Unity;
using Unity.Mvc3;

namespace PruebaJardinDelMar.UI
{
    public static class Bootstrapper
    {

        public static void Initialize()
        {
            var container = new UnityContainer();

            IoCUnityContainer.ConfigureRootContainer(container);

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

        }
    }
}