using SimpleCrud.Models;
using SimpleCrud.Models.Role;
using SimpleCrud.Repositories;
using System.Linq;
using System.Web.Mvc;

namespace SimpleCrud.Controllers
{
    public class PersonController : BaseController
    {
        private readonly IRolesRepository _rolesRepository;
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository,
                                IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
            _personRepository = personRepository;
        }

        public ActionResult Index()
        {
            var userList = _personRepository.GetAllUsers();
            foreach (var user in userList)
            {
                user.Role = _rolesRepository.GetAll().Single(x => x.Id == user.RoleId);
            }

            return View(userList);
        }

        public ActionResult Edit(long id)
        {
            var model = _personRepository.GetUser(id);
            var rolesList = GetRoles();
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
            else
            {
                var rolesList = GetRoles();
                return View(model);
            }
            
        }

        [HttpGet]
        public ActionResult Add()
        {
            var model = new AddUserModel();
            var rolesList = _rolesRepository.GetAll();
            model.RoleModelList = new SelectList(rolesList,"Id","Name");
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
            var rolesList = _rolesRepository.GetAll();
            model.RoleModelList = new SelectList(rolesList, "Id", "Name");
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

        private dynamic GetRoles()
        {
            return _rolesRepository.GetAll().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
        }
    }
}