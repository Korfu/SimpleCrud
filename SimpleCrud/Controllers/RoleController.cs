using SimpleCrud.Models;
using SimpleCrud.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleCrud.Controllers
{
    public class RoleController : Controller
    {
        private IRolesRepository _rolesRepository;

        public RoleController(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        public ActionResult Index()
        {
            var allRoles = _rolesRepository.GetAll();
            return View(allRoles);
        }

        public ActionResult Add()
        {
            var role = new AddRoleModel();
            return View(role);
        }

        [HttpPost]
        public ActionResult Add(AddRoleModel model)
        {
            _rolesRepository.Add(model);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(long id)
        {
            return View(id);
        }

        [HttpPost]
        public ActionResult Delete(long id, object dummy)
        {
            _rolesRepository.Delete(id);
            return RedirectToAction("Index");
        }

    }
}