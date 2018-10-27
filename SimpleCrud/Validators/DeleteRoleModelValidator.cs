using SimpleCrud.Models.Roles;
using SimpleCrud.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleCrud.Validators
{
    public class DeleteRoleModelValidator : IValidator<DeleteRoleModel>
    {
        private readonly  IPersonRepository _repository;

        public DeleteRoleModelValidator (IPersonRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ValidateResult> Validate(DeleteRoleModel model)
        {
            var result = new List<ValidateResult>();
           if(_repository.HasAnyUserRole(model.Id))
            {
                result.Add(new ValidateResult("", "Rola nie może zostać usunięta, gdyż jest używana"));
            }
            return result;
        }
    }
}