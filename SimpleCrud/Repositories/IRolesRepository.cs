using SimpleCrud.Entities;
using SimpleCrud.Models;
using SimpleCrud.Models.Role;
using System.Collections.Generic;

namespace SimpleCrud.Repositories
{
    public interface IRolesRepository
    {
        void Add(AddRoleModel roleModel);
        void Delete(long id);
        IList<RoleModel> GetAll();
    }
}