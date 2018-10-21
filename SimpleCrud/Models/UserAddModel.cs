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
        
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}