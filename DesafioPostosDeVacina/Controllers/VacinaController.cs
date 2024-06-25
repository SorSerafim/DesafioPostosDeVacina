using DesafioPostosDeVacina.Application.DTOs;
using DesafioPostosDeVacina.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPostosDeVacina.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacinaController : ControllerBase
    {
        private readonly IService<VacinaDTO> _service;
        public VacinaController(IService<VacinaDTO> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VacinaDTO>>> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VacinaDTO>> GetById(int id)
        {
            var vacina = await _service.GetById(id);
            if (vacina == null)
            {
                return NotFound();
            }
            return Ok(vacina);
        }

        [HttpPost]
        public async Task<ActionResult> Add(VacinaDTO createVacinaDto)
        {
            await _service.Add(createVacinaDto);
            return CreatedAtAction(nameof(GetById), new { id = createVacinaDto.PostoId }, createVacinaDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, VacinaDTO vacinaDto)
        {
            if (id != vacinaDto.Id)
            {
                return BadRequest();
            }

            await _service.Update(vacinaDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {
            await _service.Remove(id);
            return NoContent();
        }
    }
}
