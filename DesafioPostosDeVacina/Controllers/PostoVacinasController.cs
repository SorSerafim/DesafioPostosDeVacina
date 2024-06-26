using DesafioPostosDeVacina.Application.DTOs;
using DesafioPostosDeVacina.Application.Interfaces;
using DesafioPostosDeVacina.Domain.Entities;
using DesafioPostosDeVacina.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPostosDeVacina.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostoVacinasController : ControllerBase
    {
        private readonly IRepository<Posto> _postoRepository;
        private readonly IRepository<Vacina> _vacinaRepository;

        public PostoVacinasController(IRepository<Posto> postorepository, IRepository<Vacina> vacinarepository)
        {
            _postoRepository = postorepository;
            _vacinaRepository = vacinarepository;
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            return Ok(_postoRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var posto = _postoRepository.GetById(id);
            if (posto == null)
            {
                return NotFound();
            }
            return Ok(posto);
        }

        [HttpPost]
        public IActionResult Create([FromBody]Posto posto) 
        {
            _postoRepository.Create(posto);
            return Ok(posto);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Posto postoAtualizado)
        {
            _postoRepository.Update(postoAtualizado);
            return Ok(postoAtualizado);
        }

        [HttpDelete]
        public IActionResult DeleteById(int id) 
        { 
            var posto = _postoRepository.GetById(id);
            _postoRepository.Remove(posto);
            return Ok();
        }
    }
}
