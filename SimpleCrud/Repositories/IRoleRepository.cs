using SimpleCrud.Models.Roles;
using System.Collections.Generic;

namespace SimpleCrud.Repositories
{
    public interface IRoleRepository
    {
       
        IEnumerable<RoleViewModel> GetAll();
        EditRoleModel GetRole(long id);
  
        long Add(AddRoleModel roleModel);
        void Update(EditRoleModel model);
        void Delete(long id);
    }
}