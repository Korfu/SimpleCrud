using SimpleCrud.Entities;
using SimpleCrud.Models;
using SimpleCrud.Repositories;
using SimpleCrud.Validators;
using System;
using System.Web.Mvc;

namespace SimpleCrud.Controllers
{
    public class PersonController : BaseController
    {
        private readonly IPersonRepository _personRepository;
        private readonly IValidator<AddUserModel> _addUserModelValidator;

        public PersonController(IPersonRepository personRepository, 
                                IValidator<AddUserModel> addUserModelValidator)
        {
            _addUserModelValidator = addUserModelValidator;
            _personRepository = personRepository;
        }


        public ActionResult Index()
        {
            var userList = _personRepository.GetAllUsers();
            return View(userList);
        }

        public ActionResult Edit(long id)
        {
            var model = _personRepository.GetUser(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditUserModel model)
        {
            _personRepository.Update(model);
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Add()
        {
            var model = new AddUserModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(AddUserModel model)
        {
            Validate(_addUserModelValidator, model);
         
            if (ModelState.IsValid)
            {
                _personRepository.Add(model);
                return RedirectToAction("Index");
            }
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
}