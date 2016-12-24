using System.Web.Mvc;

namespace PruebaJardinDelMar.UI
{
    public class PrincipalAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Principal";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            if (context != null)
            {
                context.MapRoute(
                    "Principal_default",
                    "Principal/{controller}/{action}/{id}",
                    new { area = "Principal", controller = "Principal", action = "Index", id = UrlParameter.Optional }
                );
            }
        }
    }
}
