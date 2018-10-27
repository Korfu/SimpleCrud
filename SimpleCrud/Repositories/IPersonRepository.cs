using SimpleCrud.Entities;
using SimpleCrud.Models;
using System.Collections.Generic;

namespace SimpleCrud.Repositories
{
    public interface IPersonRepository
    {
        IList<UserModel> GetAllUsers();
        EditUserModel GetUser(long id);

        long Add(AddUserModel userModel);
        void Update(EditUserModel userModel);
        void Delete(long id);
    }
}
