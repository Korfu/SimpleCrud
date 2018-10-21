using SimpleCrud.Entities;
using SimpleCrud.Models;
using SimpleCrud.Repositories;
using System.Web.Mvc;

namespace SimpleCrud.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonRepository _personRepository = new PersonRepository();

        //public PersonController(IPersonRepository personRepository)
        //{
        //    _personRepository = personRepository;
        //}


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
            var model = new UserAddModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(UserAddModel model)
        {
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