using SimpleCrud.Models;
using SimpleCrud.Models.Roles;
using SimpleCrud.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleCrud.Controllers
{
    public class RoleController : BaseController
    {
        private IRoleRepository _rolesRepository;

        public RoleController(IRoleRepository rolesRepository)
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
            if (ModelState.IsValid)
            {
                _rolesRepository.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(long id)
        {
            var roleToEdit = _rolesRepository.GetRole(id);
            return View(roleToEdit);
        }

        [HttpPost]
        public ActionResult Edit (EditRoleModel model)
        {
            if (ModelState.IsValid)
            {
                _rolesRepository.Update(model);
                return RedirectToAction("index");
            }
            return View(model);
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