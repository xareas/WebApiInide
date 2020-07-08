using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations;

namespace Inide.WebServices.Application.RequestModels
{
  
    public class CreateEventoRequest
    {
        [Required]
        public string Nombre { get; set; }
      
    }

    public class CreateEventoRequestValidator : AbstractValidator<CreateEventoRequest>
    {
        public CreateEventoRequestValidator()
        {
            RuleFor(o => o.Nombre).NotEmpty();
        }
    }
}
