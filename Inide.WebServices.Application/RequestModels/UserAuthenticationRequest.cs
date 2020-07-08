using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using FluentValidation;
using Inide.WebServices.Application.Rules;

namespace Inide.WebServices.Application.RequestModels
{
    public class UserAuthenticationRequest
    {
        [Required(ErrorMessage = "Nombre de Usuario es requerido")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Clave del Usuario es requerido")]
        public string Password { get; set; }
    }

    public class UserAuthenticationRequestValidator : AbstractValidator<UserAuthenticationRequest>
    {
        public UserAuthenticationRequestValidator()
        {
            RuleFor(o => o.UserName)
                .NotEmpty()
                .NotNull();
            RuleFor(o => o.Password)
                .NotEmpty().WithMessage(ValidationMessages.err0003)
                .NotNull().WithMessage(ValidationMessages.err0004);
        }
    }
    
}
