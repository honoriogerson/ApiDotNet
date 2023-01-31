using ApiDotNet.Application.DTO;
using ApiDotNet.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDotNet.Application.Mappings
{
    public class DomainToDTOMapping : Profile
    {
        public DomainToDTOMapping() 
        {
            CreateMap<Cliente, ClienteDTO>();
            CreateMap<Itens, ItensDTO>();
            CreateMap<Pedido, PedidoDetailDTO>()
                .ForMember(x => x.Cliente, opt => opt.Ignore())
                .ForMember(x => x.Itens, opt => opt.Ignore())
                .ConstructUsing((model, context) =>
                {
                    var dto = new PedidoDetailDTO
                    {
                        Itens = model.Itens.Name,
                        Id = model.Id,
                        Date = model.Date,
                        Cliente = model.Cliente.Name
                    };
                    return dto;
                });
        }
    }
}
