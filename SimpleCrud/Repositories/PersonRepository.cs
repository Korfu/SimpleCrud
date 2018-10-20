using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleCrud.Entities;
using SimpleCrud.Models;

namespace SimpleCrud.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly static IList<User> _users = new List<User>() {
        new User {Id=1, FirstName="Agnieszka", LastName = "Malczewska", DateOfBirth = new DateTime(1987,11,11)},
        new User {Id=2, FirstName="Ania", LastName = "Piwońska", DateOfBirth = new DateTime(1989,11,11)},
        new User {Id=3, FirstName="Monika", LastName = "Alońska", DateOfBirth = new DateTime(1986,11,11)}
        };

        private long GenerateKey()
        {
            return _users.Max(u => u.Id) + 1;
        }

        public void Add(UserAddModel userModel)
        {
            var user = new User
            {
                Id = GenerateKey(),
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                DateOfBirth = userModel.DateOfBirth,
                IsActive = true
            };
            _users.Add(user);
        }

        public IList<UserModel> GetAllUsers()
        {
            return _users.Select(u => new UserModel
            {
                Id = u.Id,
                FullName = string.Format($"{u.FirstName} {u.LastName}"),
                Age = DateTime.Now.Year - u.DateOfBirth.Year,
                IsActiveAsString = u.IsActive ? "Tak" : "Nie"
            }).ToList();
        }

        public EditUserModel GetUser(long id)
        {

            return _users.Select(u => new EditUserModel
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                IsActive=u.IsActive})
            .SingleOrDefault(u => u.Id == id);
        }

        public void Update(EditUserModel model)
        {
            var userToUpdate = _users.Single(u => u.Id == model.Id);
            userToUpdate.FirstName = model.FirstName;
            userToUpdate.LastName = model.LastName;
            userToUpdate.IsActive = model.IsActive;
        }

        public void Delete(long id)
        {
            var userToDelete = _users.Single(u => u.Id == id);
            _users.Remove(userToDelete);
        }
    }
}