using System;

namespace SimpleCrud.Entities
{
    public class User
    {
        public long Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public long RoleId { get; set; }
        public bool IsActive { get; set; }
    }
}
