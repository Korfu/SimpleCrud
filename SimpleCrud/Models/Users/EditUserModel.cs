using System;
using SimpleCrud.Entities;
using System.ComponentModel.DataAnnotations;

namespace SimpleCrud.Models
{
    public class EditUserModel
    {
        public long Id { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "za krótkie Imię!")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "za krótkie Nazwisko!")]
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public Entities.Role Role { get; set; }

    }
}