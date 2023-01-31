using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDotNet.Application.DTO.Validations
{
    public class PedidoDTOValidation : AbstractValidator<PedidoDTO>
    {
        public PedidoDTOValidation() {
            RuleFor(x => x.NumeroPedido)
                .NotEmpty()
                .NotEmpty()
                .WithMessage("Numero do pedido deve ser informado");

        }
        
    }
}
