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
    public class DTOToDomainMapping : Profile
    {
        public DTOToDomainMapping() 
        {
            CreateMap<ClienteDTO, Cliente>();
            CreateMap<ItensDTO, Itens>();            
            CreateMap<PedidoDTO, Pedido>();
        }
    }
}
