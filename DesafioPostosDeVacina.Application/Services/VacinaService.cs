using AutoMapper;
using DesafioPostosDeVacina.Application.DTOs;
using DesafioPostosDeVacina.Application.Interfaces;
using DesafioPostosDeVacina.Domain.Entities;
using DesafioPostosDeVacina.Domain.Interfaces;

namespace DesafioPostosDeVacina.Application.Services
{
    public class VacinaService : IService<VacinaDTO>
    {
        private IRepository<Vacina> _repository;
        private readonly IMapper _mapper;

        public VacinaService(IRepository<Vacina> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VacinaDTO>> GetAll()
        {
            return _mapper.Map<List<VacinaDTO>>(await _repository.GetAllAsync());
        }

        public async Task<VacinaDTO> GetById(int? id)
        {
            return _mapper.Map<VacinaDTO>(await _repository.GetByIdAsync(id));
        }

        public async Task Add(VacinaDTO dto)
        {
            if(dto.DataValidade <= DateTime.Today)
        {
                throw new Exception("A data de validade deve ser uma data futura.");
            }

            var lotesExistentes = await _repository.GetAllAsync();
            if (lotesExistentes.Any(v => v.Lote == dto.Lote))
            {
                throw new Exception("Já existe uma vacina com este lote.");
            }

            await _repository.CreateAsync(_mapper.Map<Vacina>(dto));
        }

        public async Task Update(VacinaDTO dto)
        {
            await _repository.UpdateAsync(_mapper.Map<Vacina>(dto));
        }

        public async Task Remove(int? id)
        {
            var vacina = await _repository.GetByIdAsync(id);
            if (vacina == null)
            {
                throw new Exception("Vacina não encontrada.");
            }
            await _repository.RemoveAsync(vacina);
        }
    }
}
