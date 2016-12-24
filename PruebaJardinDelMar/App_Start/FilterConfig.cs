using System.Web;
using System.Web.Mvc;

namespace PruebaJardinDelMar.UI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            if (filters != null)
            {
                filters.Add(new HandleErrorAttribute());
            }
        }
    }
}