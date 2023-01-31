using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDotNet.Application.DTO.Validations
{
    public class ItensDTOValidation : AbstractValidator<ItensDTO>
    {
        public ItensDTOValidation() 
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotEmpty()
                .WithMessage("O nome do item deve ser informado");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("O preço deve ser informado");
        }
    }
}
