using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http;
using Autofac;
using NLog;
using MvcSiteMapProvider;
using HGenealogy.App_Start;

namespace HGenealogy
{
    public class MvcApplication : System.Web.HttpApplication
    {
        // Logger
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AutofacConfig.Register();
 
            //var builder = new ContainerBuilder();
            //// Register modules
            //builder.RegisterModule(new MvcSiteMapProviderModule()); // Required
            //builder.RegisterModule(new MvcModule()); // Required by MVC. Typically already part of your setup (double check the contents of the module).

            //// Create the DI container (typically part of your config already)
            //var container = builder.Build();

            //// Setup global sitemap loader (required)
            //MvcSiteMapProvider.SiteMaps.Loader = container.Resolve<ISiteMapLoader>();

            //// Register the Sitemaps routes for search engines (optional)
            //XmlSiteMapController.RegisterRoutes(RouteTable.Routes);        
        }
    }
}
