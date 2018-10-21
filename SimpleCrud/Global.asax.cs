using Ninject;
using SimpleCrud.Controllers;
using SimpleCrud.Models;
using SimpleCrud.Repositories;
using SimpleCrud.Validators;
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
            AddBindings(kernel);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(kernel));
            //tworzymy nową fabrykę dla kontrolerów, aby mogły otrzymywać parametry w konstrukotrze

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private static void AddBindings(IKernel kernel)
        {

            // jak napotka to co po lewej, to wstrzyknie to co po prawej, prawa strona implementuje interfejs z lewej strony
            kernel.Bind<IPersonRepository>().To<PersonRepository>();
            kernel.Bind<PersonController>().To<PersonController>();
            kernel.Bind<IValidator<AddUserModel>>().To<AddUSerModelValidator>();
        }
    }
}
