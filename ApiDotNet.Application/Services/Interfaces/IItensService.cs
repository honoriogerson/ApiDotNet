using ApiDotNet.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDotNet.Application.Services.Interfaces
{
    public interface IItensService
    {
        Task<ResultService<ItensDTO>> CreateAsync(ItensDTO itensDTO);
        Task<ResultService<ItensDTO>> GetByIdAscync(int id);
        Task<ResultService<ICollection<ItensDTO>>> GetAscync();
        Task<ResultService> UpdateAsync(ItensDTO itensDTO);
        Task<ResultService> DeleteAsync(int id);
    }
}
