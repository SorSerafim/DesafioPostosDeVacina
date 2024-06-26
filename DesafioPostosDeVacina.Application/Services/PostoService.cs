﻿using AutoMapper;
using DesafioPostosDeVacina.Application.DTOs;
using DesafioPostosDeVacina.Application.Interfaces;
using DesafioPostosDeVacina.Domain.Entities;
using DesafioPostosDeVacina.Domain.Interfaces;

namespace DesafioPostosDeVacina.Application.Services
{
    public class PostoService : IService<PostoDTO>
    {
        private IRepository<Posto> _repository;
        private readonly IMapper _mapper;

        public PostoService(IRepository<Posto> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Add(PostoDTO dto)
        {
            var postosExistentes = await _repository.GetAllAsync();
            if (postosExistentes.Any(p => p.Nome == dto.Nome))
            {
                throw new Exception("Já existe um posto com este nome.");
            }
            await _repository.CreateAsync(_mapper.Map<Posto>(dto));
        }

        public async Task<PostoDTO> GetById(int? id)
        {
            return _mapper.Map<PostoDTO>(await _repository.GetByIdAsync(id));
        }

        public async Task<IEnumerable<PostoDTO>> GetAll()
        {
            return _mapper.Map<List<PostoDTO>>(await _repository.GetAllAsync());
        }

        public async Task Remove(int? id)
        {
            var posto = await _repository.GetByIdAsync(id);
            if (posto == null)
            {
                throw new Exception("Posto não encontrado.");
            }
            _repository.RemoveAsync(posto);
        }

        public async Task Update(PostoDTO dto)
        {
            await _repository.UpdateAsync(_mapper.Map<Posto>(dto));
        }
    }
}
