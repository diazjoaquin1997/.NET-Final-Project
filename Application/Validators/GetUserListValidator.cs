using Application.Contracts;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class GetUserListValidator : AbstractValidator<GetUserListRequest>
    {
        public GetUserListValidator() {
            RuleFor(r => r.RolId)
                .NotEqual(0)
                .WithMessage("El rol no puede ser cero.");
        }
    }
}
