using SimpleCrud.Models.Roles;
using SimpleCrud.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SimpleCrud.Models
{
    public class AddUserModel : UserBaseModel
    {
        public AddUserModel()
        {
            DateOfBirth = DateTime.Now;            
        }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}