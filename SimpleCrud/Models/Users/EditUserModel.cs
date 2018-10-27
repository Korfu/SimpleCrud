using System;
using SimpleCrud.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Collections.Generic;
using SimpleCrud.Models.Users;

namespace SimpleCrud.Models
{
    public class EditUserModel : UserBaseModel
    {
        public long Id { get; set; }
        public bool IsActive { get; set; }
    }
}