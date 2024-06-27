using AutoMapper;
using DesafioPostosDeVacina.Application.DTOs;
using DesafioPostosDeVacina.Application.Interfaces;
using DesafioPostosDeVacina.Domain.Entities;
using DesafioPostosDeVacina.Domain.Interfaces;
using FluentResults;

namespace DesafioPostosDeVacina.Application.Services
{
    public class VacinaService : IVacinaService
    {
        private IVacinaRepository _repository;
        private readonly IMapper _mapper;

        public VacinaService(IVacinaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void CreateVacina(CreateVacinaDTO createDto)
        {
            _repository.Create(_mapper.Map<Vacina>(createDto));
        }

        public Result UpdateVacina(int id, CreateVacinaDTO updateDto)
        {
            
            if(updateDto.DataValidade <= DateTime.Today)
            {
                return Result.Fail("A data de validade tem que ser uma data futura!");
            }

            Vacina vacina = _repository.GetById(id);
            if (vacina != null)
            {
                vacina.Id = id;
                vacina.Nome = updateDto.Nome;
                vacina.Lote = updateDto.Lote;
                vacina.Fabricante = updateDto.Fabricante;
                vacina.Quantidade = updateDto.Quantidade;
                vacina.DataValidade = updateDto.DataValidade;
                vacina.PostoId = updateDto.PostoId;
                _repository.Update(vacina);
                return Result.Ok();
            }
            return Result.Fail("Vacina não encontrada");
        }

        public Result DeleteVacina(int id)
        {
            Vacina vacina = _repository.GetById(id);
            if (vacina != null) 
            {
                _repository.Remove(vacina);
                return Result.Ok();
            }
            return Result.Fail("Vacina não encontrada");
        }

        public ReadVacinaDTO GetVacina(int id)
        {
            Vacina vacina = _repository.GetById(id);
            if (vacina != null) return _mapper.Map<ReadVacinaDTO>(vacina);
            return null;
        }

        public List<ReadVacinaDTO> GetAllVacinas()
        {
            return _mapper.Map<List<ReadVacinaDTO>>(_repository.GetAll());
        }

        /*
        public List<ReadVacinaDTO> GetAllVacinasOfOnePosto(string nome)
        {
            return _mapper.Map<List<ReadVacinaDTO>>(_repository.GetAllWithNameOfPosto(nome));
        }
        */
    }
}
