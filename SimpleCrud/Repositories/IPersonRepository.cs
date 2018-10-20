using SimpleCrud.Entities;
using System.Collections.Generic;

namespace SimpleCrud.Repositories
{
    public interface IPersonRepository
    {
        IList<User> GetAllUsers();
        User GetUser(long id);

        void Add(User user);
        void Update(User user);
    }
}
