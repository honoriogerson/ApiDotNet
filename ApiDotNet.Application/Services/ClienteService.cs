using ApiDotNet.Application.DTO;
using ApiDotNet.Application.DTO.Validations;
using ApiDotNet.Application.Services.Interfaces;
using ApiDotNet.Domain.Entities;
using ApiDotNet.Domain.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ApiDotNet.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<ClienteDTO>> CreateAsync(ClienteDTO clienteDTO)
        {
            if (clienteDTO == null)
                return ResultService.Fail<ClienteDTO>("Objeto deve ser informado");

            var result = new ClienteDTOValidation().Validate(clienteDTO);
            if (!result.IsValid)
                return ResultService.RequestError<ClienteDTO>("Problemas de validação", result);

            var cliente = _mapper.Map<Cliente>(clienteDTO);
            var data = await _clienteRepository.CreateAsync(cliente);
            return ResultService.Ok<ClienteDTO>(_mapper.Map<ClienteDTO>(data));
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null)
                return ResultService.Fail("Cliente não encontrad");

            await _clienteRepository.DeleteAsync(cliente);
            return ResultService.Ok($"Cliente numero:{id} foi deletado");
        }

        public async Task<ResultService<ICollection<ClienteDTO>>> GetAsync()
        {
            var cliente = await _clienteRepository.GetClienteAsync();
            return ResultService.Ok<ICollection<ClienteDTO>>(_mapper.Map<ICollection<ClienteDTO>>(cliente));
        }

        public async Task<ResultService<ClienteDTO>> GetByIdAsync(int id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);

            if (cliente == null)
                return ResultService.Fail<ClienteDTO>("Cliente não encontrado");

            return ResultService.Ok(_mapper.Map<ClienteDTO>(cliente));
        }

        public async Task<ResultService> UpdateAsync(ClienteDTO clienteDTO)
        {
            if (clienteDTO == null)
                return ResultService.Fail("Objeto de ser informado");

            var validation = new ClienteDTOValidation().Validate(clienteDTO);
            if (!validation.IsValid)
                return ResultService.RequestError("Prolemas com validação dos campos", validation);

            var cliente = await _clienteRepository.GetByIdAsync(clienteDTO.Id);
            if (cliente == null)
                return ResultService.Fail("Cliente não encontrado");

            cliente = _mapper.Map<ClienteDTO, Cliente>(clienteDTO, cliente);
            await _clienteRepository.EditAsync(cliente);
            return ResultService.Ok("Cliente editado com sucesso");
        }
    }
}