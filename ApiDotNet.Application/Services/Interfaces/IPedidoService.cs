using ApiDotNet.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDotNet.Application.Services.Interfaces
{
    public interface IPedidoService
    {
        Task<ResultService<PedidoDTO>> CreateAsync(PedidoDTO pedidoDTO);
        Task<ResultService<PedidoDetailDTO>> GetByIdAsync(int id);
        Task<ResultService<ICollection<PedidoDetailDTO>>> GetAsync();
        Task<ResultService> DeleteAsync(int id);
        Task<ResultService<PedidoDTO>> UpdateAsync(PedidoDTO pedidoDTO);
    }
}
