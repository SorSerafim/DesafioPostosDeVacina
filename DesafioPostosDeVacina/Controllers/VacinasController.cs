using DesafioPostosDeVacina.Application.DTOs;
using DesafioPostosDeVacina.Application.Interfaces;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPostosDeVacina.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacinasController : ControllerBase
    {
        private IVacinaService _service;

        public VacinasController(IVacinaService service)
        {
            _service = service;
        }

        [HttpPost("Cria uma vacina")]
        public IActionResult CreateVacina(CreateVacinaDTO createDto)
        {
            _service.CreateVacina(createDto);
            return Ok();
        }

        [HttpGet("Lista de Vacinas")]
        public IActionResult GetAllVacinas()
        {
            List<ReadVacinaDTO> listDto = _service.GetAllVacinas();
            if (listDto != null) return Ok(listDto);
            return NoContent();
        }

        /*
        [HttpGet("nome/{nome}")]
        public IActionResult GetAllVacinasWithPostoName(string nome)
        {
            List<ReadVacinaDTO> listDto = _service.GetAllVacinasOfOnePosto(nome);
            if (listDto != null) return Ok(listDto);
            return NoContent();
        }
        */

        [HttpGet("{id}")]
        public IActionResult GetVacinaById(int id)
        {
            ReadVacinaDTO readDto = _service.GetVacina(id);
            if (readDto != null) return Ok(readDto);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVacinaById(int id, CreateVacinaDTO updateDto)
        {
            Result result = _service.UpdateVacina(id, updateDto);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletevacinaById(int id)
        {
            Result result = _service.DeleteVacina(id);
            if (result.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
