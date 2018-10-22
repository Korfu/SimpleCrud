using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleCrud.Entities;
using SimpleCrud.Models;
using SimpleCrud.Models.Role;

namespace SimpleCrud.Repositories
{
    public class RolesRepository : IRolesRepository
    {
        private static readonly IList<Role> _roles = new List<Role>()
        {
            new Role {Id =0, Name="Admin" },
            new Role {Id = 1, Name="User"},
            new Role {Id = 2, Name="Guest"}
        };

        private long GenerateKey()
        {
            return _roles.Max(u => u.Id) + 1;
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

        public IList<RoleModel> GetAll()
        {
            return _roles.Select(u => new RoleModel
            {
                Id = u.Id,
                Name = u.Name
            }).ToList();
        }

        public void Delete(long id)
        {
            var roleToDelete = _roles.Single(u => u.Id == id);
            _roles.Remove(roleToDelete);
        }
    }
}