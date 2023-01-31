using ApiDotNet.Application.DTO;
using ApiDotNet.Application.DTO.Validations;
using ApiDotNet.Application.Services.Interfaces;
using ApiDotNet.Domain.Entities;
using ApiDotNet.Domain.Repositories;
using AutoMapper;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDotNet.Application.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IItensRepository _itensRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;
       
        public PedidoService(IItensRepository itensRepository, IClienteRepository clienteRepository, IPedidoRepository pedidoRepository, IMapper mapper)
        {
            _clienteRepository= clienteRepository;
            _itensRepository= itensRepository;      
            _pedidoRepository= pedidoRepository;
            _mapper = mapper;
        }
        public async Task<ResultService<PedidoDTO>> CreateAsync(PedidoDTO pedidoDTO)
        {
            if (pedidoDTO == null)
                return ResultService.Fail<PedidoDTO>("Objeto de ser informado");

            var validate = new PedidoDTOValidation().Validate(pedidoDTO);
            if (validate.IsValid)
            return ResultService.RequestError<PedidoDTO>("Problemas de validação", validate);

            var itemId = await _itensRepository.GetByIdAsync(pedidoDTO.Id);
            var clienteId = await _clienteRepository.GetByIdAsync(pedidoDTO.Id);
            var pedido = new Pedido(itemId, clienteId);
            var data = await _pedidoRepository.CreateAsync(pedido);
            pedidoDTO.Id = data.Id;
            return ResultService.Ok<PedidoDTO>(pedidoDTO);
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var pedido = await _pedidoRepository.GetByIdAsync(id);
            if (pedido == null)
                return ResultService.Fail("Pedido não foi encontrado");

            await _pedidoRepository.DeleteAsync(pedido);
            return ResultService.Ok($"Pedido: {id} foi deletado com sucesso");
        }

        public async Task<ResultService<ICollection<PedidoDetailDTO>>> GetAsync()
        {
           var pedidos = await _pedidoRepository.GetPedidoeAsync();
            return ResultService.Ok(_mapper.Map<ICollection<PedidoDetailDTO>>(pedidos));
        }

        public async Task<ResultService<PedidoDetailDTO>> GetByIdAsync(int id)
        {
            var pedido = await _pedidoRepository.GetByIdAsync(id);
            if (pedido == null)
                return ResultService.Fail<PedidoDetailDTO>("Compra não econtrada");

            return ResultService.Ok(_mapper.Map<PedidoDetailDTO>(pedido));
        }

        public async Task<ResultService<PedidoDTO>> UpdateAsync(PedidoDTO pedidoDTO)
        {
            if (pedidoDTO == null)
                return ResultService.Fail<PedidoDTO>("Objeto deve ser informado");

            var result = new PedidoDTOValidation().Validate(pedidoDTO);
            if (!result.IsValid)
                return ResultService.RequestError<PedidoDTO>("Problemas de validação", result);

            var pedido = await _pedidoRepository.GetByIdAsync(pedidoDTO.Id);
            if (pedido == null)
                return ResultService.Fail<PedidoDTO>("Pedido não econtrado");

            var itemId = await _itensRepository.GetByIdAsync(pedidoDTO.Id);
            var clienteId = await _clienteRepository.GetByIdAsync(pedidoDTO.Id);
            //pedido.Edit(pedido.Id, itemId, clienteId);
            await _pedidoRepository.EditAsync(pedido);
            return ResultService.Ok(pedidoDTO);

        }
    }
}
