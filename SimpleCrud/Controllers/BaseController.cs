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
        public void Validate<Tmodel>(IValidator<Tmodel> validator, Tmodel model)
        {
            var result = validator.Validate(model);

            foreach (var item in result)
            {
                ModelState.AddModelError(item.Key, item.Message);
            }
        }
    }
}