using System.Web;
using System.Web.Mvc;

namespace Readify.WebSChallenge.FrontEnd
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
