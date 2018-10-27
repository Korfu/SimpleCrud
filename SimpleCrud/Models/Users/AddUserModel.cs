using SimpleCrud.Models.Roles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SimpleCrud.Models
{
    public class AddUserModel
    {
        public AddUserModel()
        {
            DateOfBirth = DateTime.Now;            
        }
        [Required]
        [MinLength(3, ErrorMessage = "za krótkie Imię!")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(3,ErrorMessage ="za krótkie Nazwisko!")]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public IEnumerable<SelectListItem> RoleModelList { get; set; }
        public long RoleId { get; set; }
    }
}