using ApiDotNet.Application.DTO;
using ApiDotNet.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiDotNet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItensController : ControllerBase
    {
        private readonly IItensService _itensService;

        public ItensController(IItensService itensService)
        {
            _itensService = itensService;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] ItensDTO itensDTO)
        {
            var result = await _itensService.CreateAsync(itensDTO);
            if(result.isSuccess)
                return Ok(result);

            return BadRequest(result);  
            
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var result = await _itensService.GetAscync();
            if (result.isSuccess) 
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var result = await _itensService.GetByIdAscync(id);
            if(result.isSuccess)
                return Ok(result);  
            return BadRequest(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] ItensDTO itensDTO)
        {
            var result = await _itensService.UpdateAsync(itensDTO);
            if (result.isSuccess)
                return Ok(result);

            return BadRequest(result);

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var result = await _itensService.DeleteAsync(id);
            if (result.isSuccess)
                return Ok(result);

            return BadRequest(result);

        }


    }
}
