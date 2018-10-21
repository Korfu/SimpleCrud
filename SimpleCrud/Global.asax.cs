using Ninject;
using SimpleCrud.Controllers;
using SimpleCrud.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SimpleCrud
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var kernel = new StandardKernel(); //tworzenie instancji kontenera
            kernel.Bind<IPersonRepository>().To<PersonRepository>();
            kernel.Bind<PersonController>().To<PersonController>();


            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(kernel));
            //tworzymy nową fabrykę dla kontrolerów, aby mogły otrzymywać parametry w konstrukotrze

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
