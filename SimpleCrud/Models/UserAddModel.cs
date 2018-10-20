using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleCrud.Models
{
    public class UserAddModel
    {
        public UserAddModel()
        {
            DateOfBirth = DateTime.Now;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}