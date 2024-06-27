using DesafioPostosDeVacina.Application.DTOs;
using DesafioPostosDeVacina.Application.Interfaces;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPostosDeVacina.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostosController : ControllerBase
    {
        private IPostoService _service;

        public PostosController(IPostoService service)
        {
            _service = service;
        }

        [HttpPost("Cria um posto")]
        public IActionResult Create(CreatePostoDTO createDto)
        {
            _service.CreatePosto(createDto);
            return Ok();
        }

        [HttpGet("Lista de postos")]
        public IActionResult GetAll()
        {
            List<ReadPostoDTO> listDto = _service.GetAllPostos();
            if (listDto != null) return Ok(listDto);
            return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetPostoById(int id)
        {
            ReadPostoDTO readDto = _service.GetPosto(id);
            if (readDto != null) return Ok(readDto);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePostoById(int id, CreatePostoDTO updateDto)
        {
            Result result = _service.UpdatePosto(id, updateDto);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePostoById(int id)
        {
            Result result = _service.DeletePosto(id);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
