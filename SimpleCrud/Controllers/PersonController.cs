using SimpleCrud.Extentions;
using SimpleCrud.Models;
using SimpleCrud.Repositories;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SimpleCrud.Controllers
{
    public class PersonController : BaseController
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository,
                                IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
            _personRepository = personRepository;
        }

        public ActionResult Index()
        {
            var model = new PersonIndexModel()
            {
                AllowAdd = true,
                Users = _personRepository.GetAllUsers()
            };
            return View(model);
        }

        public ActionResult Edit(long id)
        {
            var model = _personRepository.GetUser(id);
            model.RoleModelList = _roleRepository.GetAll().ToSelectList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditUserModel model)
        {
            Validate(model);

            if (ModelState.IsValid)
            {
                _personRepository.Update(model);
                return RedirectToAction("index");
            }
            model.RoleModelList = _roleRepository.GetAll().ToSelectList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var model = new AddUserModel();
            model.RoleModelList = _roleRepository.GetAll().ToSelectList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(AddUserModel model)
        {
            Validate(model);
         
            if (ModelState.IsValid)
            {
                _personRepository.Add(model);
                return RedirectToAction("Index");
            }
             
            model.RoleModelList = _roleRepository.GetAll().ToSelectList();
            return View(model);
        }

        public ActionResult Details(long id)
        {
            var person = _personRepository.GetUser(id);
            return View(person);
        }

        public ActionResult Delete(long id)
        {
            return View(id);
        }

        [HttpPost]
        public ActionResult Delete(long id, object dummy)
        {
            _personRepository.Delete(id);

            return RedirectToAction("Index");
        }
    }

    public class PersonIndexModel
    {
        public IEnumerable<UserModel> Users { get; set; }
        public bool AllowAdd { get; set; }
    }

}