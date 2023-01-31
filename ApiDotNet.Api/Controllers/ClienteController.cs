using ApiDotNet.Application.DTO;
using ApiDotNet.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiDotNet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;

        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClienteDTO clienteDTO)
        {
            var result = await _clienteService.CreateAsync(clienteDTO);
            if (result.isSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var result = await _clienteService.GetAsync();
            if (result.isSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var result = await _clienteService.GetByIdAsync(id);
            if (result.isSuccess)
                return Ok(result);

            return BadRequest(result); 
        }


        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] ClienteDTO clienteDTO)
        {
            var result = await _clienteService.UpdateAsync(clienteDTO);
            if (result.isSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _clienteService.DeleteAsync(id);
            if (result.isSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
