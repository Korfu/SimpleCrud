using System;
using SimpleCrud.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

            if(yearsDifference <= 10)
            {
                result.Add(new ValidateResult { Key = nameof(model.DateOfBirth), Message = "Too YOUNG!" });
            }

            return result;
        }
    }
}