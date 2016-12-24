using System;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PruebaJardinDelMar.UI
{
    // Nota: para obtener instrucciones sobre cómo habilitar el modo clásico de IIS6 o IIS7, 
    // visite http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //var area1reg = new ComprobanteAreaRegistration();
            //var area1context = new AreaRegistrationContext(area1reg.AreaName, RouteTable.Routes);
            //area1reg.RegisterArea(area1context);

            AreaRegistration.RegisterAllAreas();

            ApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            Bootstrapper.Initialize();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            Response.Clear();

            HttpException httpException = exception as HttpException;

            if (httpException != null)
            {
                // clear error on server
                Server.ClearError();

                Response.Redirect("~/Views/Shared/Error");
            }

        }
    }
}
