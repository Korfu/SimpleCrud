using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleCrud.Entities;

namespace SimpleCrud.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly static IList<User> _users = new List<User>() {
        new User {Id=1, FirstName="Agnieszka", LastName = "Malczewska", DateOfBirth = new DateTime(1987,11,11)},
        new User {Id=2, FirstName="Ania", LastName = "Piwońska", DateOfBirth = new DateTime(1989,11,11)},
        new User {Id=3, FirstName="Monika", LastName = "Alońska", DateOfBirth = new DateTime(1986,11,11)}
        };
        
        public void Add(User user)
        {
           _users.Add(user);
        }

        public IList<User> GetAllUsers()
        {
            return _users;
        }

        public User GetUser(long id)
        {
            return _users.SingleOrDefault(u => u.Id == id);
        }

        public void Update(User user)
        {
            var userToUpdate = _users.Single(u => u.Id == user.Id);

            userToUpdate.DateOfBirth = user.DateOfBirth;
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.IsActive = user.IsActive;
            userToUpdate.Id = user.Id;
        }
    }
}