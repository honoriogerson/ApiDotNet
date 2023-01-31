using ApiDotNet.Application.DTO;
using ApiDotNet.Application.DTO.Validations;
using ApiDotNet.Application.Services.Interfaces;
using ApiDotNet.Domain.Entities;
using ApiDotNet.Domain.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDotNet.Application.Services
{
    public class ItensService : IItensService
    {
        private readonly IItensRepository _itensRepository;
        private readonly IMapper _mapper;

        public ItensService(IItensRepository itensRepository, IMapper mapper)
        {
            _itensRepository = itensRepository;
            _mapper = mapper;   
        }

        public async Task<ResultService<ItensDTO>> CreateAsync(ItensDTO itensDTO)
        {
            if(itensDTO == null)
                return ResultService.Fail<ItensDTO>("Objeto precisa ser informado");

            var result = new ItensDTOValidation().Validate(itensDTO);
            if (!result.IsValid)
                return ResultService.RequestError<ItensDTO>("Problemas na validação,", result);

            var itens = _mapper.Map<Itens>(itensDTO);
            var data = await _itensRepository.CreateAsync(itens);
            return ResultService.Ok<ItensDTO>(_mapper.Map<ItensDTO>(data));
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var itens = await _itensRepository.GetByIdAsync(id);
            if (itens == null)
                return ResultService.Fail("Item não encontrado");

            await _itensRepository.DeleteAsync(itens);
            return ResultService.Ok($"Item: {id} foi deletado com sucesso");
        }

        public async Task<ResultService<ICollection<ItensDTO>>> GetAscync()
        {
            var itens = await _itensRepository.GetItensAsync();
            return ResultService.Ok<ICollection<ItensDTO>>(_mapper.Map<ICollection<ItensDTO>>(itens));
        }

        public async Task<ResultService<ItensDTO>> GetByIdAscync(int id)
        {
            var itens = await _itensRepository.GetByIdAsync(id);
            if (itens == null)
                return ResultService.Fail<ItensDTO>("Item não encontrado");

            return ResultService.Ok<ItensDTO>(_mapper.Map<ItensDTO>(itens));
        }

        public async Task<ResultService> UpdateAsync(ItensDTO itensDTO)
        {

            if (itensDTO == null)
                return ResultService.Fail("Objeto precisa ser informado");

            var validation = new ItensDTOValidation().Validate(itensDTO);
            if (!validation.IsValid)
                return ResultService.RequestError("Problemas de validação", validation);

            var itens = await _itensRepository.GetByIdAsync(itensDTO.Id);
            if (itens == null)
                return ResultService.Fail("Item não encontrado");

            itens = _mapper.Map<ItensDTO, Itens>(itensDTO, itens);
            await _itensRepository.EditAsync(itens);
            return ResultService.Ok("Item editado com sucesso");

        }
    }
}
