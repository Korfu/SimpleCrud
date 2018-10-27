using System;
using SimpleCrud.Models;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SimpleCrud.Validators
{
    public class AddUSerModelValidator : IValidator<AddUserModel>
    {
        public IEnumerable<ValidateResult> Validate(AddUserModel model)
        {
            var result = new List<ValidateResult>();
            var dateOfBirth = model.DateOfBirth;
            var now = DateTime.UtcNow;

            var yearsDifference = now.Year - dateOfBirth.Year;

            if (yearsDifference <= 10)
            {
                result.Add(new ValidateResult("","Too YOUNG!"));
            }

            return result;
            
        }


    }
}