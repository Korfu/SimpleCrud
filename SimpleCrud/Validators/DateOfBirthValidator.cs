using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleCrud.Validators
{
    public class DateOfBirthValidator : IValidator
    {
        public ValidateResult Validate<DateTime>(string key, DateTime param)
        {
            throw new NotImplementedException();
        }
    }
}