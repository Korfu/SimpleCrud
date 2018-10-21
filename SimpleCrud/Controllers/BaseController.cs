using Ninject;
using SimpleCrud.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleCrud.Controllers
{
    public abstract class BaseController : Controller
    {
        [Inject]
        public IKernel Kernel { get; set; }

        public void Validate<Tmodel>(Tmodel model)
        {
            var validator = Kernel.Get<IValidator<Tmodel>>();

            var result = validator.Validate(model);

            foreach (var item in result)
            {
                ModelState.AddModelError(item.Key, item.Message);
            }
        }
    }
}