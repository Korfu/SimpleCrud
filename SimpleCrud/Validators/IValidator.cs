﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCrud.Validators
{
    public interface IValidator<TModel>
    {
        IEnumerable<ValidateResult> Validate(TModel model);
    }

    public class ValidateResult
    {
        public string Key { get; set; }
        public string Message { get; set; }
    }
}


// Ponizsze zapisy sa rownoznaczne
//public interface IValidator
//{
//    (string key, string message) Validate();
//}

//public class ValidateResult
//{
//    public string Key { get; set; }
//    public string Message { get; set; }
//}


