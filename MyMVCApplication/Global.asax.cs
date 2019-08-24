using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DAL;

namespace MyMVCApplication
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            using (var context = new UnitOfWork())
                context.Initialize();
        }
    }
}