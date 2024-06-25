using DesafioPostosDeVacina.Application.DTOs;
using DesafioPostosDeVacina.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPostosDeVacina.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacinasController : ControllerBase
    {
        private readonly IService<VacinaDTO> _service;
        public VacinasController(IService<VacinaDTO> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VacinaDTO>>> GetAll()
        {
            var dto = await _service.GetAll();
            if (dto == null)
                return NotFound("Nenhuma vacina foi encontrada!");

            return Ok(dto);
        }

        [HttpGet("{id:int}", Name = "GetVacina")]
        public async Task<ActionResult<VacinaDTO>> Get(int id)
        {
            var dto = await _service.GetById(id);
            if (dto == null)
                return NotFound("Nenhuma vacina foi encontrada!");

            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] VacinaDTO dto)
        {
            if (dto == null)
                return BadRequest();

            await _service.Add(dto);

            return new CreatedAtRouteResult("GetVacina", new { id = dto.Id }, dto);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] VacinaDTO dto)
        {
            if (id != dto.Id)
                return BadRequest();

            if (dto == null)
                return BadRequest();

            await _service.Update(dto);

            return Ok(dto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<VacinaDTO>> Delete(int id)
        {
            var dto = await _service.GetById(id);
            if (dto == null)
                return NotFound("Nenhuma vacina foi encontrada!");

            await _service.Remove(id);

            return Ok(dto);
        }
    }
}
