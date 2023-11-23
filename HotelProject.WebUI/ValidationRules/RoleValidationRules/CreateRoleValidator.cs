using FluentValidation;
using HotelProject.WebUI.Models.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebUI.ValidationRules.RoleValidationRules
{
    public class CreateRoleValidator : AbstractValidator<AddRoleViewModel>
    {
        public CreateRoleValidator()
        {
            RuleFor(x => x.RoleName).NotEmpty().WithMessage("Rol adı boş olamaz.");
            RuleFor(x => x.RoleName).MinimumLength(3).WithMessage("En az 3 karakter giriniz.");
        }
    }
}
