using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace DotNetPaging.AspNetMvc
{
    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
                return null;

            var controller = MvcApplication.GetInstance(controllerType);
            return controller as Controller;
        }
    }
}