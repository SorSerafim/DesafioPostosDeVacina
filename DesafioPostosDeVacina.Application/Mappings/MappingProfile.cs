using AutoMapper;
using DesafioPostosDeVacina.Application.DTOs;
using DesafioPostosDeVacina.Domain.Entities;

namespace DesafioPostosDeVacina.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Posto, PostoDTO>().ReverseMap();
            CreateMap<Vacina, VacinaDTO>().ReverseMap();
        }
    }
}
