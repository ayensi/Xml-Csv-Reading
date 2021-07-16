
using System.Configuration;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace dataAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public class Globals
        {
            private static string XMLPath;
            private static string DataSource;
            public static string dataSource
            {
                get
                {
                    return DataSource;
                }
                set { DataSource = value; }
            }
            public static string xmlPath
            {
                get
                {
                    return XMLPath;
                }
                set { XMLPath = value; }
            }

        }
        protected void Application_Start()
        {
            Globals.xmlPath = HttpContext.Current.Server.MapPath(@"~/Files/sample_data.xml");
            Globals.dataSource = ConfigurationManager.AppSettings["DefaultDataSource"];
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
