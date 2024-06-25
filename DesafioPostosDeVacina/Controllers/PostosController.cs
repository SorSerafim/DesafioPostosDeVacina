using DesafioPostosDeVacina.Application.DTOs;
using DesafioPostosDeVacina.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPostosDeVacina.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostosController : ControllerBase
    {
        private readonly IService<PostoDTO> _service;
        public PostosController(IService<PostoDTO> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostoDTO>>> GetAll()
        {
            var dto = await _service.GetAll();
            if (dto == null)
                return NotFound("Nenhum posto foi encontrado!");

            return Ok(dto);
        }

        [HttpGet("{id:int}", Name = "GetPosto")]
        public async Task<ActionResult<PostoDTO>> Get(int id)
        {
            var dto = await _service.GetById(id);
            if (dto == null)
                return NotFound("Nenhum posto foi encontrado!");

            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PostoDTO dto)
        {
            if (dto == null)
                return BadRequest();

            await _service.Add(dto);

            return new CreatedAtRouteResult("GetPosto", new { id = dto.Id }, dto);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] PostoDTO dto)
        {
            if (id != dto.Id)
                return BadRequest();

            if (dto == null)
                return BadRequest();

            await _service.Update(dto);

            return Ok(dto);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<PostoDTO>> Delete(int id)
        {
            var dto = await _service.GetById(id);
            if (dto == null)
                return NotFound("Nenhum posto foi encontrado!");

            await _service.Remove(id);

            return Ok(dto);
        }
    }
}
