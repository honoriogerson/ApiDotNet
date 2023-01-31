using ApiDotNet.Application.DTO;
using ApiDotNet.Application.Services;
using ApiDotNet.Application.Services.Interfaces;
using ApiDotNet.Domain.Validations;
using Microsoft.AspNetCore.Mvc;

namespace ApiDotNet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] PedidoDTO pedidoDTO)
        {
            try
            {
                var result = await _pedidoService.CreateAsync(pedidoDTO);
                if (result.isSuccess)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (DomainValidationException ex)
            {
                var result = ResultService.Fail(ex.Message);
                return BadRequest(result);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var result = await _pedidoService.GetAsync();
            if (result.isSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var result = await _pedidoService.GetByIdAsync(id);
            if (result.isSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<ActionResult> EditAsync([FromBody] PedidoDTO pedidoDTO)
        {
            try
            {
                var result = await _pedidoService.UpdateAsync(pedidoDTO);
                if (result.isSuccess)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (DomainValidationException ex)
            {
                var result = ResultService.Fail(ex.Message);
                return BadRequest(result);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _pedidoService.DeleteAsync(id);
            if (result.isSuccess)
                return Ok(result);

            return BadRequest(result);
        }

    }
}
