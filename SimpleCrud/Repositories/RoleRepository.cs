using System.Collections.Generic;
using System.Linq;
using SimpleCrud.Entities;
using SimpleCrud.Models.Roles;

namespace SimpleCrud.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public static readonly IList<Role> Roles = new List<Role>()
        {
            new Role {Id =0, Name="Admin" },
            new Role {Id = 1, Name="User"},
            new Role {Id = 2, Name="Guest"},
            new Role {Id = 3, Name="Noob"}
        };

        private long GenerateKey()
        {
            return Roles.Max(u => u.Id) + 1;
        }

        public EditRoleModel GetRole(long id)
        {
            return Roles.Select(u => new EditRoleModel
            {
                Id = u.Id,
                Name = u.Name
            }).SingleOrDefault(u => u.Id == id);

        }

        public IEnumerable<RoleViewModel> GetAll()
        {
            return Roles.Select(u => new RoleViewModel
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
            Roles.Add(role);
        }

        public void Delete(long id)
        {
            var roleToDelete = Roles.Single(u => u.Id == id);
            Roles.Remove(roleToDelete);
        }

        public void Update(EditRoleModel model)
        {
            var roleToUpdate = Roles.SingleOrDefault(r => r.Id == model.Id);
            roleToUpdate.Name = model.Name;
        }
    }
}