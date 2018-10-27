using System.Collections.Generic;
using System.Linq;
using SimpleCrud.Entities;
using SimpleCrud.Models.Roles;

namespace SimpleCrud.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private static readonly IList<Role> _roles = new List<Role>()
        {
            new Role {Id =0, Name="Admin" },
            new Role {Id = 1, Name="User"},
            new Role {Id = 2, Name="Guest"},
            new Role {Id = 3, Name="Noob"}
        };

        private long GenerateKey()
        {
            return _roles.Max(u => u.Id) + 1;
        }

        public EditRoleModel GetRole(long id)
        {
            return _roles.Select(u => new EditRoleModel
            {
                Id = u.Id,
                Name = u.Name
            }).SingleOrDefault();

        }

        public IEnumerable<RoleViewModel> GetAll()
        {
            return _roles.Select(u => new RoleViewModel
            {
                Id = u.Id,
                Name = u.Name
            });
        }

        public void Add(AddRoleModel roleModel)
        {
            var role = new Role
            {
                Id = GenerateKey(),
                Name = roleModel.Name
            };
            _roles.Add(role);
        }

        public void Delete(long id)
        {
            var roleToDelete = _roles.Single(u => u.Id == id);
            _roles.Remove(roleToDelete);
        }

        public void Update(EditRoleModel model)
        {
            var roleToUpdate = _roles.SingleOrDefault(r => r.Id == model.Id);
            roleToUpdate.Name = model.Name;
        }
    }
}