using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleCrud.Models.Users
{
    public abstract class UserBaseModel
    {
        [Required]
        [MinLength(3, ErrorMessage = "za krótkie Imię!")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "za krótkie Nazwisko!")]
        public string LastName { get; set; }

        

        public IEnumerable<SelectListItem> RoleModelList { get; set; }
        public long RoleId { get; set; }
    }
}