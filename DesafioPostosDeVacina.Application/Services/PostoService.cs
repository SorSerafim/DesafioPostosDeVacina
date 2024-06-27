using AutoMapper;
using DesafioPostosDeVacina.Application.DTOs;
using DesafioPostosDeVacina.Application.Interfaces;
using DesafioPostosDeVacina.Domain.Entities;
using DesafioPostosDeVacina.Domain.Interfaces;
using FluentResults;
using System.IO;

namespace DesafioPostosDeVacina.Application.Services
{
    public class PostoService : IPostoService
    {
        private IPostoRepository _repository;
        private IMapper _mapper;

        public PostoService(IPostoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void CreatePosto(CreatePostoDTO createDto)
        {
            var postosExistentes = _repository.GetAll();
            if(postosExistentes.Any(p => p.Nome == createDto.Nome))
            {
                throw new Exception("Já exite um posto com esse nome!");
            }
            _repository.Create(_mapper.Map<Posto>(createDto));
        }

        public Result UpdatePosto(int id, CreatePostoDTO updateDto)
        {
            Posto posto = _repository.GetById(id);
            if (posto != null)
            {
                var postosExistentes = _repository.GetAll();
                if (postosExistentes.Any(p => p.Nome == updateDto.Nome))
                {
                    throw new Exception("Já exite um posto com esse nome!");
                }

                posto.Nome = updateDto.Nome;
                _repository.Update(posto);
                return Result.Ok();
            }
            return Result.Fail("Posto não encontrado.");
        }

        public Result DeletePosto(int id)
        {
            Posto posto = _repository.GetById(id);
            if (posto == null)
            {
                return Result.Fail("Posto não encontrado.");
            }
            if(posto.Vacinas != null)
            {
                return Result.Fail("Não é possível deletar um posto com vacinas cadastradas.");
            }
            _repository.Remove(posto);
            return Result.Ok();
        }

        public ReadPostoDTO GetPosto(int id)
        {
            Posto posto = _repository.GetById(id);
            if(posto != null) return _mapper.Map<ReadPostoDTO>(posto);
            return null;
        }

        public List<ReadPostoDTO> GetAllPostos()
        {
            return _mapper.Map<List<ReadPostoDTO>>(_repository.GetAll());
        }
    }
}
