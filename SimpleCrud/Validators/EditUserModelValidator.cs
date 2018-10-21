using SimpleCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SimpleCrud.Validators
{
    public class EditUserModelValidator : IValidator<EditUserModel>
    {
        public IEnumerable<ValidateResult> Validate(EditUserModel model)
        {
            var result = new List<ValidateResult>();

            if (model.FirstName?.Any(char.IsDigit) ?? false)
            {
                result.Add(new ValidateResult { Key = nameof(model.FirstName), Message = "Wrong first name!" });
            };
            if (model.LastName?.Any(char.IsDigit) ?? false)
            {
                result.Add(new ValidateResult { Key = nameof(model.LastName), Message = "Wrong last name!" });
            };

            return result;
        }
    }
}