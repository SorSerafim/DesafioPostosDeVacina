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
            return Ok(await _service.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostoDTO>> GetById(int id)
        {
            var posto = await _service.GetById(id);
            if (posto == null)
            {
                return NotFound();
            }
            return Ok(posto);
        }

        [HttpPost]
        public async Task<ActionResult> Add(PostoDTO createPostoDto)
        {
            await _service.Add(createPostoDto);
            return CreatedAtAction(nameof(GetById), new { id = createPostoDto.Nome }, createPostoDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, PostoDTO postoDto)
        {
            if (id != postoDto.Id)
            {
                return BadRequest();
            }

            await _service.Update(postoDto);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<PostoDTO>> Remove(int id)
        {
            var dto = await _service.GetById(id);
            if (dto == null)
                return NotFound("Posto não encontrado!");

            await _service.Remove(id);

            return Ok(dto);
        }
    }
}
