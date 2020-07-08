using FluentValidation;
using System;

namespace Inide.WebServices.Application.RequestModels
{
    public class UpdateEventoRequest
    {
        public string Nombre { get; set; }
     //    public DateTime DateOfBirth { get; set; }
    }

    public class UpdateEventoRequestValidator : AbstractValidator<UpdateEventoRequest>
    {
        public UpdateEventoRequestValidator()
        {
            RuleFor(o => o.Nombre).NotEmpty();
        
            //RuleFor(o => o.DateOfBirth)
             //       .NotEmpty()
            //        .Must(PropertyValidation.IsValidDateTime)
             //       .LessThan(DateTime.Today).WithMessage("No es valido una fecha de futuro.");
        }
    }
}
