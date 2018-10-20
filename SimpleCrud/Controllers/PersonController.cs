using SimpleCrud.Entities;
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
            return View();
        }

        public ActionResult Add()
        {
            if (ModelState.IsValid)
            {
                var user = new User();
                _personRepository.Add(user);
                return View("Add");
            } else
            {
                return View("index");
            }
        }

        public ActionResult Details(long id)
        {
            var person = _personRepository.GetUser(id);
            return View(person);
        }
    }
}