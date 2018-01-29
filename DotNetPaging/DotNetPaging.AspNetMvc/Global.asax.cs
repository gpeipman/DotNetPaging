using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using StructureMap;

namespace DotNetPaging.AspNetMvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public MvcApplication()
        {
            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private static Container Container
        {
            get
            {
                var context = HttpContext.Current;
                if (context == null)
                    throw new NullReferenceException("Can't get current HTTP context");

                var container = context.Items["StructureMapContainer"] as Container;
                if (container == null)
                {
                    container = new Container(new WebRegistry());
                    context.Items.Add("StructureMapContainer", container);
                }

                return container;
            }
        }

        public static T GetInstance<T>()
        {
            return Container.GetInstance<T>();
        }

        public static object GetInstance(Type type)
        {
            return Container.GetInstance(type);
        }
    }
}
