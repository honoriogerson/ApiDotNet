using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDotNet.Application.DTO.Validations
{
    public class ClienteDTOValidation : AbstractValidator<ClienteDTO>
    {
        public ClienteDTOValidation() 
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotEmpty()
                .WithMessage("Nome deve ser informado");

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotEmpty()
                .WithMessage("email deve ser informado");
        }

    }
}
